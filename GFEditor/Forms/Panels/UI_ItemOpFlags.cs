using GFEditor.Structs.ClientServer;

namespace GFEditor.Editor
{
    public partial class UI_ItemOpFlags : Form
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private Item? m_Item;
        private readonly Dictionary<OpFlags, CheckBox> m_opCheckBoxDict;
        
        public UI_ItemOpFlags()
        {
            InitializeComponent();
            ControlBox = false;
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
        }

        private void PopulateOpFlags()
        {
            if (m_Item == null)
            {
                m_Log.Info("Failed to populate item opflags, item is null, was it assigned beforehand ?");
                return;
            }
            var flag = (OpFlags)m_Item.OpFlags;
            foreach (var entry in m_opCheckBoxDict)
            {
                if (flag.HasFlag(entry.Key))
                    entry.Value.Checked = true;
                else
                    entry.Value.Checked = false;
            }
        }

        public void SetItem(Item item)
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
            m_Item?.SetOpFlags(Useable, OpFlags.CanUse);
        }

        private void Combinable_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(Combinable, OpFlags.Combineable);
        }

        private void BindOnEquip_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(BindOnEquip, OpFlags.BindOnEquip);
        }

        private void AccumTime_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(AccumTime, OpFlags.AccumTime);
        }

        private void LinkQuest_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(LinkQuest, OpFlags.LinkToQuest);
        }

        private void ForDead_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(ForDead, OpFlags.ForDead);
        }

        private void UnbindItem_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(UnbindItem, OpFlags.UnBindItem);
        }

        private void OnlyEquip_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(OnlyEquip, OpFlags.OnlyEquip);
        }

        private void NoDecrease_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(NoDecrease, OpFlags.NoDecrease);
        }

        private void NoTrade_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(NoTrade, OpFlags.NoTrade);
        }

        private void NoDiscard_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(NoDiscard, OpFlags.NoDiscard);
        }

        private void NoEnchance_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(NoEnchance, OpFlags.NoEnhance);
        }

        private void NoRepair_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(NoRepair, OpFlags.NoRepair);
        }

        private void NoSameBuff_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(NoSameBuff, OpFlags.NoSameBuff);
        }

        private void NoInBattle_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(NoInBattle, OpFlags.NoInBattle);
        }

        private void NoInTown_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(NoInTown, OpFlags.NoInTown);
        }

        private void NoInCave_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(NoInCave, OpFlags.NoInCave);
        }

        private void NoInInstance_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(NoInInstance, OpFlags.NoInInstance);
        }

        private void NoInBattlefield_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(Useable, OpFlags.CanUse);
        }

        private void NoInField_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(NoInField, OpFlags.NoInField);
        }

        private void NoTransNode_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(NoTransNode, OpFlags.NoTransNode);
        }

        private void Only1_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(Only1, OpFlags.Only1);
        }

        private void Only2_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(Only2, OpFlags.Only2);
        }

        private void Only3_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(Only3, OpFlags.Only3);
        }

        private void Only4_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(Only4, OpFlags.Only4);
        }

        private void Only5_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(Only5, OpFlags.Only5);
        }

        private void Replaceable1_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(Replaceable1, OpFlags.Replaceable1);
        }

        private void Replaceable2_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(Replaceable2, OpFlags.Replaceable2);
        }

        private void Replaceable3_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(Replaceable3, OpFlags.Replaceable3);
        }

        private void Replaceable4_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(Replaceable4, OpFlags.Replaceable4);
        }

        private void Replaceable5_CheckedChanged(object sender, EventArgs e)
        {
            m_Item?.SetOpFlags(Replaceable5, OpFlags.Replaceable5);
        }
    }
}
