namespace GFEditor.Utils.Extensions
{
    public static class StringBuilderUtils
    {
        public static StringBuilder AppendGF(this StringBuilder sb, string value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            ArgumentNullException.ThrowIfNull(value);
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                sb.Append("");
            else
                sb.Append(value);
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, int value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != 0)
                sb.Append(value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, long value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != 0)
                sb.Append(value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, ulong value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != 0)
                sb.Append(value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, byte value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != 0)
                sb.Append(value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, short value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != 0)
                sb.Append(value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, ushort value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != 0)
                sb.Append(value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, float value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != 0.0f)
                sb.Append(value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, double value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != 0.0)
                sb.Append(value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EItemOpFlags value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            ulong flagValue = (ulong)value;
            if (flagValue != 0)
                sb.Append(flagValue.ToString("X"));
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EItemOpFlagsPlus value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            ulong flagValue = (ulong)value;
            if (flagValue != 0)
                sb.Append(flagValue.ToString("X"));
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, ERestrictClass value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            ulong flagValue = (ulong)value;
            if (flagValue != 0)
                sb.Append(flagValue.ToString("X"));
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EItemTarget value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != EItemTarget.eIT_None)
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EItemType value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != EItemType.eIIT_None)
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EEquipType value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != EEquipType.eEPT_None && value != EEquipType.eEPT_Max)
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EItemQuality value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != EItemQuality.eIQ_Max && value != EItemQuality.eIQ_White) // By default, white is the base quality !
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EAlignement value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != EAlignement.eA_None)
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EGender value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != EGender.eG_Female) // By default, female is the default !
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EAttrResist value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != EAttrResist.eAR_None && value != EAttrResist.eAR_Max) // By default, female is the default !
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EMonsterType value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != EMonsterType.eET_None) // By default, none is the default !
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EEnchantType value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != EEnchantType.eENT_None && value != EEnchantType.eENT_Max) // By default, none is the default !
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, ETimeType value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != ETimeType.eTIT_None) // By default, none is the default !
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EShopPriceType value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != EShopPriceType.eSPT_None) // By default, none is the default !
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EAuctionType value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != EAuctionType.eAT_None && value != EAuctionType.eAT_Max) // By default, none is the default !
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, EBuffIconType value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != EBuffIconType.eBT_None) // By default, none is the default !
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }

        public static StringBuilder AppendGF(this StringBuilder sb, ELimitTimeType value)
        {
            ArgumentNullException.ThrowIfNull(sb);
            if (value != ELimitTimeType.eLTT_None && value != ELimitTimeType.eLTT_Max) // By default, none is the default !
                sb.Append((int)value);
            else
                sb.Append("");
            return sb;
        }
    }
}
