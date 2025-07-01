namespace GFEditor.Editor
{
    public class ItemEditor
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private static readonly TranslatedValues m_Translate = TranslateUtils.Json.TranslatedValues;
        private const string m_itemIconPath = "textures\\itemicon";
        private const string m_dropPath = "textures\\chest";
        private readonly ItemEditorUtils m_itemEditorUtils = new();
        private readonly ItemQuery m_ItemList = new();
        private readonly ClassesTextures m_ClassImages = new();
        private readonly Dictionary<string, Texture2D> m_iconsImages = [];
        private readonly Dictionary<string, Texture2D> m_dropImages = [];
        private string[] m_ItemsStringList = [];
        private int m_SelectedListIndex = 0;
        public bool IsOpen = false;
        static int ReputationIndex = -1;
        static int selectedValue = 0;

        private static void EditorError(string message)
        {
            m_Log.Error(message);
            ImGuiNotify.Insert(new ImGuiToast(ImGuiToastType.Error, "Item Editor", 2000, message));
        }

        public void Init()
        {
            if (m_ItemList.ContainsAnyValue()) // Avoid loading item each time the editor open...
                return;
            m_ClassImages.LoadTextures();
            m_itemEditorUtils.SetClassTextures(m_ClassImages);
            string filePath = ConfigUtils.Configs.Path.Client + "/C_Item.ini";
            if (filePath.FileExist())
            {
                m_ItemList.ReadFile(filePath);

                return;
            }
            EditorError("Failed to load file: " + filePath + ", file probably not found !");
        }

        public void DrawContent()
        {
            if (!IsOpen) return;

            // Now that the item is loaded, update the item list !
            if (m_ItemsStringList.Length <= 0 && m_ItemList.IsLoaded()) ResetStringList();

            DrawItemList();
            DrawItemProperties();
        }

        private void DrawItemList()
        {
            if (ImGui.Begin(m_Translate.ItemListName))
            {
                // Now create the item list window.
                var regionSize = ImGui.GetContentRegionAvail();
                ImGui.SetNextWindowSize(new Vector2(regionSize.X - 1f, regionSize.Y - 20f));
                ImGuiUtils.ListBox("##ItemList", ref m_SelectedListIndex, m_ItemsStringList);
                ImGui.Separator();

                if (ImGuiUtils.DoubleButton(m_Translate.AddBtnName, m_Translate.RemoveBtnName, out var add, out var remove))
                {
                    if (add) OnListAdd();
                    if (remove) OnListRemove();
                }
            }
            ImGui.End();
        }

        private void DrawItemProperties()
        {
            if (ImGui.Begin(m_Translate.ItemEditorName, ref IsOpen) && m_ItemsStringList.Length > 0)
            {
                var strIndex = m_ItemsStringList[m_SelectedListIndex].AsULong();
                if (m_ItemList.GetItem(strIndex, out var item))
                {
                    ImGuiUtils.Label(m_Translate.HeaderItemIndex + ": " + item.m_nId, false);
                    ImGuiUtils.Label(m_Translate.HeaderItemName + ": " + item.m_kName, false);
                    ImGuiUtils.InputText(m_Translate.HeaderItemModel, ref item.m_nModelFilename);

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemIcon))
                    {
                        ImGuiUtils.InputText(m_Translate.HeaderItemIcon + ":", ref item.m_kIconFilename);
                        var image = GetIconByName(item.m_kIconFilename);
                        if (image != null)
                        {
                            ImGui.SameLine();
                            ImGuiUtils.Image(image, false);
                        }
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemDrop))
                    {
                        ImGuiUtils.InputULong("Drop Index", ref item.m_nDropIndex);
                        ImGuiUtils.InputChar("Drop Rate", ref item.m_nDropRate);
                        ImGuiUtils.InputText(m_Translate.HeaderDropName, ref item.m_nDropFilename);
                        var drop = GetChestByName(item.m_nDropFilename);
                        if (drop != null)
                        {
                            ImGui.SameLine();
                            ImGuiUtils.ImageSized(drop, new Vector2(128, 128));
                        }
                    }
                    
                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemEffects))
                    {
                        ImGuiUtils.InputULong("Weapon effect", ref item.m_nWeaponEffectId);
                        ImGuiUtils.InputULong("Fly effect", ref item.m_nFlyEffectId);
                        ImGuiUtils.InputULong("Used effect", ref item.m_nUsedEffectId);
                        ImGuiUtils.InputULong("Enchanced effect", ref item.m_nEnhanceEffectId);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemRestriction))
                    {
                        ImGuiUtils.SetOffsetPos(new Vector2(15f, 0f));
                        if (ImGui.CollapsingHeader(m_Translate.HeaderItemClass))
                        {
                            m_itemEditorUtils.DrawClassCheckbox(item, ERestrictClass.Novice, 30f);
                            m_itemEditorUtils.DrawClassSection(item, m_Translate.FighterSection, 2f, ERestrictClass.Fighter, m_itemEditorUtils.FighterClassSections);
                            m_itemEditorUtils.DrawClassSection(item, m_Translate.HunterSection, 2f, ERestrictClass.Hunter, m_itemEditorUtils.HunterClassSections);
                            m_itemEditorUtils.DrawClassSection(item, m_Translate.AcolyteSection, 2f, ERestrictClass.Acolyte, m_itemEditorUtils.AcolyteClassSections);
                            m_itemEditorUtils.DrawClassSection(item, m_Translate.SpellcasterSection, 2f, ERestrictClass.Spellcaster, m_itemEditorUtils.SpellcasterClassSections);
                            m_itemEditorUtils.DrawClassSection(item, m_Translate.MechanicSection, 2f, ERestrictClass.Mechanic, m_itemEditorUtils.MechanicClassSections);
                            m_itemEditorUtils.DrawClassSection(item, m_Translate.WandererSection, 2f, ERestrictClass.Wanderer, m_itemEditorUtils.WandererClassSections);
                        }
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemFlags))
                    {
                        ImGuiUtils.SetOffsetPos(new Vector2(15f, 0f));
                        if (ImGui.CollapsingHeader(m_Translate.OpFlags))
                        {
                            m_itemEditorUtils.DrawOpFlagParameter(item, m_Translate.OpFlagsDesc.CanUse, EItemOpFlags.eIOF_CanUse);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Disappear when used ?", EItemOpFlags.eIOF_NoDecrease);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Can't be traded ?", EItemOpFlags.eIOF_NoTrade);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Can't be discarded ?", EItemOpFlags.eIOF_NoDiscard);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Can't be enchanced ?", EItemOpFlags.eIOF_NoEnhance);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Can be combined ?", EItemOpFlags.eIOF_Combineable);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Bind on equiped ?", EItemOpFlags.eIOF_BindOnEquip);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Allow time accumulation when used ?", EItemOpFlags.eIOF_AccumTime);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Disallow using if same buff is already in use ?", EItemOpFlags.eIOF_NoSameBuff);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Can't be used in battle ?", EItemOpFlags.eIOF_NoInBattle);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Can't be used in town ?", EItemOpFlags.eIOF_NoInTown);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Can't be used in cave ?", EItemOpFlags.eIOF_NoInCave);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Can't be used in instance ?", EItemOpFlags.eIOF_NoInInstance);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Does this item is linked to a quest ?", EItemOpFlags.eIOF_LinkToQuest);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Used for dead people ?", EItemOpFlags.eIOF_ForDead);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Can't be used in battefield ?", EItemOpFlags.eIOF_NoInBattlefield);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Can't be used in fields ?", EItemOpFlags.eIOF_NoInField);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Can't be used for teleport ?", EItemOpFlags.eIOF_NoTransNode);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Allow this item to unbind other items ?", EItemOpFlags.eIOF_UnBindItem);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Can't equip the same item ?", EItemOpFlags.eIOF_OnlyEquip);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Unknown parameter", EItemOpFlags.eIOF_Unknown);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Only1 (Unknown param)", EItemOpFlags.eIOF_Only1);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Only2 (Unknown param)", EItemOpFlags.eIOF_Only2);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Only3 (Unknown param)", EItemOpFlags.eIOF_Only3);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Only4 (Unknown param)", EItemOpFlags.eIOF_Only4);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Only5 (Unknown param)", EItemOpFlags.eIOF_Only5);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Only (All) (Unknown param)", EItemOpFlags.eIOF_Only);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Replaceable1 (Unknown param)", EItemOpFlags.eIOF_Replaceable1);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Replaceable2 (Unknown param)", EItemOpFlags.eIOF_Replaceable2);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Replaceable3 (Unknown param)", EItemOpFlags.eIOF_Replaceable3);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Replaceable4 (Unknown param)", EItemOpFlags.eIOF_Replaceable4);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Replaceable5 (Unknown param)", EItemOpFlags.eIOF_Replaceable5);
                            m_itemEditorUtils.DrawOpFlagParameter(item, "Replaceable (All) (Unknown param)", EItemOpFlags.eIOF_Replaceable);

                            // If all only or replaceable are selected, remove them and enable all with the only/replaceable flags.
                            if (item.m_bOpFlagsArray[EItemOpFlags.eIOF_Only1] &&
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Only2] &&
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Only3] &&
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Only4] &&
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Only5])
                            {
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Only1] = false;
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Only2] = false;
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Only3] = false;
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Only4] = false;
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Only5] = false;
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Only] = true;
                            }

                            if (item.m_bOpFlagsArray[EItemOpFlags.eIOF_Replaceable1] &&
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Replaceable2] &&
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Replaceable3] &&
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Replaceable4] &&
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Replaceable5])
                            {
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Replaceable1] = false;
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Replaceable2] = false;
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Replaceable3] = false;
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Replaceable4] = false;
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Replaceable5] = false;
                                item.m_bOpFlagsArray[EItemOpFlags.eIOF_Replaceable] = true;
                            }
                        }

                        ImGuiUtils.SetOffsetPos(new Vector2(15f, 0f));
                        if (ImGui.CollapsingHeader(m_Translate.OpFlagsPlus))
                        {
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "IK Combineable ?", EItemOpFlagsPlus.eIOFP_IKCombine);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "GK Combineable ?", EItemOpFlagsPlus.eIOFP_GKCombine);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Show equipment ?", EItemOpFlagsPlus.eIOFP_EquipShow);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Purple WLimit ?", EItemOpFlagsPlus.eIOFP_PurpleWLimit);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Purple ALimit ?", EItemOpFlagsPlus.eIOFP_PurpleALimit);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Bind on use ?", EItemOpFlagsPlus.eIOFP_UseBind);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Stack limited to 1 ?", EItemOpFlagsPlus.eIOFP_OneStack);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Is ride IK combineable ?", EItemOpFlagsPlus.eIOFP_RideCombineIK);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Is ride GK combineable ?", EItemOpFlagsPlus.eIOFP_RideCombineGK);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Is ride combineable ?", EItemOpFlagsPlus.eIOFP_ISRideCombine);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Is item VIP ?", EItemOpFlagsPlus.eIOFP_VIP);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Is chair IK combineable ?", EItemOpFlagsPlus.eIOFP_ChairCombineIK);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Is chair GK combineable ?", EItemOpFlagsPlus.eIOFP_ChairCombineGK);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Is chair combineable ?", EItemOpFlagsPlus.eIOFP_ISChairCombine);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Red WLimit ?", EItemOpFlagsPlus.eIOFP_RedWLimit);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Red ALimit ?", EItemOpFlagsPlus.eIOFP_RedALimit);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Is crystal combo ?", EItemOpFlagsPlus.eIOFP_CrystalCombo);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Is souvenir combo ?", EItemOpFlagsPlus.eIOFP_SouvenirCombo);
                            m_itemEditorUtils.DrawOpFlagPlusParameter(item, "Is godarea combo ?", EItemOpFlagsPlus.eIOFP_GodAreaCombo);
                        }
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemReputation))
                    {
                        List<string> alignementList = [];
                        foreach (var value in Enum.GetValues<EAlignement>())
                        {
                            if (value == EAlignement.eA_End || value == EAlignement.eA_GroupEnd) continue; // Skip alignement
                            alignementList.Add(AlignementUtils.GetAlignementName(value));
                        }
                        ImGui.ListBox("Type", ref ReputationIndex, [.. alignementList], alignementList.Count);
                        alignementList.Clear();
                        item.m_eRestrictAlign = AlignementUtils.GetEnumAlignementFromID(ReputationIndex);

                        ImGuiUtils.InputULong("Value", ref item.m_nRestrictPrestige);
                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemAttribute))
                    {

                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemEnchantments))
                    {

                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemElf))
                    {

                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemAttributeDamage))
                    {

                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemSpecialDamage))
                    {

                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemPrice))
                    {

                    }

                    if (ImGui.CollapsingHeader(m_Translate.HeaderItemSockets))
                    {

                    }

                    item.ProcessClassRestriction();
                    item.ProcessOpFlags();
                    item.ProcessOpFlagsPlus();
                }
            }
            ImGui.End();
        }

        public void Show()
        {
            IsOpen = true;
            Init();
        }

        public void Hide()
        {
            IsOpen = false;
        }

        private void ResetStringList()
        {
            m_ItemsStringList = m_ItemList.GetAllItems().Select(e => e.m_nId).ToStringArray();
        }

        private void OnListAdd()
        {

        }

        private void OnListRemove()
        {

        }

        private Texture2D? GetIconByName(string name)
        {
            // if exist check it..
            if (m_iconsImages.TryGetValue(name, out Texture2D? value))
                return value;

            // Else add it !
            if (m_itemIconPath.FolderExist())
            {
                var filePath = Path.Combine(m_itemIconPath, name + ".png");
                var fileName = Path.GetFileNameWithoutExtension(filePath).ToLower();
                if (fileName != name) return null;
                if (m_iconsImages.TryAdd(fileName, TextureUtils.LoadTextureFromFile(filePath)))
                    return m_iconsImages[fileName];
            }

            // If either not added or found return null !
            return null;
        }

        private Texture2D? GetChestByName(string name)
        {
            // if exist check it..
            if (m_dropImages.TryGetValue(name, out Texture2D? value))
                return value;

            // Else add it !
            if (m_dropPath.FolderExist())
            {
                var filePath = Path.Combine(m_dropPath, name + ".png");
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                if (fileName != name) return null;
                if (m_dropImages.TryAdd(name, TextureUtils.LoadTextureFromFile(filePath)))
                    return m_dropImages[name];
            }

            // If either not added or found return null !
            return null;
        }

        public void Dispose()
        {
            foreach (var item in m_iconsImages)
                TextureUtils.DisposeTexture(item.Value);
            m_iconsImages.Clear();
            m_ClassImages.Dispose();
        }
    }
}
