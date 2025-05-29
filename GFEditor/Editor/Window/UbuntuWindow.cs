namespace GFEditor.Editor.Window
{
    public class UbuntuWindow
    {
        private static readonly TranslatedValues m_Translate = TranslateUtils.Json.TranslatedValues;
        private const string RootPath = "/root/gf_server";
        private Session? m_session = null;
        private SessionOptions? m_sessionOptions = null;
        private CConfigUbuntu m_Ubuntu = ConfigUtils.Configs.Ubuntu;
        private string m_Hostname = string.Empty;
        private string m_Hostkey = string.Empty;
        private string m_Username = string.Empty;
        private string m_Password = string.Empty;
        private int m_Port = 0;
        private bool m_Shown = false;
        private bool m_WasConnectedByAutoConnect = false; // Autoconnect one time !
        public bool IsOpen => m_Shown;

        public void Show() => m_Shown = true;
        public void Hide() => m_Shown = false;
        public bool IsConnected() => m_session != null && m_session.Opened;

        public void Initialize()
        {
            if (m_Ubuntu.Host.IsValid()) m_Hostname = m_Ubuntu.Host;
            if (m_Ubuntu.HostKey.IsValid()) m_Hostkey = m_Ubuntu.HostKey;
            if (m_Ubuntu.Username.IsValid()) m_Username = m_Ubuntu.Username;
            if (m_Ubuntu.Password.IsValid()) m_Password = m_Ubuntu.Password;
            if (m_Ubuntu.Port != 0) m_Port = m_Ubuntu.Port;
        }

        private void UpdateConfig()
        {
            // Also handle if the host has changed values...
            if (!m_Ubuntu.Host.IsValid() || m_Ubuntu.Host != m_Hostname) m_Ubuntu.Host = m_Hostname;
            if (!m_Ubuntu.HostKey.IsValid() || m_Ubuntu.HostKey != m_Hostkey) m_Ubuntu.HostKey = m_Hostkey;
            if (!m_Ubuntu.Username.IsValid() || m_Ubuntu.Username != m_Username) m_Ubuntu.Username = m_Username;
            if (!m_Ubuntu.Password.IsValid() || m_Ubuntu.Password != m_Password) m_Ubuntu.Password = m_Password;
            if (m_Ubuntu.Port == 0 || m_Ubuntu.Port != m_Port) m_Ubuntu.Port = m_Port;
        }

        private void CreateSftpClient()
        {
            if (m_session == null)
            {
                Initialize();
                UpdateConfig();
                m_sessionOptions = new SessionOptions()
                {
                    Protocol = Protocol.Sftp,
                    FtpMode = FtpMode.Passive,
                    UserName = m_Ubuntu.Username,
                    Password = m_Ubuntu.Password,
                    HostName = m_Ubuntu.Host,
                    PortNumber = m_Ubuntu.Port,
                    SshHostKeyFingerprint = m_Ubuntu.HostKey,
                    Timeout = TimeSpan.FromMilliseconds(100),
                    TimeoutInMilliseconds = 100,
                };
                m_sessionOptions.AddRawSettings("SftpServer", "sudo%20/usr/lib/openssh/sftp-server");
                m_session ??= new Session();
            }
        }

        public void DrawContent()
        {
            if (m_Shown)
            {
                if (ImGui.Begin(m_Translate.UbuntuName, ref m_Shown))
                {
                    ImGuiUtils.InputText("SFTP Host", ref m_Hostname);
                    ImGuiUtils.InputText("SFTP HostKey", ref m_Hostkey);
                    ImGuiUtils.InputText("Username", ref m_Username);
                    ImGuiUtils.InputText("Password", ref m_Password);
                    ImGuiUtils.InputInt("Port", ref m_Port);
                    if (ImGui.Button("Connect"))
                        Connect();
                    ImGui.SameLine(); ImGui.Checkbox("Auto connect", ref m_Ubuntu.AutoConnect);
                    ImGui.End();
                }
            }
        }

        private void Connect()
        {
            CreateSftpClient();
            if (m_session != null && !m_session.Opened && m_sessionOptions != null)
            {
                try
                {
                    //m_session.Open(m_sessionOptions);
                    if (m_session.Opened)
                        ImGuiNotify.Insert(new ImGuiToast(ImGuiToastType.Success, "Ubuntu Server", 2000, "Connected to " + m_Hostname));
                }
                catch (Exception ex)
                {
                    ImGuiNotify.Insert(new ImGuiToast(ImGuiToastType.Error, "Ubuntu Server", 2000, ex.Message));
                }
            }
        }

        public void Disconnect()
        {
            if (IsConnected())
            {
                m_session?.Close();
                Dispose();
                m_sessionOptions = null;
                ImGuiNotify.Insert(new ImGuiToast(ImGuiToastType.Success, "Ubuntu Server", 2000, "Disconnected"));
            }
        }

        public void Dispose()
        {
            if (m_session != null)
            {
                if (m_session.Opened)
                    m_session.Close();
                m_session.Dispose();
            }
            m_session = null;
        }

        public void AutoConnect()
        {
            if (m_Ubuntu.AutoConnect && m_session == null && !m_WasConnectedByAutoConnect &&
                m_Ubuntu.Host.IsValid() && m_Ubuntu.HostKey.IsValid() && m_Ubuntu.Password.IsValid() && m_Ubuntu.Username.IsValid() && m_Ubuntu.Port != 0)
            {
                Connect();
                m_WasConnectedByAutoConnect = true;
            }
        }
    }
}
