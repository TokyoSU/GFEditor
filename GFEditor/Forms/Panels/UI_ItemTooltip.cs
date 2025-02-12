namespace GFEditor.Editor
{
    [Flags]
    public enum TextFlags: byte
    {
        None = 0x0,
        /// <summary>
        /// Make the text go to next line.
        /// </summary>
        NextLine = 0x1,
        /// <summary>
        /// Add a space at the end of the text (even with fallback or basic text).
        /// </summary>
        AddSpaceOnEnd = 0x2,
        /// <summary>
        /// Same as 'AddSpaceOnEnd' but for start of text.
        /// </summary>
        AddSpaceOnStart = 0x4,
    }

    public partial class UI_ItemTooltip : Form
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private bool m_Visible = false;
        private Item? m_Item;

        public UI_ItemTooltip()
        {
            InitializeComponent();
            ControlBox = false;
            TooltipTxt.Font = new Font("Arial Unicode MS", TooltipTxt.Font.Size);
            TooltipTxt.BackColor = SColor.Black;
            TooltipTxt.ForeColor = SColor.Black;
            TooltipTxt.SelectionColor = SColor.Black;
            m_Visible = false;
        }

        /// <summary>
        /// Does the tooltip is shown or hidden ?
        /// </summary>
        /// <returns></returns>
        public bool IsVisible() => m_Visible;

        private bool TranslateCommand(string value)
        {
            if (m_Item == null) throw new AccessViolationException("Failed to translate command, item is null, was it assigned beforehand ?");

            if (value.Contains("#9#"))
            {
                var item = TItemDatabase.GetByIndex(m_Item.Index);
                var newName = Constants.Parameters.TranslateAutoOnLoad ? (item != null ? item.Name : m_Item.Name) : m_Item.Name;
                AddText(newName, string.Empty, GetColorFromQuality((QualityType)m_Item.ItemQuality), TextFlags.NextLine);
            }
            else if (value.Contains("#12#"))
            {
                AddTextIndex(72, string.Empty, SColor.LightBlue, TextFlags.NextLine);
            }
            else if (value.Contains("#26#") && value.Contains("^327^")) // STR
            {
                AddTextIndex(327, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.Str.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#27#") && value.Contains("^328^")) // VIT
            {
                AddTextIndex(328, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.Vit.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#28#") && value.Contains("^329^")) // INT
            {
                AddTextIndex(329, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.Int.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#29#") && value.Contains("^330^")) // WIL
            {
                AddTextIndex(330, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.Wil.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#30#") && value.Contains("^331^")) // AGI
            {
                AddTextIndex(331, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.Agi.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#24#") && value.Contains("^8513^")) // HP
            {
                AddText("+", m_Item.MaxHp.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8513, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#25#") && value.Contains("^8514^")) // MP
            {
                AddText("+", m_Item.MaxMp.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8514, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#34#")) // Attack Speed
            {
                double result = Convert.ToDouble(m_Item.AttackSpeed) / 10.0; // Attack speed is multiplied by 10.
                AddTextIndex(8507, string.Empty, SColor.White, TextFlags.AddSpaceOnEnd); // SPD text at 8507
                AddText(result.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#35#") && value.Contains("^8511^")) // Defence
            {
                AddTextIndex(8511, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.PhysicoDefence.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#37#") && value.Contains("^8512^")) // Magic Defence
            {
                AddTextIndex(8512, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.MagicDefence.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#38#") && value.Contains("^8515^")) // HitRate
            {
                int result = m_Item.HitRate / 10; // HitRate is multiplied by 10.
                AddText("+", result.ToString(), SColor.White, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8515, string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#61#") && value.Contains("^8530^")) // Socket Count ? (it say slots...)
            {
                AddText(m_Item.SocketMax.ToString(), string.Empty, SColor.White, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8530, string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#72#") && value.Contains("^8508^")) // Attack
            {
                AddTextIndex(8508, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.Attack.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#73#") && value.Contains("^8509^")) // Ranged Attack
            {
                AddTextIndex(8509, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.RangedAttack.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#36#") && value.Contains("^8510^")) // Magic Attack
            {
                AddTextIndex(8510, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.MagicDamage.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#79#"))
            {
                AddTextIndex(11971, string.Empty, SColor.LightBlue, TextFlags.NextLine);
            }
            // TODO: Check what this value do !
            //else if (value.Contains("#82#"))
            //{
            //    AddText("#82#", string.Empty, SColor.White, TextFlags.NextLine);
            //}
            else if (value.Contains("#83#"))
            {
                if (m_Item.IsHoly())
                    AddText("✩✩✩✩✩", string.Empty, SColor.Red, TextFlags.NextLine);
                else
                    AddText("Not an holy equipment (no star).", string.Empty, SColor.Red, TextFlags.NextLine);
            }
            else if (value.Contains("#84#"))
            {
                if (m_Item.IsHoly())
                    AddTextIndex(16563, string.Empty, SColor.LightBlue, TextFlags.NextLine);
                else
                    AddText("Not an holy equipment (not eligible).", string.Empty, SColor.LightBlue, TextFlags.NextLine);
            }

            return true;
        }

        private void MakeTooltip()
        {
            TooltipTxt.Clear(); // Remove previous text if any.

            // First, get the tooltip format in the translation file (T_TextIndex)
            var tooltipText = TTextIndexDatabase.GetByStringInText("#9#");
            if (tooltipText != null)
            {
                var list = tooltipText.Value.Split('\n');
                foreach (var str in list)
                {
                    if (!TranslateCommand(str)) // false = no_item, avoid spamming logs with the same info...
                        break;
                }
            }
            else
            {
                m_Log.Info("Failed to get the tooltip format in T_TextIndex by using #9# !");
            }
        }

        public void SetItem(Item? item)
        {
            m_Item = item ?? throw new ArgumentNullException("Failed to get tooltip item, it's null !");
            if (m_Item != null)
                MakeTooltip();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            Hide();
            m_Visible = false;
        }

        private void ItemTooltip_Shown(object sender, EventArgs e)
        {
            m_Visible = true;
        }

        private void AddText(string text, string endText, SColor textColor, TextFlags flags = TextFlags.None)
        {
            TooltipTxt.SelectionColor = textColor;
            string result = text;
            if (flags.HasFlag(TextFlags.AddSpaceOnStart))
                result += " ";
            if (!string.IsNullOrEmpty(endText))
                result += endText;
            if (flags.HasFlag(TextFlags.AddSpaceOnEnd))
                result += " ";
            if (flags.HasFlag(TextFlags.NextLine))
                result += "\n";
            TooltipTxt.AppendText(result);
        }

        private void AddTextIndex(int index, string endText, SColor textColor, TextFlags flags = TextFlags.None)
        {
            TooltipTxt.SelectionColor = textColor;

            var textIndex = TTextIndexDatabase.GetByIndex(index);
            if (textIndex == null)
            {
                TooltipTxt.SelectionColor = SColor.Red;
                TooltipTxt.AppendText("Failed to find index: " + index + " in T_TextIndex !\n");
                return;
            }

            string result = textIndex.Value;
            if (flags.HasFlag(TextFlags.AddSpaceOnEnd))
                result += " ";
            if (!string.IsNullOrEmpty(endText))
                result += endText;
            if (flags.HasFlag(TextFlags.NextLine))
                result += "\n";
            TooltipTxt.AppendText(result);
        }

        private SColor GetColorFromQuality(QualityType quality)
        {
            return quality switch
            {
                QualityType.Gray => SColor.Gray,
                QualityType.White => SColor.White,
                QualityType.Green => SColor.Green,
                QualityType.Blue => SColor.Blue,
                QualityType.Orange => SColor.Orange,
                QualityType.Gold => SColor.Gold,
                QualityType.Purple => SColor.Purple,
                QualityType.Red => SColor.Red,
                _ => SColor.White
            };
        }
    }
}
