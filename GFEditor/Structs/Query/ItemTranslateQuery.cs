using GFEditor.Structs.Interface;

namespace GFEditor.Structs.Query
{
    public class ItemTranslateQuery : FixedQuery<IdType, ItemDataTranslated>
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();

        public ItemTranslateQuery() : base("ItemTranslateQuery", 3)
        {
        }

        public override bool Get(IdType index, out ItemDataTranslated result)
        {
            return m_kMap.TryGetValue(index, out result);
        }

        public override IOrderedEnumerable<ItemDataTranslated> GetAllValues()
        {
            return m_kMap.Values.OrderBy(e => e.m_nId);
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
                    m_Log.Warn("Duplicate id {0} found, skipping...", index);
                    continue;
                }

                m_kMap.Add(index, new ItemDataTranslated
                {
                    m_nId = index,
                    m_kName = value[1],
                    m_kTip = value[2]
                });
            }

            GuiNotify.Show(ImGuiToastType.Success, m_queryName, $"Loaded {m_kMap.Count} items translations from {m_fileName}");
        }
    }
}
