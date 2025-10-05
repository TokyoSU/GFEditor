namespace GFEditor.Structs
{
    public class Item
    {
        [JsonProperty("id")]
        public IdType m_nId;
        [JsonProperty("iconFilename")]
        public string m_kIconFilename = string.Empty;
        [JsonProperty("modelFilename")]
        public string m_nModelFilename = string.Empty;
        [JsonProperty("dropFilename")]
        public string m_nDropFilename = string.Empty;
        [JsonProperty("weaponEffectId")]
        public IdType m_nWeaponEffectId;
        [JsonProperty("flyEffectId")]
        public IdType m_nFlyEffectId;
        [JsonProperty("usedEffectId")]
        public IdType m_nUsedEffectId;
        [JsonProperty("usedSoundName")]
        public string m_nUsedSoundName = string.Empty;
        [JsonProperty("enhanceEffectId")]
        public IdType m_nEnhanceEffectId;
        [JsonProperty("name")]
        public string m_kName = string.Empty;
        [JsonProperty("itemType")]
        public EItemType m_eItemType;
        [JsonProperty("equipType")]
        public EEquipType m_eEquipType;
        [JsonProperty("opFlags")]
        public EItemOpFlags m_nOpFlags;
        [JsonProperty("opFlagsPlus")]
        public EItemOpFlagsPlus m_nOpFlagsPlus;
        [JsonProperty("target")]
        public EItemTarget m_eTarget;
        [JsonProperty("restrictGender")]
        public EGender m_eRestrictGender;
        [JsonProperty("restrictLevel")]
        public LevelType m_nRestrictLevel;
        [JsonProperty("restrictMaxLevel")]
        public LevelType m_nRestrictMaxLevel;
        [JsonProperty("rebirthCount")]
        public short m_nRebirthCount;
        [JsonProperty("rebirthScore")]
        public short m_nRebirthScore;
        [JsonProperty("rebirthMaxScore")]
        public short m_nRebirthMaxScore;
        [JsonProperty("restrictAlign")]
        public EAlignement m_eRestrictAlign;
        [JsonProperty("restrictPrestige")]
        public ulong m_nRestrictPrestige;
        [JsonProperty("restrictClass")]
        public ERestrictClass m_nRestrictClass;
        [JsonProperty("itemQuality")]
        public EItemQuality m_eItemQuality;
        [JsonProperty("itemGroup")]
        public ushort m_nItemGroup;
        [JsonProperty("castingTime")]
        public TimeType m_nCastingTime;
        [JsonProperty("coolDownTime")]
        public TimeType m_nCoolDownTime;
        [JsonProperty("coolDownGroup")]
        public ushort m_nCoolDownGroup;
        [JsonProperty("maxHp")]
        public ulong m_nMaxHp;
        [JsonProperty("maxMp")]
        public ulong m_nMaxMp;
        [JsonProperty("str")]
        public BaseAttrType m_nStr;
        [JsonProperty("con")]
        public BaseAttrType m_nVit;
        [JsonProperty("int")]
        public BaseAttrType m_nInt;
        [JsonProperty("vol")]
        public BaseAttrType m_nWil;
        [JsonProperty("dex")]
        public BaseAttrType m_nDex;
        [JsonProperty("avgPhysicoDamage")]
        public ulong m_nAvgPhysicalDamage;
        [JsonProperty("randPhysicoDamage")]
        public ulong m_nRandPhysicalDamage;
        [JsonProperty("attackRange")]
        public GridType m_nAttackRange;
        [JsonProperty("attackSpeed")]
        public AttackSpeedType m_nAttackSpeed;
        [JsonProperty("attack")]
        public ulong m_nAttack;
        [JsonProperty("rangeAttack")]
        public ulong m_nRangeDamage;
        [JsonProperty("physicoDefence")]
        public ulong m_nPhysicalDefence;
        [JsonProperty("magicDamage")]
        public ulong m_nMagicDamage;
        [JsonProperty("magicDefence")]
        public ulong m_nMagicDefence;
        [JsonProperty("hitRate")]
        public RateType m_nHitRate;
        [JsonProperty("dodgeRate")]
        public RateType m_nDodgeRate;
        [JsonProperty("physicoCriticalRate")]
        public short m_nPhysicalCriticalRate;
        [JsonProperty("physicoCriticalDamage")]
        public ulong m_nPhysicalCriticalDamage;
        [JsonProperty("magicCriticalRate")]
        public short m_nMagicCriticalRate;
        [JsonProperty("magicCriticalDamage")]
        public ulong m_nMagicCriticalDamage;
        [JsonProperty("physicalPenetration")]
        public short m_nPhysicalPenetration;
        [JsonProperty("magicalPenetration")]
        public short m_nMagicalPenetration;
        [JsonProperty("physicalPenetrationDefence")]
        public short m_nPhysicalPenetrationDefence;
        [JsonProperty("magicalPenetrationDefence")]
        public short m_nMagicalPenetrationDefence;
        [JsonProperty("attribute")]
        public EAttrResist m_eAttribute;
        [JsonProperty("attributeRate")]
        public short m_nAttributeRate;
        [JsonProperty("attributeDamage")]
        public ulong m_nAttributeDamage;
        [JsonProperty("attributeResist")]
        public ulong m_nAttributeResist;
        [JsonProperty("specialType")]
        public EMonsterType m_eSpecialType;
        [JsonProperty("specialRate")]
        public short m_nSpecialRate;
        [JsonProperty("specialDamage")]
        public ulong m_nSpecialDamage;
        [JsonProperty("dropRate")]
        public RateType m_nDropRate;
        [JsonProperty("dropIndex")]
        public IdType m_nDropIndex;
        [JsonProperty("treasureBuffs1")]
        public int m_kTreasureBuffs1;
        [JsonProperty("treasureBuffs2")]
        public int m_kTreasureBuffs2;
        [JsonProperty("treasureBuffs3")]
        public int m_kTreasureBuffs3;
        [JsonProperty("treasureBuffs4")]
        public int m_kTreasureBuffs4;
        [JsonProperty("enchantType")]
        public EBuffIconType m_eEnchantType;
        [JsonProperty("enchantId")]
        public BuffType m_nEnchantId;
        [JsonProperty("expertLevel")]
        public short m_nExpertLevel;
        [JsonProperty("expertEnchantId")]
        public BuffType m_nExpertEnchantId;
        [JsonProperty("elfSkillId")]
        public ushort m_nElfSkillId;
        [JsonProperty("enchantTimeType")]
        public ETimeType m_eEnchantTimeType;
        [JsonProperty("enchantDuration")]
        public TimeType m_nEnchantDuration;
        [JsonProperty("limitType")]
        public ELimitTimeType m_nLimitType;
        [JsonProperty("dueDateTime")]
        public RentType m_nDueDateTime;
        [JsonProperty("backpackSize")]
        public byte m_nBackpackSize;
        [JsonProperty("maxSocket")]
        public byte m_nMaxSocket;
        [JsonProperty("socketRate")]
        public RateType m_nSocketRate;
        [JsonProperty("maxDurability")]
        public ushort m_nMaxDurability;
        [JsonProperty("maxStack")]
        public ushort m_nMaxStack;
        [JsonProperty("shopPriceType")]
        public EShopPriceType m_nShopPriceType;
        [JsonProperty("sysPrice")]
        public ulong m_nSysPrice; /// First 000000 is gold, next 00 is silver and last 00 is copper. !
        [JsonProperty("restrictEventPosId")]
        public string m_nRestrictEventPosId = string.Empty;
        [JsonProperty("missionPosId")]
        public IdType m_nMissionPosId;
        [JsonProperty("blockRate")]
        public RateType m_nBlockRate;
        [JsonProperty("logLevel")]
        public byte m_nLogLevel;
        [JsonProperty("auctionType")]
        public EAuctionType m_eAuctionType;
        [JsonProperty("extraData1")]
        public long m_kExtraData1;
        [JsonProperty("extraData2")]
        public long m_kExtraData2;
        [JsonProperty("extraData3")]
        public long m_kExtraData3;
        [JsonProperty("tip")]
        public string m_kTip = string.Empty;

        public Item() => Initialize();

        // Editor only:

        public Dictionary<EItemOpFlags, bool> m_bOpFlagsArray = [];
        public Dictionary<EItemOpFlagsPlus, bool> m_bOpFlagsPlusArray = [];
        public Dictionary<ERestrictClass, bool> m_bClassRestrictionArray = [];

        /// <summary>
        /// Generates a serialized string representation of the object's data.
        /// </summary>
        /// <remarks>The returned string contains a pipe-delimited sequence of the object's properties and
        /// fields. Each value is serialized in a specific order and format, which is consistent across calls. This
        /// method is typically used for exporting or logging the object's state.</remarks>
        /// <returns>A <see cref="string"/> containing the serialized representation of the object's data.</returns>
        public string GetClientString()
        {
            var m_sBuilder = new StringBuilder();
            m_sBuilder.AppendGF(m_nId).Append('|');
            m_sBuilder.AppendGF(m_kIconFilename).Append('|');
            m_sBuilder.AppendGF(m_nModelFilename).Append('|');
            m_sBuilder.AppendGF(m_nDropFilename).Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF(m_nUsedSoundName).Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|'); // Placeholder for m_kName, only required if you don't have editor support xD (also reduce the size of the file by a lot !)
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF(m_nLogLevel).Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|');
            m_sBuilder.AppendGF("").Append('|'); // Placeholder for m_kTip, only required if you don't have editor support xD (also reduce the size of the file by a lot !)
            return m_sBuilder.ToString();
        }

        /// <summary>
        /// Server need to have stats and necessity informations !
        /// </summary>
        public string GetServerString()
        {
            var m_sBuilder = new StringBuilder();
            m_sBuilder.AppendGF(m_nId).Append('|');
            m_sBuilder.AppendGF(m_kIconFilename).Append('|');
            m_sBuilder.AppendGF(m_nModelFilename).Append('|');
            m_sBuilder.AppendGF(m_nDropFilename).Append('|');
            m_sBuilder.AppendGF(m_nWeaponEffectId).Append('|');
            m_sBuilder.AppendGF(m_nFlyEffectId).Append('|');
            m_sBuilder.AppendGF(m_nUsedEffectId).Append('|');
            m_sBuilder.AppendGF(m_nUsedSoundName).Append('|');
            m_sBuilder.AppendGF(m_nEnhanceEffectId).Append('|');
            m_sBuilder.AppendGF("").Append('|'); // Placeholder for m_kName, only required if you don't have editor support xD (also reduce the size of the file by a lot !)
            m_sBuilder.AppendGF(m_eItemType).Append('|');
            m_sBuilder.AppendGF(m_eEquipType).Append('|');
            m_sBuilder.AppendGF(m_nOpFlags).Append('|');
            m_sBuilder.AppendGF(m_nOpFlagsPlus).Append('|');
            m_sBuilder.AppendGF(m_eTarget).Append('|');
            m_sBuilder.AppendGF(m_eRestrictGender).Append('|');
            m_sBuilder.AppendGF(m_nRestrictLevel).Append('|');
            m_sBuilder.AppendGF(m_nRestrictMaxLevel).Append('|');
            m_sBuilder.AppendGF(m_nRebirthCount).Append('|');
            m_sBuilder.AppendGF(m_nRebirthScore).Append('|');
            m_sBuilder.AppendGF(m_nRebirthMaxScore).Append('|');
            m_sBuilder.AppendGF(m_eRestrictAlign).Append('|');
            m_sBuilder.AppendGF(m_nRestrictPrestige).Append('|');
            m_sBuilder.AppendGF(m_nRestrictClass).Append('|');
            m_sBuilder.AppendGF(m_eItemQuality).Append('|');
            m_sBuilder.AppendGF(m_nItemGroup).Append('|');
            m_sBuilder.AppendGF(m_nCastingTime).Append('|');
            m_sBuilder.AppendGF(m_nCoolDownTime).Append('|');
            m_sBuilder.AppendGF(m_nCoolDownGroup).Append('|');
            m_sBuilder.AppendGF(m_nMaxHp).Append('|');
            m_sBuilder.AppendGF(m_nMaxMp).Append('|');
            m_sBuilder.AppendGF(m_nStr).Append('|');
            m_sBuilder.AppendGF(m_nVit).Append('|');
            m_sBuilder.AppendGF(m_nInt).Append('|');
            m_sBuilder.AppendGF(m_nWil).Append('|');
            m_sBuilder.AppendGF(m_nDex).Append('|');
            m_sBuilder.AppendGF(m_nAvgPhysicalDamage).Append('|');
            m_sBuilder.AppendGF(m_nRandPhysicalDamage).Append('|');
            m_sBuilder.AppendGF(m_nAttackRange).Append('|');
            m_sBuilder.AppendGF(m_nAttackSpeed).Append('|');
            m_sBuilder.AppendGF(m_nAttack).Append('|');
            m_sBuilder.AppendGF(m_nRangeDamage).Append('|');
            m_sBuilder.AppendGF(m_nPhysicalDefence).Append('|');
            m_sBuilder.AppendGF(m_nMagicDamage).Append('|');
            m_sBuilder.AppendGF(m_nMagicDefence).Append('|');
            m_sBuilder.AppendGF(m_nHitRate).Append('|');
            m_sBuilder.AppendGF(m_nDodgeRate).Append('|');
            m_sBuilder.AppendGF(m_nPhysicalCriticalRate).Append('|');
            m_sBuilder.AppendGF(m_nPhysicalCriticalDamage).Append('|');
            m_sBuilder.AppendGF(m_nMagicCriticalRate).Append('|');
            m_sBuilder.AppendGF(m_nMagicCriticalDamage).Append('|');
            m_sBuilder.AppendGF(m_nPhysicalPenetration).Append('|');
            m_sBuilder.AppendGF(m_nMagicalPenetration).Append('|');
            m_sBuilder.AppendGF(m_nPhysicalPenetrationDefence).Append('|');
            m_sBuilder.AppendGF(m_nMagicalPenetrationDefence).Append('|');
            m_sBuilder.AppendGF(m_eAttribute).Append('|');
            m_sBuilder.AppendGF(m_nAttributeRate).Append('|');
            m_sBuilder.AppendGF(m_nAttributeDamage).Append('|');
            m_sBuilder.AppendGF(m_nAttributeResist).Append('|');
            m_sBuilder.AppendGF(m_eSpecialType).Append('|');
            m_sBuilder.AppendGF(m_nSpecialRate).Append('|');
            m_sBuilder.AppendGF(m_nSpecialDamage).Append('|');
            m_sBuilder.AppendGF(m_nDropRate).Append('|');
            m_sBuilder.AppendGF(m_nDropIndex).Append('|');
            m_sBuilder.AppendGF(m_kTreasureBuffs1).Append('|');
            m_sBuilder.AppendGF(m_kTreasureBuffs2).Append('|');
            m_sBuilder.AppendGF(m_kTreasureBuffs3).Append('|');
            m_sBuilder.AppendGF(m_kTreasureBuffs4).Append('|');
            m_sBuilder.AppendGF(m_eEnchantType).Append('|');
            m_sBuilder.AppendGF(m_nEnchantId).Append('|');
            m_sBuilder.AppendGF(m_nExpertLevel).Append('|');
            m_sBuilder.AppendGF(m_nExpertEnchantId).Append('|');
            m_sBuilder.AppendGF(m_nElfSkillId).Append('|');
            m_sBuilder.AppendGF(m_eEnchantTimeType).Append('|');
            m_sBuilder.AppendGF(m_nEnchantDuration).Append('|');
            m_sBuilder.AppendGF(m_nLimitType).Append('|');
            m_sBuilder.AppendGF(m_nDueDateTime).Append('|');
            m_sBuilder.AppendGF(m_nBackpackSize).Append('|');
            m_sBuilder.AppendGF(m_nMaxSocket).Append('|');
            m_sBuilder.AppendGF(m_nSocketRate).Append('|');
            m_sBuilder.AppendGF(m_nMaxDurability).Append('|');
            m_sBuilder.AppendGF(m_nMaxStack).Append('|');
            m_sBuilder.AppendGF(m_nShopPriceType).Append('|');
            m_sBuilder.AppendGF(m_nSysPrice).Append('|');
            m_sBuilder.AppendGF(m_nRestrictEventPosId).Append('|');
            m_sBuilder.AppendGF(m_nMissionPosId).Append('|');
            m_sBuilder.AppendGF(m_nBlockRate).Append('|');
            m_sBuilder.AppendGF(m_nLogLevel).Append('|');
            m_sBuilder.AppendGF(m_eAuctionType).Append('|');
            m_sBuilder.AppendGF(m_kExtraData1).Append('|');
            m_sBuilder.AppendGF(m_kExtraData2).Append('|');
            m_sBuilder.AppendGF(m_kExtraData3).Append('|');
            m_sBuilder.AppendGF("").Append('|'); // Placeholder for m_kTip, only required if you don't have editor support xD (also reduce the size of the file by a lot !)
            return m_sBuilder.ToString();
        }

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

        public override string ToString()
        {
            return $"{m_nId}";
        }
    }
}
