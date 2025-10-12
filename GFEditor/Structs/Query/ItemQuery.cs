using GFEditor.Structs.Interface;

namespace GFEditor.Structs.Query
{
    public class ItemQuery(Action onReadFinished) : BaseQuery<IdType, ItemData>("ItemQuery")
    {
        private readonly Action OnReadFinished = onReadFinished;

        public override bool Get(IdType index, out ItemData result)
        {
            return m_kMap.TryGetValue(index, out result);
        }

        public override IOrderedEnumerable<ItemData> GetAllValues()
        {
            return m_kMap.Values.OrderBy(e => e.m_nId);
        }

        protected override void OnFileRead(List<List<string>> listOfStrings)
        {
            foreach (var value in listOfStrings)
            {
                if (value == null)
                {
                    GuiNotify.Show(ImGuiToastType.Warning, m_queryName, "Found null value in splitted values, column count: {0}", m_nColumnCount);
                    continue;
                }

                var rb = new GFStringReader(value);

                var index = (IdType)rb.ReadUInt();
                if (m_kMap.ContainsKey(index))
                {
                    GuiNotify.Show(ImGuiToastType.Warning, m_queryName, "Duplicate item ID found: {0}, skipping.", index);
                    continue;
                }

                var item = new ItemData();
                item.m_nId = index;
                item.m_kIconFilename = rb.ReadString().ToLower();
                item.m_nModelFilename = rb.ReadString();
                item.m_nDropFilename = rb.ReadString();
                item.m_nWeaponEffectId = (IdType)rb.ReadUInt();
                item.m_nFlyEffectId = (IdType)rb.ReadUInt();
                item.m_nUsedEffectId = (IdType)rb.ReadUInt();
                item.m_nUsedSoundName = rb.ReadString();
                item.m_nEnhanceEffectId = (IdType)rb.ReadUInt();
                item.m_kName = rb.ReadString();
                item.m_eItemType = (EItemType)rb.ReadInt();
                item.m_eEquipType = (EEquipType)rb.ReadInt();
                item.m_nOpFlags = (EItemOpFlags)rb.ReadULong();
                if (m_nVer >= 12)
                    item.m_nOpFlagsPlus = (EItemOpFlagsPlus)rb.ReadULong();
                item.m_eTarget = (EItemTarget)rb.ReadInt();
                item.m_eRestrictGender = (EGender)rb.ReadInt();
                item.m_nRestrictLevel = rb.ReadByte();
                if (m_nVer >= 9)
                    item.m_nRestrictMaxLevel = rb.ReadByte();
                if (m_nVer >= 14)
                {
                    item.m_nRebirthCount = rb.ReadShort();
                    item.m_nRebirthScore = rb.ReadShort();
                    item.m_nRebirthMaxScore = rb.ReadShort();
                }
                item.m_eRestrictAlign = (EAlignement)rb.ReadShort();
                item.m_nRestrictPrestige = rb.ReadULong();
                item.m_nRestrictClass = (ERestrictClass)rb.ReadHex();
                item.m_eItemQuality = (EItemQuality)rb.ReadShort();
                item.m_nItemGroup = rb.ReadUShort();
                item.m_nCastingTime = rb.ReadLong();
                item.m_nCoolDownTime = rb.ReadLong();
                item.m_nCoolDownGroup = rb.ReadUShort();
                item.m_nMaxHp = rb.ReadULong();
                item.m_nMaxMp = rb.ReadULong();
                item.m_nStr = rb.ReadShort();
                item.m_nVit = rb.ReadShort();
                item.m_nInt = rb.ReadShort();
                item.m_nWil = rb.ReadShort();
                item.m_nDex = rb.ReadShort();
                item.m_nAvgPhysicalDamage = rb.ReadULong();
                item.m_nRandPhysicalDamage = rb.ReadULong();
                item.m_nAttackRange = rb.ReadUShort();
                item.m_nAttackSpeed = rb.ReadUShort();
                item.m_nAttack = (ulong)rb.ReadDouble();
                item.m_nRangeDamage = (ulong)rb.ReadDouble();
                item.m_nPhysicalDefence = (ulong)rb.ReadDouble();
                item.m_nMagicDamage = (ulong)rb.ReadDouble();
                item.m_nMagicDefence = (ulong)rb.ReadDouble();
                item.m_nHitRate = rb.ReadChar();
                item.m_nDodgeRate = rb.ReadChar();
                item.m_nPhysicalCriticalRate = rb.ReadShort();
                item.m_nPhysicalCriticalDamage = rb.ReadULong();
                item.m_nMagicCriticalRate = rb.ReadShort();
                item.m_nMagicCriticalDamage = rb.ReadULong();
                if (m_nVer >= 15)
                {
                    item.m_nPhysicalPenetration = rb.ReadShort();
                    item.m_nMagicalPenetration = rb.ReadShort();
                    item.m_nPhysicalPenetrationDefence = rb.ReadShort();
                    item.m_nMagicalPenetrationDefence = rb.ReadShort();
                }
                item.m_eAttribute = (EAttrResist)rb.ReadInt();
                item.m_nAttributeRate = rb.ReadShort();
                item.m_nAttributeDamage = rb.ReadULong();
                item.m_nAttributeResist = rb.ReadULong();
                item.m_eSpecialType = (EMonsterType)rb.ReadInt();
                item.m_nSpecialRate = rb.ReadShort();
                item.m_nSpecialDamage = rb.ReadULong();
                item.m_nDropRate = rb.ReadChar();
                item.m_nDropIndex = (IdType)rb.ReadULong();
                item.m_kTreasureBuffs1 = rb.ReadInt();
                item.m_kTreasureBuffs2 = rb.ReadInt();
                item.m_kTreasureBuffs3 = rb.ReadInt();
                item.m_kTreasureBuffs4 = rb.ReadInt();
                item.m_eEnchantType = (EBuffIconType)rb.ReadShort();
                item.m_nEnchantId = rb.ReadInt();
                if (m_nVer >= 16)
                {
                    item.m_nExpertLevel = rb.ReadShort();
                    item.m_nExpertEnchantId = rb.ReadInt();
                }
                if (m_nVer >= 11)
                    item.m_nElfSkillId = rb.ReadUShort();
                item.m_eEnchantTimeType = (ETimeType)rb.ReadUShort();
                item.m_nEnchantDuration = rb.ReadLong();
                item.m_nLimitType = (ELimitTimeType)rb.ReadULong();
                item.m_nDueDateTime = rb.ReadULong();
                item.m_nBackpackSize = rb.ReadByte();
                item.m_nMaxSocket = rb.ReadByte();
                item.m_nSocketRate = rb.ReadChar();
                item.m_nMaxDurability = (ushort)rb.ReadDouble();
                item.m_nMaxStack = rb.ReadUShort();
                if (m_nVer >= 9)
                    item.m_nShopPriceType = (EShopPriceType)rb.ReadUShort();
                item.m_nSysPrice = (ulong)rb.ReadDouble();
                item.m_nRestrictEventPosId = rb.ReadString();
                item.m_nMissionPosId = (IdType)rb.ReadULong();
                item.m_nBlockRate = rb.ReadChar();
                item.m_nLogLevel = rb.ReadByte();
                item.m_eAuctionType = (EAuctionType)rb.ReadShort();
                if (m_nVer >= 13)
                {
                    item.m_kExtraData1 = rb.ReadLong();
                    item.m_kExtraData2 = rb.ReadLong();
                    item.m_kExtraData3 = rb.ReadLong();
                }
                item.m_kTip = rb.ReadString();
                item.Initialize();

                m_kMap.TryAdd(index, item);
            }

            GuiNotify.Show(ImGuiToastType.Success, m_queryName, $"Loaded {m_kMap.Count} items from {m_fileName}");
            OnReadFinished.Invoke();
        }
    }
}
