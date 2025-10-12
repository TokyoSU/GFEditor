using GFEditor.Structs.Interface;

namespace GFEditor.Structs.Query
{
    public class EnchantTranslateQuery : FixedQuery<IdType, EnchantDataTranslate>
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();

        public EnchantTranslateQuery() : base("EnchantTranslateQuery", 5)
        {
        }

        public override bool Get(IdType index, out EnchantDataTranslate result)
        {
            return m_kMap.TryGetValue(index, out result);
        }

        public override IOrderedEnumerable<EnchantDataTranslate> GetAllValues()
        {
            return m_kMap.Values.OrderBy(x => x.m_nId);
        }

        protected override void OnFileRead(List<List<string>> listOfStrings)
        {
            for (int rowId = 0; rowId < listOfStrings.Count; rowId++)
            {
                var value = listOfStrings[rowId];
                if (value == null)
                {
                    m_Log.Warn("Found null value in splitted values, row id: {0}", rowId);
                    continue;
                }

                var index = (IdType)value[0].AsUInt();
                if (m_kMap.ContainsKey(index))
                {
                    m_Log.Warn("Duplicate enchant translation id {0} found, skipping...", index);
                    continue;
                }

                m_kMap.Add(index, new EnchantDataTranslate
                {
                    m_nId = index,
                    m_kName = value[1],
                    m_kDescription = value[2],
                    m_kTransitionName = value[3],
                    m_kTransitionDescription = value[4]
                });
            }

            GuiNotify.Show(ImGuiToastType.Success, m_queryName, $"Loaded {m_kMap.Count} enchants translations from {m_fileName}");
        }
    }
}
