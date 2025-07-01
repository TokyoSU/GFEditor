using System.Reflection.Emit;

namespace GFEditor.Editor
{
    public class ItemEditorUtils
    {
        private static readonly TranslatedValues m_Translate = TranslateUtils.Json.TranslatedValues;
        private readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private ClassesTextures? m_classTextures;

        public List<ERestrictClass> FighterClassSections = 
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

        public List<ERestrictClass> HunterClassSections =
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

        public List<ERestrictClass> SpellcasterClassSections =
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

        public List<ERestrictClass> AcolyteClassSections =
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

        public List<ERestrictClass> MechanicClassSections =
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

        public List<ERestrictClass> WandererClassSections =
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

        public void SetClassTextures(ClassesTextures textures) => m_classTextures = textures;

        public void DrawOpFlagParameter(ItemData item, string label, EItemOpFlags flags, float offsetX = 30f)
        {
            ImGuiUtils.SetOffsetPos(new Vector2(offsetX, 0f));
            bool value = item.m_bOpFlagsArray[flags];
            if (ImGui.Checkbox("##" + label, ref value))
                item.m_bOpFlagsArray[flags] = value;
            switch (flags)
            {
                case EItemOpFlags.eIOF_Only1:
                case EItemOpFlags.eIOF_Only2:
                case EItemOpFlags.eIOF_Only3:
                case EItemOpFlags.eIOF_Only4:
                case EItemOpFlags.eIOF_Only5:
                    // If any of these value is ticked, then remove the only all value !
                    if (value)
                        item.m_bOpFlagsArray[EItemOpFlags.eIOF_Only] = false;
                    break;
                case EItemOpFlags.eIOF_Replaceable1:
                case EItemOpFlags.eIOF_Replaceable2:
                case EItemOpFlags.eIOF_Replaceable3:
                case EItemOpFlags.eIOF_Replaceable4:
                case EItemOpFlags.eIOF_Replaceable5:
                    if (value)
                        item.m_bOpFlagsArray[EItemOpFlags.eIOF_Replaceable] = false;
                    break;
            }

            ImGui.SameLine();
            ImGui.Text(label);
        }

        public void DrawOpFlagPlusParameter(ItemData item, string label, EItemOpFlagsPlus flags, float offsetX = 30f)
        {
            ImGuiUtils.SetOffsetPos(new Vector2(offsetX, 0f));
            bool value = item.m_bOpFlagsPlusArray[flags];
            if (ImGui.Checkbox("##" + label, ref value))
                item.m_bOpFlagsPlusArray[flags] = value;
            ImGui.SameLine();
            ImGui.Text(label);
        }

        public static void DrawClassCheckBoxRestrict(string label, ItemData item, ERestrictClass restrictType)
        {
            
        }

        public void DrawClassCheckbox(ItemData item, ERestrictClass eRestrictClass, float offsetX)
        {
            ImGuiUtils.SetOffsetPos(new Vector2(offsetX, 0f));

            if (m_classTextures != null)
                ImGuiUtils.Image(m_classTextures.GetTextureByEnum(eRestrictClass));

            string label = m_Translate.GetClassName(eRestrictClass);
            bool value = item.m_bClassRestrictionArray[eRestrictClass]; // Update value of checkbox if changed...
            if (ImGui.Checkbox("##" + label, ref value))
                item.m_bClassRestrictionArray[eRestrictClass] = value;

            // Need to be after checkbox in this case since the image is drawn before label.
            ImGui.SameLine();
            ImGui.Text(label);
        }

        public void DrawClassSection(ItemData item, string sectionName, float offsetXMultiplier, ERestrictClass headerIcon, List<ERestrictClass> eRestrictClasses)
        {
            if (eRestrictClasses == null || eRestrictClasses.Count != 10)
            {
                m_Log.Error("Failed to draw the class section: " + sectionName + " class list is null or length is not exactly 10 !");
                return;
            }

            ImGuiUtils.SetOffsetPos(new Vector2(15f * offsetXMultiplier, 0f));
            if (m_classTextures != null ?
                ImGuiUtils.CollapsingHeaderWithTexture(m_classTextures.GetTextureByEnum(headerIcon), sectionName) :
                ImGui.CollapsingHeader(sectionName))
            {
                DrawClassCheckbox(item, eRestrictClasses[0], 15f * offsetXMultiplier + 25f);
                DrawClassCheckbox(item, eRestrictClasses[1], 15f * offsetXMultiplier + 25f);
                ImGui.Separator();
                DrawClassCheckbox(item, eRestrictClasses[2], 15f * offsetXMultiplier + 25f);
                DrawClassCheckbox(item, eRestrictClasses[3], 15f * offsetXMultiplier + 25f);
                DrawClassCheckbox(item, eRestrictClasses[4], 15f * offsetXMultiplier + 25f);
                DrawClassCheckbox(item, eRestrictClasses[5], 15f * offsetXMultiplier + 25f);
                ImGui.Separator();
                DrawClassCheckbox(item, eRestrictClasses[6], 15f * offsetXMultiplier + 25f);
                DrawClassCheckbox(item, eRestrictClasses[7], 15f * offsetXMultiplier + 25f);
                DrawClassCheckbox(item, eRestrictClasses[8], 15f * offsetXMultiplier + 25f);
                DrawClassCheckbox(item, eRestrictClasses[9], 15f * offsetXMultiplier + 25f);
            }
        }
    }
}
