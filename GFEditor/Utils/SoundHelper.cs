namespace GFEditor.Utils
{
    public static class SoundHelper
    {
        /// <summary>
        /// Copy specific sound from the srcFolder to the Constants.AssetSoundPath folder.
        /// </summary>
        /// <param name="database">The item database.</param>
        public static void CopyRequiredUsedSounds()
        {
            var soundList = CSItemDatabase.GetUsedSoundNameList();
            if (soundList == null) return;
            if (soundList.Count <= 0)
            {
                Console.WriteLine($"No used sound name in item database found, failed to copy sound to: {Constants.AssetSoundPath}");
                return;
            }

            // Select GF folder.
            var srcFolder = new FolderBrowserDialog()
            {
                Description = "Selecting grand fantasia sound folder...",
                ShowNewFolderButton = false
            };
            var result = srcFolder.ShowDialog();
            if (result != DialogResult.OK && !string.IsNullOrWhiteSpace(srcFolder.SelectedPath))
                return;

            foreach (var sound in soundList)
            {
                try
                {
                    string fileName = sound + ".wav";
                    string destFilename = Constants.AssetSoundPath + fileName;
                    if (!File.Exists(destFilename))
                        File.Copy(srcFolder.SelectedPath + "\\" + fileName, destFilename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
