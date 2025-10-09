using GFEditor.Structs.Query;

namespace GFEditor.Editor
{
    public static class ItemEditor
    {
        private static readonly TranslatedValues m_Translate = TranslateUtils.Json.TranslatedValues;
        private static readonly ItemQuery m_ItemList = new(ResetStringList);
        private static readonly ItemTranslateQuery m_ItemTranslateQuery = new();
        private static Action<int>? m_OnItemSelected;
        private static string[] _ItemsStringList = [];
        private static int _SelectedListIndex = 0;
        private static bool _IsOpen = false;

        private static void Initialize()
        {
            if (m_ItemList.HasValues()) // Avoid loading item each time the editor open...
                return;

            var translatePath = ConfigUtils.GetPath("Data\\Translate\\T_Item.ini");
            if (translatePath.FileExist())
                m_ItemTranslateQuery.ReadFile(translatePath);

            var filePath = ConfigUtils.GetPath("Data\\DB\\C_Item.ini");
            if (filePath.FileExist())
            {
                m_OnItemSelected += OnItemSelectedCallback;
                m_ItemList.ReadFile(filePath);
                return;
            }

            GuiNotify.Show(ImGuiToastType.Error, "Item Editor", "Failed to load item list, file probably not found !");
        }

        private static void OnItemSelectedCallback(int listIndex)
        {
            // Initialize value when it's selected !
            var strIndex = _ItemsStringList[_SelectedListIndex].AsUInt();
            if (m_ItemList.Get(strIndex, out var item))
            {
                Constants.TimeLimitTypeIndex = (int)item.m_nLimitType;
                Constants.EquipTypeIndex = (int)item.m_eEquipType;
                Constants.ItemTypeIndex = (int)item.m_eItemType;
                Constants.QualityIndex = (int)item.m_eItemQuality;
                Constants.AlignementIndex = (int)item.m_eRestrictAlign;
                Constants.AttributeIndex = (int)item.m_eAttribute;
                Constants.PriceIndex = (int)item.m_nShopPriceType;
                Constants.SpecialIndex = (int)item.m_eSpecialType;
                Constants.EnchantTypeIndex = (int)item.m_eEnchantType;
                Constants.EnchantTimeTypeIndex = (int)item.m_eEnchantTimeType;
                Constants.AuctionTypeIndex = (int)item.m_eAuctionType;
                Constants.DropTypeIndex = (int)GetChestTypeByName(item.m_nDropFilename);
            }
        }

        public static void DrawContent()
        {
            if (!_IsOpen) return;
            DrawItemList();
            DrawItemProperties();
        }

        private static void DrawItemList()
        {
            if (ImGui.Begin(m_Translate.ItemListName, ImGuiWindowFlags.AlwaysAutoResize))
            {
                // Now create the item list window.
                var regionSize = ImGui.GetContentRegionAvail();
                ImGui.SetNextWindowSize(new Vector2(regionSize.X - 1f, regionSize.Y - 40f));
                if (ImGuiUtils.ListBox("##ItemList", ref _SelectedListIndex, _ItemsStringList))
                    m_OnItemSelected?.Invoke(_SelectedListIndex);

                ImGui.Separator();
                if (ImGuiUtils.DoubleButton(m_Translate.AddBtnName, m_Translate.RemoveBtnName, out var add, out var remove))
                {
                    if (add) OnListAdd();
                    if (remove) OnListRemove();
                }
            }
            ImGui.End();
        }

        private static void DrawItemProperties()
        {
            if (ImGui.Begin(m_Translate.ItemEditorName, ref _IsOpen, ImGuiWindowFlags.AlwaysAutoResize) && _ItemsStringList.Length > 0)
            {
                var version = m_ItemList.GetVersion();
                var strIndex = _ItemsStringList[_SelectedListIndex].AsUInt();
                if (m_ItemList.Get(strIndex, out var item))
                {
                    m_ItemTranslateQuery.Get(strIndex, out var itemTranslate);
                    item.DrawProperties(m_Translate, itemTranslate, version);
                }
            }
            ImGui.End();
        }

        public static void Show()
        {
            if (!_IsOpen)
            {
                Initialize();
                _IsOpen = true;
            }
            else
            {
                Dispose();
                _IsOpen = false;
            }
        }

        private static void ResetStringList()
        {
            _ItemsStringList = m_ItemList.GetAllValues().Select(e => e.m_nId).ToStringArray();
        }

        private static void OnListAdd()
        {
            GuiNotify.Show(ImGuiToastType.Warning, "ItemEditor", "Add item is not implemented yet !");
        }

        private static void OnListRemove()
        {
            GuiNotify.Show(ImGuiToastType.Warning, "ItemEditor", "Remove item is not implemented yet !");
        }

        private static EChestType GetChestTypeByName(string name)
        {
            return name switch
            {
                "G00000" => EChestType.None,
                "G00001" => EChestType.Equipment,
                "G00002" => EChestType.Quest,
                "G00003" => EChestType.Basic,
                "G00004" => EChestType.Cursed,
                "G00005" => EChestType.Special,
                "G00006" => EChestType.Green,
                "G00007" => EChestType.Legendary,
                "G00008" => EChestType.Blue,
                "G00009" => EChestType.EquipmentGlowing,
                "G00010" => EChestType.GreenGlowing,
                _ => EChestType.None,
            };
        }

        public static void Dispose()
        {
            ImageChest.Dispose();
            IconItem.Dispose();
            m_OnItemSelected = null;
            _ItemsStringList = [];
            _SelectedListIndex = 0;
        }

        public static void Save()
        {
            var str = new StringBuilder();
            str.AppendLine($"|{m_ItemList.GetVersionStr()}|{m_ItemList.GetColumnCount()}|");
            foreach (var item in m_ItemList.GetAllValues())
            {
                str.AppendLine(item.GetString(m_ItemList.GetVersion()));
            }

            try
            {
                File.WriteAllText(ConfigUtils.GetPath("Data\\DB\\C_Item.ini"), str.ToString(), Encoding.GetEncoding("Big5"));
                File.WriteAllText(ConfigUtils.GetPath("Data\\DB\\S_Item.ini"), str.ToString(), Encoding.GetEncoding("Big5"));
                GuiNotify.Show(ImGuiToastType.Success, "Item Editor", "C/S_Item saved successfully !");
            }
            catch (Exception ex)
            {
                GuiNotify.Show(ImGuiToastType.Error, "Item Editor", "Failed to save C/S_Item: {0}", ex.Message);
            }
        }
    }
}
