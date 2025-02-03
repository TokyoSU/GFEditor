using GFEditor.Database;
using GFEditor.Editor;
using System;

namespace GFEditor
{
    public class Program
    {
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

        [STAThread] // Required cause Form dont support multithreading except through the BackgroundWorker.
        private static void Main(string[] args)
        {
            Console.Title = "GFEditor";
            LoadAllDatabase();
            new ItemEditor().ShowDialog(); // TODO: Change with a global panel.
            SaveAllDatabase();
        }
    }
}
