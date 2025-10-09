namespace GFEditor.Structs
{
    public class EnchantData
    {
        public IdType m_nId;
        public string m_kIconFilename = string.Empty;
        public uint m_nAnimId;
        public uint m_nEffectId;
        public string m_kEffectNode = string.Empty;
        public string m_kName = string.Empty;
        public EEnchantType m_eEnchantType;
        public uint m_nEnchantFlag;
        public EEnchantCategory m_eEnchantCategory; // v10+
        public ushort m_nImmuneMonsterType;
        public List<Commands> m_kEnchantCommands = [];
        public uint m_nPeriod;
        public ushort m_nHiword;
        public byte m_nLowword;
        public List<uint> m_kTransitionCmd = [];
        public EEnchantTransition m_eEEnchantTransition;
        public byte m_nTransitionRate;
        public uint m_nTransitionDuration;
        public uint m_nTransitionPeriod;
        public string m_kTransitionIconFilename = string.Empty;
        public EEnchantType m_eTransitionEnchantType;
        public uint m_nTransitionEnchantFlag;
        public EEnchantCategory m_eTransitionEnchantCategory; // v10+
        public uint m_nTransitionAnimId;
        public uint m_nTransitionEffectId;
        public string m_kTransitionEffectNode = string.Empty;
        public uint m_nTransitionEffectDuration;
        public string m_kTransitionEffectDurationNode = string.Empty;
        public uint m_nTransitionCooldownTime;
        public ushort m_nTransitionEnchantHiword;
        public byte m_nTransitionEnchantLowword;
        public string m_kTip = string.Empty;
        public string m_kTransitionTip = string.Empty;
        public string m_kTransitionName = string.Empty;
        public ushort m_nMaxStack;
        public uint m_nWeaponFlag; // v9+

        public class Commands
        {
            public uint m_nId;
            public string m_nParam1 = string.Empty;
            public string m_nParam2 = string.Empty;
            public string m_nParam3 = string.Empty;
            public string m_nParam4 = string.Empty;
            public string m_nParam5 = string.Empty;
            public string m_nParam6 = string.Empty;
        }

        public string GetString(long version, char delimiter = '|')
        {
            var sb = new StringBuilder();
            sb.AppendGF(m_nId).Append(delimiter);
            sb.AppendGF(m_kIconFilename).Append(delimiter);
            sb.AppendGF(m_nAnimId).Append(delimiter);
            sb.AppendGF(m_nEffectId).Append(delimiter);
            sb.AppendGF(m_kEffectNode).Append(delimiter);
            sb.AppendGF(m_kName).Append(delimiter);
            sb.AppendGF((int)m_eEnchantType).Append(delimiter);
            sb.AppendGF(m_nEnchantFlag).Append(delimiter);
            if (version >= 10)
                sb.AppendGF((int)m_eEnchantCategory).Append(delimiter);
            sb.AppendGF(m_nImmuneMonsterType).Append(delimiter);
            foreach (var cmd in m_kEnchantCommands)
            {
                sb.AppendGF(cmd.m_nId).Append(delimiter);
                sb.AppendGF(cmd.m_nParam1).Append(delimiter);
                sb.AppendGF(cmd.m_nParam2).Append(delimiter);
                sb.AppendGF(cmd.m_nParam3).Append(delimiter);
                sb.AppendGF(cmd.m_nParam4).Append(delimiter);
                sb.AppendGF(cmd.m_nParam5).Append(delimiter);
                sb.AppendGF(cmd.m_nParam6).Append(delimiter);
            }
            sb.AppendGF(m_nPeriod).Append(delimiter);
            sb.AppendGF(m_nHiword).Append(delimiter);
            sb.AppendGF(m_nLowword).Append(delimiter);
            for (int i = 0; i < m_kTransitionCmd.Count; i++)
            {
                if (i == m_kTransitionCmd.Count - 1)
                    sb.AppendGF(m_kTransitionCmd[i]).Append(delimiter); // last one is delimiter.
                else
                    sb.AppendGF(m_kTransitionCmd[i]).Append(';'); // others inside are semicolon.
            }
            sb.AppendGF((int)m_eEEnchantTransition).Append(delimiter);
            sb.AppendGF(m_nTransitionRate).Append(delimiter);
            sb.AppendGF(m_nTransitionDuration).Append(delimiter);
            sb.AppendGF(m_nTransitionPeriod).Append(delimiter);
            sb.AppendGF(m_kTransitionIconFilename).Append(delimiter);
            sb.AppendGF((int)m_eTransitionEnchantType).Append(delimiter);
            sb.AppendGF(m_nTransitionEnchantFlag).Append(delimiter);
            if (version >= 10)
                sb.AppendGF((int)m_eTransitionEnchantCategory).Append(delimiter);
            sb.AppendGF(m_nTransitionAnimId).Append(delimiter);
            sb.AppendGF(m_nTransitionEffectId).Append(delimiter);
            sb.AppendGF(m_kTransitionEffectNode).Append(delimiter);
            sb.AppendGF(m_nTransitionEffectDuration).Append(delimiter);
            sb.AppendGF(m_kTransitionEffectDurationNode).Append(delimiter);
            sb.AppendGF(m_nTransitionCooldownTime).Append(delimiter);
            sb.AppendGF(m_nTransitionEnchantHiword).Append(delimiter);
            sb.AppendGF(m_nTransitionEnchantLowword).Append(delimiter);
            sb.AppendGF(m_kTip).Append(delimiter);
            sb.AppendGF(m_kTransitionTip).Append(delimiter);
            sb.AppendGF(m_kTransitionName).Append(delimiter);
            sb.AppendGF(m_nMaxStack).Append(delimiter);
            if (version >= 9)
                sb.AppendGF(m_nWeaponFlag).Append(delimiter);
            return sb.ToString();
        }
    }
}
