using GFEditor.Structs.Query;

namespace GFEditor.Editor
{
    public static class EnchantEditor
    {
        private static readonly EditorTranslate m_Translate = TranslateUtils.Json.TranslatedValues;
        private static readonly EnchantQuery m_EnchantList = new(ResetStringList);
        private static readonly EnchantTranslateQuery m_EnchantTranslateList = new();
        private static Action<int>? m_OnEnchantSelected;
        private static string[] _EnchantStringList = [];
        private static int _SelectedListIndex = 0;
        private static bool _IsOpen = false;

        private static void Initialize()
        {
            if (m_EnchantList.HasValues()) // Avoid loading item each time the editor open...
                return;

            var translatePath = ConfigUtils.GetPath("Data\\Translate\\T_Enchant.ini");
            if (translatePath.FileExist())
                m_EnchantTranslateList.ReadFile(translatePath);

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
            var strIndex = _EnchantStringList[_SelectedListIndex].AsUInt();
            if (m_EnchantList.Get(strIndex, out var enchant))
            {
                Constants.EnchantCategoryIndex = (int)enchant.m_eEnchantCategory;
                Constants.EnchantType2Index = (int)enchant.m_eEnchantType;
                Constants.EnchantTransitionCategoryIndex = (int)enchant.m_eTransitionEnchantCategory;
                Constants.EnchantTransitionType = (int)enchant.m_eTransitionEnchantType;
            }
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
                if (m_EnchantList.Get(strIndex, out var enchant))
                {
                    m_EnchantTranslateList.Get(strIndex, out var enchantT);
                    enchant.DrawParameters(m_Translate, enchantT, version);
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
            IconSkill.Dispose();
        }

        private static void ResetStringList()
        {
            _EnchantStringList = m_EnchantList.GetAllValues().Select(e => e.m_nId).ToStringArray();
        }

        public static void Save()
        {
            if (!m_EnchantList.IsLoaded()) return;
            var str = new StringBuilder();
            str.AppendLine($"|{m_EnchantList.GetVersionStr()}|{m_EnchantList.GetColumnCount()}|");
            foreach (var enchant in m_EnchantList.GetAllValues())
            {
                str.AppendLine(enchant.GetString(m_EnchantList.GetVersion()));
            }

            try
            {
                File.WriteAllText(ConfigUtils.GetPath("Data\\DB\\C_Enchant.ini"), str.ToString(), Encoding.GetEncoding("Big5"));
                File.WriteAllText(ConfigUtils.GetPath("Data\\DB\\S_Enchant.ini"), str.ToString(), Encoding.GetEncoding("Big5"));
                GuiNotify.Show(ImGuiToastType.Success, "Enchant Editor", "C/S_Enchant saved successfully !");
            }
            catch (Exception ex)
            {
                GuiNotify.Show(ImGuiToastType.Error, "Enchant Editor", "Failed to save C/S_Enchant: {0}", ex.Message);
            }
        }
    }
}
