namespace GFEditor.Editor.Window
{
    public static class UbuntuWindow
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly EditorTranslate m_Translate = TranslateUtils.Json.TranslatedValues;
        private static readonly CConfigUbuntu m_Ubuntu = ConfigUtils.Configs.Ubuntu;
        private static SessionOptions SessionOptions
        {
            get
            {
                var sessionOptions = new SessionOptions()
                {
                    Protocol = Protocol.Sftp,
                    UserName = m_Username,
                    Password = m_Password,
                    PortNumber = m_Port,
                    HostName = m_Hostname,
                    SshHostKeyFingerprint = m_Hostkey,
                    Timeout = TimeSpan.FromMilliseconds(100),
                    FtpMode = FtpMode.Active,
                    FtpSecure = FtpSecure.None
                };
                sessionOptions.AddRawSettings("SftpServer", "sudo%20/usr/lib/openssh/sftp-server");
                return sessionOptions;
            }
        }
        private static string m_Hostname = string.Empty;
        private static string m_Hostkey = string.Empty;
        private static string m_Username = string.Empty;
        private static string m_Password = string.Empty;
        private static int m_Port = 0;
        private static bool m_Shown = false;
        public static bool IsOpen => m_Shown;
        public static void Show()
        {
            if (!m_Shown)
            {
                Initialize();
                m_Shown = true;
            }
            else
            {
                m_Shown = false;
            }
        }

        public static void Initialize()
        {
            if (m_Ubuntu.Host.IsValid()) m_Hostname = m_Ubuntu.Host;
            if (m_Ubuntu.HostKey.IsValid()) m_Hostkey = m_Ubuntu.HostKey;
            if (m_Ubuntu.Username.IsValid()) m_Username = m_Ubuntu.Username;
            if (m_Ubuntu.Password.IsValid()) m_Password = m_Ubuntu.Password;
            if (m_Ubuntu.Port != 0) m_Port = m_Ubuntu.Port;
        }

        private static void UpdateConfig()
        {
            // Also handle if the host has changed values...
            if (!m_Ubuntu.Host.IsValid() || m_Ubuntu.Host != m_Hostname) m_Ubuntu.Host = m_Hostname;
            if (!m_Ubuntu.HostKey.IsValid() || m_Ubuntu.HostKey != m_Hostkey) m_Ubuntu.HostKey = m_Hostkey;
            if (!m_Ubuntu.Username.IsValid() || m_Ubuntu.Username != m_Username) m_Ubuntu.Username = m_Username;
            if (!m_Ubuntu.Password.IsValid() || m_Ubuntu.Password != m_Password) m_Ubuntu.Password = m_Password;
            if (m_Ubuntu.Port == 0 || m_Ubuntu.Port != m_Port) m_Ubuntu.Port = m_Port;
        }

        public static void ListDirectory(string localPath)
        {
            UpdateConfig();
            Task.Run(() =>
            {
                using var session = new Session();
                session.Open(SessionOptions);
                if (session.Opened)
                {
                    var result = session.ListDirectory(localPath);
                    foreach (var file in result.Files)
                    {
                        Log.Info("File: {0}, Size: {1}, IsDirectory: {2}", file.Name, file.Length, file.IsDirectory);
                    }

                    /*var result = session.PutFilesToDirectory(localPath, removePath, null, false);
                    result.Check();

                    if (result.IsSuccess)
                    {
                        Log.Info("Successfully transferred files from {0} to {1}", localPath, removePath);
                        foreach (var msg in result.Transfers)
                        {
                            Log.Info("Transfered file: {0}", msg.FileName);
                        }
                    }
                    else
                    {
                        foreach (var error in result.Failures)
                        {
                            Log.Error("Failed to transfer file: {0}", error.Message);
                        }
                    }*/
                }
                else
                {
                    Log.Error("Failed to open SFTP session to {0}:{1} with user {2}", m_Ubuntu.Host, m_Ubuntu.Port, m_Ubuntu.Username);

                }
            });
        }

        public static void DrawContent()
        {
            if (m_Shown)
            {
                UpdateConfig();
                if (ImGui.Begin(m_Translate.UbuntuName, ref m_Shown))
                {
                    ImGuiUtils.InputText("SFTP Host", ref m_Hostname);
                    ImGuiUtils.InputText("SFTP HostKey", ref m_Hostkey);
                    ImGuiUtils.InputText("Username", ref m_Username);
                    ImGuiUtils.InputText("Password", ref m_Password);
                    ImGuiUtils.InputInt("Port", ref m_Port);
                    ImGui.End();
                }
            }
        }
    }
}
