

namespace GFEditor.Editor
{
    public partial class ItemEditor : Form
    {
        private readonly List<CSItemImg> m_itemsImage = [];
        private readonly List<CSItemImg> m_dropChestImage = [];
        private readonly List<SoundPlayer> m_soundData = [];
        private readonly ItemClassPanel m_classPanel = new();
        private readonly ItemOpPanel m_itemPanel = new();
        private readonly ItemTooltip m_tooltipPanel = new();
        private CSItem? m_currentItem = null;

        public ItemEditor()
        {
            InitializeComponent();
            InitializeDropChest();
            InitializeItems();
            LoadSounds();
            PopulateItemImageList();
            PopulateItemList();
            PopulateSndList();
            PopulateItemType();
            PopulateEquipType();
            PopulateItemTargetType();
            PopulateReputationType();
            PopulateItemQualityType();
            PopulateItemAttributeType();
            PopulateItemSpecialType();
            PopulateItemEnchantTimeType();
            PopulateItemTimeLimitType();
            PopulateItemAuctionType();
            PopulateItemPriceType();
        }

        private void InitializeDropChest()
        {
            m_dropChestImage.Add(new CSItemImg { Filename = "None", Image = SLImage.Load(Constants.NoChestDropImg) });
            m_dropChestImage.Add(new CSItemImg { Filename = "G00001", Image = SLImage.Load(Constants.G00001Img) });
            m_dropChestImage.Add(new CSItemImg { Filename = "G00002", Image = SLImage.Load(Constants.G00002Img) });
            m_dropChestImage.Add(new CSItemImg { Filename = "G00003", Image = SLImage.Load(Constants.G00003Img) });
            m_dropChestImage.Add(new CSItemImg { Filename = "G00004", Image = SLImage.Load(Constants.G00004Img) });
            m_dropChestImage.Add(new CSItemImg { Filename = "G00005", Image = SLImage.Load(Constants.G00005Img) });
            m_dropChestImage.Add(new CSItemImg { Filename = "G00006", Image = SLImage.Load(Constants.G00006Img) });
            m_dropChestImage.Add(new CSItemImg { Filename = "G00007", Image = SLImage.Load(Constants.G00007Img) });
            m_dropChestImage.Add(new CSItemImg { Filename = "G00008", Image = SLImage.Load(Constants.G00008Img) });
            m_dropChestImage.Add(new CSItemImg { Filename = "G00009", Image = SLImage.Load(Constants.G00009Img) });
            m_dropChestImage.Add(new CSItemImg { Filename = "G00010", Image = SLImage.Load(Constants.G00010Img) });
            Console.WriteLine("Loaded drop chest image.");
        }

        private CSItem? GetCurrentItem()
        {
            if (int.TryParse(ItemList.Items[ItemList.SelectedIndex].ToString(), out var itemIndex))
            {
                var foundItem = CSItemDatabase.GetItemByIndex(itemIndex);
                if (foundItem != null)
                    return foundItem;
            }
            else
            {
                Console.WriteLine("Failed to populate item property, ItemList.Items[ItemList.SelectedIndex] was not integer !");
            }
            return null;
        }

        private void InitializeItems()
        {
            var iconFiles = Directory.GetFiles(Constants.AssetItemPath);

            m_itemsImage.Add(new CSItemImg()
            {
                Filename = "None",
                Image = SLImage.Load(Constants.AssetItemPath + "NoItem.png"),
            });

            foreach (var iconFile in iconFiles)
            {
                var newImg = new CSItemImg
                {
                    Filename = Path.GetFileNameWithoutExtension(iconFile),
                    Image = SLImage.Load(iconFile)
                };
                m_itemsImage.Add(newImg);
            }

            Console.WriteLine("Loaded items icon image.");
        }

        private void PopulateItemImageList()
        {
            m_itemsImage.ForEach(item =>
            {
                ItemImgList.Items.Add(item.Filename);
            });

            Console.WriteLine("Populated items image list.");
        }

