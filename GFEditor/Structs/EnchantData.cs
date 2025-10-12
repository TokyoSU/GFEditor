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

        public void DrawParameters(EditorTranslate editorT, EnchantDataTranslate enchantT, long version)
        {
            string emptyStr = string.Empty;

            ImGuiUtils.Label(editorT.HeaderItemIndex + ": " + m_nId, false);
            ImGuiUtils.InputText("Name: ", ref m_kName);
            if (enchantT != null) ImGuiUtils.InputText("Translated name: ", ref enchantT.m_kName);
            else ImGuiUtils.InputText("Translated name: ", ref emptyStr, true);

            ImGuiUtils.InputText(editorT.IconName + ": ", ref m_kIconFilename);
            ImGui.SameLine();
            var icon = IconSkill.GetByName(m_kIconFilename);
            if (icon != null)
                ImGui.Image(icon.ToImGui(), new Vector2(32, 32));
            ImGuiUtils.InputUInt("Anim id: ", ref m_nAnimId);
            ImGuiUtils.InputUInt("Effect id: ", ref m_nEffectId);
            ImGuiUtils.InputText("Effect node: ", ref m_kEffectNode);
            ImGuiUtils.InputUShort("Immune monster type: ", ref m_nImmuneMonsterType);

            if (ImGui.CollapsingHeader("Description"))
            {
                ImGuiUtils.InputTextMultiline("Tip: ", ref m_kTip, new Vector2(1024, 512));
                if (enchantT != null) ImGuiUtils.InputTextMultiline("Translated Tip: ", ref enchantT.m_kDescription, new Vector2(1024, 512));
                else ImGuiUtils.InputTextMultiline("Translated Tip: ", ref emptyStr, new Vector2(1024, 512), true);
            }

            if (ImGui.CollapsingHeader("Enchantments"))
            {
                ImGuiUtils.ComboBoxEnum("EnchantType: ", ref Constants.EnchantType2Index, out m_eEnchantType, EEnchantType.Max);
                ImGuiUtils.InputUInt("EnchantFlag: ", ref m_nEnchantFlag);
                if (version >= 10)
                    ImGuiUtils.ComboBoxEnum("EnchantCategory: ", ref Constants.EnchantCategoryIndex, out m_eEnchantCategory);
                ImGui.Separator();
                if (ImGui.Button("Add new enchant command"))
                    m_kEnchantCommands.Add(new Commands());
                ImGuiUtils.Label("Enchantments count: " + m_kEnchantCommands.Count, false);
                for (int i = 0; i < m_kEnchantCommands.Count; i++)
                {
                    var cmd = m_kEnchantCommands[i];
                    ImGui.Separator();
                    ImGuiUtils.InputUInt($"Enchant {i} id: ", ref cmd.m_nId);
                    ImGuiUtils.InputText($"Enchant {i} param 1: ", ref cmd.m_nParam1);
                    ImGuiUtils.InputText($"Enchant {i} param 2: ", ref cmd.m_nParam2);
                    ImGuiUtils.InputText($"Enchant {i} param 3: ", ref cmd.m_nParam3);
                    ImGuiUtils.InputText($"Enchant {i} param 4: ", ref cmd.m_nParam4);
                    ImGuiUtils.InputText($"Enchant {i} param 5: ", ref cmd.m_nParam5);
                    ImGuiUtils.InputText($"Enchant {i} param 6: ", ref cmd.m_nParam6);
                }
                ImGui.Separator();
            }

            if (ImGui.CollapsingHeader("Transition"))
            {
                ImGui.Separator();
                ImGuiUtils.Label("Transition commands count: " + m_kTransitionCmd.Count, false);
                if (ImGui.Button("Add new transition command"))
                    m_kTransitionCmd.Add(0);
                for (int i = 0; i < m_kTransitionCmd.Count; i++)
                {
                    uint cmd = m_kTransitionCmd[i];
                    ImGuiUtils.InputUInt($"Transition {i} id: ", ref cmd);
                    m_kTransitionCmd[i] = cmd;
                    ImGui.SameLine();
                    if (ImGui.Button($"Remove transition {i}"))
                    {
                        m_kTransitionCmd.RemoveAt(i);
                        break;
                    }
                }
                ImGui.Separator();
                ImGuiUtils.ComboBoxEnum("Enchant transition: ", ref Constants.EnchantTypeIndex, out m_eEEnchantTransition);
                ImGuiUtils.InputByte("Transition rate: ", ref m_nTransitionRate);
                ImGuiUtils.InputUInt("Transition duration: ", ref m_nTransitionDuration);
                ImGuiUtils.InputUInt("Transition period: ", ref m_nTransitionPeriod);
                ImGuiUtils.InputText("Transition icon: ", ref m_kTransitionIconFilename);
                ImGuiUtils.ComboBoxEnum("Transition enchant type: ", ref Constants.EnchantTransitionType, out m_eTransitionEnchantType, EEnchantType.Max);
                ImGuiUtils.InputUInt("Transition enchant flag: ", ref m_nTransitionEnchantFlag);
                if (version >= 10)
                    ImGuiUtils.ComboBoxEnum("Transition enchant category: ", ref Constants.EnchantTransitionCategoryIndex, out m_eTransitionEnchantCategory);
                ImGuiUtils.InputUInt("Transition anim id: ", ref m_nTransitionAnimId);
                ImGuiUtils.InputUInt("Transition effect id: ", ref m_nTransitionEffectId);
                ImGuiUtils.InputUInt("Transition effect duration: ", ref m_nTransitionEffectDuration);
                ImGuiUtils.InputText("Transition effect node: ", ref m_kTransitionEffectNode);
                ImGuiUtils.InputText("Transition effect node duration: ", ref m_kTransitionEffectDurationNode);
                ImGuiUtils.InputUInt("Transition cooldown time: ", ref m_nTransitionCooldownTime);
                ImGuiUtils.InputUShort("Transition enchant hiword: ", ref m_nTransitionEnchantHiword);
                ImGuiUtils.InputByte("Transition enchant lowword: ", ref m_nTransitionEnchantLowword);
                ImGui.Separator();
                ImGuiUtils.Label("Transition name: ", false);
                if (enchantT != null) ImGuiUtils.InputTextMultiline("Transition name: ", ref m_kTransitionName, new Vector2(1024, 512));
                else ImGuiUtils.InputTextMultiline("Transition name: ", ref emptyStr, new Vector2(1024, 512), true);
                ImGuiUtils.Label("Transition description: ", false);
                if (enchantT != null) ImGuiUtils.InputTextMultiline("Transition description: ", ref m_kTransitionTip, new Vector2(1024, 512));
                else ImGuiUtils.InputTextMultiline("Transition description: ", ref emptyStr, new Vector2(1024, 512), true);
                ImGuiUtils.Label("Translated transition name: ", false);
                if (enchantT != null) ImGuiUtils.InputTextMultiline("Translated transition name: ", ref enchantT.m_kTransitionName, new Vector2(1024, 512));
                else ImGuiUtils.InputTextMultiline("Translated transition name: ", ref emptyStr, new Vector2(1024, 512), true);
                ImGuiUtils.Label("Translated transition description: ", false);
                if (enchantT != null) ImGuiUtils.InputTextMultiline("Translated transition description: ", ref enchantT.m_kTransitionDescription, new Vector2(1024, 512));
                else ImGuiUtils.InputTextMultiline("Translated transition description: ", ref emptyStr, new Vector2(1024, 512), true);
            }

            if (ImGui.CollapsingHeader("Misc"))
            {
                ImGuiUtils.InputUInt("Period: ", ref m_nPeriod);
                ImGuiUtils.InputUShort("Hiword: ", ref m_nHiword);
                ImGuiUtils.InputByte("Lowword: ", ref m_nLowword);
                ImGuiUtils.InputUShort("MaxStack: ", ref m_nMaxStack);
                if (version >= 9)
                    ImGuiUtils.InputUInt("WeaponFlag: ", ref m_nWeaponFlag);
            }
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

            var transitionCmdField = m_kTransitionCmd.Count > 0 ? string.Join(';', m_kTransitionCmd) : string.Empty;
            sb.AppendGF(transitionCmdField).Append(delimiter);

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
