namespace GFEditor.Utils
{
    public static class OpenGL
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private static GL? m_GL = null;

        public static GL Ptr
        {
            get
            {
                if (m_GL == null)
                    m_Log.Error("OpenGL context is not set !");
                return m_GL!;
            }
        }

        public static void SetGLContext(GL glContext)
        {
            if (glContext == null)
            {
                m_Log.Error("Trying to set null OpenGL context !");
                return;
            }
            m_GL = glContext;
        }
    }
}
