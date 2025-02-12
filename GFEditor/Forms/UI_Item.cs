

namespace GFEditor.Editor
{
    public partial class UI_Item : Form
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private readonly UI_ItemClass m_classPanel = new();
        private readonly UI_ItemOpFlags m_itemPanel = new();
        private readonly UI_ItemTooltip m_tooltipPanel = new();
        private Item? m_currentItem = null;

        public UI_Item()
        {
            // Required for form.
            InitializeComponent();
            ControlBox = false;
        }

        private void ItemForm_Shown(object sender, EventArgs e)
        {
            // Populating combobox and dropdown list.
            PopulateDropChestList();
            PopulateItemImageList();
            PopulateSoundList();
            PopulateItemList();
            PopulateItemType();
            PopulateItemEquipType();
            PopulateItemTargetType();
            PopulateReputationType();
            PopulateItemQualityType();
            PopulateItemAttributeType();
            PopulateItemSpecialType();
            PopulateItemEnchantTimeType();
            PopulateItemTimeLimitType();
            PopulateItemAuctionType();
            PopulateItemPriceType();
            PopulateDefaultValues();
        }

        private Item? GetCurrentItem()
        {
            if (int.TryParse(ItemList.Items[ItemList.SelectedIndex].ToString(), out var itemIndex))
            {
                var foundItem = CItemDatabase.GetItemByIndex(itemIndex);
                if (foundItem != null)
                    return foundItem;
            }
            else throw new InvalidCastException("Failed to populate item property, ItemList.Items[ItemList.SelectedIndex] was not integer !");
            return null;
        }

        private void PopulateItemList()
        {
            ItemList.Items.Clear();

            var indexList = CItemDatabase.GetIndexList();
            if (indexList != null)
            {
                ItemList.Items.AddRange([.. indexList]);
                m_Log.Info("Populated items list.");
            }
            else
            {
                throw new Exception("Error populating the items list, index list is null, did the item database was loaded ?");
            }
        }

        private void PopulateSoundList()
        {
            BasicAssetDatabase.PopulateSoundsList(UsedSndList);
        }

        private void PopulateItemImageList()
        {
            BasicAssetDatabase.PopulateItemImagesList(ItemImgList);
        }

        private void PopulateDropChestList()
        {
            BasicAssetDatabase.PopulateDropChestList(DropChestBox);
        }

        private void PopulateItemPriceType()
        {
            PriceTypeBox.Items.Clear();
            PriceTypeBox.Items.AddRange(Enum.GetNames<MerchantCoinType>());
            PriceTypeBox.Items.RemoveAt(8); // Remove nothing.
            m_Log.Info("Populated item price type.");
        }

        private void PopulateItemAuctionType()
        {
            AuctionTypeBox.Items.Clear();
            AuctionTypeBox.Items.AddRange(Enum.GetNames<AuctionType>());
            m_Log.Info("Populated item auction type.");
        }

        private void PopulateItemTimeLimitType()
        {
            TimeLimitTypeBox.Items.Clear();
            TimeLimitTypeBox.Items.AddRange(Enum.GetNames<TimeLimitType>());
            m_Log.Info("Populated item time limit type.");
        }

        private void PopulateItemEnchantTimeType()
        {
            EnchantTimeTypeBox.Items.Clear();
            EnchantTimeTypeBox.Items.AddRange(Enum.GetNames<TimeType>());
            m_Log.Info("Populated enchant time type.");
        }

        private void PopulateItemSpecialType()
        {
            SpecialTypeBox.Items.Clear();
            SpecialTypeBox.Items.AddRange(Enum.GetNames<MonsterType>());
            m_Log.Info("Populated item special type.");
        }

        private void PopulateItemAttributeType()
        {
            AttributeTypeBox.Items.Clear();
            AttributeTypeBox.Items.AddRange(Enum.GetNames<AttributeType>());
            m_Log.Info("Populated item attribute type.");
        }

