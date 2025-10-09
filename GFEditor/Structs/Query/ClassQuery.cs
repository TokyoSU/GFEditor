using GFEditor.Structs.Interface;

namespace GFEditor.Structs.Query
{
    public class ClassQuery(Action onReadFinished) : BaseQuery<LevelType, ClassData>("ClassQuery")
    {
        private readonly Action OnReadFinished = onReadFinished;

        public override bool Get(LevelType index, out ClassData result)
        {
            return m_kMap.TryGetValue(index, out result);
        }

        public override IOrderedEnumerable<ClassData> GetAllValues()
        {
            return m_kMap.Values.OrderBy(e => e.m_nLevel);
        }

        protected override void OnFileRead(List<List<string>> listOfStrings)
        {
            foreach (var value in listOfStrings)
            {
                if (value == null)
                {
                    GuiNotify.Show(ImGuiToastType.Warning, "ClassQuery", "Found null value in splitted values, column count: {0}", m_nColumnCount);
                    continue;
                }

                var index = (LevelType)value[0].AsByte();
                if (m_kMap.ContainsKey(index))
                {
                    GuiNotify.Show(ImGuiToastType.Warning, "ClassQuery", "Duplicate class ID found: {0}, skipping.", index);
                    continue;
                }

                m_kMap.Add(index, new ClassData()
                {
                    m_nLevel = index,
                    m_kName = value[1],
                    m_nMaxHP = value[2].AsUInt(),
                    m_nMaxMP = value[3].AsUInt(),
                    m_nStr = (BaseAttrType)value[4].AsByte(),
                    m_nCon = (BaseAttrType)value[5].AsByte(),
                    m_nInt = (BaseAttrType)value[6].AsByte(),
                    m_nVol = (BaseAttrType)value[7].AsByte(),
                    m_nDex = (BaseAttrType)value[8].AsByte(),
                    m_nPhysicoDamage = value[9].AsUInt(),
                    m_nRangeDamage = value[10].AsUInt(),
                    m_nMagicDamage = value[11].AsUInt(),
                    m_nPhysicoDefence = value[12].AsUInt(),
                    m_nMagicDefence = value[13].AsUInt(),
                    m_nDodgeRate = value[14].AsUInt(),
                    m_kBaseSpells =
                    [
                        value[15].AsUInt(),
                        value[16].AsUInt(),
                        value[17].AsUInt(),
                        value[18].AsUInt(),
                        value[19].AsUInt(),
                        value[20].AsUInt()
                    ]
                });
            }

            GuiNotify.Show(ImGuiToastType.Success, "ClassQuery", "Loaded {0} class entries.", m_kMap.Count);
            OnReadFinished.Invoke();
        }
    }
}
