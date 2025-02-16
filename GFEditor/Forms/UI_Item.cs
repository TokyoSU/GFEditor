namespace GFEditor.Editor
{
    public partial class UI_Item : Form
    {
        private static readonly Logger m_Log = LogManager.GetLogger("UI_Item");
        private readonly Dictionary<ClassType, CheckBox> m_classCheckBoxDict;
        private readonly Dictionary<OpFlags, CheckBox> m_opCheckBoxDict;
        private readonly UI_TooltipViewer m_tooltipViewer = new();
        private Item? m_currentItem = null;
        private bool m_Visible;

        public UI_Item()
        {
            InitializeComponent();
            PopulateItemType();
            PopulateItemEquipType();
            PopulateItemTargetType();
            PopulateReputationType();
            PopulateItemQualityType();
            PopulateItemTimeLimitType();
            PopulateItemAuctionType();
            PopulateItemPriceType();
            PopulateItemSpecialType();
            PopulateItemAttributeType();
            PopulateItemEnchantTimeType();
            m_classCheckBoxDict = new Dictionary<ClassType, CheckBox>()
            {
                { ClassType.Novice, Novice },
                { ClassType.Fighter, Fighter },
                { ClassType.Warrior, Warrior },
                { ClassType.Paladin, Paladin },
                { ClassType.Berserker, Berserker },
                { ClassType.Hunter, Hunter },
                { ClassType.Archer, Archer },
                { ClassType.Ranger, Ranger },
                { ClassType.Assassin, Assassin },
                { ClassType.Acolyte, Acolyte },
                { ClassType.Priest, Priest },
                { ClassType.Cleric, Cleric },
                { ClassType.Sage, Sage },
                { ClassType.Spellcaster, Spellcaster },
                { ClassType.Mage, Mage },
                { ClassType.Wizard, Wizard },
                { ClassType.Necromancer, Necromancer },
                { ClassType.Warlord, Warlord },
                { ClassType.Templar, Templar },
                { ClassType.Sharpshooter, Sharpshooter },
                { ClassType.DarkStalker, Darkstalker },
                { ClassType.Prophet, Prophet },
                { ClassType.Mystic, Mystic },
                { ClassType.Archmage, Archmage },
                { ClassType.Demonologist, Demonologist },
                { ClassType.Mechanic, Mechanic },
                { ClassType.Machinist, Machinist },
                { ClassType.Enginner, Enginner },
                { ClassType.Demolisionist, Demolitionist },
                { ClassType.GearMaster, Gearmaster },
                { ClassType.Gunner, Gunner },
                { ClassType.Deathknight, Deathknight },
                { ClassType.Crusader, Crusader },
                { ClassType.Hawkeye, Hawkeye },
                { ClassType.Windshadow, Windshadow },
                { ClassType.Saint, Saint },
                { ClassType.Shaman, Shaman },
                { ClassType.Avatar, Avatar },
                { ClassType.Shadowlord, Shadowlord },
                { ClassType.Destroyer, Destroyer },
                { ClassType.HolyKnight, Holyknight },
                { ClassType.Predator, Predator },
                { ClassType.Shinobi, Shinobi },
                { ClassType.Archangel, Archangel },
                { ClassType.Druid, Druid },
                { ClassType.Warlock, Warlock },
                { ClassType.Shinigami, Shinigami },
                { ClassType.CogMaster, Cogmaster },
                { ClassType.Bombardier, Bombardier },
                { ClassType.MechMaster, Mechmaster },
                { ClassType.Artillerist, Artillerist },
                { ClassType.Wanderer, Wanderer },
                { ClassType.Drifter, Drifter },
                { ClassType.VoidRunner, Voidrunner },
                { ClassType.TimeTraveler, Timetraveler },
                { ClassType.Dimensionalist, Dimentionalist },
                { ClassType.KeyMaster, Keymaster },
                { ClassType.Reaper, Reaper },
                { ClassType.Chronomancer, Chronomancer },
                { ClassType.Phantom, Phantom },
                { ClassType.ChronoShifter, Chronoshifter }
            };
            m_opCheckBoxDict = new Dictionary<OpFlags, CheckBox>()
            {
                { OpFlags.CanUse, Useable },
                { OpFlags.NoDecrease, NoDecrease },
                { OpFlags.NoTrade, NoTrade },
                { OpFlags.NoDiscard, NoDiscard },
                { OpFlags.NoEnhance, NoEnchance },
                { OpFlags.NoRepair, NoRepair },
                { OpFlags.Combineable, Combinable },
                { OpFlags.BindOnEquip, BindOnEquip },
                { OpFlags.AccumTime, AccumTime },
                { OpFlags.NoSameBuff, NoSameBuff },
                { OpFlags.NoInBattle, NoInBattle },
                { OpFlags.NoInTown, NoInTown },
                { OpFlags.NoInCave, NoInCave },
                { OpFlags.NoInInstance, NoInInstance },
                { OpFlags.LinkToQuest, LinkQuest },
                { OpFlags.ForDead, ForDead },
                { OpFlags.Only1, Only1 },
                { OpFlags.Only2, Only2 },
                { OpFlags.Only3, Only3 },
                { OpFlags.Only4, Only4 },
                { OpFlags.Only5, Only5 },
                { OpFlags.Replaceable1, Replaceable1 },
                { OpFlags.Replaceable2, Replaceable2 },
                { OpFlags.Replaceable3, Replaceable3 },
                { OpFlags.Replaceable4, Replaceable4 },
                { OpFlags.Replaceable5, Replaceable5 },
                { OpFlags.NoInBattlefield, NoInBattlefield },
                { OpFlags.NoInField, NoInField },
                { OpFlags.NoTransNode, NoTransNode },
                { OpFlags.UnBindItem, UnbindItem },
                { OpFlags.OnlyEquip, OnlyEquip }
            };
            if (TEditorTranslate.Editor == null)
            {
                m_Log.Warn("Failed to translate restricted class panel, TEditorTranslate.Editor is null !");
                return;
            }
            m_classCheckBoxDict.TranslateClassText(TEditorTranslate.Editor.ItemClassPanel);
        }

        public bool IsVisible() => m_Visible;

        private void ItemForm_Shown(object sender, EventArgs e)
        {
            // Populating combobox and dropdown list.
            PopulateDropChestList();
            PopulateItemImageList();
            PopulateSoundList();
            PopulateItemList();
            PopulateDefaultValues();
            m_Visible = true;
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
                throw new AccessViolationException("Error populating the items list, index list is null, did the item database was loaded ?");
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

        private void PopulateItemEnchantTimeType()
        {
            EnchantTimeTypeBox.Items.Clear();
            EnchantTimeTypeBox.Items.AddRange(Enum.GetNames<TimeType>());
            m_Log.Info("Populated enchant time type.");
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
            TimeLimitTypeBox.SelectedIndex = 0;
            AuctionTypeBox.SelectedIndex = 0;
            AttributeTypeBox.SelectedIndex = 0;
            SpecialTypeBox.SelectedIndex = 0;
            EnchantTimeTypeBox.SelectedIndex = 0;
        }

        private void PopulateItemProperty(Item item)
        {
            m_currentItem = item;

            // Update tooltip if the item changed.
            m_tooltipViewer.SetItem(m_currentItem);
            m_tooltipViewer.Update();

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
            DropRateUD.Value = item.DropRate;
            DropIndexUD.Value = item.DropIndex;
            TimeLimitTypeBox.SelectIndexByEnum((TimeLimitType)item.LimitType);
            TimeLimitUD.Value = item.DueDateTime;
            BackpackSizeUD.Value = item.BackpackSize;
            SocketMaxUD.Value = item.SocketMax;
            SocketRateUD.Value = item.SocketRate;
            MaxStackUD.Value = item.MaxStack;
            PriceTypeBox.SelectIndexByEnum((MerchantCoinType)item.ShopPriceType);
            PriceUD.Value = item.Price;
            RestrictEventPosTxt.Text = item.RestrictEventPosition;
            MissionIndexUD.Value = item.MissionIndex;
            LogLevelUD.Value = item.LogLevel;
            AuctionTypeBox.SelectIndexByEnum((AuctionType)item.AuctionType);
            ExtraData1UD.Value = item.ExtraData01;
            ExtraData2UD.Value = item.ExtraData02;
            ExtraData3UD.Value = item.ExtraData03;

            var itemName = item.Name.Length > 0 ? item.Name : string.Empty;
            var itemDesc = item.Tip.Length > 0 ? item.Tip : string.Empty;
            if (Constants.Parameters.TranslateAutoOnLoad)
            {
                var itemText = TItemDatabase.GetByIndex(item.Index);
                NameTxt.Text = itemText != null ? (itemText.Name.Length > 0 ? itemText.Name : itemName) : itemName;
                TipTxt.Text = itemText != null ? (itemText.Description.Length > 0 ? itemText.Description : itemDesc) : itemDesc;
            }
            else
            {
                NameTxt.Text = itemName;
                TipTxt.Text = itemDesc;
            }

            MaxHPUD.Value = item.MaxHp;
            MaxMPUD.Value = item.MaxMp;
            StrUD.Value = item.Str;
            VitUD.Value = item.Vit;
            IntUD.Value = item.Int;
            WilUD.Value = item.Wil;
            AgiUD.Value = item.Agi;
            AveragePhysicalUD.Value = item.AvgPhysicoDamage;
            RandomPhysicalUD.Value = item.RandPhysicoDamage;
            AttackRangeUD.Value = item.AttackRange;
            AttackSpeedUD.Value = item.AttackSpeed;
            AttackUD.Value = item.Attack;
            RangedAttackUD.Value = item.RangedAttack;
            PhysicalDefenceUD.Value = item.PhysicoDefence;
            MagicAttackUD.Value = item.MagicDamage;
            MagicalDefenceUD.Value = item.MagicDefence;
            MaxDurabilityUD.Value = item.MaxDurability;
            HitRateUD.Value = item.HitRate;
            DodgeRateUD.Value = item.EvadeRate;
            PhysicalCriticalRateUD.Value = item.PhysicoCriticalRate;
            PhysicalCriticalDamageUD.Value = item.PhysicoCriticalDamage;
            MagicalCriticalRateUD.Value = item.MagicCriticalRate;
            MagicalCriticalDamageUD.Value = item.MagicCriticalDamage;
            PhysicalPenetrationUD.Value = item.PhysicalPenetration;
            MagicalPenetrationUD.Value = item.MagicalPenetration;
            PhysicalPenetrationDefenceUD.Value = item.PhysicalPenetrationDefence;
            MagicalPenetrationDefenceUD.Value = item.MagicalPenetrationDefence;
            BlockRateUD.Value = item.BlockRate;

            AttributeTypeBox.SelectIndexByEnum((AttributeType)item.Attribute);
            AttributeDamageUD.Value = item.AttributeDamage;
            AttributeRateUD.Value = item.AttributeRate;
            AttributeResistanceUD.Value = item.AttributeResist;

            SpecialTypeBox.SelectIndexByEnum((MonsterType)item.SpecialType);
            SpecialRateUD.Value = item.SpecialRate;
            SpecialDamageUD.Value = item.SpecialDamage;

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

            PopulateItemClassCheckbox(item);
            PopulateOpFlags(item);
        }

        private void PopulateItemClassCheckbox(Item item)
        {
            if (item == null)
            {
                m_Log.Error("Failed to populate item class restriction, item is null, was it assigned beforehand ?");
                return;
            }
            var flag = (ClassType)item.RestrictClass;
            foreach (var entry in m_classCheckBoxDict)
            {
                if (flag.HasFlag(entry.Key))
                    entry.Value.Checked = true;
                else
                    entry.Value.Checked = false;
            }
        }

        private void PopulateOpFlags(Item item)
        {
            if (item == null)
            {
                m_Log.Info("Failed to populate item opflags, item is null, was it assigned beforehand ?");
                return;
            }
            var flag = (OpFlags)item.OpFlags;
            foreach (var entry in m_opCheckBoxDict)
            {
                if (flag.HasFlag(entry.Key))
                    entry.Value.Checked = true;
                else
                    entry.Value.Checked = false;
            }
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
            {
                // If it's translated, update the translate instead !
                if (Constants.Parameters.TranslateAutoOnLoad)
                    TItemDatabase.UpdateNewDescription(m_currentItem.Index, TipTxt.Text);
                else // Else update the tip of item.
                    m_currentItem.Tip = TipTxt.Text;
                m_tooltipViewer.UpdateTooltip();
                m_tooltipViewer.Update();
            }
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
            if (!m_tooltipViewer.IsVisible())
                m_tooltipViewer.Show(this);
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
            m_tooltipViewer.SaveAndClose();
            Hide();
            m_Visible = false;
            CItemDatabase.Save();
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

        private void PhysicalDefenceUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.PhysicoDefence = (int)PhysicalDefenceUD.Value;
        }

        private void MagicalDefenceUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MagicDefence = (int)MagicalDefenceUD.Value;
        }

        private void MaxDurabilityUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MaxDurability = (int)MaxDurabilityUD.Value;
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

        private void AveragePhysicalUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.AvgPhysicoDamage = (int)AveragePhysicalUD.Value;
        }

        private void RandomPhysicalUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.RandPhysicoDamage = (int)RandomPhysicalUD.Value;
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
                m_currentItem.EvadeRate = (int)DodgeRateUD.Value;
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

        private void PhysicalCriticalDamageUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.PhysicoCriticalDamage = (int)PhysicalCriticalDamageUD.Value;
        }

        private void MagicalCriticalDamageUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MagicCriticalDamage = (int)MagicalCriticalDamageUD.Value;
        }

        private void PhysicalPenetrationDefenceUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.PhysicalPenetrationDefence = (int)PhysicalPenetrationDefenceUD.Value;
        }

        private void MagicalPenetrationDefenceUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.MagicalPenetrationDefence = (int)MagicalPenetrationDefenceUD.Value;
        }

        private void SpecialTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<MonsterType>().ElementAtOrDefault(SpecialTypeBox.SelectedIndex); // Get enum value by index
            if (m_currentItem != null)
                m_currentItem.SpecialType = (int)selectedEnumValue;
        }

        private void SpecialDamageUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.SpecialDamage = (int)SpecialDamageUD.Value;
        }

        private void SpecialRateUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.SpecialRate = (int)SpecialRateUD.Value;
        }

        private void AttributeTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnumValue = Enum.GetValues<AttributeType>().ElementAtOrDefault(AttributeTypeBox.SelectedIndex); // Get enum value by index
            if (m_currentItem != null)
                m_currentItem.Attribute = (int)selectedEnumValue;
        }

        private void AttributeDamageUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.AttributeDamage = (int)AttributeDamageUD.Value;
        }

        private void AttributeRateUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.AttributeRate = (int)AttributeRateUD.Value;
        }

        private void AttributeResistanceUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.AttributeResist = (int)AttributeResistanceUD.Value;
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

        private void ElfSkillIndexUD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.ElfSkillIndex = (int)ElfSkillIndexUD.Value;
        }

        private void TreasureBuff1UD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.TreasureBuffs01 = (int)TreasureBuff1UD.Value;
        }

        private void TreasureBuff2UD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.TreasureBuffs02 = (int)TreasureBuff2UD.Value;
        }

        private void TreasureBuff3UD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.TreasureBuffs03 = (int)TreasureBuff3UD.Value;
        }

        private void TreasureBuff4UD_ValueChanged(object sender, EventArgs e)
        {
            if (m_currentItem != null)
                m_currentItem.TreasureBuffs04 = (int)TreasureBuff4UD.Value;
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

        private void EnchantTimeTypeBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void Novice_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Novice, ClassType.Novice);
        }

        private void Fighter_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Fighter, ClassType.Fighter);
        }

        private void Warrior_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Warrior, ClassType.Warrior);
        }

        private void Berserker_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Berserker, ClassType.Berserker);
        }

        private void Warlord_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Warlord, ClassType.Warlord);
        }

        private void Deathknight_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Deathknight, ClassType.Deathknight);
        }

        private void Destroyer_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Destroyer, ClassType.Destroyer);
        }

        private void Paladin_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Paladin, ClassType.Paladin);
        }

        private void Templar_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Templar, ClassType.Templar);
        }

        private void Crusader_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Crusader, ClassType.Crusader);
        }

        private void Holyknight_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Holyknight, ClassType.HolyKnight);
        }

        private void Hunter_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Hunter, ClassType.Hunter);
        }

        private void Archer_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Archer, ClassType.Archer);
        }

        private void Ranger_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Ranger, ClassType.Ranger);
        }

        private void Sharpshooter_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Sharpshooter, ClassType.Sharpshooter);
        }

        private void Hawkeye_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Hawkeye, ClassType.Hawkeye);
        }

        private void Predator_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Predator, ClassType.Predator);
        }

        private void Assassin_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Assassin, ClassType.Assassin);
        }

        private void Darkstalker_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Darkstalker, ClassType.DarkStalker);
        }

        private void Windshadow_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Windshadow, ClassType.Windshadow);
        }

        private void Shinobi_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Shinobi, ClassType.Shinobi);
        }

        private void Acolyte_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Acolyte, ClassType.Acolyte);
        }

        private void Priest_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Priest, ClassType.Priest);
        }

        private void Cleric_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Cleric, ClassType.Cleric);
        }

        private void Prophet_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Prophet, ClassType.Prophet);
        }

        private void Saint_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Saint, ClassType.Saint);
        }

        private void Archangel_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Archangel, ClassType.Archangel);
        }

        private void Sage_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Sage, ClassType.Sage);
        }

        private void Mystic_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Mystic, ClassType.Mystic);
        }

        private void Shaman_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Shaman, ClassType.Shaman);
        }

        private void Druid_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Druid, ClassType.Druid);
        }

        private void Spellcaster_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Spellcaster, ClassType.Spellcaster);
        }

        private void Mage_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Mage, ClassType.Mage);
        }

        private void Wizard_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Wizard, ClassType.Wizard);
        }

        private void Archmage_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Archmage, ClassType.Archmage);
        }

        private void Avatar_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Avatar, ClassType.Avatar);
        }

        private void Warlock_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Warlock, ClassType.Warlock);
        }

        private void Necromancer_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Necromancer, ClassType.Necromancer);
        }

        private void Demonologist_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Demonologist, ClassType.Demonologist);
        }

        private void Shadowlord_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Shadowlord, ClassType.Shadowlord);
        }

        private void Shinigami_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Shinigami, ClassType.Shinigami);
        }

        private void Mechanic_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Mechanic, ClassType.Mechanic);
        }

        private void Machinist_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Machinist, ClassType.Machinist);
        }

        private void Demolitionist_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Demolitionist, ClassType.Demolisionist);
        }

        private void Gunner_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Gunner, ClassType.Gunner);
        }

        private void Bombardier_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Bombardier, ClassType.Bombardier);
        }

        private void Artillerist_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Artillerist, ClassType.Artillerist);
        }

        private void Enginner_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Enginner, ClassType.Enginner);
        }

        private void Gearmaster_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Gearmaster, ClassType.GearMaster);
        }

        private void Cogmaster_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Cogmaster, ClassType.CogMaster);
        }

        private void Mechmaster_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Mechmaster, ClassType.MechMaster);
        }

        private void Wanderer_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Wanderer, ClassType.Wanderer);
        }

        private void Drifter_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Drifter, ClassType.Drifter);
        }

        private void Timetraveler_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Timetraveler, ClassType.TimeTraveler);
        }

        private void Keymaster_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Keymaster, ClassType.KeyMaster);
        }

        private void Chronomancer_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Chronomancer, ClassType.Chronomancer);
        }

        private void Chronoshifter_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Chronoshifter, ClassType.ChronoShifter);
        }

        private void Voidrunner_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Voidrunner, ClassType.VoidRunner);
        }

        private void Dimentionalist_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Dimentionalist, ClassType.Dimensionalist);
        }

        private void Reaper_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Reaper, ClassType.Reaper);
        }

        private void Phantom_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetClassFlags(Phantom, ClassType.Phantom);
        }

        private void Useable_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Useable, OpFlags.CanUse);
        }

        private void Combinable_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Combinable, OpFlags.Combineable);
        }

        private void BindOnEquip_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(BindOnEquip, OpFlags.BindOnEquip);
        }

        private void AccumTime_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(AccumTime, OpFlags.AccumTime);
        }

        private void LinkQuest_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(LinkQuest, OpFlags.LinkToQuest);
        }

        private void ForDead_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(ForDead, OpFlags.ForDead);
        }

        private void UnbindItem_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(UnbindItem, OpFlags.UnBindItem);
        }

        private void OnlyEquip_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(OnlyEquip, OpFlags.OnlyEquip);
        }

        private void NoDecrease_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(NoDecrease, OpFlags.NoDecrease);
        }

        private void NoTrade_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(NoTrade, OpFlags.NoTrade);
        }

        private void NoDiscard_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(NoDiscard, OpFlags.NoDiscard);
        }

        private void NoEnchance_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(NoEnchance, OpFlags.NoEnhance);
        }

        private void NoRepair_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(NoRepair, OpFlags.NoRepair);
        }

        private void NoSameBuff_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(NoSameBuff, OpFlags.NoSameBuff);
        }

        private void NoInBattle_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(NoInBattle, OpFlags.NoInBattle);
        }

        private void NoInTown_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(NoInTown, OpFlags.NoInTown);
        }

        private void NoInCave_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(NoInCave, OpFlags.NoInCave);
        }

        private void NoInInstance_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(NoInInstance, OpFlags.NoInInstance);
        }

        private void NoInBattlefield_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Useable, OpFlags.CanUse);
        }

        private void NoInField_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(NoInField, OpFlags.NoInField);
        }

        private void NoTransNode_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(NoTransNode, OpFlags.NoTransNode);
        }

        private void Only1_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Only1, OpFlags.Only1);
        }

        private void Only2_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Only2, OpFlags.Only2);
        }

        private void Only3_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Only3, OpFlags.Only3);
        }

        private void Only4_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Only4, OpFlags.Only4);
        }

        private void Only5_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Only5, OpFlags.Only5);
        }

        private void Replaceable1_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Replaceable1, OpFlags.Replaceable1);
        }

        private void Replaceable2_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Replaceable2, OpFlags.Replaceable2);
        }

        private void Replaceable3_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Replaceable3, OpFlags.Replaceable3);
        }

        private void Replaceable4_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Replaceable4, OpFlags.Replaceable4);
        }

        private void Replaceable5_CheckedChanged(object sender, EventArgs e)
        {
            m_currentItem?.SetOpFlags(Replaceable5, OpFlags.Replaceable5);
        }
    }
}