        private void LoadSounds()
        {
            var soundFiles = Directory.GetFiles(Constants.AssetSoundPath);
            if (soundFiles.Length <= 0) // if no sound found, copy it.
                SoundHelper.CopyRequiredUsedSounds();

            // Check again if there is any sound files.
            soundFiles = Directory.GetFiles(Constants.AssetSoundPath);
            m_soundData.Add(new SoundPlayer() { Name = "None", File = null, Player = null }); // No sound

            foreach (var soundPath in soundFiles)
            {
                var snd = new SoundPlayer()
                {
                    Name = Path.GetFileNameWithoutExtension(soundPath),
                    File = new AudioFileReader(soundPath),
                    Player = new WaveOutEvent()
                };
                snd.Init();
                m_soundData.Add(snd);
            }

            Console.WriteLine("Loaded sounds.");
        }

        private void PopulateSndList()
        {
            m_soundData.ForEach(item =>
            {
                UsedSndList.Items.Add(item.Name);
            });
            Console.WriteLine("[ItemEditor] Populated sound list.");
        }

        private void PopulateItemList()
        {
            ItemList.Items.Clear();
            
            var indexList = CSItemDatabase.GetIndexList();
            if (indexList != null)
            {
                foreach (var index in indexList)
                    ItemList.Items.Add(index);
                Console.WriteLine("[ItemEditor] Populated items list.");
            }
            else
            {
                Console.WriteLine("[ItemEditor] Error populating the items list, index list is null !");
            }
        }

        private void PopulateItemPriceType()
        {
            PriceTypeBox.Items.AddRange(Enum.GetNames<MerchantCoinType>());
            PriceTypeBox.Items.RemoveAt(8); // Remove nothing.
        }

        private void PopulateItemAuctionType()
        {
            AuctionTypeBox.Items.AddRange(Enum.GetNames<AuctionType>());
        }

        private void PopulateItemTimeLimitType()
        {
            TimeLimitTypeBox.Items.AddRange(Enum.GetNames<TimeLimitType>());
        }

        private void PopulateItemEnchantTimeType()
        {
            EnchantTimeTypeBox.Items.AddRange(Enum.GetNames<TimeType>());
        }

        private void PopulateItemSpecialType()
        {
            SpecialTypeBox.Items.AddRange(Enum.GetNames<SpecialType>());
        }

        private void PopulateItemAttributeType()
        {
            AttributeTypeBox.Items.AddRange(Enum.GetNames<AttributeType>());
        }

        private void PopulateItemQualityType()
        {
            ItemQualityBox.Items.AddRange(Enum.GetNames<QualityType>());
        }

        private void PopulateReputationType()
        {
            RestrictReputationBox.Items.AddRange(Enum.GetNames<ReputationType>());
        }

        private void PopulateItemTargetType()
        {
            TargetBox.Items.AddRange(Enum.GetNames<TargetType>());
            TargetBox.Items.RemoveAt(1); // Remove nothing.
        }

        private void PopulateItemType()
        {
            var itemTypeList = Enum.GetNames<ItemType>().ToList();
            itemTypeList.RemoveRange(64, 9);
            ItemTypeBox.Items.AddRange(itemTypeList.ToArray());
        }

        private void PopulateEquipType()
        {
            EquipTypeBox.Items.AddRange(Enum.GetNames<EquipType>());
            EquipTypeBox.Items.RemoveAt(EquipTypeBox.Items.Count - 1); // Remove last which is 'Max', that's not an equip type.
        }

