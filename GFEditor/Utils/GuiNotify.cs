namespace GFEditor.Utils
{
    public class GuiNotify
    {
        private static readonly Logger m_Log = LogManager.GetLogger("DefaultLogger");

        public static void Show(ImGuiToastType type, string message)
        {
            ImGuiNotify.Insert(new ImGuiToast(type, message));
            switch (type)
            {
                case ImGuiToastType.Error:
                    m_Log.Error(message);
                    break;
                case ImGuiToastType.Warning:
                    m_Log.Warn(message);
                    break;
                case ImGuiToastType.Info:
                    m_Log.Info(message);
                    break;
                case ImGuiToastType.Success:
                    m_Log.Info(message);
                    break;
                default:
                    m_Log.Debug(message);
                    break;
            }
        }

        public static void Show(ImGuiToastType type, string message, int timer)
        {
            ImGuiNotify.Insert(new ImGuiToast(type, message, timer * 320));
            switch (type)
            {
                case ImGuiToastType.Error:
                    m_Log.Error(message);
                    break;
                case ImGuiToastType.Warning:
                    m_Log.Warn(message);
                    break;
                case ImGuiToastType.Info:
                    m_Log.Info(message);
                    break;
                case ImGuiToastType.Success:
                    m_Log.Info(message);
                    break;
                default:
                    m_Log.Debug(message);
                    break;
            }
        }

        public static void Show(ImGuiToastType type, string title, string contents)
        {
            ImGuiNotify.Insert(new ImGuiToast(type, title, contents));
            switch (type)
            {
                case ImGuiToastType.Error:
                    m_Log.Error($"[{title}]: {contents}");
                    break;
                case ImGuiToastType.Warning:
                    m_Log.Warn($"[{title}]: {contents}");
                    break;
                case ImGuiToastType.Info:
                    m_Log.Info($"[{title}]: {contents}");
                    break;
                case ImGuiToastType.Success:
                    m_Log.Info($"[{title}]: {contents}");
                    break;
                default:
                    m_Log.Debug($"[{title}]: {contents}");
                    break;
            }
        }

        public static void Show(ImGuiToastType type, string title, string contents, params object?[] args)
        {
            ImGuiNotify.Insert(new ImGuiToast(type, title, contents, args));
            switch (type)
            {
                case ImGuiToastType.Error:
                    m_Log.Error($"[{title}]: {string.Format(contents, args)}");
                    break;
                case ImGuiToastType.Warning:
                    m_Log.Warn($"[{title}]: {string.Format(contents, args)}");
                    break;
                case ImGuiToastType.Info:
                    m_Log.Info($"[{title}]: {string.Format(contents, args)}");
                    break;
                case ImGuiToastType.Success:
                    m_Log.Info($"[{title}]: {string.Format(contents, args)}");
                    break;
                default:
                    m_Log.Debug($"[{title}]: {string.Format(contents, args)}");
                    break;
            }
        }

        public static void Show(ImGuiToastType type, string title, string contents, int timer, params object?[] args)
        {
            ImGuiNotify.Insert(new ImGuiToast(type, title, timer * 320, contents, args));
            switch (type)
            {
                case ImGuiToastType.Error:
                    m_Log.Error($"[{title}]: {string.Format(contents, args)}");
                    break;
                case ImGuiToastType.Warning:
                    m_Log.Warn($"[{title}]: {string.Format(contents, args)}");
                    break;
                case ImGuiToastType.Info:
                    m_Log.Info($"[{title}]: {string.Format(contents, args)}");
                    break;
                case ImGuiToastType.Success:
                    m_Log.Info($"[{title}]: {string.Format(contents, args)}");
                    break;
                default:
                    m_Log.Debug($"[{title}]: {string.Format(contents, args)}");
                    break;
            }
        }
    }
}
