namespace GFEditor
{
    public static class Program
    {
        private static void InitializeLibraries()
        {
            StringConverter.Initialize();
        }

        private static void LoadAllDatabase()
        {
            // Client/Server

            CSItemDatabase.Load();

            // Translation

            TTextIndexDatabase.Load();

        }

        private static void SaveAllDatabase()
        {
            // Client/Server

            CSItemDatabase.Save();

            // Translation

            TTextIndexDatabase.Save();
        }

        [STAThread]
        private static void Main()
        {
            InitializeLibraries();
            LoadAllDatabase();
            new ItemEditor().ShowDialog(); // TODO: Change with a global panel.
            SaveAllDatabase();
        }
    }
}