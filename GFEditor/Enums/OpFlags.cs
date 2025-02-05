namespace GFEditor.Enums
{
    [Flags]
    public enum OpFlags : uint
    {
        None = 0x0,
        CanUse = 0x1,
        NoDecrease = 0x2,
        NoTrade = 0x4,
        NoDiscard = 0x8,
        NoEnhance = 0x10,
        NoRepair = 0x20,
        Combineable = 0x40,
        BindOnEquip = 0x80,
        AccumTime = 0x100,
        NoSameBuff = 0x200,
        NoInBattle = 0x400,
        NoInTown = 0x800,
        NoInCave = 0x1000,
        NoInInstance = 0x2000,
        LinkToQuest = 0x4000,
        ForDead = 0x8000,
        Only1 = 0x10000,
        Only2 = 0x20000,
        Only3 = 0x40000,
        Only4 = 0x80000,
        Only5 = 0x100000,
        Replaceable1 = 0x200000,
        Replaceable2 = 0x400000,
        Replaceable3 = 0x800000,
        Replaceable4 = 0x1000000,
        Replaceable5 = 0x2000000,
        NoInBattlefield = 0x4000000,
        NoInField = 0x8000000,
        NoTransNode = 0x10000000,
        UnBindItem = 0x20000000,
        OnlyEquip = 0x80000000
    }
}
