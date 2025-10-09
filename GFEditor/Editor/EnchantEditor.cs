using GFEditor.Structs.Query;

namespace GFEditor.Editor
{
    public static class EnchantEditor
    {
        private static readonly TranslatedValues m_Translate = TranslateUtils.Json.TranslatedValues;
        private static readonly EnchantQuery m_EnchantList = new(ResetStringList);
        private static Action<int>? m_OnEnchantSelected;
        private static string[] _EnchantStringList = [];
        private static int _SelectedListIndex = 0;
        private static bool _IsOpen = false;

        private static void Initialize()
        {
            if (m_EnchantList.HasValues()) // Avoid loading item each time the editor open...
                return;

            //var translatePath = ConfigUtils.GetPath("Data\\Translate\\T_Item.ini");
            //if (translatePath.FileExist())
            //    m_ItemTranslateQuery.ReadFile(translatePath);

            var filePath = ConfigUtils.GetPath("Data\\DB\\C_Enchant.ini");
            if (filePath.FileExist())
            {
                m_OnEnchantSelected += OnEnchantSelectedCallback;
                m_EnchantList.ReadFile(filePath);
                return;
            }

            GuiNotify.Show(ImGuiToastType.Error, "Item Editor", "Failed to load item list, file probably not found !");
        }

        private static void OnEnchantSelectedCallback(int listIndex)
        {

        }

        public static void DrawContent()
        {
            if (!_IsOpen) return;
            DrawEnchantList();
            DrawEnchantProperties();
        }

        private static void DrawEnchantList()
        {
            if (ImGui.Begin("Enchant list"))
            {
                // Now create the item list window.
                var regionSize = ImGui.GetContentRegionAvail();
                ImGui.SetNextWindowSize(new Vector2(regionSize.X - 1f, regionSize.Y - 40f));
                if (ImGuiUtils.ListBox("##EnchantList", ref _SelectedListIndex, _EnchantStringList))
                    m_OnEnchantSelected?.Invoke(_SelectedListIndex);

                ImGui.Separator();
                if (ImGuiUtils.DoubleButton(m_Translate.AddBtnName, m_Translate.RemoveBtnName, out var add, out var remove))
                {
                    if (add) OnListAdd();
                    if (remove) OnListRemove();
                }
            }
            ImGui.End();
        }

        private static void DrawEnchantProperties()
        {
            if (ImGui.Begin("Enchant editor", ref _IsOpen, ImGuiWindowFlags.AlwaysAutoResize) && _EnchantStringList.Length > 0)
            {
                var version = m_EnchantList.GetVersion();
                var strIndex = _EnchantStringList[_SelectedListIndex].AsUInt();
                var emptyStr = string.Empty;
                if (m_EnchantList.Get(strIndex, out var enchant))
                {
                    ImGuiUtils.Label(m_Translate.HeaderItemIndex + ": " + enchant.m_nId, false);
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

        private static void OnListAdd()
        {
            GuiNotify.Show(ImGuiToastType.Warning, "EnchantEditor", "Add enchant is not implemented yet !");
        }

        private static void OnListRemove()
        {
            GuiNotify.Show(ImGuiToastType.Warning, "EnchantEditor", "Remove enchant is not implemented yet !");
        }

        public static void Dispose()
        {

        }

        private static void ResetStringList()
        {
            _EnchantStringList = m_EnchantList.GetAllValues().Select(e => e.m_nId).ToStringArray();
        }
    }
}
