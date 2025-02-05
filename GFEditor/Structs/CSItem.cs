namespace GFEditor.Structs
{
    /// <summary>
    /// 92 entries. (Starting from 0)
    /// </summary>
    public class CSItem : IComparable<CSItem>
    {
        [JsonProperty]
        public int Index;
        [JsonProperty]
        public required string IconFilename;
        [JsonProperty]
        public required string ModelId; // Item model
        [JsonProperty]
        public required string ModelFilename; // Chest model
        [JsonProperty]
        public int WeaponEffectId;
        [JsonProperty]
        public int FlyEffectId;
        [JsonProperty]
        public int UsedEffectId;
        [JsonProperty]
        public required string UsedSoundName;
        [JsonProperty]
        public int EnchanceEffectId;
        [JsonProperty]
        public required string Name;
        [JsonProperty]
        public int ItemType;
        [JsonProperty]
        public int EquipType;
        [JsonProperty]
        public uint OpFlags;
        [JsonProperty]
        public int OpFlagsPlus;
        [JsonProperty]
        public int Target;
        [JsonProperty]
        public int RestrictGender;
        [JsonProperty]
        public int RestrictLevel;
        [JsonProperty]
        public int RestrictMaxLevel;
        [JsonProperty]
        public int RebirthCount;
        [JsonProperty]
        public int RebirthScore;
        [JsonProperty]
        public int RebirthMaxScore;
        [JsonProperty]
        public int RestrictReputation;
        [JsonProperty]
        public int RestrictReputationCount;
        [JsonProperty]
        public ulong RestrictClass;
        [JsonProperty]
        public int ItemQuality;
        [JsonProperty]
        public int ItemGroup;
        [JsonProperty]
        public int CastingTime; // 10 = 1.0 second.
        [JsonProperty]
        public int CoolDownTime; // 10 = 1.0 second.
        [JsonProperty]
        public int CoolDownGroup;
        [JsonProperty]
        public int MaxHp;
        [JsonProperty]
        public int MaxMp;
        [JsonProperty]
        public int Str;
        [JsonProperty]
        public int Vit;
        [JsonProperty]
        public int Int;
        [JsonProperty]
        public int Wil;
        [JsonProperty]
        public int Agi;
        [JsonProperty]
        public int AvgPhysicoDamage;
        [JsonProperty]
        public int RandPhysicoDamage;
        [JsonProperty]
        public int AttackRange;
        [JsonProperty]
        public int AttackSpeed;
        [JsonProperty]
        public int Attack;
        [JsonProperty]
        public int RangeAttack;
        [JsonProperty]
        public int PhysicoDefence;
        [JsonProperty]
        public int MagicDamage;
        [JsonProperty]
        public int MagicDefence;
        [JsonProperty]
        public int HitRate;
        [JsonProperty]
        public int DodgeRate;
        [JsonProperty]
        public int PhysicoCriticalRate;
        [JsonProperty]
        public int PhysicoCriticalDamage;
        [JsonProperty]
        public int MagicCriticalRate;
        [JsonProperty]
        public int MagicCriticalDamage;
        [JsonProperty]
        public int PhysicalPenetration;
        [JsonProperty]
        public int MagicalPenetration;
        [JsonProperty]
        public int PhysicalPenetrationDefence;
        [JsonProperty]
        public int MagicalPenetrationDefence;
        [JsonProperty]
        public int Attribute;
        [JsonProperty]
        public int AttributeRate; // 10 = 1%
        [JsonProperty]
        public int AttributeDamage;
        [JsonProperty]
        public int AttributeResist;
        [JsonProperty]
        public int SpecialType;
        [JsonProperty]
        public int SpecialRate;
        [JsonProperty]
        public int SpecialDamage;
        [JsonProperty]
        public int DropRate;
        [JsonProperty]
        public int DropIndex;
        [JsonProperty]
        public int TreasureBuffs01;
        [JsonProperty]
        public int TreasureBuffs02;
        [JsonProperty]
        public int TreasureBuffs03;
        [JsonProperty]
        public int TreasureBuffs04;
        [JsonProperty]
        public int EnchantEnabler;
        [JsonProperty]
        public int EnchantIndex;
        [JsonProperty]
        public int ExpertLevel;
        [JsonProperty]
        public int ExpertEnchantIndex;
        [JsonProperty]
        public int ElfSkillIndex;
        [JsonProperty]
        public int EnchantTimeType;
        [JsonProperty]
        public int EnchantDuration;
        [JsonProperty]
        public int LimitType;
        [JsonProperty]
        public int DueDateTime;
        [JsonProperty]
        public int BackpackSize;
        [JsonProperty]
        public int SocketMax;
        [JsonProperty]
        public int SocketRate;
        [JsonProperty]
        public int MaxDurability;
        [JsonProperty]
        public int MaxStack;
        [JsonProperty]
        public int ShopPriceType;
        [JsonProperty]
        public int Price; // GG/SS/CC gold, silver, copper. or count if other than gold.
        [JsonProperty]
        public required string RestrictEventPosition; // NOTE: RestrictEventPosId is a position of X and Y separated by ';'
        [JsonProperty]
        public int MissionIndex;
        [JsonProperty]
        public int BlockRate;
        [JsonProperty]
        public int LogLevel;
        [JsonProperty]
        public int AuctionType;
        [JsonProperty]
        public int ExtraData01;
        [JsonProperty]
        public int ExtraData02;
        [JsonProperty]
        public int ExtraData03;
        [JsonProperty]
        public required string Tip;

        /// <summary>
        /// Is red equipment ?
        /// </summary>
        public bool IsHoly()
        {
            return (ItemType)ItemType == Enums.ItemType.HolyItem;
        }

        public int CompareTo(CSItem? other)
        {
            if (other == null) return 1;
            if (Index < other.Index) return -1;
            if (Index > other.Index) return 1;
            return 0;
        }

        public override string ToString()
        {
            var fields = GetType().GetFields(BindingFlags.Public | BindingFlags.Instance).OrderBy(f => f.MetadataToken); // Ensures consistent order
            var sb = new StringBuilder();
            foreach (var field in fields)
            {
                var value = field.GetValue(this);
                // Replace 0 and null with an empty string
                if (field.Name.Equals("RestrictClass") && value is ulong v2 && v2 != 0) // RestrictClass use HEX.
                    sb.Append(v2.ToString("X")).Append('|');
                else if (value == null || (value is string v5 && string.IsNullOrEmpty(v5)) || (value is int v && v == 0) || (value is ulong v1 && v1 == 0) || (value is uint v4 && v4 == 0) || (field.Name.Equals("Target") && value is int v3 && v3 == 1))
                    sb.Append("").Append('|');
                else
                    sb.Append(value).Append('|');
            }
            return sb.ToString();
        }
    }
}
