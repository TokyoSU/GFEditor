using System.Windows.Forms;

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

    public partial class UI_TooltipViewer : Form
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private bool m_Visible = false;
        private Item? m_Item = null;
        private bool m_HaveBoundItemAlready = false;

        public UI_TooltipViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Does the tooltip is shown or hidden ?
        /// </summary>
        /// <returns></returns>
        public bool IsVisible() => m_Visible;

        public void SetItem(Item? item)
        {
            m_Item = item ?? throw new ArgumentNullException("Failed to get tooltip item, it's null !");
            m_HaveBoundItemAlready = false;
            if (m_Item != null)
                UpdateTooltip();
        }

        public void SaveAndClose()
        {
            Hide();
            m_Visible = false;
        }

        private bool TranslateCommand(string value)
        {
            if (m_Item == null) throw new AccessViolationException("Failed to translate command, item is null, was it assigned beforehand ?");

            if (value.Contains("#9#"))
            {
                var item = TItemDatabase.GetByIndex(m_Item.Index);
                var itemName = m_Item.Name.Length > 0 ? m_Item.Name : string.Empty;
                AddText(Constants.Parameters.TranslateAutoOnLoad ? (item != null ? item.Name : itemName) : itemName, string.Empty, GetColorFromQuality((QualityType)m_Item.ItemQuality), TextFlags.NextLine);
            }
            else if (value.Contains("#12#") && !m_HaveBoundItemAlready)
            {
                OpFlags op = (OpFlags)m_Item.OpFlags;
                if (!op.HasFlag(OpFlags.BindOnEquip))
                    return true;
                AddTextIndex(72, string.Empty, SColor.LightBlue, TextFlags.NextLine);
                m_HaveBoundItemAlready = true;
            }
            else if (value.Contains("^8527^ #15#")) // Required level
            {
                if (m_Item.RestrictLevel == 0)
                    return true;
                AddTextIndex(8527, string.Empty, SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.RestrictLevel.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#18#")) // Class restriction
            {
                if (m_Item.RestrictClass == 0)
                    return true;

                AddText(m_Item.GetClassRestrictNameList(), string.Empty, SColor.Red, TextFlags.NextLine);
            }
            else if (value.Contains("^327^ #26#")) // STR
            {
                if (m_Item.Str == 0)
                    return true;
                AddTextIndex(327, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.Str.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("^328^ #27#")) // VIT
            {
                if (m_Item.Vit == 0)
                    return true;
                AddTextIndex(328, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.Vit.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("^329^ #28#")) // INT
            {
                if (m_Item.Int == 0)
                    return true;
                AddTextIndex(329, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.Int.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("^330^ #29#")) // WIL
            {
                if (m_Item.Wil == 0)
                    return true;
                AddTextIndex(330, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.Wil.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("^331^ #30#")) // AGI
            {
                if (m_Item.Agi == 0)
                    return true;
                AddTextIndex(331, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.Agi.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#24# ^8513^")) // HP
            {
                if (m_Item.MaxHp == 0)
                    return true;
                AddText("+", m_Item.MaxHp.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8513, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#25# ^8514^")) // MP
            {
                if (m_Item.MaxMp == 0)
                    return true;
                AddText("+", m_Item.MaxMp.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8514, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#34#")) // Attack Speed
            {
                if (m_Item.AttackSpeed == 0)
                    return true;
                double result = Convert.ToDouble(m_Item.AttackSpeed) / 10.0; // Attack speed is multiplied by 10.

                AddTextIndex(8507, string.Empty, SColor.White, TextFlags.AddSpaceOnEnd); // SPD text at 8507
                AddText(result.ToString(CultureInfo.InvariantCulture), string.Empty, SColor.White, TextFlags.NextLine); // Be sure to have '.' instead of ','
            }
            else if (value.Contains("^8511^ #35#")) // Defence
            {
                if (m_Item.PhysicoDefence == 0)
                    return true;
                AddTextIndex(8511, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.PhysicoDefence.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("^8510^ #36#")) // Magic Attack
            {
                if (m_Item.MagicDamage == 0)
                    return true;
                AddTextIndex(8510, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.MagicDamage.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("^8512^ #37#")) // Magic Defence
            {
                if (m_Item.MagicDefence == 0)
                    return true;
                AddTextIndex(8512, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.MagicDefence.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#38# ^8515^")) // HitRate
            {
                if (m_Item.HitRate == 0)
                    return true;
                int result = m_Item.HitRate / 10; // HitRate is multiplied by 10.

                AddText("+", result.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8515, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#39# ^8516^")) // Evade
            {
                if (m_Item.EvadeRate == 0)
                    return true;
                int result = m_Item.EvadeRate / 10; // Evade is multiplied by 10.

                AddText("+", result.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8516, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#40# ^8518^")) // CritRate
            {
                if (m_Item.PhysicoCriticalRate == 0)
                    return true;
                int result = m_Item.PhysicoCriticalRate / 10; // CritRate is multiplied by 10.

                AddText("+", result.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8518, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#41# ^8519^")) // CritDmg
            {
                if (m_Item.PhysicoCriticalDamage == 0)
                    return true;
                AddText("+", m_Item.PhysicoCriticalDamage.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8519, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#42# ^8520^")) // MCritRate
            {
                if (m_Item.MagicCriticalRate == 0)
                    return true;
                int result = m_Item.MagicCriticalRate / 10; // CritRate is multiplied by 10.

                AddText("+", result.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8520, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#43# ^8521^")) // MCritDmg
            {
                if (m_Item.MagicCriticalDamage == 0)
                    return true;
                AddText("+", m_Item.MagicCriticalDamage.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8521, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#61# ^8530^")) // Socket Count ? (it say slots...)
            {
                if (m_Item.SocketMax == 0)
                    return true;
                AddText(m_Item.SocketMax.ToString(), string.Empty, SColor.White, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8530, string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("^8538^#64#")) // Durability
            {
                if (m_Item.MaxDurability == 0)
                    return true;
                // Durability Value/Value (Value)
                AddTextIndex(8538, string.Empty, SColor.White, TextFlags.AddSpaceOnEnd);
                AddText($"{m_Item.MaxDurability}/{m_Item.MaxDurability} ({m_Item.MaxDurability})", string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#70#")) // Tip
            {
                if (m_Item.Tip.Length <= 0)
                    return true;
                var item = TItemDatabase.GetByIndex(m_Item.Index);
                var itemTip = m_Item.Tip.Length > 0 ? m_Item.Tip : string.Empty;
                AddText(Constants.Parameters.TranslateAutoOnLoad ? (item != null ? item.Description : itemTip) : itemTip, string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#71# ^8517^")) // Block
            {
                if (m_Item.BlockRate == 0)
                    return true;
                int result = m_Item.BlockRate / 10; // Block is multiplied by 10.

                AddText("+", result.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8517, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#72# ^8508^")) // Attack
            {
                if (m_Item.Attack == 0)
                    return true;

                AddTextIndex(8508, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.Attack.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#73# ^8509^")) // Ranged Attack
            {
                if (m_Item.RangedAttack == 0)
                    return true;

                AddTextIndex(8509, "+", SColor.White, TextFlags.AddSpaceOnEnd);
                AddText(m_Item.RangedAttack.ToString(), string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("^11075^#74#"))
            {
                if (m_Item.RestrictMaxLevel == 0)
                    return true;

                AddText(m_Item.RestrictMaxLevel.ToString(), string.Empty, SColor.White, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8528, string.Empty, SColor.White, TextFlags.NextLine);
            }
            // TODO: Check what this value do !
            //else if (value.Contains("#75#"))
            //{
            //    AddText("#75#", string.Empty, SColor.White, TextFlags.NextLine);
            //}
            // TODO: Check what this value do !
            //else if (value.Contains("#76#"))
            //{
            //    AddText("#76#", string.Empty, SColor.White, TextFlags.NextLine);
            //}
            //else if (value.Contains("#78#")) // Sprite skill name description
            //{

            //}
            else if (value.Contains("#79#"))
            {
                OpFlags op = (OpFlags)m_Item.OpFlags;
                if (!op.HasFlag(OpFlags.UnBindItem))
                    return true;
                AddTextIndex(11971, string.Empty, SColor.LightBlue, TextFlags.NextLine);
            }
            else if (value.Contains("#80#"))
            {
                
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
            }
            else if (value.Contains("#84#"))
            {
                if (m_Item.IsHoly())
                    AddTextIndex(16563, string.Empty, SColor.LightBlue, TextFlags.NextLine);
            }
            else if (value.Contains("#88# ^10623^")) // Time limit value
            {
                if (m_Item.DueDateTime == 0)
                    return true;

                AddText(m_Item.DueDateTime.ToString(), string.Empty, SColor.White, TextFlags.AddSpaceOnEnd);
                AddTextIndex(10623, string.Empty, SColor.White, TextFlags.NextLine);
            }
            else if (value.Contains("#90# ^15134^")) // PhysicalPen
            {
                if (m_Item.PhysicalPenetration == 0)
                    return true;
                int result = m_Item.PhysicalPenetration / 10;

                AddText("+", result.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(15134, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#91# ^15135^")) // MagicalPen
            {
                if (m_Item.MagicalPenetration == 0)
                    return true;
                int result = m_Item.MagicalPenetration / 10;

                AddText("+", result.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(15135, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#92# ^15136^")) // PhysicalPenReduce
            {
                if (m_Item.PhysicalPenetrationDefence == 0)
                    return true;
                int result = m_Item.PhysicalPenetrationDefence / 10;

                AddText("+", result.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(15136, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#93# ^15137^")) // MagicalPenReduce
            {
                if (m_Item.MagicalPenetrationDefence == 0)
                    return true;
                int result = m_Item.MagicalPenetrationDefence / 10;

                AddText("+", result.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(15137, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            // TODO: Check what this value do !
            //else if (value.Contains("#100#"))
            //{
            //    AddText("#100#", string.Empty, SColor.White, TextFlags.NextLine);
            //}
            else if (value.Contains("^8539^#16#^8540^#17#"))
            {
                ReputationType reputationType = (ReputationType)m_Item.RestrictReputation;
                if (reputationType == ReputationType.None)
                    return true;

                AddTextIndex(8539, reputationType.ToString(), SColor.Red, TextFlags.AddSpaceOnStart | TextFlags.AddSpaceOnEnd);
                AddTextIndex(8540, m_Item.RestrictReputationCount.ToString(), SColor.Red, TextFlags.AddSpaceOnStart | TextFlags.AddSpaceOnEnd | TextFlags.NextLine);
            }
            else if (value.Contains("^8524^#46#^8522^#44##45#^8506^")) // Attribute description
            {
                AttributeType attribType = (AttributeType)m_Item.Attribute;
                if (attribType == AttributeType.None || m_Item.AttributeDamage == 0)
                    return true;
                int resultRate = m_Item.AttributeRate / 10;

                AddTextIndex(8524, string.Empty, SColor.Cyan, TextFlags.AddSpaceOnEnd); // When physically attacking
                AddText("+", resultRate.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8522, string.Empty, SColor.Cyan, TextFlags.AddSpaceOnEnd); // % chance for additional damage
                AddText(attribType.ToString(), string.Empty, SColor.Cyan, TextFlags.AddSpaceOnEnd); // Attribute Name
                AddText(string.Empty, m_Item.AttributeDamage.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8506, string.Empty, SColor.Cyan, TextFlags.NextLine); // DMG
                AddTextIndexReplace(9797, string.Empty, [m_Item.AttributeDamage.ToString(), attribType.ToString()], 2, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("#47##44#^8523^")) // Attribute resistance
            {
                AttributeType attribType = (AttributeType)m_Item.Attribute;
                if (attribType == AttributeType.None)
                    return true;

                AddText(attribType.ToString(), "+", SColor.Cyan, TextFlags.AddSpaceOnStart);
                AddText(m_Item.AttributeResist.ToString(), string.Empty, SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8523, string.Empty, SColor.Cyan, TextFlags.NextLine);
            }
            else if (value.Contains("^8524^#49#^8525^#48#^8526^#50#^8506^")) // Special description
            {
                MonsterType specialType = (MonsterType)m_Item.SpecialType;
                if (specialType == MonsterType.None || m_Item.SpecialDamage == 0)
                    return true;
                int resultRate = m_Item.SpecialRate / 10;

                AddTextIndex(8524, string.Empty, SColor.Cyan, TextFlags.AddSpaceOnEnd); // When physically attacking
                AddText("+", resultRate.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8525, string.Empty, SColor.Cyan, TextFlags.AddSpaceOnEnd); // % chance to
                AddText(specialType.ToString(), string.Empty, SColor.Cyan, TextFlags.AddSpaceOnEnd); // Attribute Name
                AddTextIndex(8526, string.Empty, SColor.Cyan, TextFlags.AddSpaceOnEnd); // Cause
                AddText(string.Empty, m_Item.SpecialDamage.ToString(), SColor.Cyan, TextFlags.AddSpaceOnEnd);
                AddTextIndex(8506, string.Empty, SColor.Cyan, TextFlags.NextLine); // DMG
            }

            return true;
        }

        public void UpdateTooltip()
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
                ProcessDescriptionColors();
                m_Log.Info("Updated the tooltip !");
            }
            else
            {
                m_Log.Warn("Failed to get the tooltip format in T_TextIndex by using #9# !");
            }
        }

        private void TooltipViewer_Shown(object sender, EventArgs e)
        {
            m_Visible = true;
        }

        private void TooltipCloseBtn_Click(object sender, EventArgs e)
        {
            SaveAndClose();
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
            var textIndex = TTextIndexDatabase.GetByIndex(index);
            if (textIndex == null)
            {
                TooltipTxt.SelectionColor = SColor.Red;
                TooltipTxt.AppendText("Failed to find index: " + index + " in T_TextIndex !\n");
                return;
            }
            AddText(textIndex.Value, endText, textColor, flags);
        }

        private void AddTextIndexReplace(int index, string endText, string[] values, int replaceCount, SColor textColor, TextFlags flags = TextFlags.None)
        {
            var textIndex = TTextIndexDatabase.GetByIndex(index);
            if (textIndex == null)
            {
                TooltipTxt.SelectionColor = SColor.Red;
                TooltipTxt.AppendText("Failed to find index: " + index + " in T_TextIndex !\n");
                return;
            }

            int count = Regex.Matches(textIndex.Value, "%s").Count;
            if (count != replaceCount)
            {
                TooltipTxt.SelectionColor = SColor.Red;
                TooltipTxt.AppendText($"Failed to replace all values in: {index} from T_TextIndex, Count mismatch (from: {count}, required: {replaceCount} !\n");
                return;
            }

            string result = textIndex.Value;
            for (int i = 1; i <= count; i++) // NOTE: Replace string always start at 1.
                result = result.Replace($"%s{i}", values[i - 1]); // NOTE: values start by 0, so do i-1 to have correct value.
            AddText(result, endText, textColor, flags);
        }

        public void ProcessDescriptionColors()
        {
            if (string.IsNullOrEmpty(TooltipTxt.Text)) return;

            // Regex to find "$<number>$" markers
            var pattern = @"\$(\d+)\$"; // Capturing the number inside
            var matches = Regex.Matches(TooltipTxt.Text, pattern);

            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];

                // Extract the number inside $<number>$
                string numberString = match.Groups[1].Value;
                int number = int.Parse(numberString);

                // Start index of the match
                int startIndex = match.Index;
                int endIndex;
                // Determine the end of the section (next $<number>$ or end of string)
                if (i + 1 < matches.Count)
                {
                    endIndex = matches[i + 1].Index;
                }
                else
                {
                    endIndex = TooltipTxt.Text.Length;
                }
                int length = endIndex - startIndex;

                TooltipTxt.Select(startIndex, length);
                TooltipTxt.SelectionColor = CColorDatabase.GetByIndex(number).Color;
            }

            // Reset selection to avoid affecting further input
            TooltipTxt.Select(0, 0);
            TooltipTxt.SelectionColor = SColor.White; // Base color.
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
                QualityType.Purple => SColor.Magenta,
                QualityType.Red => SColor.Red,
                _ => SColor.White
            };
        }
    }
}
