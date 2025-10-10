namespace GFEditor.Specific
{
    public class Engine : IDisposable
    {
        private readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private readonly Window m_Window = new();

        public void Initialize()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // Register chinese (big5) encoding.
            m_Window.Initialize(1280, 720, "Grand Fantasia Editor");
            EngineLibrary.InitializeImGui(m_Window);
            EngineLibrary.InitializeImGuiNotify();
            AudioDevice.Initialize();
            TranslateUtils.Load();
            ConfigUtils.Load();
            IconClass.Initialize();
        }

        public void Run()
        {
            try
            {
                var io = ImGui.GetIO();
                while (!m_Window.ShouldClose())
                {
                    m_Window.PollEvents();
                    if (m_Window.IsIconified())
                    {
                        ImGuiImplGLFW.Sleep(10);
                        continue;
                    }

                    OpenGL.Ptr.ClearColor(0f, 0f, 0f, 1f);
                    OpenGL.Ptr.Clear(GLClearBufferMask.ColorBufferBit);
                    EngineLibrary.NewFrame();

                    MainWindow.DrawContent();

                    EngineLibrary.Render();
                    m_Window.SwapBuffers();
                }
            }
            catch (Exception ex)
            {
                m_Log.Error(ex);
            }
        }

        public void Dispose()
        {
            ImageChest.Dispose();
            IconItem.Dispose();
            IconClass.Dispose();
            ConfigUtils.Save();
            EngineLibrary.Dispose();
            m_Window.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
