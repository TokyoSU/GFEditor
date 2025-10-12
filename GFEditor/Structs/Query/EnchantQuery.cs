using GFEditor.Structs.Interface;

namespace GFEditor.Structs.Query
{
    public class EnchantQuery(Action onReadFinished) : BaseQuery<IdType, EnchantData>("EnchantQuery")
    {
        private readonly Action OnReadFinished = onReadFinished;

        public override bool Get(IdType index, out EnchantData result)
        {
            return m_kMap.TryGetValue(index, out result);
        }

        public override IOrderedEnumerable<EnchantData> GetAllValues()
        {
            return m_kMap.Values.OrderBy(x => x.m_nId);
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

                var enchantData = new EnchantData();
                enchantData.m_nId = index;
                enchantData.m_kIconFilename = rb.ReadString().ToLower();
                enchantData.m_nAnimId = rb.ReadUInt();
                enchantData.m_nEffectId = rb.ReadUInt();
                enchantData.m_kEffectNode = rb.ReadString();
                enchantData.m_kName = rb.ReadString();
                enchantData.m_eEnchantType = (EEnchantType)rb.ReadInt();
                enchantData.m_nEnchantFlag = rb.ReadUInt();
                if (m_nVer >= 10)
                    enchantData.m_eEnchantCategory = (EEnchantCategory)rb.ReadInt();
                enchantData.m_nImmuneMonsterType = rb.ReadUShort();

                for (int i = 0; i < 4; i++)
                {
                    var cmd = new EnchantData.Commands
                    {
                        m_nId = rb.ReadUInt(),
                        m_nParam1 = rb.ReadString(),
                        m_nParam2 = rb.ReadString(),
                        m_nParam3 = rb.ReadString(),
                        m_nParam4 = rb.ReadString(),
                        m_nParam5 = rb.ReadString(),
                        m_nParam6 = rb.ReadString()
                    };
                    enchantData.m_kEnchantCommands.Add(cmd);
                }

                enchantData.m_nPeriod = rb.ReadUInt();
                enchantData.m_nHiword = rb.ReadUShort();
                enchantData.m_nLowword = rb.ReadByte();

                var transitionData = rb.ReadString(); // Have multiple transition IDs separated by ';' !
                if (!string.IsNullOrEmpty(transitionData))
                {
                    var transitions = transitionData.Split(';');
                    foreach (var t in transitions)
                    {
                        if (t.AsUInt() != 0)
                            enchantData.m_kTransitionCmd.Add(t.AsUInt());
                    }
                }

                enchantData.m_eEEnchantTransition = (EEnchantTransition)rb.ReadInt();
                enchantData.m_nTransitionRate = rb.ReadByte();
                enchantData.m_nTransitionDuration = rb.ReadUInt();
                enchantData.m_nTransitionPeriod = rb.ReadUInt();
                enchantData.m_kTransitionIconFilename = rb.ReadString().ToLower();
                enchantData.m_eTransitionEnchantType = (EEnchantType)rb.ReadInt();
                enchantData.m_nTransitionEnchantFlag = rb.ReadUInt();
                if (m_nVer >= 10)
                    enchantData.m_eTransitionEnchantCategory = (EEnchantCategory)rb.ReadInt();
                enchantData.m_nTransitionAnimId = rb.ReadUInt();
                enchantData.m_nTransitionEffectId = rb.ReadUInt();
                enchantData.m_kTransitionEffectNode = rb.ReadString();
                enchantData.m_nTransitionEffectDuration = rb.ReadUInt();
                enchantData.m_kTransitionEffectDurationNode = rb.ReadString();
                enchantData.m_nTransitionCooldownTime = rb.ReadUInt();
                enchantData.m_nTransitionEnchantHiword = rb.ReadUShort();
                enchantData.m_nTransitionEnchantLowword = rb.ReadByte();
                enchantData.m_kTip = rb.ReadString();
                enchantData.m_kTransitionTip = rb.ReadString();
                enchantData.m_kTransitionName = rb.ReadString();
                enchantData.m_nMaxStack = rb.ReadUShort();
                if (m_nVer >= 9)
                    enchantData.m_nWeaponFlag = rb.ReadUInt();

                m_kMap.TryAdd(index, enchantData);
            }

            OnReadFinished.Invoke();
        }
    }
}
