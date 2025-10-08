using GFEditor.Structs.Interface;

namespace GFEditor.Structs.Query
{
    public class LevelQuery : BaseQuery<LevelType, LevelData>
    {
        public LevelQuery() : base("LevelQuery")
        {
        }

        public override bool Get(LevelType index, out LevelData result)
        {
            return m_kMap.TryGetValue(index, out result);
        }

        public override IOrderedEnumerable<LevelData> GetAllValues()
        {
            return m_kMap.Values.OrderBy(e => e.m_nLevel);
        }

        protected override void OnFileRead(List<List<string>> listOfStrings)
        {
            foreach (var value in listOfStrings)
            {
                if (value == null)
                {
                    GuiNotify.Show(ImGuiToastType.Warning, "LevelQuery", "Found null value in splitted values, column count: {0}", m_nColumnCount);
                    continue;
                }

                var index = (LevelType)value[0].AsByte();
                if (m_kMap.ContainsKey(index))
                {
                    GuiNotify.Show(ImGuiToastType.Warning, "LevelQuery", "Duplicate level ID found: {0}, skipping.", index);
                    continue;
                }

                m_kMap.Add(index, new LevelData()
                {
                    m_nLevel = index,
                    m_nCharExp = value[1].AsULong(),
                    m_nGuildExp = value[2].AsUInt(),
                    m_nPrestige = value[3].AsUInt(),
                    m_nElfLevel = value[4].AsUInt(),
                    m_nElfReturn = value[5].AsUInt(),
                    m_nMining = value[6].AsUInt(),
                    m_nPlant = value[7].AsUInt(),
                    m_nHunting = value[8].AsUInt(),
                    m_nDecompose = value[9].AsUInt(),
                    m_nSword = value[10].AsUInt(),
                    m_nAxe = value[11].AsUInt(),
                    m_nMace = value[12].AsUInt(),
                    m_nBow = value[13].AsUInt(),
                    m_nGun = value[14].AsUInt(),
                    m_nStaff = value[15].AsUInt(),
                    m_nShield = value[16].AsUInt(),
                    m_nHolyItem = value[17].AsUInt(),
                    m_nFighter = value[18].AsUInt(),
                    m_nHunter = value[19].AsUInt(),
                    m_nCaster = value[20].AsUInt(),
                    m_nAcolyte = value[21].AsUInt(),
                    m_nMoneyExp = value[22].AsUInt(),
                    m_nMonsterExp = value[23].AsUInt(),
                    m_nIsleExp = value[24].AsUInt(),
                    m_nWP = value[25].AsUInt(),
                    m_nRP = value[26].AsUInt(),
                    m_nFrearmExp = value[27].AsUInt(),
                    m_nCannonExp = value[28].AsUInt(),
                    m_nMechExp = value[29].AsUInt(),
                    m_nCrystalKanataExp = value[30].AsUInt(),
                    m_nCrystalkeyExp = value[31].AsUInt(),
                    m_nCrystalEquipExp = value[32].AsUInt(),
                    m_nRebirthFrontScore = value[33].AsUInt(),
                    m_nRebirthRearScore = value[34].AsUInt(),
                    m_nRebirthDiscount = value[35].AsUInt(),
                    m_nRebirthCharExp = value[36].AsULong(),
                    m_nWeaponAwakeAddMin = value[37].AsShort(),
                    m_nWeaponAwakeAddMax = value[38].AsShort(),
                    m_nArmorAwakeAddMin = value[39].AsShort(),
                    m_nArmorAwakeAddMax = value[40].AsShort(),
                    m_nWeaponPotential = value[41].AsUInt(),
                    m_nArmorPotential = value[42].AsUInt(),
                    m_nGas = value[43].AsUInt(),
                    m_nPigment = value[44].AsUInt(),
                    m_nMap = value[45].AsUInt(),
                    m_nSoulCrystal = value[46].AsUInt(),
                    m_TravelExp = value[47].AsUInt(),
                    m_nElftabletExp = value[48].AsUInt(),
                    m_nElftabletLvAdd = value[49].AsUInt(),
                    m_nCarvingOrangeAttack = value[50].AsUInt(),
                    m_nCarvingOrangeRange = value[51].AsUInt(),
                    m_nCarvingOrangeMagic = value[52].AsUInt(),
                    m_nCarvingYellowAttack = value[53].AsUInt(),
                    m_nCarvingYellowRange = value[54].AsUInt(),
                    m_nCarvingYellowMagic = value[55].AsUInt(),
                    m_nCarvingPurpleAttack = value[56].AsUInt(),
                    m_nCarvingPurpleRange = value[57].AsUInt(),
                    m_nCarvingPurpleMagic = value[58].AsUInt(),
                    m_nCarvingRedAttack = value[59].AsUInt(),
                    m_nCarvingRedRange = value[60].AsUInt(),
                    m_nCarvingRedMagic = value[61].AsUInt(),
                    m_nCarvingOrangeDefense = value[62].AsUInt(),
                    m_nCarvingOrangeMagicDefense = value[63].AsUInt(),
                    m_nCarvingYellowDefense = value[64].AsUInt(),
                    m_nCarvingYellowMagicDefense = value[65].AsUInt(),
                    m_nCarvingPurpleDefense = value[66].AsUInt(),
                    m_nCarvingPurpleMagicDefense = value[67].AsUInt(),
                    m_nCarvingRedDefense = value[68].AsUInt(),
                    m_nCarvingRedMagicDefense = value[69].AsUInt(),
                });
            }

            GuiNotify.Show(ImGuiToastType.Success, "LevelQuery", $"Loaded {m_kMap.Count} levels from {m_fileName}");
        }
    }
}
