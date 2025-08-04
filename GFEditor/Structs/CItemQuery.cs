using GFEditor.Structs.Interface;

namespace GFEditor.Structs
{
    public class CItemQuery : CBaseQuery<IdType, CItem>
    {
        private Task? m_readFileTask = null;
        private string m_fileName = string.Empty;
        private string m_VerStr = string.Empty;
        private long m_nVer = 0;
        private long m_nColumnCount = 0;

        public string GetVersionStr() => m_VerStr;
        public long GetVersion() => m_nVer;
        public long GetColumnCount() => m_nColumnCount;

        public bool GetItem(IdType index, out CItem result)
        {
            return m_kMap.TryGetValue(index, out result);
        }

        public IOrderedEnumerable<CItem> GetAllItems()
        {
            return m_kMap.Values.OrderBy(e => e.m_nId);
        }

        public bool HasValues()
        {
            return m_kMap.Count > 0;
        }

        private void Read()
        {
            var strm = new InTextStream(m_fileName, true, true);
            if (!strm.IsOpen())
                return;

            var delimiter = strm.GetDelimiter();
            var headerString = strm.GetFirstLine();
            headerString = headerString[1..^1]; // Remove first | and last |.
            var splittedHeader = headerString.Split(delimiter);
            m_VerStr = splittedHeader[0];
            m_nVer = m_VerStr.At(1, delimiter).AsLong();
            m_nColumnCount = splittedHeader[1].AsLong();

            var splittedValues = strm.SplitByColumns(m_nColumnCount, delimiter);
            if (splittedValues == null)
            {
                GuiNotify.Show(ImGuiToastType.Warning, "CItemQuery", "Failed to split ini data by columns, column count: {0}", m_nColumnCount);
                return;
            }

            foreach (var value in splittedValues)
            {
                if (value == null)
                {
                    GuiNotify.Show(ImGuiToastType.Warning, "CItemQuery", "Found null value in splitted values, column count: {0}", m_nColumnCount);
                    continue;
                }

                var index = (IdType)value[0].AsULong();
                if (m_kMap.ContainsKey(index))
                {
                    GuiNotify.Show(ImGuiToastType.Warning, "CItemQuery", "Duplicate item ID found: {0}, skipping.", index);
                    continue;
                }

                m_kMap.Add(index, new CItem
                {
                    m_nId = index,
                    m_kIconFilename = value[1].ToLower(),
                    m_nModelFilename = value[2],
                    m_nDropFilename = value[3],
                    m_nWeaponEffectId = (IdType)value[4].AsULong(),
                    m_nFlyEffectId = (IdType)value[5].AsULong(),
                    m_nUsedEffectId = (IdType)value[6].AsULong(),
                    m_nUsedSoundName = value[7],
                    m_nEnhanceEffectId = (IdType)value[8].AsULong(),
                    m_kName = value[9],
                    m_eItemType = (EItemType)value[10].AsInt(),
                    m_eEquipType = (EEquipType)value[11].AsInt(),
                    m_nOpFlags = (EItemOpFlags)value[12].AsULong(),
                    m_nOpFlagsPlus = (EItemOpFlagsPlus)value[13].AsULong(),
                    m_eTarget = (EItemTarget)value[14].AsInt(),
                    m_eRestrictGender = (EGender)value[15].AsInt(),
                    m_nRestrictLevel = value[16].AsByte(),
                    m_nRestrictMaxLevel = value[17].AsByte(),
                    m_nRebirthCount = value[18].AsShort(),
                    m_nRebirthScore = value[19].AsShort(),
                    m_nRebirthMaxScore = value[20].AsShort(),
                    m_eRestrictAlign = (EAlignement)value[21].AsShort(),
                    m_nRestrictPrestige = value[22].AsULong(),
                    m_nRestrictClass = (ERestrictClass)value[23].AsHex(),
                    m_eItemQuality = (EItemQuality)value[24].AsShort(),
                    m_nItemGroup = value[25].AsUShort(),
                    m_nCastingTime = (TimeType)value[26].AsLong(),
                    m_nCoolDownTime = (TimeType)value[27].AsLong(),
                    m_nCoolDownGroup = value[28].AsUShort(),
                    m_nMaxHp = value[29].AsULong(),
                    m_nMaxMp = value[30].AsULong(),
                    m_nStr = (BaseAttrType)value[31].AsShort(),
                    m_nVit = (BaseAttrType)value[32].AsShort(),
                    m_nInt = (BaseAttrType)value[33].AsShort(),
                    m_nWil = (BaseAttrType)value[34].AsShort(),
                    m_nDex = (BaseAttrType)value[35].AsShort(),
                    m_nAvgPhysicalDamage = value[36].AsULong(),
                    m_nRandPhysicalDamage = value[37].AsULong(),
                    m_nAttackRange = (GridType)value[38].AsUShort(),
                    m_nAttackSpeed = (AttackSpeedType)value[39].AsUShort(),
                    m_nAttack = (ulong)value[40].AsDouble(), // Make double to fix database issues.
                    m_nRangeDamage = (ulong)value[41].AsDouble(),
                    m_nPhysicalDefence = (ulong)value[42].AsDouble(),
                    m_nMagicDamage = (ulong)value[43].AsDouble(),
                    m_nMagicDefence = (ulong)value[44].AsDouble(),
                    m_nHitRate = (RateType)value[45].AsChar(),
                    m_nDodgeRate = (RateType)value[46].AsChar(),
                    m_nPhysicalCriticalRate = value[47].AsShort(),
                    m_nPhysicalCriticalDamage = value[48].AsULong(),
                    m_nMagicCriticalRate = value[49].AsShort(),
                    m_nMagicCriticalDamage = value[50].AsULong(),
                    m_nPhysicalPenetration = value[51].AsShort(),
                    m_nMagicalPenetration = value[52].AsShort(),
                    m_nPhysicalPenetrationDefence = value[53].AsShort(),
                    m_nMagicalPenetrationDefence = value[54].AsShort(),
                    m_eAttribute = (EAttrResist)value[55].AsShort(),
                    m_nAttributeDamage = value[56].AsULong(),
                    m_nAttributeRate = value[57].AsShort(),
                    m_nAttributeResist = value[58].AsULong(),
                    m_eSpecialType = (EMonsterType)value[59].AsULong(),
                    m_nSpecialRate = value[60].AsShort(),
                    m_nSpecialDamage = value[61].AsULong(),
                    m_nDropRate = (RateType)value[62].AsChar(),
                    m_nDropIndex = (IdType)value[63].AsULong(),
                    m_kTreasureBuffs1 = value[64].AsInt(),
                    m_kTreasureBuffs2 = value[65].AsInt(),
                    m_kTreasureBuffs3 = value[66].AsInt(),
                    m_kTreasureBuffs4 = value[67].AsInt(),
                    m_eEnchantType = (EBuffIconType)value[68].AsShort(),
                    m_nEnchantId = (BuffType)value[69].AsInt(),
                    m_nExpertLevel = value[70].AsShort(),
                    m_nExpertEnchantId = (BuffType)value[71].AsInt(),
                    m_nElfSkillId = value[72].AsUShort(),
                    m_eEnchantTimeType = (ETimeType)value[73].AsUShort(),
                    m_nEnchantDuration = value[74].AsLong(),
                    m_nLimitType = (ELimitTimeType)value[75].AsULong(),
                    m_nDueDateTime = (RentType)value[76].AsULong(),
                    m_nBackpackSize = value[77].AsByte(),
                    m_nMaxSocket = value[78].AsByte(),
                    m_nSocketRate = (RateType)value[79].AsChar(),
                    m_nMaxDurability = (ushort)value[80].AsDouble(), // Make double to fix database issues.
                    m_nMaxStack = value[81].AsUShort(),
                    m_nShopPriceType = (EShopPriceType)value[82].AsUShort(),
                    m_nSysPrice = (ulong)value[83].AsDouble(),
                    m_nRestrictEventPosId = value[84],
                    m_nMissionPosId = (IdType)value[85].AsULong(),
                    m_nBlockRate = (RateType)value[86].AsChar(),
                    m_nLogLevel = value[87].AsByte(),
                    m_eAuctionType = (EAuctionType)value[88].AsShort(),
                    m_kExtraData1 = value[89].AsLong(),
                    m_kExtraData2 = value[90].AsLong(),
                    m_kExtraData3 = value[91].AsLong(),
                    m_kTip = value[92]
                });
            }

            GuiNotify.Show(ImGuiToastType.Success, "CItemQuery", $"Loaded {m_kMap.Count} items from {m_fileName}");
        }

        public bool IsLoaded()
        {
            return m_readFileTask != null && m_readFileTask.IsCompleted;
        }

        public override void ReadFile(string filePath)
        {
            m_fileName = filePath;
            m_readFileTask = Task.Run(Read);
        }
    }
}
