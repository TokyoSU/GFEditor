namespace GFEditor.Editor.Window
{
    public class MainWindow
    {
        private static readonly TranslatedValues m_Translate = TranslateUtils.Json.TranslatedValues;
        private readonly OpenFolderDialog m_ClientFolderDialog = new() { AllowMultipleSelection = false };
        private readonly OpenFolderDialog m_ServerFolderDialog = new() { AllowMultipleSelection = false };
        private readonly OpenFolderDialog m_TranslateFolderDialog = new() { AllowMultipleSelection = false };
        private readonly OpenFolderDialog m_IconFolderDialog = new() { AllowMultipleSelection = false };
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
                    if (ImGui.Selectable(m_Translate.FileClientSelectFolder))
                        m_ClientFolderDialog.Show(FolderClientCallback);
                    if (ImGui.Selectable(m_Translate.FileServerSelectFolder))
                        m_ServerFolderDialog.Show(FolderServerCallback);
                    if (ImGui.Selectable(m_Translate.FileTranslateSelectFolder))
                        m_TranslateFolderDialog.Show(FolderTranslateCallback);
                    if (ImGui.Selectable(m_Translate.FileIconSelectFolder))
                        m_IconFolderDialog.Show(FolderIconCallback);
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
            m_ClientFolderDialog.Draw(ImGuiWindowFlags.NoDocking);
            m_ServerFolderDialog.Draw(ImGuiWindowFlags.NoDocking);
            m_TranslateFolderDialog.Draw(ImGuiWindowFlags.NoDocking);
            m_IconFolderDialog.Draw(ImGuiWindowFlags.NoDocking);
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
                0 => ConfigUtils.Configs.Path.Client,
                1 => ConfigUtils.Configs.Path.Server,
                2 => ConfigUtils.Configs.Path.Translate,
                3 => ConfigUtils.Configs.Path.Icons,
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

        private void FolderClientCallback(object? sender, DialogResult result)
        {
            ConfigUtils.Configs.Path.Client = m_ClientFolderDialog.SelectedFolder;
            PrintResult(m_Translate.ClientName, result, 0);
        }

        private void FolderServerCallback(object? sender, DialogResult result)
        {
            ConfigUtils.Configs.Path.Server = m_ServerFolderDialog.SelectedFolder;
            PrintResult(m_Translate.ServerName, result, 1);
        }

        private void FolderTranslateCallback(object? sender, DialogResult result)
        {
            ConfigUtils.Configs.Path.Translate = m_TranslateFolderDialog.SelectedFolder;
            PrintResult(m_Translate.TranslateName, result, 2);
        }

        private void FolderIconCallback(object? sender, DialogResult result)
        {
            ConfigUtils.Configs.Path.Icons = m_IconFolderDialog.SelectedFolder;
            PrintResult(m_Translate.TranslateName, result, 3);
        }

        public void Dispose()
        {
            m_ItemEditor.Dispose();
        }
    }
}