        private void PopulateItemProperty(CSItem item)
        {
            m_currentItem = item;

            ItemIndexTxt.Text = item.Index.ToString();
            ItemImgList.SelectIndexByName(item.IconFilename);
            ModelIDTxt.Text = string.IsNullOrEmpty(item.ModelId) ? "None" : item.ModelId;
            DropChestBox.SelectIndexByName(item.ModelFilename);
            WeaponEffIDTxt.Text = item.WeaponEffectId.ToString();
            FlyEffIDTxt.Text = item.FlyEffectId.ToString();
            UsedEffIDTxt.Text = item.UsedEffectId.ToString();
            UsedSndList.SelectIndexByName(item.UsedSoundName);
            EnhanceEffIDTxt.Text = item.EnchanceEffectId.ToString();
            NameTxt.Text = item.Name.ToString();
            ItemTypeBox.SelectIndexByEnum((ItemType)item.ItemType);
            EquipTypeBox.SelectIndexByEnum((EquipType)item.EquipType);
            m_itemPanel.SetItem(item); m_itemPanel.Update();
            if (item.Target == 1)
                item.Target = 0;
            TargetBox.SelectIndexByEnum((TargetType)item.Target);

            // Gender selection.
            switch (item.RestrictGender)
            {
                case 1: BoyCBox.Checked = true; break;
                case 2: GirlCBox.Checked = true; break;
                default: BoyCBox.Checked = false; GirlCBox.Checked = false; break;
            }

            RestrictLevelUD.Value = item.RestrictLevel;
            RestrictMaxLevelUD.Value = item.RestrictMaxLevel;
            RebirthUD.Value = item.RebirthCount;
            RebirthScoreUD.Value = item.RebirthScore;
            RebirthMaxScoreUD.Value = item.RebirthMaxScore;
            RestrictReputationBox.SelectIndexByEnum((ReputationType)item.RestrictReputation);
            RestrictReputationCountUD.Value = item.RestrictReputationCount;
            m_classPanel.SetItem(item); m_classPanel.Update();
            ItemQualityBox.SelectIndexByEnum((QualityType)item.ItemQuality);
            ItemGroupUD.Value = item.ItemGroup;
            CastingTimeUD.Value = item.CastingTime;
            CooldownTimeUD.Value = item.CoolDownTime;
            CooldownGroupUD.Value = item.CoolDownGroup;
            MaxHPUD.Value = item.MaxHp;
            MaxMPUD.Value = item.MaxMp;
            StrUD.Value = item.Str;
            VitUD.Value = item.Vit;
            IntUD.Value = item.Int;
            WilUD.Value = item.Wil;
            AgiUD.Value = item.Agi;
            AvgPhysicalDmgUD.Value = item.AvgPhysicoDamage;
            RandPhysicalDmgUD.Value = item.RandPhysicoDamage;
            AttackRangeUD.Value = item.AttackRange;
            AttackSpeedUD.Value = item.AttackSpeed;
            AttackUD.Value = item.Attack;
            RangedAttackUD.Value = item.RangeAttack;
            PhysicalDefUD.Value = item.PhysicoDefence;
            MagicAttackUD.Value = item.MagicDamage;
            MagicalDefUD.Value = item.MagicDefence;
            HitRateUD.Value = item.HitRate;
            DodgeRateUD.Value = item.DodgeRate;
            PhysicalCriticalRateUD.Value = item.PhysicoCriticalRate;
            PhysicalCriticalDmgUD.Value = item.PhysicoCriticalDamage;
            MagicalCriticalRateUD.Value = item.MagicCriticalRate;
            MagicalCriticalDmgUD.Value = item.MagicCriticalDamage;
            PhysicalPenetrationUD.Value = item.PhysicalPenetration;
            MagicalPenetrationUD.Value = item.MagicalPenetration;
            PhysicalPenetrationDefUD.Value = item.PhysicalPenetrationDefence;
            MagicalPenetrationDefUD.Value = item.MagicalPenetrationDefence;
            AttributeTypeBox.SelectIndexByEnum((AttributeType)item.Attribute);
            AttributeDamageUD.Value = item.AttributeDamage;
            AttributeRateUD.Value = item.AttributeRate;
            AttributeResistanceUD.Value = item.AttributeResist;
            SpecialTypeBox.SelectIndexByEnum((SpecialType)item.SpecialType);
            SpecialRateUD.Value = item.SpecialRate;
            SpecialDmgUD.Value = item.SpecialDamage;
            DropRateUD.Value = item.DropRate;
            DropIndexUD.Value = item.DropIndex;
            TreasureBuff1UD.Value = item.TreasureBuffs01;
            TreasureBuff2UD.Value = item.TreasureBuffs02;
            TreasureBuff3UD.Value = item.TreasureBuffs03;
            TreasureBuff4UD.Value = item.TreasureBuffs04;
            EnchantEnablerUD.Value = item.EnchantEnabler;
            EnchantIndexUD.Value = item.EnchantIndex;
            ExpertLevelUD.Value = item.ExpertLevel;
            ExpertEnchantIndexUD.Value = item.ExpertEnchantIndex;
            ElfSkillIndexUD.Value = item.ElfSkillIndex;
            EnchantTimeTypeBox.SelectIndexByEnum((TimeType)item.EnchantTimeType);
            EnchantDurationUD.Value = item.EnchantDuration;
            TimeLimitTypeBox.SelectIndexByEnum((TimeLimitType)item.LimitType);
            TimeLimitUD.Value = item.DueDateTime;
            BackpackSizeUD.Value = item.BackpackSize;
            SocketMaxUD.Value = item.SocketMax;
            SocketRateUD.Value = item.SocketRate;
            MaxDurabilityUD.Value = item.MaxDurability;
            MaxStackUD.Value = item.MaxStack;
            PriceTypeBox.SelectIndexByEnum((MerchantCoinType)item.ShopPriceType);
            PriceUD.Value = item.Price;
            RestrictEventPosTxt.Text = item.RestrictEventPosition;
            MissionIndexUD.Value = item.MissionIndex;
            BlockRateUD.Value = item.BlockRate;
            LogLevelUD.Value = item.LogLevel;
            AuctionTypeBox.SelectIndexByEnum((AuctionType)item.AuctionType);
            ExtraData1UD.Value = item.ExtraData01;
            ExtraData2UD.Value = item.ExtraData02;
            ExtraData3UD.Value = item.ExtraData03;
            TipTxt.Text = item.Tip;

            // Update tooltip if the item changed.
            m_tooltipPanel.SetItem(item);
            m_tooltipPanel.Update();
        }

