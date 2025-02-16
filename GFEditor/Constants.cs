namespace GFEditor
{
    public class ConstantFromJson
    {
        [JsonProperty]
        public string ClientPath = string.Empty;
        [JsonProperty]
        public string ServerPath = string.Empty; // NOTE: Make it use the real server through network ?
        [JsonProperty]
        public string TranslatePath = string.Empty;
        [JsonProperty]
        public bool TranslateAutoOnLoad;
    }

    public static class Constants
    {
        // Parameters


        // Client/Server Path

        public static ConstantFromJson Parameters = new();

        // Editor Path

        public static string AssetItemPath = "Assets/Items/";
        public static string AssetChestPath = "Assets/DropChest/";
        public static string AssetDataPath = "Assets/Data/";
        public static string AssetSoundPath = "Assets/Sounds/";

        // Editor Destination Path

        // Database Path

        public static string AssetJCItemPath = AssetDataPath + "C_Item.json";
        public static string AssetJCColor = AssetDataPath + "C_Color.json";

        public static string AssetJTItem = AssetDataPath + "T_Item.json";
        public static string AssetJTTextIndex = AssetDataPath + "T_TextIndex.json";

        public static string AssetJEditorPath = AssetDataPath + "Editor.json";

        public static void Load()
        {
            if (File.Exists(AssetJEditorPath)) // Load through json if exist.
            {
                Parameters = JsonConvert.DeserializeObject<ConstantFromJson>(File.ReadAllText(AssetJEditorPath)) ?? throw new Exception("Failed to read json: " + AssetJEditorPath + ", something went wrong !");
            }
            else
            {
                SelectOriginalClientFolder();
                SelectOriginalServerFolder();
                SelectOriginalTranslateFolder();
            }
        }

        public static void Save()
        {
            SaveHelper.SaveJson(AssetJEditorPath, Parameters);
        }

        public static void SelectOriginalClientFolder()
        {
            var folder = new FolderBrowserDialog()
            {
                Description = "Selecting ini client folder (C)...",
                ShowNewFolderButton = false
            };
            var result = folder.ShowDialog();
            if (result != DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                throw new Exception("Failed to select ini client folder !");
            Parameters.ClientPath = folder.SelectedPath;
        }

        public static void SelectOriginalServerFolder()
        {
            var folder = new FolderBrowserDialog()
            {
                Description = "Selecting ini server folder (S)...",
                ShowNewFolderButton = false
            };
            var result = folder.ShowDialog();
            if (result != DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                throw new Exception("Failed to select ini server folder !");
            if (folder.SelectedPath.Equals(Parameters.ClientPath))
                throw new Exception("Failed to select ini server folder, same folder as client, please select the server ini folder instead !");
            Parameters.ServerPath = folder.SelectedPath;
        }

        public static void SelectOriginalTranslateFolder()
        {
            var folder = new FolderBrowserDialog()
            {
                Description = "Selecting ini translate folder (T)...",
                ShowNewFolderButton = false
            };
            var result = folder.ShowDialog();
            if (result != DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                throw new Exception("Failed to select ini translate folder !");
            Parameters.TranslatePath = folder.SelectedPath;
        }
    }
}
