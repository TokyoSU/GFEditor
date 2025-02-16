namespace GFEditor.Structs.Translate
{
    /// <summary>
    /// Dont change the name, it should match with the ClassType enum !
    /// Else GetValuesByClassTypes() will fail...
    /// </summary>
    public class TEditorItemClassPanel
    {
        [JsonProperty]
        public string Novice = string.Empty;
        [JsonProperty]
        public string Fighter = string.Empty;
        [JsonProperty]
        public string Warrior = string.Empty;
        [JsonProperty]
        public string Berserker = string.Empty;
        [JsonProperty]
        public string Warlord = string.Empty;
        [JsonProperty]
        public string Deathknight = string.Empty;
        [JsonProperty]
        public string Destroyer = string.Empty;
        [JsonProperty]
        public string Paladin = string.Empty;
        [JsonProperty]
        public string Templar = string.Empty;
        [JsonProperty]
        public string Crusader = string.Empty;
        [JsonProperty]
        public string Holyknight = string.Empty;
        [JsonProperty]
        public string Hunter = string.Empty;
        [JsonProperty]
        public string Archer = string.Empty;
        [JsonProperty]
        public string Ranger = string.Empty;
        [JsonProperty]
        public string Sharpshooter = string.Empty;
        [JsonProperty]
        public string Hawkeye = string.Empty;
        [JsonProperty]
        public string Predator = string.Empty;
        [JsonProperty]
        public string Assassin = string.Empty;
        [JsonProperty]
        public string Darkstalker = string.Empty;
        [JsonProperty]
        public string Windshadow = string.Empty;
        [JsonProperty]
        public string Shinobi = string.Empty;
        [JsonProperty]
        public string Acolyte = string.Empty;
        [JsonProperty]
        public string Priest = string.Empty;
        [JsonProperty]
        public string Cleric = string.Empty;
        [JsonProperty]
        public string Prophet = string.Empty;
        [JsonProperty]
        public string Saint = string.Empty;
        [JsonProperty]
        public string Archangel = string.Empty;
        [JsonProperty]
        public string Sage = string.Empty;
        [JsonProperty]
        public string Mystic = string.Empty;
        [JsonProperty]
        public string Shaman = string.Empty;
        [JsonProperty]
        public string Druid = string.Empty;
        [JsonProperty]
        public string Spellcaster = string.Empty;
        [JsonProperty]
        public string Mage = string.Empty;
        [JsonProperty]
        public string Wizard = string.Empty;
        [JsonProperty]
        public string Archmage = string.Empty;
        [JsonProperty]
        public string Avatar = string.Empty;
        [JsonProperty]
        public string Warlock = string.Empty;
        [JsonProperty]
        public string Necromancer = string.Empty;
        [JsonProperty]
        public string Demonologist = string.Empty;
        [JsonProperty]
        public string Shadowlord = string.Empty;
        [JsonProperty]
        public string Shinigami = string.Empty;
        [JsonProperty]
        public string Mechanic = string.Empty;
        [JsonProperty]
        public string Machinist = string.Empty;
        [JsonProperty]
        public string Demolitionist = string.Empty;
        [JsonProperty]
        public string Gunner = string.Empty;
        [JsonProperty]
        public string Bombardier = string.Empty;
        [JsonProperty]
        public string Artillerist = string.Empty;
        [JsonProperty]
        public string Enginner = string.Empty;
        [JsonProperty]
        public string Gearmaster = string.Empty;
        [JsonProperty]
        public string Cogmaster = string.Empty;
        [JsonProperty]
        public string Mechmaster = string.Empty;
        [JsonProperty]
        public string Wanderer = string.Empty;
        [JsonProperty]
        public string Drifter = string.Empty;
        [JsonProperty]
        public string Timetraveler = string.Empty;
        [JsonProperty]
        public string Keymaster = string.Empty;
        [JsonProperty]
        public string Chronomancer = string.Empty;
        [JsonProperty]
        public string Chronoshifter = string.Empty;
        [JsonProperty]
        public string Voidrunner = string.Empty;
        [JsonProperty]
        public string Dimensionalist = string.Empty;
        [JsonProperty]
        public string Reaper = string.Empty;
        [JsonProperty]
        public string Phantom = string.Empty;

        public List<string> GetValues()
        {
            var values = new List<string>();
            var fields = typeof(TEditorItemClassPanel).GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fields)
                values.Add(field.GetValue(this) as string ?? string.Empty);
            return values;
        }

        /// <summary>
        /// Retrieves a dictionary mapping each <see cref="ClassType"/> enum value to its corresponding 
        /// string value from the fields of the <see cref="TEditorItemClassPanel"/> class.
        /// </summary>
        /// <returns>
        /// A dictionary where the keys are <see cref="ClassType"/> enum values and the values 
        /// are the corresponding string values from the class fields.
        /// </returns>
        /// <remarks>
        /// <para>- The function uses reflection to iterate through all public instance fields of the class.</para>
        /// <para>- It attempts to match each field name with an enum name from <see cref="ClassType"/>.</para>
        /// <para>- If a match is found (case-insensitive), the field value is added to the dictionary.</para>
        /// <para>- If no matching field is found or the value is null, an empty string is used as the value.</para>
        /// </remarks>
        public Dictionary<ClassType, string> GetValuesByClassTypes()
        {
            var fields = typeof(TEditorItemClassPanel).GetFields(BindingFlags.Public | BindingFlags.Instance);
            var enumValues = Enum.GetValues<ClassType>();
            var enumNames = Enum.GetNames<ClassType>();
            var dict = new Dictionary<ClassType, string>();

            for (int i = 0; i < enumNames.Length; i++)
            {
                var enumName = enumNames[i];
                var enumValue = enumValues[i];
                foreach (var field in fields)
                {
                    // Field is invalid ?
                    // Field and enum should have the same name..
                    if (!field.Name.Contains(enumName, StringComparison.CurrentCultureIgnoreCase))
                        continue;

                    // Try to add in the dictionary
                    // GetValue() should return string.
                    dict.TryAdd(enumValue, field.GetValue(this) as string ?? string.Empty);
                }
            }

            return dict;
        }
    }

    public class TEditorItemEnchantPanel
    {
        [JsonProperty]
        public string IsEnchantEnabled = string.Empty;
        [JsonProperty]
        public string EnchantIndex = string.Empty;
        [JsonProperty]
        public string ElfSkillIndex = string.Empty;
        [JsonProperty]
        public string ExpertMaxLevel = string.Empty;
        [JsonProperty]
        public string ExpertEnchantIndex = string.Empty;
        [JsonProperty]
        public string EnchantTimeType = string.Empty;
        [JsonProperty]
        public string EnchantDuration = string.Empty;
        [JsonProperty]
        public string TreasureBuffIndex0 = string.Empty;
        [JsonProperty]
        public string TreasureBuffIndex1 = string.Empty;
        [JsonProperty]
        public string TreasureBuffIndex2 = string.Empty;
        [JsonProperty]
        public string TreasureBuffIndex3 = string.Empty;
    }

    public class TEditorItemMainPanel
    {
        [JsonProperty]
        public string MaxHP = string.Empty;
        [JsonProperty]
        public string MaxMP = string.Empty;
        [JsonProperty]
        public string PhysicalDefence = string.Empty;
        [JsonProperty]
        public string MagicalDefence = string.Empty;
        [JsonProperty]
        public string MaxDurability = string.Empty;
        [JsonProperty]
        public string Str = string.Empty;
        [JsonProperty]
        public string Vit = string.Empty;
        [JsonProperty]
        public string Int = string.Empty;
        [JsonProperty]
        public string Wil = string.Empty;
        [JsonProperty]
        public string Agi = string.Empty;
        [JsonProperty]
        public string AveragePhysicalDamage = string.Empty;
        [JsonProperty]
        public string RandomPhysicalDamage = string.Empty;
        [JsonProperty]
        public string Attack = string.Empty;
        [JsonProperty]
        public string RangedAttack = string.Empty;
        [JsonProperty]
        public string MagicAttack = string.Empty;
        [JsonProperty]
        public string PhysicalCriticalRate = string.Empty;
        [JsonProperty]
        public string MagicalCriticalRate = string.Empty;
        [JsonProperty]
        public string PhysicalPenetration = string.Empty;
        [JsonProperty]
        public string MagicalPenetration = string.Empty;
        [JsonProperty]
        public string PhysicalCriticalDamage = string.Empty;
        [JsonProperty]
        public string MagicalCriticalDamage = string.Empty;
        [JsonProperty]
        public string PhysicalPenetrationDefence = string.Empty;
        [JsonProperty]
        public string MagicalPenetrationDefence = string.Empty;
        [JsonProperty]
        public string AttackRange = string.Empty;
        [JsonProperty]
        public string AttackSpeed = string.Empty;
        [JsonProperty]
        public string DodgeRate = string.Empty;
        [JsonProperty]
        public string BlockRate = string.Empty;
        [JsonProperty]
        public string HitRate = string.Empty;
        [JsonProperty]
        public string AttributeParameters = string.Empty;
        [JsonProperty]
        public string AttributeType = string.Empty;
        [JsonProperty]
        public string AttributeRate = string.Empty;
        [JsonProperty]
        public string AttributeDamage = string.Empty;
        [JsonProperty]
        public string AttributeResistance = string.Empty;
        [JsonProperty]
        public string SpecialParameters = string.Empty;
        [JsonProperty]
        public string SpecialType = string.Empty;
        [JsonProperty]
        public string SpecialDamage = string.Empty;
        [JsonProperty]
        public string SpecialRate = string.Empty;
    }

    public class TEditorItemOpFlagsPanel
    {
        [JsonProperty]
        public string Useable = string.Empty;
        [JsonProperty]
        public string Combinable = string.Empty;
        [JsonProperty]
        public string BindOnEquip = string.Empty;
        [JsonProperty]
        public string AccumulateTimeOnUse = string.Empty;
        [JsonProperty]
        public string LinkToQuest = string.Empty;
        [JsonProperty]
        public string ForDeadPlayer = string.Empty;
        [JsonProperty]
        public string UnbindItem = string.Empty;
        [JsonProperty]
        public string OnlyEquip = string.Empty;
        [JsonProperty]
        public string NoDecrease = string.Empty;
        [JsonProperty]
        public string NoTrade = string.Empty;
        [JsonProperty]
        public string NoDiscard = string.Empty;
        [JsonProperty]
        public string NoEnchance = string.Empty;
        [JsonProperty]
        public string NoRepair = string.Empty;
        [JsonProperty]
        public string NoSameBuff = string.Empty;
        [JsonProperty]
        public string NoInBattle = string.Empty;
        [JsonProperty]
        public string NoInTown = string.Empty;
        [JsonProperty]
        public string NoInCave = string.Empty;
        [JsonProperty]
        public string NoInInstance = string.Empty;
        [JsonProperty]
        public string NoInBattlefield = string.Empty;
        [JsonProperty]
        public string NoInField = string.Empty;
        [JsonProperty]
        public string NoTransportNode = string.Empty;
        [JsonProperty]
        public string Only1 = string.Empty;
        [JsonProperty]
        public string Only2 = string.Empty;
        [JsonProperty]
        public string Only3 = string.Empty;
        [JsonProperty]
        public string Only4 = string.Empty;
        [JsonProperty]
        public string Only5 = string.Empty;
        [JsonProperty]
        public string Replaceable1 = string.Empty;
        [JsonProperty]
        public string Replaceable2 = string.Empty;
        [JsonProperty]
        public string Replaceable3 = string.Empty;
        [JsonProperty]
        public string Replaceable4 = string.Empty;
        [JsonProperty]
        public string Replaceable5 = string.Empty;
    }

    public class TEditorGlobal
    {
        [JsonProperty]
        public string SaveAndClose = string.Empty;
        [JsonProperty]
        public string Ok = string.Empty;
        [JsonProperty]
        public string For = string.Empty;
        [JsonProperty]
        public string Item = string.Empty;
        [JsonProperty]
        public string Client = string.Empty;
        [JsonProperty]
        public string Server = string.Empty;
        [JsonProperty]
        public string Processing = string.Empty;
        [JsonProperty]
        public string Combining = string.Empty;
        [JsonProperty]
        public string Index = string.Empty;
        [JsonProperty]
        public string Sounds = string.Empty;
        [JsonProperty]
        public string Loading = string.Empty;
        [JsonProperty]
        public string DropChestImage = string.Empty;
        [JsonProperty]
        public string ItemImage = string.Empty;
        [JsonProperty]
        public string JsonDatabase = string.Empty;
    }

    public class TEditor
    {
        [JsonProperty]
        public TEditorGlobal Global = new();
        [JsonProperty]
        public TEditorItemClassPanel ItemClassPanel = new();
        [JsonProperty]
        public TEditorItemEnchantPanel ItemEnchantPanel = new();
        [JsonProperty]
        public TEditorItemMainPanel ItemMainPanel = new();
        [JsonProperty]
        public TEditorItemOpFlagsPanel ItemOpFlagsPanel = new();
    }

    public static class TEditorTranslate
    {
        [JsonProperty]
        public static TEditor? Editor = new();

        public static void Load()
        {
            Editor = JsonConvert.DeserializeObject<TEditor>(File.ReadAllText("TranslateEN.json"));
        }
    }
}
