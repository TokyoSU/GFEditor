using GFEditor.Enums;
using GFEditor.Structs;
using GFEditor.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GFEditor.Editor
{
    public partial class ItemOpPanel : Form
    {
        private CSItem m_Item;
        private readonly Dictionary<ItemOpFlags, CheckBox> m_opCheckBoxDict;
        
        public ItemOpPanel()
        {
            InitializeComponent();
            ControlBox = false;
            m_opCheckBoxDict = new Dictionary<ItemOpFlags, CheckBox>()
            {
                { ItemOpFlags.CanUse, Useable },
                { ItemOpFlags.NoDecrease, NoDecrease },
                { ItemOpFlags.NoTrade, NoTrade },
                { ItemOpFlags.NoDiscard, NoDiscard },
                { ItemOpFlags.NoEnhance, NoEnchance },
                { ItemOpFlags.NoRepair, NoRepair },
                { ItemOpFlags.Combineable, Combinable },
                { ItemOpFlags.BindOnEquip, BindOnEquip },
                { ItemOpFlags.AccumTime, AccumTime },
                { ItemOpFlags.NoSameBuff, NoSameBuff },
                { ItemOpFlags.NoInBattle, NoInBattle },
                { ItemOpFlags.NoInTown, NoInTown },
                { ItemOpFlags.NoInCave, NoInCave },
                { ItemOpFlags.NoInInstance, NoInInstance },
                { ItemOpFlags.LinkToQuest, LinkQuest },
                { ItemOpFlags.ForDead, ForDead },
                { ItemOpFlags.Only1, Only1 },
                { ItemOpFlags.Only2, Only2 },
                { ItemOpFlags.Only3, Only3 },
                { ItemOpFlags.Only4, Only4 },
                { ItemOpFlags.Only5, Only5 },
                { ItemOpFlags.Replaceable1, Replaceable1 },
                { ItemOpFlags.Replaceable2, Replaceable2 },
                { ItemOpFlags.Replaceable3, Replaceable3 },
                { ItemOpFlags.Replaceable4, Replaceable4 },
                { ItemOpFlags.Replaceable5, Replaceable5 },
                { ItemOpFlags.NoInBattlefield, NoInBattlefield },
                { ItemOpFlags.NoInField, NoInField },
                { ItemOpFlags.NoTransNode, NoTransNode },
                { ItemOpFlags.UnBindItem, UnbindItem },
                { ItemOpFlags.OnlyEquip, OnlyEquip }
            };
        }

        private void PopulateOpFlags()
        {
            var flag = (ItemOpFlags)m_Item.OpFlags;
            foreach (var entry in m_opCheckBoxDict)
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
            if (m_Item != null) PopulateOpFlags();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Useable_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Useable, ItemOpFlags.CanUse);
        }

        private void Combinable_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Combinable, ItemOpFlags.Combineable);
        }

        private void BindOnEquip_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(BindOnEquip, ItemOpFlags.BindOnEquip);
        }

        private void AccumTime_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(AccumTime, ItemOpFlags.AccumTime);
        }

        private void LinkQuest_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(LinkQuest, ItemOpFlags.LinkToQuest);
        }

        private void ForDead_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(ForDead, ItemOpFlags.ForDead);
        }

        private void UnbindItem_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(UnbindItem, ItemOpFlags.UnBindItem);
        }

        private void OnlyEquip_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(OnlyEquip, ItemOpFlags.OnlyEquip);
        }

        private void NoDecrease_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(NoDecrease, ItemOpFlags.NoDecrease);
        }

        private void NoTrade_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(NoTrade, ItemOpFlags.NoTrade);
        }

        private void NoDiscard_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(NoDiscard, ItemOpFlags.NoDiscard);
        }

        private void NoEnchance_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(NoEnchance, ItemOpFlags.NoEnhance);
        }

        private void NoRepair_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(NoRepair, ItemOpFlags.NoRepair);
        }

        private void NoSameBuff_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(NoSameBuff, ItemOpFlags.NoSameBuff);
        }

        private void NoInBattle_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(NoInBattle, ItemOpFlags.NoInBattle);
        }

        private void NoInTown_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(NoInTown, ItemOpFlags.NoInTown);
        }

        private void NoInCave_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(NoInCave, ItemOpFlags.NoInCave);
        }

        private void NoInInstance_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(NoInInstance, ItemOpFlags.NoInInstance);
        }

        private void NoInBattlefield_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Useable, ItemOpFlags.CanUse);
        }

        private void NoInField_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(NoInField, ItemOpFlags.NoInField);
        }

        private void NoTransNode_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(NoTransNode, ItemOpFlags.NoTransNode);
        }

        private void Only1_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Only1, ItemOpFlags.Only1);
        }

        private void Only2_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Only2, ItemOpFlags.Only2);
        }

        private void Only3_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Only3, ItemOpFlags.Only3);
        }

        private void Only4_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Only4, ItemOpFlags.Only4);
        }

        private void Only5_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Only5, ItemOpFlags.Only5);
        }

        private void Replaceable1_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Replaceable1, ItemOpFlags.Replaceable1);
        }

        private void Replaceable2_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Replaceable2, ItemOpFlags.Replaceable2);
        }

        private void Replaceable3_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Replaceable3, ItemOpFlags.Replaceable3);
        }

        private void Replaceable4_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Replaceable4, ItemOpFlags.Replaceable4);
        }

        private void Replaceable5_CheckedChanged(object sender, EventArgs e)
        {
            m_Item.SetOpFlags(Replaceable5, ItemOpFlags.Replaceable5);
        }
    }
}
