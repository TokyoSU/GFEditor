namespace GFEditor.Specific
{
    public class EngineLibrary
    {
        private const string m_ImGuiVersionGlsl = "#version 150";

        public static void InitializeImGui(Window window)
        {
            var guiContext = ImGui.CreateContext();
            ImGui.SetCurrentContext(guiContext);

            var io = ImGui.GetIO();
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableGamepad;
            io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;

            unsafe
            {
                io.Fonts.AddFontFromFileTTF("fonts\\unicode.ttf", 14.0f, null, io.Fonts.GetGlyphRangesDefault());
            }

            ImGuiImplGLFW.SetCurrentContext(guiContext);
            if (!ImGuiImplGLFW.InitForOpenGL(Unsafe.BitCast<GLFWwindowPtr, Hexa.NET.ImGui.Backends.GLFW.GLFWwindowPtr>(window.GetWindowPtr()), true))
                throw new Exception("Failed to associate ImGui and Glfw !");

            ImGuiImplOpenGL3.SetCurrentContext(guiContext);
            if (!ImGuiImplOpenGL3.Init(m_ImGuiVersionGlsl))
                throw new Exception("Failed to associate ImGui and OpenGL3 !");
        }

        public static void InitializeImGuiNotify()
        {
            var io = ImGui.GetIO();
            ImGuiNotify.Setup();
            ImGuiNotify.EnableRenderOutsideMainWindow(io.ConfigFlags.HasFlag(ImGuiConfigFlags.ViewportsEnable));
        }

        public static void NewFrame()
        {
            ImGuiImplOpenGL3.NewFrame();
            ImGuiImplGLFW.NewFrame();
            ImGui.NewFrame();
            ImGui.DockSpaceOverViewport();
        }

        public static void Render()
        {
            ImGuiNotify.RenderNotifications();
            ImGui.EndFrame();
            ImGui.Render();
            ImGuiImplOpenGL3.RenderDrawData(ImGui.GetDrawData());

            var io = ImGui.GetIO();
            if (io.ConfigFlags.HasFlag(ImGuiConfigFlags.ViewportsEnable))
            {
                var backupCurrentContext = GLFW.GetCurrentContext();
                ImGui.UpdatePlatformWindows();
                ImGui.RenderPlatformWindowsDefault();
                GLFW.MakeContextCurrent(backupCurrentContext);
            }
        }

        public static void Dispose()
        {
            ImGuiImplOpenGL3.Shutdown();
            ImGuiImplGLFW.Shutdown();
            ImGui.DestroyContext();
        }
    }
}