        private void PopulateItemQualityType()
        {
            ItemQualityBox.Items.Clear();
            ItemQualityBox.Items.AddRange(Enum.GetNames<QualityType>());
            m_Log.Info("Populated item quality type.");
        }

        private void PopulateReputationType()
        {
            RestrictReputationBox.Items.Clear();
            RestrictReputationBox.Items.AddRange(Enum.GetNames<ReputationType>());
            m_Log.Info("Populated item reputation type.");
        }

        private void PopulateItemTargetType()
        {
            TargetBox.Items.Clear();
            TargetBox.Items.AddRange(Enum.GetNames<TargetType>());
            TargetBox.Items.RemoveAt(1); // Remove nothing.
            m_Log.Info("Populated item target type.");
        }

        private void PopulateItemType()
        {
            var itemTypeList = Enum.GetNames<ItemType>().ToList();
            itemTypeList.RemoveRange(64, 9); // Remove everything after OptionalLuckyBag.
            ItemTypeBox.Items.Clear();
            ItemTypeBox.Items.AddRange([.. itemTypeList]);
            m_Log.Info("Populated item type.");
        }

        private void PopulateItemEquipType()
        {
            EquipTypeBox.Items.Clear();
            EquipTypeBox.Items.AddRange(Enum.GetNames<EquipType>());
            EquipTypeBox.Items.RemoveAt(EquipTypeBox.Items.Count - 1); // Remove last which is 'Max', that's not an equip type.
            m_Log.Info("Populated item equip type.");
        }

        private void PopulateDefaultValues()
        {
            ChestDropImg.Image = GFImageConverter.ToNetImage(BasicAssetDatabase.GetChestDropByIndex(0).Image.ToArray()); // It create a new file, this will need to be disposed off later.
            ItemIconImg.Image = GFImageConverter.ToNetImage(BasicAssetDatabase.GetItemImageByIndex(0).Image.ToArray()); // Same free it later.
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

        private void PopulateItemProperty(Item item)
        {
            m_currentItem = item;

            m_itemPanel.SetItem(item);
            m_itemPanel.Update();
            m_classPanel.SetItem(item);
            m_classPanel.Update();

            ItemIndexTxt.Text = item.Index.ToString();
            ItemImgList.SelectIndexByName(item.IconFilename);
            ModelIDTxt.Text = string.IsNullOrEmpty(item.ModelId) ? "None" : item.ModelId;
            DropChestBox.SelectIndexByName(item.ModelFilename);
            WeaponEffectIdUD.Value = item.WeaponEffectId;
            FlyEffectIdUD.Value = item.FlyEffectId;
            UsedEffectIdUD.Value = item.UsedEffectId;
            UsedSndList.SelectIndexByName(item.UsedSoundName);
            EnchanceEffectIdUD.Value = item.EnchanceEffectId;
            ItemTypeBox.SelectIndexByEnum((ItemType)item.ItemType);
            EquipTypeBox.SelectIndexByEnum((EquipType)item.EquipType);
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
            RangedAttackUD.Value = item.RangedAttack;
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
            SpecialTypeBox.SelectIndexByEnum((MonsterType)item.SpecialType);
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

            if (Constants.Parameters.TranslateAutoOnLoad)
            {
                var itemText = TItemDatabase.GetByIndex(item.Index);
                if (itemText != null)
                {
                    NameTxt.Text = itemText.Name;
                    TipTxt.Text = itemText.Description;
                }
            }
            else
            {
                NameTxt.Text = item.Name.ToString();
                TipTxt.Text = item.Tip;
            }

            // Update tooltip if the item changed.
            m_tooltipPanel.SetItem(item);
            m_tooltipPanel.Update();
        }

        private void UIItem_Load(object sender, EventArgs e)
        {
        }

        private void UIItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            ItemIconImg.Image?.Dispose();
            ChestDropImg.Image?.Dispose();
        }

