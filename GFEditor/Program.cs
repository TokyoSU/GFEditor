namespace GFEditor
{
    public static class Program
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();

        [STAThread] // Required for Form.
        private static void Main()
        {
            StringConverter.Initialize();
            TEditorTranslate.Load();
            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                //Application.SetColorMode(SystemColorMode.Classic); // Classic or Dark ...
                Application.Run(new UI_Main());
            }
            catch (Exception ex)
            {
                m_Log.Fatal(ex);
            }
        }
    }
}