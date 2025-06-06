﻿namespace GFEditor.Renderer
{
    public class RenderGL : IDisposable
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private const string m_ImGuiVersionGlsl = "#version 150";
        private GL? GL;
        private GLFWwindowPtr m_Window;
        private GLFWimage m_ImageIcon;
        private readonly MainWindow m_mainWindow = new();
        private bool m_Failed = false;

        private void ThrowGLFWError(string message)
        {
            unsafe
            {
                byte[] messages = new byte[256];
                fixed (byte* msg = messages)
                {
                    int code = GLFW.GetError(&msg);
                    string result = new((sbyte*)msg);
                    throw new Exception(string.Format("[GLFW] {0}, Code: {1}, ErrorMessage: {2}", message, code, result));
                }
            }
        }

        private void InitGlfw()
        {
            if (GLFW.Init() == 0)
                ThrowGLFWError("Failed to initialize GLFW");
            GLFW.WindowHint(GLFW.GLFW_CONTEXT_VERSION_MAJOR, 3);
            GLFW.WindowHint(GLFW.GLFW_CONTEXT_VERSION_MINOR, 2);
            GLFW.WindowHint(GLFW.GLFW_OPENGL_PROFILE, GLFW.GLFW_OPENGL_CORE_PROFILE);  // 3.2+ only
            GLFW.WindowHint(GLFW.GLFW_FOCUSED, 1);    // Make window focused on start
            GLFW.WindowHint(GLFW.GLFW_RESIZABLE, 1);  // Make window resizable
            m_Window = GLFW.CreateWindow(1280, 720, "Grand Fantasia Editor", null, null);
            if (m_Window.IsNull)
                ThrowGLFWError("Failed to create GLFW window");
            m_ImageIcon = ImageUtils.CreateIconFromFile("Icon1.png");
            GLFW.SetWindowIcon(m_Window, 1, ref m_ImageIcon);
            GLFW.MakeContextCurrent(m_Window);
        }

        private void InitImGui()
        {
            var guiContext = ImGui.CreateContext();
            ImGui.SetCurrentContext(guiContext);

            var io = ImGui.GetIO();
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;     // Enable Keyboard Controls
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableGamepad;      // Enable Gamepad Controls
            io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;         // Enable Docking
            //io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;       // Enable Multi-Viewport / Platform Windows
            //io.ConfigViewportsNoAutoMerge = false;
            //io.ConfigViewportsNoTaskBarIcon = false;

            unsafe
            {
                io.Fonts.AddFontFromFileTTF("fonts\\unicode.ttf", 14.0f, null, io.Fonts.GetGlyphRangesChineseFull());
                if (!io.Fonts.Build())
                    m_Log.Warn("Failed to build normal and chinese fonts !");
            }

            ImGuiImplGLFW.SetCurrentContext(guiContext);
            if (!ImGuiImplGLFW.InitForOpenGL(Unsafe.BitCast<GLFWwindowPtr, Hexa.NET.ImGui.Backends.GLFW.GLFWwindowPtr>(m_Window), true))
                throw new Exception("Failed to associate ImGui and Glfw !");

            ImGuiImplOpenGL3.SetCurrentContext(guiContext);
            if (!ImGuiImplOpenGL3.Init(m_ImGuiVersionGlsl))
                throw new Exception("Failed to associate ImGui and OpenGL3 !");

            GL = new(new BindingsContext(m_Window));
            if (GL == null)
                throw new Exception("Failed to create GL class !");
            TextureUtils.SetGLContext(GL);
        }

        private static void InitImGuiNotify()
        {
            var io = ImGui.GetIO();
            ImGuiNotify.Setup();
            ImGuiNotify.EnableRenderOutsideMainWindow(io.ConfigFlags.HasFlag(ImGuiConfigFlags.ViewportsEnable));
        }

        public void Initialize()
        {
            try
            {
                // Register chinese (big5) encoding.
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                // Initialize window and renderer
                InitGlfw();
                InitImGui();
                InitImGuiNotify();
            }
            catch (Exception ex)
            {
                m_Log.Error(ex);
                m_Failed = true;
            }

            // Initialize other thinks...
            TranslateUtils.Load();
            ConfigUtils.Load();
        }

        public void Run()
        {
            if (m_Failed || GL == null) return;

            try
            {
                var io = ImGui.GetIO();
                while (GLFW.WindowShouldClose(m_Window) == 0)
                {
                    // Poll for and process events
                    GLFW.PollEvents();

                    if (GLFW.GetWindowAttrib(m_Window, GLFW.GLFW_ICONIFIED) != 0)
                    {
                        ImGuiImplGLFW.Sleep(10);
                        continue;
                    }

                    GL.ClearColor(0f, 0f, 0f, 1f);
                    GL.Clear(GLClearBufferMask.ColorBufferBit);

                    ImGuiImplOpenGL3.NewFrame();
                    ImGuiImplGLFW.NewFrame();
                    ImGui.NewFrame();
                    ImGui.DockSpaceOverViewport();

                    m_mainWindow.DrawContent();
                    ImGuiNotify.RenderNotifications();

                    ImGui.Render();
                    ImGui.EndFrame();
                    ImGuiImplOpenGL3.RenderDrawData(ImGui.GetDrawData());

                    if (io.ConfigFlags.HasFlag(ImGuiConfigFlags.ViewportsEnable))
                    {
                        ImGui.UpdatePlatformWindows();
                        ImGui.RenderPlatformWindowsDefault();
                    }

                    // Swap front and back buffers (double buffering)
                    GLFW.SwapBuffers(m_Window);
                }
            }
            catch (Exception ex)
            {
                m_Log.Error(ex);
            }
        }

        public void Dispose()
        {
            m_mainWindow.Dispose();
            ImGuiImplOpenGL3.Shutdown();
            ImGuiImplGLFW.Shutdown();
            ImGui.DestroyContext();
            GL?.Dispose();
            unsafe
            {
                if (m_ImageIcon.Pixels != null)
                    StbImage.ImageFree(m_ImageIcon.Pixels);
            }
            GLFW.DestroyWindow(m_Window);
            GLFW.Terminate();
            // Make sure to save the configs.
            ConfigUtils.Save();
            GC.SuppressFinalize(this);
        }
    }
}
