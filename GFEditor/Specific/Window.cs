namespace GFEditor.Specific
{
    public class Window : IDisposable
    {
        private readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        protected GLFWwindowPtr m_Window;
        private GLFWimage m_ImageIcon;

        public void Initialize(int width, int height, string name)
        {
            if (GLFW.Init() == 0)
                ThrowGLFWError("Failed to initialize GLFW");

            GLFW.WindowHint(GLFW.GLFW_CONTEXT_VERSION_MAJOR, 3);
            GLFW.WindowHint(GLFW.GLFW_CONTEXT_VERSION_MINOR, 2);
            GLFW.WindowHint(GLFW.GLFW_OPENGL_PROFILE, GLFW.GLFW_OPENGL_CORE_PROFILE);  // 3.2+ only
            GLFW.WindowHint(GLFW.GLFW_FOCUSED, 1);    // Make window focused on start
            GLFW.WindowHint(GLFW.GLFW_RESIZABLE, 1);  // Make window resizable

            m_Window = GLFW.CreateWindow(width, height, name, null, null);
            if (m_Window.IsNull)
                ThrowGLFWError("Failed to create GLFW window");

            m_ImageIcon = ImageUtils.CreateIconFromFile("Icon1.png");
            GLFW.SetWindowIcon(m_Window, 1, ref m_ImageIcon);
            OpenGL.SetGLContext(new(new BindingsContext(m_Window)));
            GLFW.MakeContextCurrent(m_Window);
        }

        public GLFWwindowPtr GetWindowPtr()
        {
            return m_Window;
        }

        public bool ShouldClose()
        {
            return GLFW.WindowShouldClose(m_Window) != 0;
        }

        public void PollEvents()
        {
            GLFW.PollEvents();
        }

        public bool IsIconified()
        {
            return GLFW.GetWindowAttrib(m_Window, GLFW.GLFW_ICONIFIED) != 0;
        }

        public void SwapBuffers()
        {
            GLFW.SwapBuffers(m_Window);
        }

        public void Dispose()
        {
            OpenGL.Ptr.Dispose();
            GLFW.DestroyWindow(m_Window);
            unsafe
            {
                if (m_ImageIcon.Pixels != null)
                    StbImage.ImageFree(m_ImageIcon.Pixels);
            }
            GLFW.Terminate();
            GC.SuppressFinalize(this);
        }

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
        internal unsafe class BindingsContext(GLFWwindowPtr window) : HexaGen.Runtime.IGLContext
        {
            private GLFWwindowPtr window = window;

            public nint Handle => (nint)window.Handle;

            public bool IsCurrent => GLFW.GetCurrentContext() == window;

            public void Dispose()
            {
            }

            public nint GetProcAddress(string procName)
            {
                return (nint)GLFW.GetProcAddress(procName);
            }

            public bool IsExtensionSupported(string extensionName)
            {
                return GLFW.ExtensionSupported(extensionName) != 0;
            }

            public void MakeCurrent()
            {
                GLFW.MakeContextCurrent(window);
            }

            public void SwapBuffers()
            {
                GLFW.SwapBuffers(window);
            }

            public void SwapInterval(int interval)
            {
                GLFW.SwapInterval(interval);
            }

            public bool TryGetProcAddress(string procName, out nint procAddress)
            {
                procAddress = (nint)GLFW.GetProcAddress(procName);
                return procAddress != 0;
            }
        }
    }
}
