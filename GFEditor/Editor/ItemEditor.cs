using GFEditor.Structs.Query;

namespace GFEditor.Editor
{
    public static class ItemEditor
    {
        private static readonly TranslatedValues m_Translate = TranslateUtils.Json.TranslatedValues;
        private static readonly ItemQuery m_ItemList = new();
        private static Action<int>? m_OnItemSelected;
        private static string[] _ItemsStringList = [];
        private static int _SelectedListIndex = 0;
        private static int _DropTypeIndex = 0;
        private static int _AlignementIndex = 0;
        private static int _AttributeIndex = 0;
        private static int _PriceIndex = 0;
        private static int _SpecialIndex = 0;
        private static int _EnchantTimeTypeIndex = 0;
        private static int _EnchantTypeIndex = 0;
        private static int _AuctionTypeIndex = 0;
        private static int _QualityIndex = 0;
        private static int _ItemTypeIndex = 0;
        private static int _EquipTypeIndex = 0;
        private static int _TimeLimitTypeIndex = 0;
        private static bool _IsOpen = false;

        private static void Initialize()
        {
            if (m_ItemList.HasValues()) // Avoid loading item each time the editor open...
                return;

            var filePath = ConfigUtils.GetPath("Data\\DB\\C_Item.ini");
            if (filePath.FileExist())
            {
                m_OnItemSelected += OnItemSelectedCallback;
                m_ItemList.ReadFile(filePath);
                return;
            }

            GuiNotify.Show(ImGuiToastType.Error, "Item Editor", "Failed to load item list, file probably not found !");
        }

        private static void OnItemSelectedCallback(int listIndex)
        {
            // Initialize value when it's selected !
            var strIndex = _ItemsStringList[_SelectedListIndex].AsUInt();
            if (m_ItemList.Get(strIndex, out var item))
            {
                _TimeLimitTypeIndex = (int)item.m_nLimitType;
                _EquipTypeIndex = (int)item.m_eEquipType;
                _ItemTypeIndex = (int)item.m_eItemType;
                _QualityIndex = (int)item.m_eItemQuality;
                _AlignementIndex = (int)item.m_eRestrictAlign;
                _AttributeIndex = (int)item.m_eAttribute;
                _PriceIndex = (int)item.m_nShopPriceType;
                _SpecialIndex = (int)item.m_eSpecialType;
                _EnchantTypeIndex = (int)item.m_eEnchantType;
                _EnchantTimeTypeIndex = (int)item.m_eEnchantTimeType;
                _AuctionTypeIndex = (int)item.m_eAuctionType;
                _DropTypeIndex = (int)GetChestTypeByName(item.m_nDropFilename);
            }
        }

        public static void DrawContent()
        {
            if (!_IsOpen) return;

            // Now that the item is loaded, update the item list !
            if (_ItemsStringList.Length <= 0 && m_ItemList.IsLoaded())
                ResetStringList();

            DrawItemList();
            DrawItemProperties();
        }

        private static void DrawItemList()
        {
            if (ImGui.Begin(m_Translate.ItemListName, ImGuiWindowFlags.AlwaysAutoResize))
            {
                // Now create the item list window.
                var regionSize = ImGui.GetContentRegionAvail();
                ImGui.SetNextWindowSize(new Vector2(regionSize.X - 1f, regionSize.Y - 40f));
                if (ImGuiUtils.ListBox("##ItemList", ref _SelectedListIndex, _ItemsStringList))
                    m_OnItemSelected?.Invoke(_SelectedListIndex);

                ImGui.Separator();
                if (ImGuiUtils.DoubleButton(m_Translate.AddBtnName, m_Translate.RemoveBtnName, out var add, out var remove))
                {
                    if (add) OnListAdd();
                    if (remove) OnListRemove();
                }
            }
            ImGui.End();
        }

