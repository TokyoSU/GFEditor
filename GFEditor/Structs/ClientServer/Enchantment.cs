namespace GFEditor.Structs.ClientServer
{
    // STILL WIP

    /// <summary>
    /// TransitionID
    /// the number of enchantments that are likely to be activated, if it has nothing it means that they are always “passively” active.
    /// </summary>

    ///EnchantTransition: This is how the enchantment is activated.

    public class EnchantmentCommands
    {
        public int Index;
        public double Param1;
        public double Param2;
        public double Param3;
        public double Param4;
        public double Param5;
        public double Param6;
    }

    public class Enchantment
    {
        public int Index;
        public required string IconFilename;
        public int AnimationId;
        public int EffectId;
        public int EffectNode;
        public required string Name;
        public int EnchantType; // Use EnchantType enum.
        public ulong EnchantFlags; // Not yet found...
        /// <summary>
        /// Use MonsterType to set it.
        /// </summary>
        public int ImmuneMonsterType;
        public required EnchantmentCommands EnchantCommand1;
        public required EnchantmentCommands EnchantCommand2;
        public required EnchantmentCommands EnchantCommand3;
        public int Period;
        public int HiWord;
        public int LowWord;
        public required EnchantmentCommands TransitionCommands;
        public int EnchantTransition;
        public int TransitionRate;
        public int TransitionDuration;
        public int TransitionPeriod;
        public required string TransitionIconFilename;
        public int TransitionEnchantType;
        public ulong TransitionEnchantFlags;
        public int TransitionAnimationId;
        public int TransitionEffectId;
        public int TransitionEffectNode;
        public int TransitionEffectDuration;
        public int TransitionEffectDurationNode;
        public int TransitionCooldownTime;
        public int WeaponFlags;
        public int TransitionEnchantHiWord;
        public int TransitionEnchantLowWord;
        public required string Tip;
        public required string TransitionTip;
        public required string TransitionName;
        public int MaxStack;
    }
}
