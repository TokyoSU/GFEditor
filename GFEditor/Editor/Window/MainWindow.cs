namespace GFEditor.Editor.Window
{
    public static class MainWindow
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private static readonly TranslatedValues m_Translate = TranslateUtils.Json.TranslatedValues;
        private static readonly OpenFolderDialog m_GameFolderDialog = new() { AllowMultipleSelection = false };

        private static void DrawMainBar()
        {
            if (ImGui.BeginMainMenuBar())
            {
                // File menu...
                if (ImGui.BeginMenu(m_Translate.FileBtnName))
                {
                    // Select game folder...
                    if (ImGui.Selectable(m_Translate.SelectGameFolder))
                    {
                        m_GameFolderDialog.Show((sender, result) => {
                            if (m_GameFolderDialog.SelectedFolder == null || result != DialogResult.Ok)
                            {
                                m_Log.Error("FolderGameCallback: Selected folder is null or dialog result is not OK.");
                                return;
                            }
                            ConfigUtils.SetGamePath(m_GameFolderDialog.SelectedFolder);
                            GuiNotify.Show(ImGuiToastType.Success, "Game folder set to: {0}", m_GameFolderDialog.SelectedFolder);
                        });
                    }

                    if (ImGui.Selectable("Save All"))
                    {
                        BackupUtils.MakeBackup();
                        ItemEditor.Save();
                    }

                    // Make backup...
                    if (ImGui.Selectable(m_Translate.BackupGameData))
                        BackupUtils.MakeBackup();

                    ImGui.EndMenu();
                }

                // View menu...
                if (ImGui.BeginMenu(m_Translate.EditorBar))
                {
                    // Show item editor...
                    if (ImGui.Selectable(m_Translate.ItemEditor))
                        ItemEditor.Show();
                    if (ImGui.Selectable("Enchants"))
                        EnchantEditor.Show();
                    //if (ImGui.Selectable("Level"))
                    //    LevelEditor.Show();
                    ImGui.EndMenu();
                }

                // Ubuntu menu...
                if (ImGui.BeginMenu(m_Translate.UbuntuName))
                {
                    if (ImGui.Selectable(m_Translate.Connect))
                        UbuntuWindow.Show();
                    if (ImGui.Selectable("List Directory"))
                        UbuntuWindow.ListDirectory("/root/gf_server");
                    ImGui.EndMenu();
                }
                ImGui.EndMainMenuBar();
            }
        }

        private static void DrawEditor()
        {
            ItemEditor.DrawContent();
            EnchantEditor.DrawContent();
            UbuntuWindow.DrawContent();
        }

        public static void DrawContent()
        {
            DrawMainBar();
            DrawEditor();
            m_GameFolderDialog.Draw(ImGuiWindowFlags.NoDocking);
        }

        public static void Dispose()
        {
            ItemEditor.Dispose();
            EnchantEditor.Dispose();
        }
    }
}