        private static void DrawItemProperties()
        {
            if (ImGui.Begin(m_Translate.ItemEditorName, ref _IsOpen, ImGuiWindowFlags.AlwaysAutoResize) && _ItemsStringList.Length > 0)
            {
                var strIndex = _ItemsStringList[_SelectedListIndex].AsUInt();
                if (m_ItemList.Get(strIndex, out var item))
                {
                    ImGuiUtils.Label(m_Translate.HeaderItemIndex + ": " + item.m_nId, false);
                    ImGuiUtils.InputText(m_Translate.HeaderItemName + ": ", ref item.m_kName);
                    ImGuiUtils.InputText(m_Translate.HeaderItemModel + ": ", ref item.m_nModelFilename);
                    ImGuiUtils.InputText(m_Translate.HeaderItemIcon + ":", ref item.m_kIconFilename);

                    var image = IconItem.GetByName(item.m_kIconFilename);
                    if (image != null)
                    {
                        ImGui.SameLine();
                        ImGuiUtils.Image(image, false);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemBasics))
                    {
                        ImGuiUtils.ComboBoxEnum(m_Translate.ItemQualityName, ref _QualityIndex, out item.m_eItemQuality, EItemQuality.Max);
                        ImGuiUtils.ComboBoxEnum(m_Translate.ItemTypeName, ref _ItemTypeIndex, out item.m_eItemType, EItemType.OpenUIStart, EItemType.OpenUIEnd, EItemType.Max);
                        ImGuiUtils.ComboBoxEnum(m_Translate.EquipTypeName, ref _EquipTypeIndex, out item.m_eEquipType, EEquipType.Unknown, EEquipType.Max);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemDrop))
                    {
                        ImGuiUtils.InputUInt(m_Translate.DropIndexName, ref item.m_nDropIndex);
                        ImGuiUtils.InputChar(m_Translate.DropRateName, ref item.m_nDropRate);
                        ImGuiUtils.InputText(m_Translate.HeaderDropName, ref item.m_nDropFilename);
                        ImGuiUtils.ComboBoxEnum(m_Translate.DropTypeName, ref _DropTypeIndex, out EChestType dropType, EChestType.Max);
                        if (item.m_nDropFilename.IsValid())
                        {
                            var drop = ImageChest.GetByName(item.m_nDropFilename);
                            if (drop != null)
                            {
                                ImGui.SameLine();
                                ImGuiUtils.ImageSized(drop, new Vector2(128, 128));
                            }
                        }
                    }
                    
                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemEffects))
                    {
                        ImGuiUtils.InputUInt("Weapon effect", ref item.m_nWeaponEffectId);
                        ImGuiUtils.InputUInt("Fly effect", ref item.m_nFlyEffectId);
                        ImGuiUtils.InputUInt("Used effect", ref item.m_nUsedEffectId);
                        ImGuiUtils.InputUInt("Enchanced effect", ref item.m_nEnhanceEffectId);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemRestriction))
                    {
                        ImGuiUtils.InputUShort("Item Group", ref item.m_nItemGroup);
                        ImGuiUtils.InputByte("Minimum Level", ref item.m_nRestrictLevel);
                        ImGuiUtils.InputByte("Maximum Level", ref item.m_nRestrictMaxLevel);
                        ImGuiUtils.InputUShort("Stack Size", ref item.m_nMaxStack);

                        ImGuiUtils.SetOffsetPos(new Vector2(15f, 0f));
                        if (ImGui.CollapsingHeader(m_Translate.HeaderItemRestrictionTime))
                        {
                            ImGuiUtils.ComboBoxEnum("Time Limit Type", ref _TimeLimitTypeIndex, out item.m_nLimitType, ELimitTimeType.Max);
                            ImGuiUtils.InputULong("Time Limit", ref item.m_nDueDateTime);
                        }

                        ImGuiUtils.SetOffsetPos(new Vector2(15f, 0f));
                        if (ImGui.CollapsingHeader(m_Translate.HeaderItemClass))
                        {
                            ItemEditorUtils.DrawClassCheckbox(item, ERestrictClass.Novice, 30f);
                            ItemEditorUtils.DrawClassSection(item, m_Translate.FighterSection, 2f, ERestrictClass.Fighter, BasicClassType.Fighter);
                            ItemEditorUtils.DrawClassSection(item, m_Translate.HunterSection, 2f, ERestrictClass.Hunter, BasicClassType.Hunter);
                            ItemEditorUtils.DrawClassSection(item, m_Translate.AcolyteSection, 2f, ERestrictClass.Acolyte, BasicClassType.Acolyte);
                            ItemEditorUtils.DrawClassSection(item, m_Translate.SpellcasterSection, 2f, ERestrictClass.Spellcaster, BasicClassType.Spellcaster);
                            ItemEditorUtils.DrawClassSection(item, m_Translate.MechanicSection, 2f, ERestrictClass.Mechanic, BasicClassType.Mechanic);
                            ItemEditorUtils.DrawClassSection(item, m_Translate.WandererSection, 2f, ERestrictClass.Wanderer, BasicClassType.Wanderer);
                        }
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemFlags))
                    {
                        ImGuiUtils.SetOffsetPos(new Vector2(15f, 0f));
                        if (ImGui.CollapsingHeader(m_Translate.OpFlags))
                        {
                            var opFlags = Enum.GetValues<EItemOpFlags>();
                            foreach (var opFlag in opFlags)
                            {
                                if (opFlag == EItemOpFlags.None) continue;
                                ItemEditorUtils.DrawOpFlagParameter(item, opFlag.ToString(), opFlag);
                            }
                            item.ProcessOnlyAndReplaceableFlags();
                        }

                        ImGuiUtils.SetOffsetPos(new Vector2(15f, 0f));
                        if (ImGui.CollapsingHeader(m_Translate.OpFlagsPlus))
                        {
                            var opFlagsPlus = Enum.GetValues<EItemOpFlagsPlus>();
                            foreach (var opFlagPlus in opFlagsPlus)
                            {
                                if (opFlagPlus == EItemOpFlagsPlus.None) continue;
                                ItemEditorUtils.DrawOpFlagPlusParameter(item, opFlagPlus.ToString(), opFlagPlus);
                            }
                        }
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemReputation))
                    {
                        ImGuiUtils.ComboBoxEnum("Reputation Type", ref _AlignementIndex, out item.m_eRestrictAlign, EAlignement.End, EAlignement.GroupEnd);
                        ImGuiUtils.InputULong("Reputation Value", ref item.m_nRestrictPrestige);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemStats))
                    {
                        ImGuiUtils.InputULong("Health", ref item.m_nMaxHp);
                        ImGuiUtils.InputULong("Mana", ref item.m_nMaxMp);
                        ImGuiUtils.InputShort("Str", ref item.m_nStr);
                        ImGuiUtils.InputShort("Vit", ref item.m_nVit);
                        ImGuiUtils.InputShort("Int", ref item.m_nInt);
                        ImGuiUtils.InputShort("Wil", ref item.m_nWil);
                        ImGuiUtils.InputShort("Agi", ref item.m_nDex);
                        ImGuiUtils.InputLong("Casting Time", ref item.m_nCastingTime);
                        ImGuiUtils.InputULong("Physical Attack", ref item.m_nAttack);
                        ImGuiUtils.InputULong("Ranged Attack", ref item.m_nRangeDamage);
                        ImGuiUtils.InputULong("Magical Attack", ref item.m_nMagicDamage);
                        ImGuiUtils.InputULong("Physical Attack (Average)", ref item.m_nAvgPhysicalDamage);
                        ImGuiUtils.InputULong("Physical Attack (Random)", ref item.m_nRandPhysicalDamage);
                        ImGuiUtils.InputShort("Physical Penetration", ref item.m_nPhysicalPenetration);
                        ImGuiUtils.InputShort("Magical Penetration", ref item.m_nMagicalPenetration);
                        ImGuiUtils.InputULong("Physical Defence", ref item.m_nPhysicalDefence);
                        ImGuiUtils.InputULong("Magical Defence", ref item.m_nMagicDefence);
                        ImGuiUtils.InputShort("Physical Penetration Defence", ref item.m_nPhysicalPenetrationDefence);
                        ImGuiUtils.InputShort("Magical Penetration Defence", ref item.m_nMagicalPenetrationDefence);
                        ImGuiUtils.InputUShort("Attack Range", ref item.m_nAttackRange);
                        if (item.m_nAttackSpeed < 8) // Can't be less than 0.8 or the server crash !
                            item.m_nAttackSpeed = 8;
                        ImGuiUtils.InputUShort("Attack Speed", ref item.m_nAttackSpeed);
                        ImGuiUtils.InputChar("Hit Rate", ref item.m_nHitRate);
                        ImGuiUtils.InputChar("Dodge Rate", ref item.m_nDodgeRate);
                        ImGuiUtils.InputChar("Block Rate", ref item.m_nBlockRate);
                        ImGuiUtils.InputShort("Physical Critical Rate", ref item.m_nPhysicalCriticalRate);
                        ImGuiUtils.InputShort("Magical Critical Rate", ref item.m_nMagicCriticalRate);
                        ImGuiUtils.InputULong("Physical Critical Damage", ref item.m_nPhysicalCriticalDamage);
                        ImGuiUtils.InputULong("Magical Critical Damage", ref item.m_nMagicCriticalDamage);
                        ImGuiUtils.InputUShort("Durability", ref item.m_nMaxDurability);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemAttribute))
                    {
                        ImGuiUtils.ComboBoxEnum("Attribute Type", ref _AttributeIndex, out item.m_eAttribute, EAttrResist.Max);
                        ImGuiUtils.InputULong("Attribute Damage", ref item.m_nAttributeDamage);
                        ImGuiUtils.InputShort("Attribute Rate", ref item.m_nAttributeRate);
                        ImGuiUtils.InputULong("Attribute Resistance", ref item.m_nAttributeResist);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemEnchantments))
                    {
                        ImGuiUtils.ComboBoxEnum("Enchant Type", ref _EnchantTypeIndex, out item.m_eEnchantType, EBuffIconType.Max);
                        ImGuiUtils.InputInt("Enchant Index", ref item.m_nEnchantId);
                        ImGuiUtils.ComboBoxEnum("Enchant Time Type", ref _EnchantTimeTypeIndex, out item.m_eEnchantTimeType, ETimeType.Max);
                        ImGuiUtils.InputLong("Enchant Duration", ref item.m_nEnchantDuration);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemCooldown))
                    {
                        ImGuiUtils.InputLong("Cooldown Time", ref item.m_nCoolDownTime);
                        ImGuiUtils.InputUShort("Cooldown Group", ref item.m_nCoolDownGroup);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemElf))
                    {
                        ImGuiUtils.InputUShort("Elf Skill", ref item.m_nElfSkillId);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemSpecial))
                    {
                        ImGuiUtils.ComboBoxEnum("Special Type", ref _SpecialIndex, out item.m_eSpecialType);
                        ImGuiUtils.InputULong("Special Damage", ref item.m_nSpecialDamage);
                        ImGuiUtils.InputShort("Special Rate", ref item.m_nSpecialRate);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemPrice))
                    {
                        ImGuiUtils.ComboBoxEnum("Price Type", ref _PriceIndex, out item.m_nShopPriceType);
                        ImGuiUtils.InputULong("Price", ref item.m_nSysPrice);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemSockets))
                    {
                        ImGuiUtils.InputByte("Socket Max", ref item.m_nMaxSocket);
                        ImGuiUtils.InputChar("Socket Rate", ref item.m_nSocketRate);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemRebirth))
                    {
                        ImGuiUtils.InputShort("Minimum Required", ref item.m_nRebirthCount);
                        ImGuiUtils.InputShort("Max Score", ref item.m_nRebirthMaxScore);
                        ImGuiUtils.InputShort("Score", ref item.m_nRebirthScore);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemMiscellaneous))
                    {
                        ImGuiUtils.InputByte("Backpack Size", ref item.m_nBackpackSize);
                        ImGuiUtils.InputInt("Treasure Buffs 1", ref item.m_kTreasureBuffs1);
                        ImGuiUtils.InputInt("Treasure Buffs 2", ref item.m_kTreasureBuffs2);
                        ImGuiUtils.InputInt("Treasure Buffs 3", ref item.m_kTreasureBuffs3);
                        ImGuiUtils.InputInt("Treasure Buffs 4", ref item.m_kTreasureBuffs4);
                        ImGuiUtils.InputLong("Extra Data 1", ref item.m_kExtraData1);
                        ImGuiUtils.InputLong("Extra Data 2", ref item.m_kExtraData2);
                        ImGuiUtils.InputLong("Extra Data 3", ref item.m_kExtraData3);
                        ImGuiUtils.InputByte("Log Level", ref item.m_nLogLevel);
                    }
                    
                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemAuction))
                    {
                        ImGuiUtils.ComboBoxEnum("Auction Type", ref _AuctionTypeIndex, out item.m_eAuctionType, EAuctionType.Max);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemExperience))
                    {
                        ImGuiUtils.InputShort("Expert Max Level", ref item.m_nExpertLevel);
                        ImGuiUtils.InputInt("Expert Enchant Index", ref item.m_nExpertEnchantId);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemMissionAndEvents))
                    {
                        ImGuiUtils.InputUInt("Mission Position ID", ref item.m_nMissionPosId);
                        ImGuiUtils.InputText("Restrict Event Position IDs", ref item.m_nRestrictEventPosId);
                    }

                    item.ProcessClassRestriction();
                    item.ProcessOpFlags();
                    item.ProcessOpFlagsPlus();
                }
            }
            ImGui.End();
        }

        public static void Show()
        {
            if (!_IsOpen)
            {
                Initialize();
                _IsOpen = true;
            }
            else
            {
                Dispose();
                _IsOpen = false;
            }
        }

        private static void ResetStringList()
        {
            _ItemsStringList = m_ItemList.GetAllValues().Select(e => e.m_nId).ToStringArray();
        }

        private static void OnListAdd()
        {
            GuiNotify.Show(ImGuiToastType.Warning, "ItemEditor", "Add item is not implemented yet !");
        }

        private static void OnListRemove()
        {
            GuiNotify.Show(ImGuiToastType.Warning, "ItemEditor", "Remove item is not implemented yet !");
        }

        private static EChestType GetChestTypeByName(string name)
        {
            return name switch
            {
                "G00000" => EChestType.None,
                "G00001" => EChestType.Equipment,
                "G00002" => EChestType.Quest,
                "G00003" => EChestType.Basic,
                "G00004" => EChestType.Cursed,
                "G00005" => EChestType.Special,
                "G00006" => EChestType.Green,
                "G00007" => EChestType.Legendary,
                "G00008" => EChestType.Blue,
                "G00009" => EChestType.EquipmentGlowing,
                "G00010" => EChestType.GreenGlowing,
                _ => EChestType.None,
            };
        }

        public static void Dispose()
        {
            ImageChest.Dispose();
            IconItem.Dispose();
            m_OnItemSelected = null;
            _ItemsStringList = [];
            _SelectedListIndex = 0;
        }

        public static void Save()
        {
            var str = new StringBuilder();
            str.AppendLine($"|{m_ItemList.GetVersionStr()}|{m_ItemList.GetColumnCount()}|");
            foreach (var item in m_ItemList.GetAllValues())
            {
                str.AppendLine(item.GetString());
            }

            try
            {
                File.WriteAllText(ConfigUtils.GetPath("Data\\DB\\C_Item.ini"), str.ToString(), Encoding.GetEncoding("Big5"));
                File.WriteAllText(ConfigUtils.GetPath("Data\\DB\\S_Item.ini"), str.ToString(), Encoding.GetEncoding("Big5"));
                GuiNotify.Show(ImGuiToastType.Success, "Item Editor", "C/S_Item saved successfully !");
            }
            catch (Exception ex)
            {
                GuiNotify.Show(ImGuiToastType.Error, "Item Editor", "Failed to save C/S_Item: {0}", ex.Message);
            }
        }
    }
}