        private void DropChestBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChestDropImg.Image?.Dispose(); // Dispose it to avoid memory leak !
            ChestDropImg.Image = GFImageConverter.ToNetImage(BasicAssetDatabase.GetChestDropByIndex(DropChestBox.SelectedIndex).Image.ToArray());
            if (m_currentItem != null)
                m_currentItem.ModelFilename = BasicAssetDatabase.GetChestDropByIndex(DropChestBox.SelectedIndex).Filename;
        }

        private void ItemImgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemIconImg.Image?.Dispose();

            var iconName = ItemImgList.Items[ItemImgList.SelectedIndex] as string ?? throw new InvalidCastException("Failed to update selected index image list, convertion to string failed !");
            if (string.IsNullOrEmpty(iconName))
            {
                m_Log.Error("Failed to update selected index image list, returned iconName is null or empty !");
                return;
            }

            var icon = BasicAssetDatabase.GetItemImageByFilename(iconName.ToLower());
            if (icon != null)
                ItemIconImg.Image = GFImageConverter.ToNetImage(icon.Image.ToArray());
            else
                ItemIconImg.Image = GFImageConverter.ToNetImage(BasicAssetDatabase.GetItemImageByIndex(0).Image.ToArray());
        }

        private void ItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var foundItem = GetCurrentItem();
            if (foundItem != null)
                PopulateItemProperty(foundItem);
        }

        private void UsedSndList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
            {
                var usedSoundName = UsedSndList.Items[UsedSndList.SelectedIndex] as string ?? throw new InvalidCastException("Failed to assign new used sound name, UsedSndList.Items[UsedSndList.SelectedIndex] as string returned null !");
                if (string.IsNullOrEmpty(usedSoundName))
                {
                    m_Log.Error("Failed to update used sound name, returned usedSoundName is null or empty !");
                    return;
                }
                m_currentItem.UsedSoundName = usedSoundName;
            }
        }

        private void TestSoundBtn_Click(object sender, EventArgs e)
        {
            // Avoid 0 because its "None"
            if (UsedSndList.SelectedIndex <= 0) return;

            var usedSoundName = UsedSndList.Items[UsedSndList.SelectedIndex] as string ?? throw new InvalidCastException("Failed to test sound, returned UsedSndList.Items[UsedSndList.SelectedIndex] is null !");
            if (string.IsNullOrEmpty(usedSoundName))
            {
                m_Log.Error("Failed to play used sound name, returned usedSoundName is null or empty !");
                return;
            }

            var sound = BasicAssetDatabase.GetSoundByFilename(usedSoundName);
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
                m_currentItem.RangedAttack = (int)RangedAttackUD.Value;
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
            var selectedEnumValue = Enum.GetValues<MonsterType>().ElementAtOrDefault(SpecialTypeBox.SelectedIndex); // Get enum value by index
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
            if (!m_tooltipPanel.IsVisible())
                m_tooltipPanel.Show(this);
        }

        private void AddNewItemBtn_Click(object sender, EventArgs e)
        {
            if (CItemDatabase.CreateNewItem(out var newIndex))
            {
                PopulateItemList();
                ItemList.SelectedIndex = newIndex <= 0 ? 0 : newIndex - 1; // Select the new item, -1 because SelectedIndex start at 0 and newIndex start at 1.
            }
        }

        private void ModelIDTxt_TextChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.ModelId = ModelIDTxt.Text;
        }

        private void SaveAndCloseBtn_Click(object sender, EventArgs e)
        {
            CItemDatabase.Save();
            Hide();
        }

        private void WeaponEffectIdUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.WeaponEffectId = (int)WeaponEffectIdUD.Value;
        }

        private void FlyEffectIdUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.FlyEffectId = (int)FlyEffectIdUD.Value;
        }

        private void UsedEffectIdUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.UsedEffectId = (int)UsedEffectIdUD.Value;
        }

        private void EnchanceEffectIdUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.EnchanceEffectId = (int)EnchanceEffectIdUD.Value;
        }
    }
}
