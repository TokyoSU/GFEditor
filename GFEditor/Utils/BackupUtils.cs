namespace GFEditor.Utils
{
    public static class BackupUtils
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();

        public static void MakeBackup()
        {
            var fromPath = ConfigUtils.GetPath("Data\\DB\\");
            var toPath = ConfigUtils.GetRelativePath("Backups\\");
            var toPathName = toPath + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            if (fromPath.FolderExist() && toPath.FolderExist())
            {
                if (Directory.CreateDirectory(toPathName).Exists)
                {
                    Directory.EnumerateFiles(fromPath, "*.*", SearchOption.AllDirectories).AsParallel().ForAll(filepath =>
                    {
                        var fileName = Path.GetFileName(filepath);
                        var newpath = Path.Combine(toPathName, fileName);
                        try
                        {
                            File.Copy(filepath, newpath, true);
                        }
                        catch (Exception ex)
                        {
                            m_Log.Error(ex, $"MakeBackup: Failed to backup file: {filepath} to: {newpath}.");
                        }
                    });
                }
                else
                {
                    m_Log.Error($"MakeBackup: Failed to create backup folder at: {toPathName}");
                }
            }
            else
            {
                m_Log.Error($"MakeBackup: Source({fromPath}) or/and Destination({toPath}) folder doesn't exist!");
            }
        }
    }
}