        private void ItemEditor_Load(object sender, EventArgs e)
        {
            ChestDropImg.Image = GFImageConverter.ToNetImage(m_dropChestImage[0].Image.ToArray()); // It create a new file, this will need to be disposed off later.
            ItemIconImg.Image = GFImageConverter.ToNetImage(m_itemsImage[0].Image.ToArray()); // Same free it later.
            DropChestBox.SelectedIndex = 0;
            ItemImgList.SelectedIndex = 0;
            ItemList.SelectedIndex = 0;
            UsedSndList.SelectedIndex = 0;
            EquipTypeBox.SelectedIndex = 0;
            TargetBox.SelectedIndex = 0;
            RestrictReputationBox.SelectedIndex = 0;
            ItemQualityBox.SelectedIndex = 0;
            AttributeTypeBox.SelectedIndex = 0;
            SpecialTypeBox.SelectedIndex = 0;
            EnchantTimeTypeBox.SelectedIndex = 0;
            TimeLimitTypeBox.SelectedIndex = 0;
            AuctionTypeBox.SelectedIndex = 0;
        }

        private void ItemEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save database (project)
            foreach (var sound in m_soundData)
                sound?.Release();
            Console.WriteLine("[ItemEditor] Released sounds.");

            foreach (var item in m_itemsImage)
                item.Image.Dispose();
            ItemIconImg.Image?.Dispose();
            Console.WriteLine("[ItemEditor] Released items icon images.");

            foreach (var img in m_dropChestImage)
                img.Image.Dispose();
            ChestDropImg.Image?.Dispose();
            Console.WriteLine("[ItemEditor] Released chest drop images.");
        }

