namespace GFEditor.Database
{
    public static class BasicAssetDatabase
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private static readonly List<NamedImage> m_itemsImage = [];
        private static readonly List<NamedImage> m_dropChestImage = [];
        private static readonly List<SoundPlayer> m_soundData = [];
        private static UI_Loader? m_Loader = null;

        public static void SetLoader(UI_Loader? loader)
        {
            m_Loader = loader;
            m_Loader?.IncreaseClassMax();
        }

        public static void Load()
        {
            m_Loader?.SetClassProgress("BasicAssets");
            InitializeDropChestImages();
            InitializeItemsImages();
            InitializeSounds();
        }

        public static NamedImage GetChestDropByIndex(int index) => m_dropChestImage[index];
        public static NamedImage? GetChestDropByFilename(string name) => m_itemsImage.Find(e => e.Filename.Equals(name, StringComparison.CurrentCultureIgnoreCase));

        public static NamedImage GetItemImageByIndex(int index) => m_itemsImage[index];
        public static NamedImage? GetItemImageByFilename(string name) => m_itemsImage.Find(e => e.Filename.Contains(name, StringComparison.CurrentCultureIgnoreCase));

        public static SoundPlayer GetSoundByIndex(int index) => m_soundData[index];
        public static SoundPlayer? GetSoundByFilename(string name) => m_soundData.Find(e => e.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));

        public static void PopulateDropChestList(ComboBox box)
        {
            box.Items.Clear();
            var dropChestList = m_dropChestImage.Select(e => e.Filename);
            box.Items.AddRange([.. dropChestList]);
            m_Log.Info("Populated drop chest.");
        }

        public static void PopulateItemImagesList(ComboBox box)
        {
            box.Items.Clear();
            var itemImageList = m_itemsImage.Select(item => item.Filename);
            box.Items.AddRange([.. itemImageList]);
            m_Log.Info("Populated items images list.");
        }

        public static void PopulateSoundsList(ComboBox box)
        {
            box.Items.Clear();
            var soundList = m_soundData.Select(e => e.Name);
            box.Items.AddRange([.. soundList]);
            m_Log.Info("Populated sounds list.");
        }

        public static void Release()
        {
            foreach (var sound in m_soundData)
                sound?.Release();
            m_Log.Info("Released sounds.");

            foreach (var item in m_itemsImage)
                item?.Image?.Dispose();
            m_Log.Info("Released items icon images.");

            foreach (var img in m_dropChestImage)
                img?.Image?.Dispose();
            m_Log.Info("Released chest drop images.");
        }

        private static void InitializeDropChestImages()
        {
            var chestFiles = Directory.GetFiles(Constants.AssetChestPath);
            int index = 0;

            m_Loader?.SetCurProgress("Loading drop chest images.", 0);
            m_Loader?.EnableItem(true);
            m_Loader?.SetItemProgress(string.Empty, 0);
            m_Loader?.SetItemMaxProgress(chestFiles.Length);
            foreach (var chestPath in chestFiles)
            {
                var named = new NamedImage()
                {
                    Filename = Path.GetFileNameWithoutExtension(chestPath).ToUpper(),
                    Image = SLImage.Load(chestPath)
                };
                m_Loader?.SetItemProgress($"Loading: {named.Filename}", index++);
                m_dropChestImage.Add(named);
            }
            m_Loader?.SetItemMaxProgress(100);
            m_Loader?.EnableItem(false);

            m_dropChestImage[0].Filename = "None";
            m_Log.Info("Loaded drop chest images.");
        }

        private static void InitializeItemsImages()
        {
            var iconFiles = Directory.GetFiles(Constants.AssetItemPath);
            int index = 0;

            m_itemsImage.Add(new NamedImage()
            {
                Filename = "None",
                Image = SLImage.Load(Constants.AssetItemPath + "NoItem.png"),
            });

            m_Loader?.SetCurProgress("Loading items images.", 50);
            m_Loader?.EnableItem(true);
            m_Loader?.SetItemProgress(string.Empty, 0);
            m_Loader?.SetItemMaxProgress(iconFiles.Length);
            foreach (var iconPath in iconFiles)
            {
                var named = new NamedImage
                {
                    Filename = Path.GetFileNameWithoutExtension(iconPath),
                    Image = SLImage.Load(iconPath)
                };
                m_Loader?.SetItemProgress($"Loading: {named.Filename}", index++);
                m_itemsImage.Add(named);
            }
            m_Loader?.SetItemMaxProgress(100);
            m_Loader?.EnableItem(false);

            m_Log.Info("Loaded items images.");
        }

        private static void InitializeSounds()
        {
            var soundFiles = Directory.GetFiles(Constants.AssetSoundPath);
            if (soundFiles.Length <= 0) // if no sound found, copy it.
                SoundHelper.CopyRequiredUsedSounds();

            // Adding default 'None' sound.
            m_soundData.Add(new SoundPlayer() { Name = "None", File = null, Player = null });

            // Check again if there is any sound files.
            soundFiles = Directory.GetFiles(Constants.AssetSoundPath);
            int index = 0;

            m_Loader?.SetCurProgress("Loading sounds.", 100);
            m_Loader?.EnableItem(true);
            m_Loader?.SetItemProgress(string.Empty, 0);
            m_Loader?.SetItemMaxProgress(soundFiles.Length);
            foreach (var soundPath in soundFiles)
            {
                var snd = new SoundPlayer()
                {
                    Name = Path.GetFileNameWithoutExtension(soundPath),
                    File = new AudioFileReader(soundPath),
                    Player = new WaveOutEvent()
                };
                m_Loader?.SetItemProgress($"Loading: {snd.Name}", index++);
                snd.Init();
                m_soundData.Add(snd);
            }
            m_Loader?.SetItemMaxProgress(100);
            m_Loader?.EnableItem(false);

            m_Log.Info("Loaded sounds.");
        }
    }
}
