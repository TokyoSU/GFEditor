namespace GFEditor.Structs
{
    public class ClassData
    {
        public LevelType m_nLevel;
        public string m_kName = string.Empty;
        public uint m_nMaxHP;
        public uint m_nMaxMP;
        public BaseAttrType m_nStr;
        public BaseAttrType m_nCon; // Vit
        public BaseAttrType m_nInt;
        public BaseAttrType m_nVol; // Wil
        public BaseAttrType m_nDex; // Agi
        public uint m_nPhysicoDamage;
        public uint m_nRangeDamage;
        public uint m_nMagicDamage;
        public uint m_nPhysicoDefence;
        public uint m_nMagicDefence;
        public uint m_nDodgeRate;
        public List<IdType> m_kBaseSpells = []; // 6 max?
    }
}
