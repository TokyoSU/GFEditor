using GFEditor.Enums;
using GFEditor.Structs;
using GFEditor.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GFEditor.Editor
{
    public partial class ItemClassPanel : Form
    {
        private CSItem m_Item;
        private readonly Dictionary<ClassTypeEnum, CheckBox> m_classCheckBoxDict;

        public ItemClassPanel()
        {
            InitializeComponent();
            ControlBox = false;
            m_classCheckBoxDict = new Dictionary<ClassTypeEnum, CheckBox>()
            {
                { ClassTypeEnum.Novice, Novice },
                { ClassTypeEnum.Fighter, Fighter },
                { ClassTypeEnum.Warrior, Warrior },
                { ClassTypeEnum.Paladin, Paladin },
                { ClassTypeEnum.Berserker, Berserker },
                { ClassTypeEnum.Hunter, Hunter },
                { ClassTypeEnum.Archer, Archer },
                { ClassTypeEnum.Ranger, Ranger },
                { ClassTypeEnum.Assassin, Assassin },
                { ClassTypeEnum.Acolyte, Acolyte },
                { ClassTypeEnum.Priest, Priest },
                { ClassTypeEnum.Cleric, Cleric },
                { ClassTypeEnum.Sage, Sage },
                { ClassTypeEnum.Spellcaster, Spellcaster },
                { ClassTypeEnum.Mage, Mage },
                { ClassTypeEnum.Wizard, Wizard },
                { ClassTypeEnum.Necromancer, Necromancer },
                { ClassTypeEnum.Warlord, Warlord },
                { ClassTypeEnum.Templar, Templar },
                { ClassTypeEnum.Sharpshooter, Sharpshooter },
                { ClassTypeEnum.DarkStalker, Darkstalker },
                { ClassTypeEnum.Prophet, Prophet },
                { ClassTypeEnum.Mystic, Mystic },
                { ClassTypeEnum.Archmage, Archmage },
                { ClassTypeEnum.Demonologist, Demonologist },
                { ClassTypeEnum.Mechanic, Mechanic },
                { ClassTypeEnum.Machinist, Machinist },
                { ClassTypeEnum.Enginner, Enginner },
                { ClassTypeEnum.Demolisionist, Demolitionist },
                { ClassTypeEnum.GearMaster, Gearmaster },
                { ClassTypeEnum.Gunner, Gunner },
                { ClassTypeEnum.Deathknight, Deathknight },
                { ClassTypeEnum.Crusader, Crusader },
                { ClassTypeEnum.Hawkeye, Hawkeye },
                { ClassTypeEnum.Windshadow, Windshadow },
                { ClassTypeEnum.Saint, Saint },
                { ClassTypeEnum.Shaman, Shaman },
                { ClassTypeEnum.Avatar, Avatar },
                { ClassTypeEnum.Shadowlord, Shadowlord },
                { ClassTypeEnum.Destroyer, Destroyer },
                { ClassTypeEnum.HolyKnight, Holyknight },
                { ClassTypeEnum.Predator, Predator },
                { ClassTypeEnum.Shinobi, Shinobi },
                { ClassTypeEnum.Archangel, Archangel },
                { ClassTypeEnum.Druid, Druid },
                { ClassTypeEnum.Warlock, Warlock },
                { ClassTypeEnum.Shinigami, Shinigami },
                { ClassTypeEnum.CogMaster, Cogmaster },
                { ClassTypeEnum.Bombardier, Bombardier },
                { ClassTypeEnum.MechMaster, Mechmaster },
                { ClassTypeEnum.Artillerist, Artillerist },
                { ClassTypeEnum.Wanderer, Wanderer },
                { ClassTypeEnum.Drifter, Drifter },
                { ClassTypeEnum.VoidRunner, Voidrunner },
                { ClassTypeEnum.TimeTraveler, Timetraveler },
                { ClassTypeEnum.Dimensionalist, Dimentionalist },
                { ClassTypeEnum.KeyMaster, Keymaster },
                { ClassTypeEnum.Reaper, Reaper },
                { ClassTypeEnum.Chronomancer, Chronomancer },
                { ClassTypeEnum.Phantom, Phantom },
                { ClassTypeEnum.ChronoShifter, Chronoshifter }
            };
        }

        private void PopulateItemClassCheckbox()
        {
            var flag = (ClassTypeEnum)m_Item.RestrictClass;
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
            m_Item.SetClassFlags(Novice, ClassTypeEnum.Novice);
        }

        private void Fighter_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Fighter, ClassTypeEnum.Fighter);
        }

        private void Warrior_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Warrior, ClassTypeEnum.Warrior);
        }

        private void Berserker_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Berserker, ClassTypeEnum.Berserker);
        }

        private void Warlord_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Warlord, ClassTypeEnum.Warlord);
        }

        private void Deathknight_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Deathknight, ClassTypeEnum.Deathknight);
        }

        private void Destroyer_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Destroyer, ClassTypeEnum.Destroyer);
        }

        private void Paladin_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Paladin, ClassTypeEnum.Paladin);
        }

        private void Templar_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Templar, ClassTypeEnum.Templar);
        }

        private void Crusader_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Crusader, ClassTypeEnum.Crusader);
        }

        private void Holyknight_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Holyknight, ClassTypeEnum.HolyKnight);
        }

        private void Hunter_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Hunter, ClassTypeEnum.Hunter);
        }

        private void Archer_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Archer, ClassTypeEnum.Archer);
        }

        private void Ranger_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Ranger, ClassTypeEnum.Ranger);
        }

        private void Sharpshooter_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Sharpshooter, ClassTypeEnum.Sharpshooter);
        }

        private void Hawkeye_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Hawkeye, ClassTypeEnum.Hawkeye);
        }

        private void Predator_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Predator, ClassTypeEnum.Predator);
        }

        private void Assassin_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Assassin, ClassTypeEnum.Assassin);
        }

        private void Darkstalker_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Darkstalker, ClassTypeEnum.DarkStalker);
        }

        private void Windshadow_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Windshadow, ClassTypeEnum.Windshadow);
        }

        private void Shinobi_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Shinobi, ClassTypeEnum.Shinobi);
        }

        private void Acolyte_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Acolyte, ClassTypeEnum.Acolyte);
        }

        private void Priest_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Priest, ClassTypeEnum.Priest);
        }

        private void Cleric_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Cleric, ClassTypeEnum.Cleric);
        }

        private void Prophet_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Prophet, ClassTypeEnum.Prophet);
        }

        private void Saint_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Saint, ClassTypeEnum.Saint);
        }

        private void Archangel_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Archangel, ClassTypeEnum.Archangel);
        }

        private void Sage_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Sage, ClassTypeEnum.Sage);
        }

        private void Mystic_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Mystic, ClassTypeEnum.Mystic);
        }

        private void Shaman_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Shaman, ClassTypeEnum.Shaman);
        }

        private void Druid_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Druid, ClassTypeEnum.Druid);
        }

        private void Spellcaster_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Spellcaster, ClassTypeEnum.Spellcaster);
        }

        private void Mage_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Mage, ClassTypeEnum.Mage);
        }

        private void Wizard_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Wizard, ClassTypeEnum.Wizard);
        }

        private void Archmage_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Archmage, ClassTypeEnum.Archmage);
        }

        private void Avatar_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Avatar, ClassTypeEnum.Avatar);
        }

        private void Warlock_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Warlock, ClassTypeEnum.Warlock);
        }

        private void Necromancer_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Necromancer, ClassTypeEnum.Necromancer);
        }

        private void Demonologist_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Demonologist, ClassTypeEnum.Demonologist);
        }

        private void Shadowlord_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Shadowlord, ClassTypeEnum.Shadowlord);
        }

        private void Shinigami_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Shinigami, ClassTypeEnum.Shinigami);
        }

        private void Mechanic_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Mechanic, ClassTypeEnum.Mechanic);
        }

        private void Machinist_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Machinist, ClassTypeEnum.Machinist);
        }

        private void Demolitionist_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Demolitionist, ClassTypeEnum.Demolisionist);
        }

        private void Gunner_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Gunner, ClassTypeEnum.Gunner);
        }

        private void Bombardier_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Bombardier, ClassTypeEnum.Bombardier);
        }

        private void Artillerist_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Artillerist, ClassTypeEnum.Artillerist);
        }

        private void Enginner_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Enginner, ClassTypeEnum.Enginner);
        }

        private void Gearmaster_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Gearmaster, ClassTypeEnum.GearMaster);
        }

        private void Cogmaster_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Cogmaster, ClassTypeEnum.CogMaster);
        }

        private void Mechmaster_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Mechmaster, ClassTypeEnum.MechMaster);
        }

        private void Wanderer_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Wanderer, ClassTypeEnum.Wanderer);
        }

        private void Drifter_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Drifter, ClassTypeEnum.Drifter);
        }

        private void Timetraveler_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Timetraveler, ClassTypeEnum.TimeTraveler);
        }

        private void Keymaster_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Keymaster, ClassTypeEnum.KeyMaster);
        }

        private void Chronomancer_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Chronomancer, ClassTypeEnum.Chronomancer);
        }

        private void Chronoshifter_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Chronoshifter, ClassTypeEnum.ChronoShifter);
        }

        private void Voidrunner_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Voidrunner, ClassTypeEnum.VoidRunner);
        }

        private void Dimentionalist_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Dimentionalist, ClassTypeEnum.Dimensionalist);
        }

        private void Reaper_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Reaper, ClassTypeEnum.Reaper);
        }

        private void Phantom_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetClassFlags(Phantom, ClassTypeEnum.Phantom);
        }
    }
}