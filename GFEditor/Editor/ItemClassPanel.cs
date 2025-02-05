namespace GFEditor.Editor
{
    public partial class ItemClassPanel : Form
    {
        private CSItem? m_Item;
        private readonly Dictionary<ClassType, CheckBox> m_classCheckBoxDict;

        public ItemClassPanel()
        {
            InitializeComponent();
            ControlBox = false;
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
        }

        private void PopulateItemClassCheckbox()
        {
            if (m_Item == null)
            {
                Console.WriteLine("Failed to populate item class restriction, item is null, was it assigned beforehand ?");
                return;
            }
            var flag = (ClassType)m_Item.RestrictClass;
            foreach (var entry in m_classCheckBoxDict)
            {
                if (flag.HasFlag(entry.Key))
                    entry.Value.Checked = true;
                else
                    entry.Value.Checked = false;
            }
        }

        public void SetItem(CSItem item)
        {
            m_Item = item;
            if (m_Item != null)
                PopulateItemClassCheckbox();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Novice_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Novice, ClassType.Novice);
        }

        private void Fighter_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Fighter, ClassType.Fighter);
        }

        private void Warrior_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Warrior, ClassType.Warrior);
        }

        private void Berserker_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Berserker, ClassType.Berserker);
        }

        private void Warlord_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Warlord, ClassType.Warlord);
        }

        private void Deathknight_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Deathknight, ClassType.Deathknight);
        }

        private void Destroyer_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Destroyer, ClassType.Destroyer);
        }

        private void Paladin_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Paladin, ClassType.Paladin);
        }

        private void Templar_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Templar, ClassType.Templar);
        }

        private void Crusader_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Crusader, ClassType.Crusader);
        }

        private void Holyknight_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Holyknight, ClassType.HolyKnight);
        }

        private void Hunter_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Hunter, ClassType.Hunter);
        }

        private void Archer_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Archer, ClassType.Archer);
        }

        private void Ranger_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Ranger, ClassType.Ranger);
        }

        private void Sharpshooter_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Sharpshooter, ClassType.Sharpshooter);
        }

        private void Hawkeye_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Hawkeye, ClassType.Hawkeye);
        }

        private void Predator_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Predator, ClassType.Predator);
        }

        private void Assassin_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Assassin, ClassType.Assassin);
        }

        private void Darkstalker_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Darkstalker, ClassType.DarkStalker);
        }

        private void Windshadow_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Windshadow, ClassType.Windshadow);
        }

        private void Shinobi_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Shinobi, ClassType.Shinobi);
        }

        private void Acolyte_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Acolyte, ClassType.Acolyte);
        }

        private void Priest_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Priest, ClassType.Priest);
        }

        private void Cleric_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Cleric, ClassType.Cleric);
        }

        private void Prophet_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Prophet, ClassType.Prophet);
        }

        private void Saint_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Saint, ClassType.Saint);
        }

        private void Archangel_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Archangel, ClassType.Archangel);
        }

        private void Sage_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Sage, ClassType.Sage);
        }

        private void Mystic_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Mystic, ClassType.Mystic);
        }

        private void Shaman_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Shaman, ClassType.Shaman);
        }

        private void Druid_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Druid, ClassType.Druid);
        }

        private void Spellcaster_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Spellcaster, ClassType.Spellcaster);
        }

        private void Mage_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Mage, ClassType.Mage);
        }

        private void Wizard_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Wizard, ClassType.Wizard);
        }

        private void Archmage_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Archmage, ClassType.Archmage);
        }

        private void Avatar_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Avatar, ClassType.Avatar);
        }

        private void Warlock_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Warlock, ClassType.Warlock);
        }

        private void Necromancer_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Necromancer, ClassType.Necromancer);
        }

        private void Demonologist_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Demonologist, ClassType.Demonologist);
        }

        private void Shadowlord_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Shadowlord, ClassType.Shadowlord);
        }

        private void Shinigami_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Shinigami, ClassType.Shinigami);
        }

        private void Mechanic_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Mechanic, ClassType.Mechanic);
        }

        private void Machinist_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Machinist, ClassType.Machinist);
        }

        private void Demolitionist_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Demolitionist, ClassType.Demolisionist);
        }

        private void Gunner_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Gunner, ClassType.Gunner);
        }

        private void Bombardier_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Bombardier, ClassType.Bombardier);
        }

        private void Artillerist_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Artillerist, ClassType.Artillerist);
        }

        private void Enginner_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Enginner, ClassType.Enginner);
        }

        private void Gearmaster_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Gearmaster, ClassType.GearMaster);
        }

        private void Cogmaster_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Cogmaster, ClassType.CogMaster);
        }

        private void Mechmaster_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Mechmaster, ClassType.MechMaster);
        }

        private void Wanderer_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Wanderer, ClassType.Wanderer);
        }

        private void Drifter_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Drifter, ClassType.Drifter);
        }

        private void Timetraveler_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Timetraveler, ClassType.TimeTraveler);
        }

        private void Keymaster_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Keymaster, ClassType.KeyMaster);
        }

        private void Chronomancer_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Chronomancer, ClassType.Chronomancer);
        }

        private void Chronoshifter_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Chronoshifter, ClassType.ChronoShifter);
        }

        private void Voidrunner_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Voidrunner, ClassType.VoidRunner);
        }

        private void Dimentionalist_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Dimentionalist, ClassType.Dimensionalist);
        }

        private void Reaper_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Reaper, ClassType.Reaper);
        }

        private void Phantom_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetClassFlags(Phantom, ClassType.Phantom);
        }
    }
}