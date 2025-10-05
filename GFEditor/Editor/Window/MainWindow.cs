namespace GFEditor.Editor.Window
{
    public class MainWindow
    {
        private static readonly TranslatedValues m_Translate = TranslateUtils.Json.TranslatedValues;
        private readonly OpenFolderDialog m_GameFolderDialog = new() { AllowMultipleSelection = false };
        private readonly ItemEditor m_ItemEditor = new();
        private readonly UbuntuWindow m_UbuntuWindow = new();

        private void DrawMainBar()
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("Project"))
                {
                    // Edit menu...
                    if (ImGui.Selectable("Save All"))
                    {
                        m_ItemEditor.Save();
                    }
                    ImGui.EndMenu();
                }

                // File menu...
                if (ImGui.BeginMenu(m_Translate.FileBtnName))
                {
                    if (ImGui.Selectable(m_Translate.SelectGameFolder))
                        m_GameFolderDialog.Show(FolderGameCallback);
                    ImGui.EndMenu();
                }

                // View menu...
                if (ImGui.BeginMenu(m_Translate.EditorBar))
                {
                    // Show item editor...
                    if (ImGui.Selectable(m_Translate.ItemEditor))
                    {
                        if (!m_ItemEditor.IsOpen)
                            m_ItemEditor.Show();
                        else
                            m_ItemEditor.Hide();
                    }
                    ImGui.EndMenu();
                }

                // Ubuntu menu...
                if (ImGui.BeginMenu(m_Translate.UbuntuName))
                {
                    if (ImGui.Selectable(m_Translate.Connect))
                    {
                        if (!m_UbuntuWindow.IsOpen)
                        {
                            m_UbuntuWindow.Initialize();
                            m_UbuntuWindow.Show();
                        }
                        else
                        {
                            m_UbuntuWindow.Hide();
                        }
                    }
                    if (ImGui.Selectable("List Directory"))
                        m_UbuntuWindow.ListDirectory("/root/gf_server");
                    ImGui.EndMenu();
                }
                ImGui.EndMainMenuBar();
            }
        }

        private void DrawDialogs()
        {
            m_GameFolderDialog.Draw(ImGuiWindowFlags.NoDocking);
        }

        private void DrawEditor()
        {
            m_ItemEditor.DrawContent();
            m_UbuntuWindow.DrawContent();
        }

        public void DrawContent()
        {
            DrawMainBar();
            DrawEditor();
            DrawDialogs();
        }

        private static string GetFolder(int type)
        {
            return type switch
            {
                0 => ConfigUtils.Configs.Path.Game,
                _ => "Failed to get paths...",
            };
        }

        private static void PrintResult(string forName, DialogResult result, int type)
        {
            var notifyTitle = string.Format(m_Translate.SelectFolderTitleStr, forName.ToLower());
            switch (result)
            {
                case DialogResult.Ok:
                    ImGuiNotify.Insert(new ImGuiToast(ImGuiToastType.Success, notifyTitle, 2000, string.Format(m_Translate.SelectFolderSuccessStr, GetFolder(type))));
                    break;
                case DialogResult.Cancel:
                case DialogResult.No:
                    ImGuiNotify.Insert(new ImGuiToast(ImGuiToastType.Info, notifyTitle, 3000, string.Format(m_Translate.SelectFolderCanceledStr, forName.ToLower())));
                    break;
                case DialogResult.Failed:
                    ImGuiNotify.Insert(new ImGuiToast(ImGuiToastType.Warning, notifyTitle, 5000, string.Format(m_Translate.SelectFolderFailedStr, forName.ToLower())));
                    break;
            }
        }

        private void FolderGameCallback(object? sender, DialogResult result)
        {
            ConfigUtils.Configs.Path.Game = m_GameFolderDialog.SelectedFolder;
            PrintResult(m_Translate.ClientName, result, 0);
        }

        public void Dispose()
        {
            m_ItemEditor.Dispose();
        }
    }
}
