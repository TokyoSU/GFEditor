namespace GFEditor.Editor
{
    public enum BasicClassType
    {
        Fighter,
        Hunter,
        Spellcaster,
        Acolyte,
        Mechanic,
        Wanderer
    }

    public static class ItemEditorUtils
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private static readonly TranslatedValues m_Translate = TranslateUtils.Json.TranslatedValues;
        private static readonly Dictionary<ERestrictClass, Texture2D> m_ClassTextures = [];

        private static readonly List<ERestrictClass> FighterClassSections = 
        [
            ERestrictClass.Fighter,
            ERestrictClass.Warrior,
            ERestrictClass.Berserker,
            ERestrictClass.Warlord,
            ERestrictClass.Deathknight,
            ERestrictClass.Destroyer,
            ERestrictClass.Paladin,
            ERestrictClass.Templar,
            ERestrictClass.Crusader,
            ERestrictClass.HolyKnight
        ];

        private static readonly List<ERestrictClass> HunterClassSections =
        [
            ERestrictClass.Hunter,
            ERestrictClass.Archer,
            ERestrictClass.Ranger,
            ERestrictClass.Sharpshooter,
            ERestrictClass.Hawkeye,
            ERestrictClass.Predator,
            ERestrictClass.Assassin,
            ERestrictClass.DarkStalker,
            ERestrictClass.Windshadow,
            ERestrictClass.Shinobi
        ];

        private static readonly List<ERestrictClass> SpellcasterClassSections =
        [
            ERestrictClass.Spellcaster,
            ERestrictClass.Mage,
            ERestrictClass.Wizard,
            ERestrictClass.Archmage,
            ERestrictClass.Avatar,
            ERestrictClass.Warlock,
            ERestrictClass.Necromancer,
            ERestrictClass.Demonologist,
            ERestrictClass.Shadowlord,
            ERestrictClass.Shinigami
        ];

        private static readonly List<ERestrictClass> AcolyteClassSections =
        [
            ERestrictClass.Acolyte,
            ERestrictClass.Priest,
            ERestrictClass.Cleric,
            ERestrictClass.Prophet,
            ERestrictClass.Saint,
            ERestrictClass.Archangel,
            ERestrictClass.Sage,
            ERestrictClass.Mystic,
            ERestrictClass.Shaman,
            ERestrictClass.Druid
        ];

        private static readonly List<ERestrictClass> MechanicClassSections =
        [
            ERestrictClass.Mechanic,
            ERestrictClass.Machinist,
            ERestrictClass.Demolitionist,
            ERestrictClass.Gunner,
            ERestrictClass.Bombardier,
            ERestrictClass.Artillerist,
            ERestrictClass.Enginner,
            ERestrictClass.GearMaster,
            ERestrictClass.CogMaster,
            ERestrictClass.MechMaster
        ];

        private static readonly List<ERestrictClass> WandererClassSections =
        [
            ERestrictClass.Wanderer,
            ERestrictClass.Drifter,
            ERestrictClass.TimeTraveler,
            ERestrictClass.KeyMaster,
            ERestrictClass.Chronomancer,
            ERestrictClass.ChronoShifter,
            ERestrictClass.VoidRunner,
            ERestrictClass.Dimensionalist,
            ERestrictClass.Reaper,
            ERestrictClass.Phantom
        ];

        public static void DisposeClassesTextures()
        {
            foreach (var texture in m_ClassTextures.Values)
                TextureUtils.DisposeTexture(texture);
            m_ClassTextures.Clear();
        }


        public static void LoadClassesTextures()
        {
            var values = Enum.GetValues<ERestrictClass>();
            foreach (var value in values)
            {
                if (value == ERestrictClass.None) continue;
                string filePath = string.Format("textures/classes/{0}.png", value.ToString().ToLower());
                if (filePath.FileExist())
                    m_ClassTextures.TryAdd(value, TextureUtils.LoadTextureFromFile(filePath));
                else
                    m_Log.Warn("Failed to load class image " + value.ToString() + ", file not found !");
            }
        }

        public static Texture2D GetClassesTextureByEnum(ERestrictClass value) => m_ClassTextures[value];

        public static void DrawClassTexture(ERestrictClass value)
        {
            ImGuiUtils.Image(GetClassesTextureByEnum(value));
        }

        public static void DrawOpFlagParameter(Item item, string label, EItemOpFlags flags, float offsetX = 30f)
        {
            ImGuiUtils.SetOffsetPos(new Vector2(offsetX, 0f));
            bool value = item.m_bOpFlagsArray[flags];
            if (ImGui.Checkbox("##" + label, ref value))
                item.m_bOpFlagsArray[flags] = value;
            switch (flags)
            {
                case EItemOpFlags.Only1:
                case EItemOpFlags.Only2:
                case EItemOpFlags.Only3:
                case EItemOpFlags.Only4:
                case EItemOpFlags.Only5:
                    // If any of these value is ticked, then remove the only all value !
                    if (value)
                        item.m_bOpFlagsArray[EItemOpFlags.Only] = false;
                    break;
                case EItemOpFlags.Replaceable1:
                case EItemOpFlags.Replaceable2:
                case EItemOpFlags.Replaceable3:
                case EItemOpFlags.Replaceable4:
                case EItemOpFlags.Replaceable5:
                    if (value)
                        item.m_bOpFlagsArray[EItemOpFlags.Replaceable] = false;
                    break;
            }

            ImGui.SameLine();
            ImGui.Text(label);
        }

        public static void DrawOpFlagPlusParameter(Item item, string label, EItemOpFlagsPlus flags, float offsetX = 30f)
        {
            ImGuiUtils.SetOffsetPos(new Vector2(offsetX, 0f));
            bool value = item.m_bOpFlagsPlusArray[flags];
            if (ImGui.Checkbox("##" + label, ref value))
                item.m_bOpFlagsPlusArray[flags] = value;
            ImGui.SameLine();
            ImGui.Text(label);
        }

        public static void DrawClassCheckbox(Item item, ERestrictClass eRestrictClass, float offsetX)
        {
            ImGuiUtils.SetOffsetPos(new Vector2(offsetX, 0f));
            ImGuiUtils.Image(ItemEditorUtils.GetClassesTextureByEnum(eRestrictClass));

            string label = m_Translate.GetClassName(eRestrictClass);
            bool value = item.m_bClassRestrictionArray[eRestrictClass]; // Update value of checkbox if changed...
            if (ImGui.Checkbox("##" + label, ref value))
                item.m_bClassRestrictionArray[eRestrictClass] = value;

            // Need to be after checkbox in this case since the image is drawn before label.
            ImGui.SameLine();
            ImGui.Text(label);
        }

        public static void DrawClassSection(Item item, string sectionName, float xOffset, ERestrictClass headerIcon, BasicClassType classType)
        {
            var eRestrictClasses = classType switch
            {
                BasicClassType.Fighter => FighterClassSections,
                BasicClassType.Hunter => HunterClassSections,
                BasicClassType.Spellcaster => SpellcasterClassSections,
                BasicClassType.Acolyte => AcolyteClassSections,
                BasicClassType.Mechanic => MechanicClassSections,
                BasicClassType.Wanderer => WandererClassSections,
                _ => null,
            };
            if (eRestrictClasses == null)
            {
                m_Log.Error("Failed to draw the class sector: " + sectionName + ", class list is null, missing class type selected ?");
                return;
            }
            if (eRestrictClasses.Count != 10)
            {
                m_Log.Error("Failed to draw the class section: " + sectionName + ", length is not exactly 10 !");
                return;
            }

            ImGuiUtils.SetOffsetPos(new Vector2(15f * xOffset, 0f));
            if (ImGuiUtils.CollapsingHeaderWithTexture(ItemEditorUtils.GetClassesTextureByEnum(headerIcon), sectionName))
            {
                DrawClassCheckbox(item, eRestrictClasses[0], 15f * xOffset + 25f);
                DrawClassCheckbox(item, eRestrictClasses[1], 15f * xOffset + 25f);
                ImGui.Separator();
                DrawClassCheckbox(item, eRestrictClasses[2], 15f * xOffset + 25f);
                DrawClassCheckbox(item, eRestrictClasses[3], 15f * xOffset + 25f);
                DrawClassCheckbox(item, eRestrictClasses[4], 15f * xOffset + 25f);
                DrawClassCheckbox(item, eRestrictClasses[5], 15f * xOffset + 25f);
                ImGui.Separator();
                DrawClassCheckbox(item, eRestrictClasses[6], 15f * xOffset + 25f);
                DrawClassCheckbox(item, eRestrictClasses[7], 15f * xOffset + 25f);
                DrawClassCheckbox(item, eRestrictClasses[8], 15f * xOffset + 25f);
                DrawClassCheckbox(item, eRestrictClasses[9], 15f * xOffset + 25f);
            }
        }
    }
}
