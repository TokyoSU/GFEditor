using GFEditor.Database.ClientServer;
using GFEditor.Database.Translate;

namespace GFEditor.Editor
{
    public partial class UI_Loader : Form
    {
        private int MaxClassIndex = 1;

        public UI_Loader()
        {
            InitializeComponent();
            MaxProgress.Maximum = 0;
        }

        public void IncreaseClassMax() => MaxProgress.Maximum++;

        public void SetClassProgress(string className)
        {
            MaxLabel.Text = "Processing: " + className + "...";
            MaxProgress.Value = MaxClassIndex++;
            Update();
        }

        public void SetCurProgress(string value, int progress)
        {
            CurLabel.Text = value;
            CurProgress.Value = progress;
            Update();
        }

        public void SetCurMaxProgress(int progresss)
        {
            CurProgress.Maximum = progresss;
            Update();
        }

        public void EnableItem(bool enabled)
        {
            ItemLabel.Enabled = enabled;
            ItemProgress.Enabled = enabled;
            Update();
        }

        public void SetItemProgress(string value, int progress)
        {
            ItemLabel.Text = value;
            ItemProgress.Value = progress;
            Update();
        }

        public void SetItemMaxProgress(int progresss)
        {
            ItemProgress.Maximum = progresss;
            Update();
        }

        private void LoaderPanel_Shown(object sender, EventArgs e)
        {
            // Select folder for the editor use.
            Constants.Load();
            Constants.Save();

            // Set loader and increase max class count.
            BasicAssetDatabase.SetLoader(this);
            CItemDatabase.SetLoader(this);
            TItemDatabase.SetLoader(this);
            TTextIndexDatabase.SetLoader(this);

            // Required Assets for the Editor.
            BasicAssetDatabase.Load();

            // Client/Server Files.
            CItemDatabase.Load();

            // Translate Files.
            TItemDatabase.Load();
            TTextIndexDatabase.Load();

            Hide();
        }

        private void LoaderPanel_Load(object sender, EventArgs e)
        {
            
        }
    }
}
