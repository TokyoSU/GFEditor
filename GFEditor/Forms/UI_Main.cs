namespace GFEditor.Forms
{
    public partial class UI_Main : Form
    {
        private readonly UI_Loader m_Loader = new();
        private readonly UI_Item m_Item = new();

        public UI_Main()
        {
            InitializeComponent();
            TranslateAutoCBox.Checked = Constants.Parameters.TranslateAutoOnLoad;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            CItemDatabase.Save();
            TItemDatabase.Save();
            TTextIndexDatabase.Save();
            BasicAssetDatabase.Release();
        }

        private void TranslateAutoCBox_CheckedChanged(object sender, EventArgs e)
        {
            Constants.Parameters.TranslateAutoOnLoad = TranslateAutoCBox.Checked;
        }

        private void ShowItemBtn_Click(object sender, EventArgs e)
        {
            m_Item.Show(this);
        }

        private void ShowEnchantBtn_Click(object sender, EventArgs e)
        {

        }

        private void Main_Shown(object sender, EventArgs e)
        {
            m_Loader?.Show(this);
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }
    }
}
