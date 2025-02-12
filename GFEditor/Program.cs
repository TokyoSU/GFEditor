namespace GFEditor
{
    public static class Program
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();

        [STAThread] // Required for Form.
        private static void Main()
        {
            StringConverter.Initialize();
            try
            {
                using var main = new UI_Main();
                main.ShowDialog();
            }
            catch (Exception ex)
            {
                m_Log.Fatal(ex);
            }
        }
    }
}