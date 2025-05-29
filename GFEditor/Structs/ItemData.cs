namespace GFEditor.Structs
{
    public class ItemData
    {
        public IdType m_nId;
        public string m_kIconFilename = string.Empty;
        public string m_nModelFilename = string.Empty;
        public string m_nDropFilename = string.Empty;
        public IdType m_nWeaponEffectId;
        public IdType m_nFlyEffectId;
        public IdType m_nUsedEffectId;
        public string m_nUsedSoundName = string.Empty;
        public IdType m_nEnhanceEffectId;
        public string m_kName = string.Empty;
        public EItemType m_eItemType;
        public EEquipType m_eEquipType;
        public EItemOpFlags m_nOpFlags; // EItemOpFlags enum
        public EItemOpFlagsPlus m_nOpFlagsPlus; // EItemOpFlagsPlus enum
        public EItemTarget m_eTarget;
        public EGender m_eRestrictGender;
        public LevelType m_nRestrictLevel;
        public LevelType m_nRestrictMaxLevel;
        public short m_nRebirthCount;
        public short m_nRebirthScore;
        public short m_nRebirthMaxScore;
        public EAlignement m_eRestrictAlign;
        public ulong m_nRestrictPrestige;
        public ERestrictClass m_nRestrictClass;
        public EItemQuality m_eItemQuality;
        public ushort m_nItemGroup;
        public TimeType m_nCastingTime;
        public TimeType m_nCoolDownTime;
        public ushort m_nCoolDownGroup;
        public ulong m_nMaxHp;
        public ulong m_nMaxMp;
        public BaseAttrType m_nStr;
        public BaseAttrType m_nCon;
        public BaseAttrType m_nInt;
        public BaseAttrType m_nVol;
        public BaseAttrType m_nDex;
        public ulong m_nAvgPhysicoDamage;
        public ulong m_nRandPhysicoDamage;
        public GridType m_nAttackRange;
        public AttackSpeedType m_nAttackSpeed;
        public ulong m_nAttack;
        public ulong m_nRangeAttack;
        public ulong m_nPhysicoDefence;
        public ulong m_nMagicDamage;
        public ulong m_nMagicDefence;
        public RateType m_nHitRate;
        public RateType m_nDodgeRate;
        public short m_nPhysicoCriticalRate;
        public ulong m_nPhysicoCriticalDamage;
        public short m_nMagicCriticalRate;
        public ulong m_nMagicCriticalDamage;
        public short m_nPhysicalPenetration;
        public short m_nMagicalPenetration;
        public short m_nPhysicalPenetrationDefence;
        public short m_nMagicalPenetrationDefence;
        public EAttrResist m_eAttribute;
        public ulong m_nAttributeDamage;
        public short m_nAttributeRate;
        public ulong m_nAttributeResist;
        public EMonsterType m_eSpecialType;
        public short m_nSpecialRate;
        public ulong m_nSpecialDamage;
        public RateType m_nDropRate;
        public IdType m_nDropIndex;
        public int m_kTreasureBuffs1;
        public int m_kTreasureBuffs2;
        public int m_kTreasureBuffs3;
        public int m_kTreasureBuffs4;
        public EBuffIconType m_eEnchantType;
        public BuffType m_nEnchantId;
        public short m_nExpertLevel;
        public BuffType m_nExpertEnchantId;
        public ushort m_nElfSkillId;
        public ETimeType m_eEnchantTimeType;
        public TimeType m_nEnchantDuration;
        public ulong m_nLimitType;
        public RentType m_nDueDateTime;
        public byte m_nBackpackSize;
        public byte m_nMaxSocket;
        public RateType m_nSocketRate;
        public ushort m_nMaxDurability;
        public ushort m_nMaxStack;
        public EShopPriceType m_nShopPriceType;
        public float m_fSysPrice;
        public string m_nRestrictEventPosId = string.Empty;
        public IdType m_nMissionPosId;
        public RateType m_nBlockRate;
        public byte m_nLogLevel;
        public EAuctionType m_eAuctionType;
        public long m_kExtraData1;
        public long m_kExtraData2;
        public long m_kExtraData3;
        public string m_kTip = string.Empty;

        // Editor only:

        public required Dictionary<EItemOpFlags, bool> m_bOpFlagsArray;
        public required Dictionary<EItemOpFlagsPlus, bool> m_bOpFlagsPlusArray;
        public required Dictionary<ERestrictClass, bool> m_bClassRestrictionArray;

        public void Initialize()
        {
            var restrictList = Enum.GetValues<ERestrictClass>();
            for (int index = 0; index < restrictList.Length; index++)
            {
                var value = restrictList[index];
                m_bClassRestrictionArray.TryAdd(value, m_nRestrictClass.HasFlag(value));
            }

            var opFlagList = Enum.GetValues<EItemOpFlags>();
            for (int index = 0; index < opFlagList.Length; index++)
            {
                var value = opFlagList[index];
                m_bOpFlagsArray.TryAdd(value, m_nOpFlags.HasFlag(value));
            }

            var opFlagPlusList = Enum.GetValues<EItemOpFlagsPlus>();
            for (int index = 0; index < opFlagPlusList.Length; index++)
            {
                var value = opFlagPlusList[index];
                m_bOpFlagsPlusArray.TryAdd(value, m_nOpFlagsPlus.HasFlag(value));
            }
        }

        private void AddOrRemoveClassRestrict(ERestrictClass cls)
        {
            if (m_bClassRestrictionArray[cls]) m_nRestrictClass |= cls;
            else m_nRestrictClass &= ~cls;
        }

        private void AddOrRemoveOpFlags(EItemOpFlags cls)
        {
            if (m_bOpFlagsArray[cls]) m_nOpFlags |= cls;
            else m_nOpFlags &= ~cls;
        }

        private void AddOrRemoveOpFlagsPlus(EItemOpFlagsPlus cls)
        {
            if (m_bOpFlagsPlusArray[cls]) m_nOpFlagsPlus |= cls;
            else m_nOpFlagsPlus &= ~cls;
        }

        public void ProcessClassRestriction()
        {
            var list = Enum.GetValues<ERestrictClass>();
            foreach (var value in list)
                AddOrRemoveClassRestrict(value);
        }

        public void ProcessOpFlags()
        {
            var list = Enum.GetValues<EItemOpFlags>();
            foreach (var value in list)
                AddOrRemoveOpFlags(value);
        }

        public void ProcessOpFlagsPlus()
        {
            var list = Enum.GetValues<EItemOpFlagsPlus>();
            foreach (var value in list)
                AddOrRemoveOpFlagsPlus(value);
        }
    }
}
