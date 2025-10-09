using GFEditor.Structs.Interface;

namespace GFEditor.Structs.Query
{
    public class ItemTranslateQuery : FixedQuery<IdType, ItemDataTranslated>
    {
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
            foreach (var value in listOfStrings)
            {
                if (value == null)
                {
                    GuiNotify.Show(ImGuiToastType.Warning, "ItemTranslateQuery", "Found null value in splitted values, column count: {0}", m_nColumnCount);
                    continue;
                }

                var index = (IdType)value[0].AsULong();
                if (m_kMap.ContainsKey(index))
                {
                    GuiNotify.Show(ImGuiToastType.Warning, "ItemTranslateQuery", "Duplicate item ID found: {0}, skipping.", index);
                    continue;
                }

                m_kMap.Add(index, new ItemDataTranslated
                {
                    m_nId = index,
                    m_kName = value[1],
                    m_kTip = value[2]
                });
            }

            GuiNotify.Show(ImGuiToastType.Success, "ItemTranslateQuery", $"Loaded {m_kMap.Count} item translations from {m_fileName}");
        }
    }
}
