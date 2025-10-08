namespace GFEditor.Structs
{
    public class LevelData
    {
        [JsonProperty("Level")]
        public LevelType m_nLevel;

        [JsonProperty("CharExp")]
        public ulong m_nCharExp;

        [JsonProperty("GuildExp")]
        public uint m_nGuildExp;

        [JsonProperty("Prestige")]
        public uint m_nPrestige;

        [JsonProperty("ElfLevel")]
        public uint m_nElfLevel;

        [JsonProperty("ElfReturn")]
        public uint m_nElfReturn;

        [JsonProperty("Mining")]
        public uint m_nMining;

        [JsonProperty("Plant")]
        public uint m_nPlant;

        [JsonProperty("Hunting")]
        public uint m_nHunting;

        [JsonProperty("Decompose")]
        public uint m_nDecompose;

        [JsonProperty("Sword")]
        public uint m_nSword;

        [JsonProperty("Axe")]
        public uint m_nAxe;

        [JsonProperty("Mace")]
        public uint m_nMace;

        [JsonProperty("Bow")]
        public uint m_nBow;

        [JsonProperty("Gun")]
        public uint m_nGun;

        [JsonProperty("Staff")]
        public uint m_nStaff;

        [JsonProperty("Shield")]
        public uint m_nShield;

        [JsonProperty("HolyItem")]
        public uint m_nHolyItem;

        [JsonProperty("Fighter")]
        public uint m_nFighter;

        [JsonProperty("Hunter")]
        public uint m_nHunter;

        [JsonProperty("Caster")]
        public uint m_nCaster;

        [JsonProperty("Acolyte")]
        public uint m_nAcolyte;

        [JsonProperty("MoneyExp")]
        public uint m_nMoneyExp;

        [JsonProperty("MonsterExp")]
        public uint m_nMonsterExp;

        [JsonProperty("IsleExp")]
        public uint m_nIsleExp;

        [JsonProperty("WP")]
        public uint m_nWP;

        [JsonProperty("RP")]
        public uint m_nRP;

        [JsonProperty("FrearmExp")]
        public uint m_nFrearmExp;

        [JsonProperty("CannonExp")]
        public uint m_nCannonExp;

        [JsonProperty("MechExp")]
        public uint m_nMechExp;

        [JsonProperty("CrystalKanataExp")]
        public uint m_nCrystalKanataExp;

        [JsonProperty("CrystalkeyExp")]
        public uint m_nCrystalkeyExp;

        [JsonProperty("CrystalEquipExp")]
        public uint m_nCrystalEquipExp;

        [JsonProperty("RebirthFrontScore")]
        public uint m_nRebirthFrontScore;

        [JsonProperty("RebirthRearScore")]
        public uint m_nRebirthRearScore;

        [JsonProperty("RebirthDiscount")]
        public uint m_nRebirthDiscount;

        [JsonProperty("RebirthCharExp")]
        public ulong m_nRebirthCharExp;

        [JsonProperty("WeaponAwakeAddMin")]
        public short m_nWeaponAwakeAddMin;

        [JsonProperty("WeaponAwakeAddMax")]
        public short m_nWeaponAwakeAddMax;

        [JsonProperty("ArmorAwakeAddMin")]
        public short m_nArmorAwakeAddMin;

        [JsonProperty("ArmorAwakeAddMax")]
        public short m_nArmorAwakeAddMax;

        [JsonProperty("WeaponPotential")]
        public uint m_nWeaponPotential;

        [JsonProperty("ArmorPotential")]
        public uint m_nArmorPotential;

        [JsonProperty("Gas")]
        public uint m_nGas;

        [JsonProperty("Pigment")]
        public uint m_nPigment;

        [JsonProperty("Map")]
        public uint m_nMap;

        [JsonProperty("SoulCrystal")]
        public uint m_nSoulCrystal;

        [JsonProperty("TravelExp")]
        public uint m_TravelExp;

        [JsonProperty("ElftabletExp")]
        public uint m_nElftabletExp;

        [JsonProperty("ElftabletLvAdd")]
        public uint m_nElftabletLvAdd;

        [JsonProperty("CarvingOrangeAttack")]
        public uint m_nCarvingOrangeAttack;

        [JsonProperty("CarvingOrangeRange")]
        public uint m_nCarvingOrangeRange;

        [JsonProperty("CarvingOrangeMagic")]
        public uint m_nCarvingOrangeMagic;

        [JsonProperty("CarvingYellowAttack")]
        public uint m_nCarvingYellowAttack;

        [JsonProperty("CarvingYellowRange")]
        public uint m_nCarvingYellowRange;

        [JsonProperty("CarvingYellowMagic")]
        public uint m_nCarvingYellowMagic;

        [JsonProperty("CarvingPurpleAttack")]
        public uint m_nCarvingPurpleAttack;

        [JsonProperty("CarvingPurpleRange")]
        public uint m_nCarvingPurpleRange;

        [JsonProperty("CarvingPurpleMagic")]
        public uint m_nCarvingPurpleMagic;

        [JsonProperty("CarvingRedAttack")]
        public uint m_nCarvingRedAttack;

        [JsonProperty("CarvingRedRange")]
        public uint m_nCarvingRedRange;

        [JsonProperty("CarvingRedMagic")]
        public uint m_nCarvingRedMagic;

        [JsonProperty("CarvingOrangeDefense")]
        public uint m_nCarvingOrangeDefense;

        [JsonProperty("CarvingOrangeMagicDefense")]
        public uint m_nCarvingOrangeMagicDefense;

        [JsonProperty("CarvingYellowDefense")]
        public uint m_nCarvingYellowDefense;

        [JsonProperty("CarvingYellowMagicDefense")]
        public uint m_nCarvingYellowMagicDefense;

        [JsonProperty("CarvingPurpleDefense")]
        public uint m_nCarvingPurpleDefense;

        [JsonProperty("CarvingPurpleMagicDefense")]
        public uint m_nCarvingPurpleMagicDefense;

        [JsonProperty("CarvingRedDefense")]
        public uint m_nCarvingRedDefense;

        [JsonProperty("CarvingRedMagicDefense")]
        public uint m_nCarvingRedMagicDefense;

        public string GetString(char delimiter = '|')
        {
            var sb = new StringBuilder();
            sb.AppendGF(m_nLevel).Append(delimiter);
            sb.AppendGF(m_nCharExp).Append(delimiter);
            sb.AppendGF(m_nGuildExp).Append(delimiter);
            sb.AppendGF(m_nPrestige).Append(delimiter);
            sb.AppendGF(m_nElfLevel).Append(delimiter);
            sb.AppendGF(m_nElfReturn).Append(delimiter);
            sb.AppendGF(m_nMining).Append(delimiter);
            sb.AppendGF(m_nPlant).Append(delimiter);
            sb.AppendGF(m_nHunting).Append(delimiter);
            sb.AppendGF(m_nDecompose).Append(delimiter);
            sb.AppendGF(m_nSword).Append(delimiter);
            sb.AppendGF(m_nAxe).Append(delimiter);
            sb.AppendGF(m_nMace).Append(delimiter);
            sb.AppendGF(m_nBow).Append(delimiter);
            sb.AppendGF(m_nGun).Append(delimiter);
            sb.AppendGF(m_nStaff).Append(delimiter);
            sb.AppendGF(m_nShield).Append(delimiter);
            sb.AppendGF(m_nHolyItem).Append(delimiter);
            sb.AppendGF(m_nFighter).Append(delimiter);
            sb.AppendGF(m_nHunter).Append(delimiter);
            sb.AppendGF(m_nCaster).Append(delimiter);
            sb.AppendGF(m_nAcolyte).Append(delimiter);
            sb.AppendGF(m_nMoneyExp).Append(delimiter);
            sb.AppendGF(m_nMonsterExp).Append(delimiter);
            sb.AppendGF(m_nIsleExp).Append(delimiter);
            sb.AppendGF(m_nWP).Append(delimiter);
            sb.AppendGF(m_nRP).Append(delimiter);
            sb.AppendGF(m_nFrearmExp).Append(delimiter);
            sb.AppendGF(m_nCannonExp).Append(delimiter);
            sb.AppendGF(m_nMechExp).Append(delimiter);
            sb.AppendGF(m_nCrystalKanataExp).Append(delimiter);
            sb.AppendGF(m_nCrystalkeyExp).Append(delimiter);
            sb.AppendGF(m_nCrystalEquipExp).Append(delimiter);
            sb.AppendGF(m_nRebirthFrontScore).Append(delimiter);
            sb.AppendGF(m_nRebirthRearScore).Append(delimiter);
            sb.AppendGF(m_nRebirthDiscount).Append(delimiter);
            sb.AppendGF(m_nRebirthCharExp).Append(delimiter);
            sb.AppendGF(m_nWeaponAwakeAddMin).Append(delimiter);
            sb.AppendGF(m_nWeaponAwakeAddMax).Append(delimiter);
            sb.AppendGF(m_nArmorAwakeAddMin).Append(delimiter);
            sb.AppendGF(m_nArmorAwakeAddMax).Append(delimiter);
            sb.AppendGF(m_nWeaponPotential).Append(delimiter);
            sb.AppendGF(m_nArmorPotential).Append(delimiter);
            sb.AppendGF(m_nGas).Append(delimiter);
            sb.AppendGF(m_nPigment).Append(delimiter);
            sb.AppendGF(m_nMap).Append(delimiter);
            sb.AppendGF(m_nSoulCrystal).Append(delimiter);
            sb.AppendGF(m_TravelExp).Append(delimiter);
            sb.AppendGF(m_nElftabletExp).Append(delimiter);
            sb.AppendGF(m_nElftabletLvAdd).Append(delimiter);
            sb.AppendGF(m_nCarvingOrangeAttack).Append(delimiter);
            sb.AppendGF(m_nCarvingOrangeRange).Append(delimiter);
            sb.AppendGF(m_nCarvingOrangeMagic).Append(delimiter);
            sb.AppendGF(m_nCarvingYellowAttack).Append(delimiter);
            sb.AppendGF(m_nCarvingYellowRange).Append(delimiter);
            sb.AppendGF(m_nCarvingYellowMagic).Append(delimiter);
            sb.AppendGF(m_nCarvingPurpleAttack).Append(delimiter);
            sb.AppendGF(m_nCarvingPurpleRange).Append(delimiter);
            sb.AppendGF(m_nCarvingPurpleMagic).Append(delimiter);
            sb.AppendGF(m_nCarvingRedAttack).Append(delimiter);
            sb.AppendGF(m_nCarvingRedRange).Append(delimiter);
            sb.AppendGF(m_nCarvingRedMagic).Append(delimiter);
            sb.AppendGF(m_nCarvingOrangeDefense).Append(delimiter);
            sb.AppendGF(m_nCarvingOrangeMagicDefense).Append(delimiter);
            sb.AppendGF(m_nCarvingYellowDefense).Append(delimiter);
            sb.AppendGF(m_nCarvingYellowMagicDefense).Append(delimiter);
            sb.AppendGF(m_nCarvingPurpleDefense).Append(delimiter);
            sb.AppendGF(m_nCarvingPurpleMagicDefense).Append(delimiter);
            sb.AppendGF(m_nCarvingRedDefense).Append(delimiter);
            sb.AppendGF(m_nCarvingRedMagicDefense).Append(delimiter);
            return sb.ToString();
        }
    }
}
