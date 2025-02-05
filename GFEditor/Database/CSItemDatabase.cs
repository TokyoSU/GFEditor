namespace GFEditor.Database
{
    public class ItemDatabaseHolder
    {
        [JsonProperty]
        public List<CSItem> Items = [];
    }

    public static class CSItemDatabase
    {
        private static List<CSItem>? m_Database = [];
        private static readonly List<CSItem>? m_DatabaseServer = [];

        public static CSItem? GetItemByIndex(int index)
        {
            if (m_Database == null)
            {
                Console.WriteLine($"Failed to get item by index: {index}, database is null, was it loaded ?");
                return null;
            }
            return m_Database.Find(x => x.Index == index);
        }

        public static List<int>? GetIndexList()
        {
            if (m_Database == null)
            {
                Console.WriteLine("Failed to get item index list, database is null, was it loaded ?");
                return null;
            }
            return m_Database.Select(item => item.Index).ToList();
        }

        public static List<string>? GetUsedSoundNameList()
        {
            if (m_Database == null)
            {
                Console.WriteLine("Failed to get used sound names list, database is null, was it loaded ?");
                return null;
            }
            return m_Database.Where(item => !string.IsNullOrWhiteSpace(item.UsedSoundName)).Select(item => item.UsedSoundName).ToList();
        }

        public static int FindMissingIndex()
        {
            if (m_Database == null)
            {
                Console.WriteLine("Failed to find missing index, database is null, was it loaded ?");
                return 0;
            }

            // Check for the begin (0 -> 9000~) since it could be missing.
            for (int i = 1; i < m_Database.Count - 1; i++) // ID start at 1
            {
                var item = m_Database.FirstOrDefault();
                if (item != null && i < item.Index) // First item is probably in the 9000+ which is really big, so we can use index less than 9000!
                    return i;
            }

            // Now check for gaps between consecutive indices
            for (int i = 0; i < m_Database.Count - 1; i++)
            {
                int currentIndex = m_Database[i + 0].Index;
                int nextIndex    = m_Database[i + 1].Index;
                // If there's a gap between current and next index
                if (nextIndex > currentIndex + 1)
                    return currentIndex + 1;
            }

            return -1;
        }

        public static bool CreateNewItem()
        {
            if (m_Database == null)
            {
                Console.WriteLine("Failed to create new item, database is null, was it loaded beforehand ?");
                return false;
            }

            var item = new CSItem()
            {
                Index = 0,
                Name = "NewItem",
                IconFilename = string.Empty,
                UsedSoundName = string.Empty,
                ModelFilename = "G00005",
                ModelId = string.Empty, // Default
                RestrictEventPosition = string.Empty,
                Tip = string.Empty
            };

            int missingIndex = FindMissingIndex();
            if (missingIndex == -1)
            {
                Console.WriteLine("There is no gaps in item, adding new one.");
                item.Index = m_Database.Count;
                m_Database.Add(item);
            }
            else
            {
                item.Index = missingIndex;
                m_Database.Add(item);
            }

            m_Database.Sort();
            return true;
        }

        public static void Load()
        {
            m_Database?.Clear();
            m_DatabaseServer?.Clear();

            if (!File.Exists(Constants.AssetJItemPath))
            {
                LoadIni();
                LoadIniServer();
                CombineBoth();
            }
            else
            {
                m_Database = JsonConvert.DeserializeObject<List<CSItem>>(File.ReadAllText(Constants.AssetJItemPath, Encoding.UTF8)); // Already contains server data.
            }

            m_DatabaseServer?.Clear(); // No need for server anymore since it was combined.
        }

        public static void Save()
        {
            if (m_Database == null)
            {
                Console.WriteLine("Failed to save items database, database is null, was it loaded ?");
                return;
            }

            // Save client
            var build = new StringBuilder();
            build.AppendLine("|V.16|93|"); // TODO: Unhardcoded this, load it through the client/server ini file !
            foreach (var item in m_Database)
                build.AppendLine(item.ToString());
            File.WriteAllText(Constants.AssetCItemPath, build.ToString(), StringConverter.GetChinese());
            File.WriteAllText(Constants.AssetSItemPath, build.ToString(), StringConverter.GetChinese()); // Client and server is the same.

            SaveHelper.SaveJson(Constants.AssetJItemPath, m_Database);
        }

        private static void LoadIni()
        {
            if (m_Database == null)
            {
                Console.WriteLine("Failed to load items database, database is null, was it initialized beforehand ?");
                return;
            }

            var wholeFile = File.ReadAllText(Constants.AssetOrigCItemPath, StringConverter.GetChinese());
            var lines = wholeFile.Split('|').ToList();
            for (int index = 3; index < lines.Count - 3; index += 93)
                m_Database.Add(Read(lines, index));
            m_Database.Sort(); // Sort based on Index.
        }

        private static void LoadIniServer()
        {
            if (m_DatabaseServer == null)
            {
                Console.WriteLine("Failed to load items server database, database is null, was it initialized beforehand ?");
                return;
            }

            var wholeFile = File.ReadAllText(Constants.AssetOrigSItemPath, StringConverter.GetChinese());
            var lines = wholeFile.Split('|').ToList();
            for (int index = 3; index < lines.Count - 3; index += 93)
                m_DatabaseServer.Add(Read(lines, index));
            m_DatabaseServer.Sort(); // Sort based on Index.
        }

        private static void CombineItem(CSItem item, CSItem servItem)
        {
            var fields = typeof(CSItem).GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fields)
            {
                var clientValue = field.GetValue(item);
                var serverValue = field.GetValue(servItem);

                // Apply merging logic based on field type
                if (clientValue is int clientInt && serverValue is int serverInt)
                {
                    // If it's an integer, copy the server value only if client value is 0 (or other condition)
                    if (clientInt == 0 && serverInt != 0)
                        field.SetValue(item, serverValue);
                }
                else if (clientValue is string clientString && serverValue is string serverString)
                {
                    // If it's a string, copy the server value only if client value is empty
                    if (string.IsNullOrEmpty(clientString) && !string.IsNullOrEmpty(serverString))
                        field.SetValue(item, serverValue);
                }
            }
        }

        private static void CombineBoth()
        {
            if (m_Database == null)
            {
                Console.WriteLine("Failed to combine items database, database is null, was it initialized beforehand ?");
                return;
            }
            if (m_DatabaseServer == null)
            {
                Console.WriteLine("Failed to combine items server database, server database is null, was it initialized beforehand ?");
                return;
            }

            m_Database.ForEach(item =>
            {
                var matchingItem = m_DatabaseServer.FirstOrDefault(servItem => servItem.Index == item.Index);
                if (matchingItem != null)
                    CombineItem(item, matchingItem);
            });
        }

        private static CSItem Read(List<string> lines, int index)
        {
            return new CSItem()
            {
                Index = lines.GetInt(index + 0),
                IconFilename = lines[index + 1],
                ModelId = lines[index + 2],
                ModelFilename = lines[index + 3],
                WeaponEffectId = lines.GetInt(index + 4),
                FlyEffectId = lines.GetInt(index + 5),
                UsedEffectId = lines.GetInt(index + 6),
                UsedSoundName = lines[index + 7],
                EnchanceEffectId = lines.GetInt(index + 8),
                Name = lines[index + 9],
                ItemType = lines.GetInt(index + 10),
                EquipType = lines.GetInt(index + 11),
                OpFlags = lines.GetUInt(index + 12),
                OpFlagsPlus = lines.GetInt(index + 13),
                Target = lines.GetInt(index + 14),
                RestrictGender = lines.GetInt(index + 15),
                RestrictLevel = lines.GetInt(index + 16),
                RestrictMaxLevel = lines.GetInt(index + 17),
                RebirthCount = lines.GetInt(index + 18),
                RebirthScore = lines.GetInt(index + 19),
                RebirthMaxScore = lines.GetInt(index + 20),
                RestrictReputation = lines.GetInt(index + 21),
                RestrictReputationCount = lines.GetInt(index + 22),
                RestrictClass = lines.GetHex(index + 23),
                ItemQuality = lines.GetInt(index + 24),
                ItemGroup = lines.GetInt(index + 25),
                CastingTime = lines.GetInt(index + 26),
                CoolDownTime = lines.GetInt(index + 27),
                CoolDownGroup = lines.GetInt(index + 28),
                MaxHp = lines.GetInt(index + 29),
                MaxMp = lines.GetInt(index + 30),
                Str = lines.GetInt(index + 31),
                Vit = lines.GetInt(index + 32),
                Int = lines.GetInt(index + 33),
                Wil = lines.GetInt(index + 34),
                Agi = lines.GetInt(index + 35),
                AvgPhysicoDamage = lines.GetInt(index + 36),
                RandPhysicoDamage = lines.GetInt(index + 37),
                AttackRange = lines.GetInt(index + 38),
                AttackSpeed = lines.GetInt(index + 39),
                Attack = lines.GetInt(index + 40),
                RangeAttack = lines.GetInt(index + 41),
                PhysicoDefence = lines.GetInt(index + 42),
                MagicDamage = lines.GetInt(index + 43),
                MagicDefence = lines.GetInt(index + 44),
                HitRate = lines.GetInt(index + 45),
                DodgeRate = lines.GetInt(index + 46),
                PhysicoCriticalRate = lines.GetInt(index + 47),
                PhysicoCriticalDamage = lines.GetInt(index + 48),
                MagicCriticalRate = lines.GetInt(index + 49),
                MagicCriticalDamage = lines.GetInt(index + 50),
                PhysicalPenetration = lines.GetInt(index + 51),
                MagicalPenetration = lines.GetInt(index + 52),
                PhysicalPenetrationDefence = lines.GetInt(index + 53),
                MagicalPenetrationDefence = lines.GetInt(index + 54),
                Attribute = lines.GetInt(index + 55),
                AttributeRate = lines.GetInt(index + 56),
                AttributeDamage = lines.GetInt(index + 57),
                AttributeResist = lines.GetInt(index + 58),
                SpecialType = lines.GetInt(index + 59),
                SpecialRate = lines.GetInt(index + 60),
                SpecialDamage = lines.GetInt(index + 61),
                DropRate = lines.GetInt(index + 62),
                DropIndex = lines.GetInt(index + 63),
                TreasureBuffs01 = lines.GetInt(index + 64),
                TreasureBuffs02 = lines.GetInt(index + 65),
                TreasureBuffs03 = lines.GetInt(index + 66),
                TreasureBuffs04 = lines.GetInt(index + 67),
                EnchantEnabler = lines.GetInt(index + 68),
                EnchantIndex = lines.GetInt(index + 69),
                ExpertLevel = lines.GetInt(index + 70),
                ExpertEnchantIndex = lines.GetInt(index + 71),
                ElfSkillIndex = lines.GetInt(index + 72),
                EnchantTimeType = lines.GetInt(index + 73),
                EnchantDuration = lines.GetInt(index + 74),
                LimitType = lines.GetInt(index + 75),
                DueDateTime = lines.GetInt(index + 76),
                BackpackSize = lines.GetInt(index + 77),
                SocketMax = lines.GetInt(index + 78),
                SocketRate = lines.GetInt(index + 79),
                MaxDurability = lines.GetInt(index + 80),
                MaxStack = lines.GetInt(index + 81),
                ShopPriceType = lines.GetInt(index + 82),
                Price = lines.GetInt(index + 83),
                RestrictEventPosition = lines[index + 84], // Separate it with ';'
                MissionIndex = lines.GetInt(index + 85),
                BlockRate = lines.GetInt(index + 86),
                LogLevel = lines.GetInt(index + 87),
                AuctionType = lines.GetInt(index + 88),
                ExtraData01 = lines.GetInt(index + 89),
                ExtraData02 = lines.GetInt(index + 90),
                ExtraData03 = lines.GetInt(index + 91),
                Tip = lines[index + 92] // 93 entries.
            };
        }
    }
}