        private void DropChestBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChestDropImg.Image?.Dispose(); // Dispose it to avoid memory leak !
            ChestDropImg.Image = GFImageConverter.ToNetImage(m_dropChestImage[DropChestBox.SelectedIndex].Image.ToArray());
            if (m_currentItem != null)
                m_currentItem.ModelFilename = m_dropChestImage[DropChestBox.SelectedIndex].Filename;
        }

        private void ItemImgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemIconImg.Image?.Dispose();
            var obj = ItemImgList.Items[ItemImgList.SelectedIndex];
            if (obj == null)
            {
                Console.WriteLine("Failed to update selected index image list, returned ItemImgList.Items[ItemImgList.SelectedIndex] is null !");
                return;
            }
            var iconName = obj.ToString();
            if (string.IsNullOrEmpty(iconName))
            {
                Console.WriteLine("Failed to update selected index image list, returned obj.ToString() is null !");
                return;
            }
            var iconFile = iconName.ToLower();
            var icon = m_itemsImage.Find(it => it.Filename.Contains(iconFile));
            if (icon != null)
                ItemIconImg.Image = GFImageConverter.ToNetImage(icon.Image.ToArray());
            else
                ItemIconImg.Image = GFImageConverter.ToNetImage(m_itemsImage[0].Image.ToArray());
        }

        private void ItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var foundItem = GetCurrentItem();
            if (foundItem != null)
                PopulateItemProperty(foundItem);
        }

        private void TestSoundBtn_Click(object sender, EventArgs e)
        {
            if (UsedSndList.SelectedIndex <= 0) // Avoid 0 because its "None"
                return;
            var obj = ItemImgList.Items[ItemImgList.SelectedIndex];
            if (obj == null)
            {
                Console.WriteLine("Failed to test sound, returned ItemImgList.Items[ItemImgList.SelectedIndex] is null !");
                return;
            }
            var soundName = obj.ToString();
            if (string.IsNullOrEmpty(soundName))
            {
                Console.WriteLine("Failed to test sound, returned obj.ToString() is null !");
                return;
            }
            var sound = m_soundData.Find(s => s.Name.Equals(soundName, StringComparison.CurrentCultureIgnoreCase));
            sound?.Play();
        }

        private void EquipTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<EquipType>().ElementAtOrDefault(EquipTypeBox.SelectedIndex); // Get enum value by index
            if (m_currentItem != null)
                m_currentItem.EquipType = (int)selectedEnumValue;
        }

        private void RestrictClassBtn_Click(object sender, EventArgs e)
        {
            m_classPanel.Show(this);
        }

        private void ItemTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<ItemType>().ElementAtOrDefault(ItemTypeBox.SelectedIndex); // Get enum value by index
            if (m_currentItem != null)
                m_currentItem.ItemType = (int)selectedEnumValue;
        }

        private void BoyCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (BoyCBox.Checked)
                GirlCBox.Checked = false;
        }

        private void GirlCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (GirlCBox.Checked)
                BoyCBox.Checked = false;
        }

        private void RestrictUseBtn_Click(object sender, EventArgs e)
        {
            m_itemPanel.Show(this);
        }

        private void TargetBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<ReputationType>().ElementAtOrDefault(TargetBox.SelectedIndex);
            if (m_currentItem != null)
                m_currentItem.Target = (int)selectedEnumValue;
        }

        private void RestrictLevelUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.RestrictLevel = (int)RestrictLevelUD.Value;
        }

        private void RestrictMaxLevelUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.RestrictMaxLevel = (int)RestrictMaxLevelUD.Value;
        }

        private void RebirthUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.RebirthCount = (int)RebirthUD.Value;
        }

        private void RebirthScoreUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.RebirthScore = (int)RebirthScoreUD.Value;
        }

        private void RebirthMaxScoreUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.RebirthMaxScore = (int)RebirthMaxScoreUD.Value;
        }

        private void RestrictReputationBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<ReputationType>().ElementAtOrDefault(RestrictReputationBox.SelectedIndex); // Get enum value by index
            if (m_currentItem != null)
                m_currentItem.RestrictReputation = (int)selectedEnumValue;
        }

        private void RestrictReputationCountUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.RestrictReputationCount = (int)RestrictReputationCountUD.Value;
        }

        private void ItemQualityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<QualityType>().ElementAtOrDefault(ItemQualityBox.SelectedIndex); // Get enum value by index
            if (m_currentItem != null)
                m_currentItem.ItemQuality = (int)selectedEnumValue;
        }

        private void ItemGroupUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.ItemGroup = (int)ItemGroupUD.Value;
        }

        private void CastingTimeUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.CastingTime = (int)CastingTimeUD.Value;
        }

        private void CooldownTimeUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.CoolDownTime = (int)CooldownTimeUD.Value;
        }

        private void CooldownGroupUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.CoolDownGroup = (int)CooldownGroupUD.Value;
        }

        private void MaxStackUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MaxStack = (int)MaxStackUD.Value;
        }

        private void MaxHPUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MaxHp = (int)MaxHPUD.Value;
        }

        private void MaxMPUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MaxMp = (int)MaxMPUD.Value;
        }

        private void PhysicalDefUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.PhysicoDefence = (int)PhysicalDefUD.Value;
        }

        private void MagicalDefUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MagicDefence = (int)MagicalDefUD.Value;
        }

        private void StrUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.Str = (int)StrUD.Value;
        }

        private void VitUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.Vit = (int)VitUD.Value;
        }

        private void IntUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.Int = (int)IntUD.Value;
        }

        private void WilUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.Wil = (int)WilUD.Value;
        }

        private void AgiUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.Agi = (int)AgiUD.Value;
        }

        private void AvgPhysicalDmgUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.AvgPhysicoDamage = (int)AvgPhysicalDmgUD.Value;
        }

        private void RandPhysicalDmgUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.RandPhysicoDamage = (int)RandPhysicalDmgUD.Value;
        }

        private void AttackUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.Attack = (int)AttackUD.Value;
        }

        private void RangedAttackUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.RangeAttack = (int)RangedAttackUD.Value;
        }

        private void MagicAttackUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MagicDamage = (int)MagicAttackUD.Value;
        }

        private void AttackRangeUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.AttackRange = (int)AttackRangeUD.Value;
        }

        private void AttackSpeedUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.AttackSpeed = (int)AttackSpeedUD.Value;
        }

        private void HitRateUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.HitRate = (int)HitRateUD.Value;
        }

        private void DodgeRateUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.DodgeRate = (int)DodgeRateUD.Value;
        }

        private void BlockRateUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.BlockRate = (int)BlockRateUD.Value;
        }

        private void PhysicalCriticalRateUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.PhysicoCriticalRate = (int)PhysicalCriticalRateUD.Value;
        }

        private void MagicalCriticalRateUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MagicCriticalRate = (int)MagicalCriticalRateUD.Value;
        }

        private void PhysicalPenetrationUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.PhysicalPenetration = (int)PhysicalPenetrationUD.Value;
        }

        private void MagicalPenetrationUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MagicalPenetration = (int)MagicalPenetrationUD.Value;
        }

        private void PhysicalCriticalDmgUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.PhysicoCriticalDamage = (int)PhysicalCriticalDmgUD.Value;
        }

        private void MagicalCriticalDmgUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MagicCriticalDamage = (int)MagicalCriticalDmgUD.Value;
        }

        private void PhysicalPenetrationDefUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.PhysicalPenetrationDefence = (int)PhysicalPenetrationDefUD.Value;
        }

        private void MagicalPenetrationDefUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MagicalPenetrationDefence = (int)MagicalPenetrationDefUD.Value;
        }

        private void AttributeTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<AttributeType>().ElementAtOrDefault(AttributeTypeBox.SelectedIndex); // Get enum value by index
            if (m_currentItem != null)
                m_currentItem.Attribute = (int)selectedEnumValue;
        }

        private void AttributeRateUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.AttributeRate = (int)AttributeRateUD.Value;
        }

        private void AttributeDamageUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.AttributeDamage = (int)AttributeDamageUD.Value;
        }

        private void AttributeResistanceUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.AttributeResist = (int)AttributeResistanceUD.Value;
        }

        private void SpecialTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<SpecialType>().ElementAtOrDefault(SpecialTypeBox.SelectedIndex); // Get enum value by index
            if (m_currentItem != null)
                m_currentItem.SpecialType = (int)selectedEnumValue;
        }

        private void SpecialDmgUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.SpecialDamage = (int)SpecialDmgUD.Value;
        }

        private void SpecialRateUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.SpecialRate = (int)SpecialRateUD.Value;
        }

        private void DropRateUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.DropRate = (int)DropRateUD.Value;
        }

        private void DropIndexUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.DropIndex = (int)DropIndexUD.Value;
        }

        private void EnchantEnablerUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.EnchantEnabler = (int)EnchantEnablerUD.Value;
        }

        private void EnchantIndexUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.EnchantIndex = (int)EnchantIndexUD.Value;
        }

        private void ExpertLevelUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.ExpertLevel = (int)ExpertLevelUD.Value;
        }

        private void ExpertEnchantIndexUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.ExpertEnchantIndex = (int)ExpertEnchantIndexUD.Value;
        }

        private void ElfSkillIndexUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.ElfSkillIndex = (int)ElfSkillIndexUD.Value;
        }

        private void EnchantTimeTypeUD_ValueChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<TimeType>().ElementAtOrDefault(EnchantTimeTypeBox.SelectedIndex); // Get enum value by index
            if (m_currentItem != null)
                m_currentItem.EnchantTimeType = (int)selectedEnumValue;
        }

        private void EnchantDurationUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.EnchantDuration = (int)EnchantDurationUD.Value;
        }

        private void TimeLimitTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<TimeLimitType>().ElementAtOrDefault(TimeLimitTypeBox.SelectedIndex); // Get enum value by index
            if (m_currentItem != null)
                m_currentItem.LimitType = (int)selectedEnumValue;
        }

        private void TimeLimitUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.DueDateTime = (int)TimeLimitUD.Value;
        }

        private void BackpackSizeUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.BackpackSize = (int)BackpackSizeUD.Value;
        }

        private void SocketMaxUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.SocketMax = (int)SocketMaxUD.Value;
        }

        private void SocketRateUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.SocketRate = (int)SocketRateUD.Value;
        }

        private void MaxDurabilityUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MaxDurability = (int)MaxDurabilityUD.Value;
        }

        private void LogLevelUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.LogLevel = (int)LogLevelUD.Value;
        }

        private void AuctionTypeUD_ValueChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<AuctionType>().ElementAtOrDefault(AuctionTypeBox.SelectedIndex); // Get enum value by index
            if (m_currentItem != null)
                m_currentItem.AuctionType = (int)selectedEnumValue;
        }

        private void ExtraData1UD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.ExtraData01 = (int)ExtraData1UD.Value;
        }

        private void ExtraData2UD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.ExtraData02 = (int)ExtraData2UD.Value;
        }

        private void ExtraData3UD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.ExtraData03 = (int)ExtraData3UD.Value;
        }

        private void TipTxt_TextChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.Tip = TipTxt.Text;
        }

        private void RestrictEventPosTxt_TextChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.RestrictEventPosition = RestrictEventPosTxt.Text;
        }

        private void PriceTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<MerchantCoinType>().ElementAtOrDefault(PriceTypeBox.SelectedIndex); // Get enum value by index
            if (m_currentItem != null)
                m_currentItem.ShopPriceType = (int)selectedEnumValue;
        }

        private void PriceUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.Price = (int)PriceUD.Value;
        }

        private void TooltipBtn_Click(object sender, EventArgs e)
        {
            m_tooltipPanel.Show(this);
        }

        private void AddNewItemBtn_Click(object sender, EventArgs e)
        {
            if (CSItemDatabase.CreateNewItem())
            {
                PopulateItemList();
                ItemList.SelectedIndex = 0; // Reset index.
            }
        }
    }
}
