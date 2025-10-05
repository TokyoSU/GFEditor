namespace GFEditor
{
    public enum EChestType
    {
        None = 0,
        Equipment = 1,
        Quest = 2,
        Basic = 3,
        Cursed = 4,
        Special = 5,
        Green = 6,
        Legendary = 7,
        Blue = 8,
        EquipmentGlowing = 9,
        GreenGlowing = 10,
        Max = 11
    };

    public enum EAchievementSummary
    {
        eAS_None = 0,
        eAS_MonsterKill = 1,
        eAS_Festival = 2,
        eAS_Mission = 3,
        eAS_Event = 4,
        eAS_Anecdotes = 5,
        eAS_Max = 6
    };

    public enum EAlignement
    {
        None = 0,
        KaslowRoyalFamily = 1,
        IlyaSenate = 2,
        JaleSteamCorporation = 3,
        Elsaland = 4,
        FourSeaTradeConcil = 5,
        RedCoconutParadise = 6,
        DeepFanthomExpedition = 7,
        //City08 = 8,
        //City09 = 9,
        //City10 = 10,
        QuillPublishing = 11,
        IronStoneAssociation = 12,
        MagicAcademy = 13,
        TreasureAppraisalCommittee = 14,
        DemonHunters = 15,
        SaphaelsHeart = 16,
        DarkSprite = 17,
        CrystalGuardian = 18,
        PKClub = 19,
        GuardianOfSaphael = 20,
        SpriteMessenger = 21,
        BodorGrasslandKing = 22,
        AliceForestQueen = 23,
        RontoDukeOfSand = 24,
        SmulcaHighlandLord = 25,
        EwanGeneralOfSpirits = 26,
        BahadoSouthSeaKing = 27,
        QuillHurricanPrince = 28,
        MosunkElderOfSerenity = 29,
        JundoEternalMother = 30,
        SiropasUnderworldKing = 31,
        IlaniaPrincessOfFrost = 32,
        GinnyMiracleSprings = 33,
        // Seem like not exist (v751 only?) !
        //Elf14 = 34,
        //Elf15 = 35,
        //Elf16 = 36,
        ClassReputation = 100,
        KaslowHolyRoyalResistance = 200,
        IlyaCultVengeance = 201,
        JaleSteamMachineMercenaries = 202,
        GasAssociation = 203,
        ArtAndCultureAssociation = 204,
        GroupEnd = 299,
        End = 300
    };

    public enum EAppellationCategory
    {
        eAppCategory_None = 0,
        eAppCategory_Normal = 1,
        eAppCategory_Max = 2
    };

    public enum EAppellationRarity
    {
        eAppRarity_None = 0,
        eAppRarity_Normal01 = 1,
        eAppRarity_Normal02 = 2,
        eAppRarity_Normal03 = 3,
        eAppRarity_Normal04 = 4,
        eAppRarity_Normal05 = 5,
        eAppRarity_Normal06 = 6,
        eAppRarity_Normal07 = 7,
        eAppRarity_Normal08 = 8,
        eAppRarity_Normal09 = 9,
        eAppRarity_Activity01 = 10,
        eAppRarity_Max = 11
    };

    public enum EAttr2AttrType
    {
        eA2A_None = 0,
        eA2A_Str2Con = 1,
        eA2A_Dex2Vol = 2,
        eA2A_Crl2Speed = 3,
        eA2A_Crl2RangeSpeed = 4,
        eA2A_Int2Str = 5,
        eA2A_Int2Dex = 6,
        eA2A_Vol2Con = 7,
        eA2A_MAtk2PAtk = 8,
        eA2A_Max = 9
    };

    public enum EAttrResist
    {
        None = 0,
        Light = 1,
        Dark = 2,
        Lightning = 3,
        Fire = 4,
        Ice = 5,
        Nature = 6,
        Max = 7,
    };

    public enum EAuctionType
    {
        None = 0,
        Sword = 1,
        Mace = 2,
        Axe = 3,
        Claymore = 4,
        WarHammer = 5,
        BattleAxe = 6,
        Bow = 7,
        Gun = 8,
        HolyItem = 9,
        Staff = 10,
        Shield = 11,
        KusoOneHand = 12,
        KusoTwoHand = 13,
        Head = 14,
        Chest = 15,
        Pants = 16,
        Glove = 17,
        Feet = 18,
        Back = 19,
        Trinket = 20,
        Backpack = 21,
        KusoHead = 22,
        KusoBack = 23,
        Mining = 24,
        Plant = 25,
        Hunting = 26,
        Arrow = 27,
        MissionItem = 28,
        Water = 29,
        Prestige = 30,
        Special = 31,
        Innate = 32,
        Rune = 33,
        ElfEquip = 34,
        ElfFurniture = 35,
        ElfCard = 36,
        Elf = 37,
        Ride = 38,
        Scroll = 39,
        Etc = 40,
        Machine = 41,
        HeavyMachine = 42,
        Cannon = 43,
        SpecialSet = 44,
        CrystalKatana = 45,
        CrystalKey = 46,
        Chair = 47,
        GodAreaEquip = 48,
        Gas = 49,
        Pigment = 50,
        PostCard = 51,
        Souvenir = 52,
        Max = 53
    };

    public enum EBattlefieldType
    {
        eBFT_None = 0,
        eBFT_1 = 1,
        eBFT_2 = 2,
        eBFT_3 = 3,
        eBFT_4 = 4,
        eBFT_5 = 5,
        eBFT_6 = 6,
        eBFT_7 = 7,
        eBFT_8 = 8,
        eBFT_9 = 9,
        eBFT_10 = 10,
        eBFT_11 = 11,
        eBFT_12 = 12,
        eBFT_13 = 13,
        eBFT_14 = 14,
        eBFT_15 = 15,
        eBFT_16 = 16,
        eBFT_17 = 17,
        eBFT_Max = 18
    };

    public enum EBFCamps
    {
        eBFC_None = 0,
        eBFC_Blue = 1,
        eBFC_Red = 2,
        eBFC_Kill = 3,
        eBFC_Max = 4
    };

    public enum EBFLevelType
    {
        eBFL_None = -1,
        eBFL_21_30 = 0,
        eBFL_31_Max = 1,
        eBFL_31_40 = 2,
        eBFL_41_50 = 3,
        eBFL_51_60 = 4,
        eBFL_61_70 = 5,
        eBFL_71_80 = 6,
        eBFL_81_90 = 7,
        eBFL_91_100 = 8,
        eBFL_81_100 = 9,
        eBFL_Max = 10
    };

    public enum EBiologyPatrolMode
    {
        eBPM_Sequence = 0,
        eBPM_Round = 1,
        eBPM_Normal = 2,
        eBPM_Sprinkle = 3,
        eBPM_Once = 4,
        eBPM_March = 5,
        eBPM_NoReturn = 6,
        eBPM_Max = 7
    };

    public enum EBuffIconType
    {
        None = 0,
        Buff = 1,
        Max = 2
    };

    public enum ECharacterSettingType
    {
        eCST_None = 0,
        eCST_ElfPick = 1,
        eCST_Max = 2
    };

    [Flags]
    public enum ERestrictClass : ulong
    {
        None = 0x0,
        Novice = 0x1,
        Fighter = 0x2,
        Warrior = 0x4,
        Paladin = 0x8,
        Berserker = 0x10,
        Hunter = 0x20,
        Archer = 0x40,
        Ranger = 0x80,
        Assassin = 0x100,
        Acolyte = 0x200,
        Priest = 0x400,
        Cleric = 0x800,
        Sage = 0x1000,
        Spellcaster = 0x2000,
        Mage = 0x4000,
        Wizard = 0x8000,
        Necromancer = 0x10000,
        Warlord = 0x20000,
        Templar = 0x40000,
        Sharpshooter = 0x80000,
        DarkStalker = 0x100000,
        Prophet = 0x200000,
        Mystic = 0x400000,
        Archmage = 0x800000,
        Demonologist = 0x1000000,
        Mechanic = 0x2000000,
        Machinist = 0x4000000,
        Enginner = 0x8000000,
        Demolitionist = 0x10000000,
        GearMaster = 0x20000000,
        Gunner = 0x40000000,
        Deathknight = 0x100000000,
        Crusader = 0x200000000,
        Hawkeye = 0x400000000,
        Windshadow = 0x800000000,
        Saint = 0x1000000000,
        Shaman = 0x2000000000,
        Avatar = 0x4000000000,
        Shadowlord = 0x8000000000,
        Destroyer = 0x10000000000,
        HolyKnight = 0x20000000000,
        Predator = 0x40000000000,
        Shinobi = 0x80000000000,
        Archangel = 0x100000000000,
        Druid = 0x200000000000,
        Warlock = 0x400000000000,
        Shinigami = 0x800000000000,
        CogMaster = 0x1000000000000,
        Bombardier = 0x2000000000000,
        MechMaster = 0x4000000000000,
        Artillerist = 0x8000000000000,
        Wanderer = 0x10000000000000,
        Drifter = 0x20000000000000,
        VoidRunner = 0x40000000000000,
        TimeTraveler = 0x80000000000000,
        Dimensionalist = 0x100000000000000,
        KeyMaster = 0x200000000000000,
        Reaper = 0x400000000000000,
        Chronomancer = 0x800000000000000,
        Phantom = 0x1000000000000000,
        ChronoShifter = 0x2000000000000000
    }

    public enum EClass
    {
        Novice = 0,
        Fighter = 1,
        Warrior = 2,
        Berserker = 3,
        Paladin = 4,
        Hunter = 5,
        Archer = 6,
        Ranger = 7,
        Assassin = 8,
        Acolyte = 9,
        Cleric = 10,
        Templar = 11,
        Sage = 12,
        Caster = 13,
        Magician = 14,
        Wizard = 15,
        Necromancer = 16,
        DevilWarrior = 17,
        SkyKnight = 18,
        TreasureHunter = 19,
        Killer = 20,
        Bishop = 21,
        Prophet = 22,
        Archmage = 23,
        DevilMaster = 24,
        Recruit = 25,
        Soldier = 26,
        Assault = 27,
        SpecialAgent = 28,
        Assault4 = 29,
        SpecialAgent4 = 30,
        All = 31,
        DevilWarrior5 = 32,
        SkyKnight5 = 33,
        TreasureHunter5 = 34,
        Killer5 = 35,
        Bishop5 = 36,
        Prophet5 = 37,
        Archmage5 = 38,
        DevilMaster5 = 39,
        DevilWarrior6 = 40,
        SkyKnight6 = 41,
        TreasureHunter6 = 42,
        Killer6 = 43,
        Bishop6 = 44,
        Prophet6 = 45,
        Archmage6 = 46,
        DevilMaster6 = 47,
        Assault5 = 48,
        SpecialAgent5 = 49,
        Assault6 = 50,
        SpecialAgent6 = 51,
        NoviceTraveler = 52,
        Traveler = 53,
        SpaceTraveler3 = 54,
        TimeTraveler3 = 55,
        SpaceTraveler4 = 56,
        TimeTraveler4 = 57,
        SpaceTraveler5 = 58,
        TimeTraveler5 = 59,
        SpaceTraveler6 = 60,
        TimeTraveler6 = 61,
        MaxClass = 62,
        Pet = 63,
        Max = 64
    };

    public enum ECombineItemType
    {
        None = 0,
        Head = 1,
        Chest = 2,
        Pants = 3,
        Glove = 4,
        Feet = 5,
        Back = 6,
        Sword = 7,
        Claymore = 8,
        Mace = 9,
        WarHammer = 10,
        Axe = 11,
        BattleAxe = 12,
        Bow = 13,
        Gun = 14,
        HolyItem = 15,
        Staff = 16,
        Shield = 17,
        Trinket = 18,
        IK_Back = 19,
        IK_Head = 20,
        IK_Suit = 21,
        IK_Shield = 22,
        IK_OneHand = 23,
        IK_TwoHand = 24,
        GK_Back = 25,
        GK_Head = 26,
        GK_Suit = 27,
        GK_Shield = 28,
        GK_OneHand = 29,
        GK_TwoHand = 30,
        Machine = 31,
        HeavyMachine = 32,
        Cannon = 33,
        Katana = 34,
        Key = 35,
        Rune = 36,
        CrystalCombo = 37,
        Souvenir = 38,
        Max = 39
    };

    public enum ECropCategory
    {
        Family = 0,
        Elf = 1,
        IsleFish = 2,
        Mineral = 3,
        Plant = 4,
        Cattle = 5,
        Max = 6
    };

    public enum ECursorType
    {
        None = 1,
        Talk = 2,
        Examine = 3,
        Transport = 4,
        Repair = 5,
        Auction = 6,
        Mail = 7,
        Max = 8
    };

    public enum EElfCombineType
    {
        None = 0,
        Strong = 1,
        Combine = 2,
        Make = 3,
        Cook = 4,
        Match = 5,
        Max = 6
    };

    public enum EElfWorkType
    {
        None = 0,
        Combine = 1,
        Collect = 2,
        Train = 3,
        Leave = 4,
        Lottery = 5,
        Unknown = 6,
        Game = 7,
        Travel = 8,
        Max = 9
    };

    public enum EElfLotteryType
    {
        eELT_None = 0,
        eELT_Normal = 1,
        eELT_ItemMall = 2,
        eELT_High = 3,
        eELT_Max = 4
    };

    public enum EElfSkillType
    {
        None = 0,
        Mining = 1,
        Plant = 2,
        Hunting = 3,
        Decompose = 4,
        Sword = 5,
        Axe = 6,
        Mace = 7,
        Bow = 8,
        Gun = 9,
        Staff = 10,
        Shield = 11,
        Relic = 12,
        Fighter = 13,
        Hunter = 14,
        Caster = 15,
        Acolyte = 16,
        Machine = 17,
        HeavyMachine = 18,
        Mech = 19,
        CrystalKatana = 20,
        CrystalKey = 21,
        CrystalEquip = 22,
        Gas = 23,
        Pigment = 24,
        Map = 25,
        SoulCrystal = 26,
        Gas1 = 27,
        Gas2 = 28,
        Gas3 = 29,
        Gas4 = 30,
        Gas5 = 31,
        Gas6 = 32,
        Gas7 = 33,
        Gas8 = 34,
        Gas9 = 35,
        Gas10 = 36,
        Gas11 = 37,
        Gas12 = 38,
        Pigment1 = 39,
        Pigment2 = 40,
        Pigment3 = 41,
        Pigment4 = 42,
        Pigment5 = 43,
        Pigment6 = 44,
        Pigment7 = 45,
        Pigment8 = 46,
        Pigment9 = 47,
        Pigment10 = 48,
        Pigment11 = 49,
        Pigment12 = 50,
        Map1 = 51,
        Map2 = 52,
        Map3 = 53,
        Map4 = 54,
        Map5 = 55,
        Map6 = 56,
        Map7 = 57,
        Map8 = 58,
        Map9 = 59,
        Map10 = 60,
        Map11 = 61,
        Map12 = 62,
        SoulCrystal1 = 63,
        SoulCrystal2 = 64,
        SoulCrystal3 = 65,
        SoulCrystal4 = 66,
        SoulCrystal5 = 67,
        SoulCrystal6 = 68,
        SoulCrystal7 = 69,
        SoulCrystal8 = 70,
        SoulCrystal9 = 71,
        SoulCrystal10 = 72,
        SoulCrystal11 = 73,
        SoulCrystal12 = 74,
        Travel = 75,
        Max = 76
    };

    public enum EElfType
    {
        Original = 0,
        Return = 1,
        Max = 2
    };

    [Flags]
    public enum EEnchantFlag
    {
        None = 0x00,
        RemoveAttack = 0x01,
        RemoveBeAttacked = 0x02,
        RemoveHurt = 0x04,
        EnchantReserve = 0x08,
        CantAbandon = 0x10,
        DieReserve = 0x20,
        VultureOnly = 0x40,
        WolfOnly = 0x80,
        GorillaOnly = 0x100,
        NoBoss = 0x200,
        NoTransNode = 0x400,
        DailyType = 0x800,
        MachineOnly = 0x1000,
        NoUseItem = 0x2000,
        NoTotem = 0x4000,
        HideIcon = 0x8000,
        VIP = 0x10000,
        NoMove = 0x20000,
        Heal = 0x40000,
        NoRebirth = 0x80000,
        NoBattlefield = 0x100000,
        NoWarningMsg = 0x200000,
        NoStack = 0x400000
    };

    public enum EEnchantTransition
    {
        eETT_None = 0,
        eETT_AttackToSelf = 1,
        eETT_AttackToOpponent = 2,
        eETT_HurtToSelf = 3,
        eETT_HurtToOpponent = 4,
        eETT_Max = 5
    };

    public enum EEnchantType
    {
        None = 0,
        Buff = 1,
        Debuff = 2,
        Max = 3
    };

    public enum EEquipTrainItemType
    {
        Sword = 0,
        Axe = 1,
        Mace = 2,
        Claymore = 3,
        BattleAxe = 4,
        WarHammer = 5,
        Staff = 6,
        Bow = 7,
        Gun = 8,
        HolyItem = 9,
        Shield = 10,
        Head = 11,
        Chest = 12,
        Pants = 13,
        Glove = 14,
        Feet = 15,
        Trinket = 16,
        Back = 17,
        Ride = 18,
        Machine = 19,
        HeavyMachine = 20,
        Cannon = 21,
        CrystalKatana = 22,
        CrystalKey = 23,
        Max = 24
    };

    public enum EEquipTrainType
    {
        eEETT_Undefined = 0,
        eEETT_Str = 1,
        eEETT_Con = 2,
        eEETT_Int = 3,
        eEETT_Vol = 4,
        eEETT_Dex = 5,
        eEETT_HP = 6,
        eEETT_MP = 7,
        eEETT_PA = 8,
        eEETT_RA = 9,
        eEETT_MA = 10,
        eEETT_Dodge = 11,
        eEETT_Hit = 12,
        eEETT_PD = 13,
        eEETT_MD = 14,
        eEETT_CriLv = 15,
        eEETT_MCriLv = 16,
        eEETT_CriDef = 17,
        eEETT_MCriDef = 18,
        eEETT_PPen = 19,
        eEETT_MPen = 20,
        eEETT_PPenDef = 21,
        eEETT_MPenDef = 22,
        eEETT_Max = 23
    };

    public enum EEquipType
    {
        Unknown = -1,
        None = 0,
        Head = 1,
        Chest = 2,
        Pants = 3,
        Glove = 4,
        Feet = 5,
        Back = 6,
        OneHand = 7,
        LeftHand = 8,
        TwoHands = 9,
        Shoot = 10,
        Accessory = 11,
        Ammo = 13,
        BackPack = 14,
        SpellStoneA = 15,
        SpellStoneB = 16,
        SpellStoneC = 17,
        SpellStoneD = 18,
        ElfStoneA = 19,
        ElfStoneB = 20,
        ElfCap = 21,
        ElfClothes = 22,
        ElfFurnitureA = 23,
        ElfFurnitureB = 24,
        ElfFurnitureC = 25,
        ElfFloor = 26,
        ElfWall = 27,
        OneHandOnly = 28, // This accept only 1 onehand of the same name.
        AccessoryOnly = 29, // This accept only 1 accessory of the same name.
        SpellStoneE = 30,
        SpellStoneF = 31,
        SpellStoneG = 32,
        SpellStoneH = 33,
        IsleEquipA = 34,
        IsleEquipB = 35,
        IsleEquipC = 36,
        IsleEquipD = 37,
        IsleEquipE = 38,
        IsleEquipF = 39,
        IKRide = 40,
        GKRide = 41,
        SoulCrystal = 42,
        Souvenir = 43,
        Max = 44
    };

    public enum EEtcFlagType
    {
        eEFT_None = 0,
        eEFT_MentorshipCantBeStudent = 1,
        eEFT_MentorshipCantBeMentor = 2,
        eEFT_Max = 3
    };

    public enum EFamilyTreeType
    {
        eFTT_Normal = 0,
        eFTT_Activity1 = 1,
        eFTT_Activity2 = 2,
        eFTT_Hard = 3,
        eFTT_Max = 4
    };

    public enum EFBattle
    {
        eFB_None = 0,
        eFB_Chaslot = 1,
        eFB_Elia = 2,
        eFB_Gear = 3,
        eFB_Deepfathom = 4,
        eFB_Max = 5
    };

    public enum EFormType
    {
        eFT_Human = 0,
        eFT_Vulture = 1,
        eFT_Wolf = 2,
        eFT_Gorilla = 3,
        eFT_Sneak = 4,
        eFT_NoCheck = 5,
        eFT_Machine = 6,
        eFT_Max = 7
    };

    public enum EFreeItemMallOpType
    {
        eFIM_None = 0,
        eFIM_Success = 1,
        eFIM_UnknowError = 2,
        eFIM_Offline = 3,
        eFIM_UnknowItem = 4,
        eFIM_BagNoSpace = 5,
        eFIM_UniqueItem = 6,
        eFIM_Max = 7
    };

    public enum EGender
    {
        eG_Female = 0,
        eG_Male = 1
    };

    public enum EGuildRank
    {
        eFR_Member = 0,
        eFR_Leader = 1,
        eFR_Cadre2 = 2,
        eFR_Cadre3 = 3,
        eFR_Cadre4 = 4,
        eFR_Cadre5 = 5,
        eFR_Cadre6 = 6,
        eFR_Cadre7 = 7,
        eFR_Cadre8 = 8,
        eFR_Max = 9
    };

    public enum EHateControl
    {
        None = 0x0,
        HateSummon = 0x1,
        WeakAttack = 0x2,
        NotReset = 0x4,
    };

    [Flags]
    public enum EItemOpFlags : ulong
    {
        None = 0x00,
        CanUse = 0x01,
        NoDecrease = 0x02,
        NoTrade = 0x04,
        NoDiscard = 0x08,
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
        Only = Only1 | Only2 | Only3 | Only4 | Only5,
        Replaceable1 = 0x200000,
        Replaceable2 = 0x400000,
        Replaceable3 = 0x800000,
        Replaceable4 = 0x1000000,
        Replaceable5 = 0x2000000,
        Replaceable = Replaceable1 | Replaceable2 | Replaceable3 | Replaceable4 | Replaceable5,
        NoInBattlefield = 0x4000000,
        NoInField = 0x8000000,
        NoTransNode = 0x10000000,
        UnBindItem = 0x20000000,
        Unknown = 0x40000000,
        OnlyEquip = 0x80000000
    };

    [Flags]
    public enum EItemOpFlagsPlus : ulong
    {
        None = 0x00,
        IKCombine = 0x01,
        GKCombine = 0x02,
        EquipShow = 0x04,
        PurpleWLimit = 0x08,
        PurpleALimit = 0x10,
        UseBind = 0x20,
        OneStack = 0x40,
        RideCombineIK = 0x80,
        RideCombineGK = 0x100,
        ISRideCombine = 0x180,
        VIP = 0x200,
        ChairCombineIK = 0x800,
        ChairCombineGK = 0x1000,
        ISChairCombine = 0x1800,
        RedWLimit = 0x2000,
        RedALimit = 0x4000,
        CrystalCombo = 0x8000,
        SouvenirCombo = 0x10000,
        GodAreaCombo = 0x20000
    };

    public enum EItemQuality
    {
        White = 0,
        Gray = 1,
        Green = 2,
        Blue = 3,
        Orange = 4,
        Yellow = 5,
        Purple = 6,
        Red = 7,
        Max = 8
    };

    public enum EItemTarget
    {
        None = 1,
        ToSelf = 2,
        ToElf = 3,
        ToChar = 4,
        ToItem = 5,
        ToCrop = 6,
        ToFarm = 7,
        ToIsleScene = 8,
        ToIsleStatue = 9,
        ToHiredFarm = 10,
        ToFishGround = 11,
        ToFish = 12,
        ToPit = 13,
        ToMineral = 14,
        ToPlant = 15,
        ToIsleFarm = 16,
        ToCattle = 17,
        ToPasturage = 18,
        ToESShortcut = 19,
        ToMonster = 20,
        ToNPC = 21,
        ToSpellAA = 22,
        Max = 23
    };

    public enum EItemType
    {
        None = 0,
        Head = 1,
        Chest = 2,
        Pants = 3,
        Glove = 4,
        Feet = 5,
        Back = 6,
        Sword = 7,
        Claymore = 8,
        Mace = 9,
        WarHammer = 10,
        Axe = 11,
        BattleAxe = 12,
        Bow = 13,
        Gun = 14,
        HolyItem = 15,
        Staff = 16,
        Shield = 17,
        Trinket = 18,
        Arrow = 19,
        Bullet = 20,
        Backpack = 21,
        Item = 22,
        Material = 23,
        Rune = 24,
        Scroll = 25,
        SpellStone = 26,
        EquipSet = 27,
        Treasure = 28,
        LuckyBag = 29,
        ElfStone = 30,
        ElfEquip = 31,
        Chip = 32,
        Formula = 33,
        Crystal = 34,
        Kuso = 35,
        KusoOneHand = 36,
        KusoTwoHand = 37,
        KusoStaff = 38,
        KusoBow = 39,
        KusoGun = 40,
        KusoShield = 41,
        KusoSuit = 42,
        ElfGameItem = 43,
        WitchCraft = 44,
        Building = 45,
        UnBindItem = 46,
        ElfBackpack = 47,
        Food = 48,
        MatchItem = 49,
        KusoTrinket = 50,
        ElfBook1 = 51,
        ElfBook2 = 52,
        ElfBook3 = 53,
        Machine = 54,
        HeavyMachine = 55,
        Cannon = 56,
        Artillery = 57,
        KusoSoulCrystal = 58,
        CrystalKatana = 59,
        CrystalKey = 60,
        PostCard = 61,
        Souvenir = 62,
        OptionalLuckyBag = 63,
        CombineRate = 8001,
        StrengthenRate = 8002,
        CookRate = 8003,
        MatchRate = 8004,
        StrengthenTransfer = 8005,
        RideCombinePoint = 8006,
        OpenUIStart = 9001,
        OpenUIEnd = 9999,
        Max = 10000
    };

    [Flags]
    public enum EItemTypeForDB
    {
        Head = 0x01,
        Chest = 0x02,
        Pants = 0x04,
        Glove = 0x08,
        Feet = 0x10,
        Back = 0x20,
        Sword = 0x40,
        Claymore = 0x80,
        Mace = 0x100,
        WarHammer = 0x200,
        Axe = 0x400,
        BattleAxe = 0x800,
        Bow = 0x1000,
        Gun = 0x2000,
        HolyItem = 0x4000,
        Staff = 0x8000,
        Shield = 0x10000,
        Trinket = 0x20000,
        Machine = 0x40000,
        HeavyMachine = 0x80000,
        Cannon = 0x100000,
        CrystalKatana = 0x200000,
        CrystalKey = 0x400000
    };

    public enum ElfBattleOperation
    {
        None = 0,
        BattleOpenEquip = 1,
        BattleMode = 2,
        Action = 3,
        Control = 4,
        SpellCast = 5,
        Pick = 6,
        Max = 7
    };

    public enum ELimitTimeType
    {
        None = 0,
        Use_Min = 1,
        Use_Hour = 2,
        Use_Day = 3,
        Get_Min = 4,
        Get_Hour = 5,
        Get_Day = 6,
        Max = 7
    };

    public enum ELuckyBarType
    {
        eLBT_None = 0,
        eLBT_BetOpportunity = 9,
        eLBT_BetDestiny = 10,
        eLBT_Max = 11
    };

    public enum ELuckyBingo
    {
        eLBingo_Fail = 0,
        eLBingo_1 = 1,
        eLBingo_2 = 2,
        eLBingo_3 = 3,
        eLBingo_4 = 4,
        eLBingo_Special = 999
    };

    public enum EMarqueeType
    {
        eMarquee_Fukubukuro = 0,
        eMarquee_GeneralRefinery = 1,
        eMarquee_ColorfulRefinery = 2,
        eMarquee_LotteryGoItem = 3,
        eMarquee_LotteryGoItemMall = 4,
        eMarquee_Max = 5
    };

    public enum EMentorRank
    {
        eMR_None = 0,
        eMR_01 = 1,
        eMR_02 = 2,
        eMR_03 = 3,
        eMR_04 = 4,
        eMR_05 = 5,
        eMR_06 = 6,
        eMR_Max = 7
    };

    public enum EMentorshipInstanceLevel
    {
        eMILV_New = 0,
        eMILV_01 = 1,
        eMILV_02 = 2,
        eMILV_03 = 3,
        eMILV_AllPassed = 4
    };

    public enum EMentorshipUpdateType
    {
        None = 0,
        Self = 1,
        Mentor = 2,
        Student = 4,
        Full = 7,
        Delete = 512
    };

    public enum EMHPMP2AttrType
    {
        None = 0,
        MHP2MeleeDamage = 1,
        MMP2MeleeDamage = 2,
        MHP2RangeDamage = 3,
        MMP2RangeDamage = 4,
        MHP2MagicDamage = 5,
        MMP2MagicDamage = 6,
        MHP2Str = 7,
        MMP2Str_2 = 8,
        MHP2Int = 9,
        MMP2Int_2 = 10,
        MHP2Dex = 11,
        MMP2Dex_2 = 12,
        Max = 13
    };

    public enum EMissionFlag
    {
        None = 0x0,
        NoAbandon = 0x1,
        NoShare = 0x2,
        Reaccept = 0x4,
        AutoAccept = 0x8,
        NoRebirthReset = 0x10
    };

    public enum EMissionType
    {
        None = 0,
        Personal = 1,
        Emergent = 2,
        Class = 3,
        Team = 4,
        Guild = 5,
        Pvp = 6,
        Max = 7
    };

    public enum EMonsterAlign
    {
        None = 0,
        Normal = 1,
        Savage = 2,
        Npc = 3,
        PlayerRed = 4,
        PlayerBlue = 5,
        Max = 6
    };

    public enum EMonsterRank
    {
        None = 0,
        Monster = 1,
        Elite = 2,
        Boss = 3,
        SceneObj = 4,
        InstanceElite = 5,
        FieldBoss = 6,
        Attacker = 7,
        Defender = 8,
        TerritoryCrystal = 9,
        PBBoss = 10,
        AltarStart = 100,
        AltarA = 101,
        AltarB = 102,
        AltarC = 103,
        AltarD = 104,
        AltarE = 105,
        AltarF = 106,
        AltarG = 107,
        AltarEnd = 108
    };

    public enum EMonsterType
    {
        None = 0x0,
        Animal = 0x1,
        Plant = 0x2,
        Human = 0x4,
        Element = 0x8,
        Machine = 0x10,
        Undead = 0x20,
        Demon = 0x40
    };

    public enum ENodeType
    {
        None = 0,
        Field = 1,
        Cave = 2,
        Town = 3,
        Instance = 4,
        Battlefield = 5,
        RaidInstance = 6,
        FamilyInstance = 7,
        FamilyBattle = 8,
        FamilyInstance2 = 9,
        GMMap = 10,
        Territory = 11,
        Arena = 12,
        RaidFamilyInstance2 = 13,
        Private = 14,
        Dungeon = 15,
        FamilyTreeInstance = 16,
        MentorInstance = 17,
        HuntingGround = 18,
        BeastsTower = 19,
        LoveChallengeInstance1 = 20,
        LoveChallengeInstance2 = 21,
        ElfTempleInstance = 22,
        CrossZoneHuntingGround = 23,
        Max = 24
    };

    public enum EPVPDamageType
    {
        ePD_Physic = 0,
        ePD_Magic = 1,
        ePD_Max = 2
    };

    public enum ERankAwardType
    {
        None = 0,
        TotalRank = 1,
        MonterKill = 2,
        Mission = 3,
        Festival = 4,
        MVP = 5,
        HightKill = 6,
        Altar = 7,
        Cure = 8,
        KillCount = 9,
        PKPalace = 10,
        Lorekeeper = 11,
        ElfGladiator = 12,
        FunBattlefield = 13,
        Race = 998,
        DynamicEvent = 999
    };

    public enum ERecommendEventsType
    {
        FirstKillMonster = 0,
        FirstKillTreasure = 1,
        KillMonster = 2,
        CompleteBattlefield = 3,
        BattlefieldVictory = 4,
        GeneralRefinery = 5,
        ColorfulRefinery = 6,
        SpecialPoints = 7,
        EquipmentStrengthen = 8,
        CompleteTask = 9,
        GetEnchant = 10,
        GreenEquipment = 11,
        OrangeEquipment = 12,
        YellowEquipment = 13,
        Marquee = 14,
        OpenLuckyBag = 15,
        ItemCombine = 16,
        KillPlayer = 17,
        ElfTeamFight = 18,
        LotteryRecord = 19,
        LevelUp = 20,
        RepairIsle = 21,
        Fishing = 22,
        Islend = 23,
        UseUnBindItem = 24,
        LuckyStarBet = 25,
        LuckyStarWinMoney = 26,
        LuckyBarBet = 27,
        LuckyBarWinMoney = 28,
        LotteryGoItem = 29,
        LotteryGoItemMall = 30,
        FightKing = 31,
        GladiatorCount = 32,
        Max = 33
    };

    public enum ERideComboQuality
    {
        None = 0,
        White = 1,
        Green = 2,
        Blue = 3,
        Orange = 4,
        Yellow = 5,
        Max = 6
    };

    public enum ERideComboType
    {
        None = 0,
        IK = 1,
        GK = 2,
        Max = 3
    };

    public enum EScheduleDayType
    {
        None = -1,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7,
        Allday = 8
    };

    public enum EScheduleFunctionType
    {
        None = 0,
        Territory1 = 1,
        Territory2 = 2,
        Territory3 = 3,
        Territory4 = 4,
        Territory5 = 5,
        Territory6 = 6,
        Battlefield1 = 100,
        Battlefield2 = 101,
        Battlefield3 = 102,
        Battlefield4 = 103,
        Battlefield5 = 104,
        Battlefield6 = 105,
        Battlefield7 = 106,
        Battlefield8 = 107,
        Battlefield9 = 108,
        Battlefield14 = 109,
        Battlefield15 = 110,
        Battlefield16 = 111,
        Colosseum = 200,
        Arena = 300,
        PKPalace = 400,
        Wedding = 500,
        ElfSchool = 600,
        BeastsTower = 700
    };

    public enum EScreenMessageType
    {
        None = 0,
        Zone = 1,
        World = 2,
        HeroMonster = 3,
        HeroActivity = 4,
        Winner = 5,
        Discovery = 6,
        Bulletin = 7,
        Megaphone = 8,
        Striking = 9,
        Notify = 10,
        ElfSchool = 11,
        DynamicEvent = 12,
        Max = 13
    };

    public enum EShopPriceType
    {
        None = 0,
        Gold = 1,
        Battlefield = 2,
        Achievement = 3,
        Love = 4,
        FamilyBattle = 5,
        HuntStamp = 6,
        FortuneCoin = 7,
        Transport = 8,
        PKPalace = 9,
        Group11 = 10,
        Group12 = 11,
        Group13 = 12
    };

    public enum EShopType
    {
        None = 0,
        Spell = 1,
        Weapon = 2,
        Armor = 3,
        Newbie = 4,
        Item = 5,
        Rider = 6,
        Elf = 7,
        Family = 8,
        Bank = 9,
        Mail = 10,
        TPA = 11,
        Strengthen = 12,
        Combine = 13,
        Auction = 14,
        ElfReturn = 15,
        MessageBoard = 16,
        FamilyStorage = 17,
        FamilyFlag = 18,
        FamilyBattleSchedule = 19,
        FamilyRecruit = 20,
        LuckyBar = 21,
        ElfBoxing = 22,
        KusoCombine = 23,
        WishingWell = 24,
        ItemMall1 = 51,
        ItemMall2 = 52,
        ItemMall3 = 53,
        ItemMall4 = 54,
        ItemMall5 = 55,
        ItemMall6 = 56,
        ItemMall7 = 57,
        ItemMall8 = 58,
        FamilyBattleSchedule1 = 59,
        Progress = 60,
        StrengthenTransfer = 61,
        FamilyBattleSchedule2 = 62,
        RideCombine = 63,
        FamilyTransform = 64,
        FamilyBattleSchedule3 = 65,
        SpellStorage = 66,
        SpellReturn = 67,
        ElfRacing_1 = 68,
        ElfRacing_2 = 69,
        ElfRacing_3 = 70,
        Rebirth = 71,
        ItemExchange = 72,
        ChairCombine = 73,
        ChairSell = 74,
        Awake = 75,
        RuneReCombo = 76,
        CrystalCombo = 77,
        SouvenirCombo = 78,
        GodAreaCombo = 79,
        MissionOpen = 10000,
        MissionReward = 10001,
        MissionOnGoing = 10002,
        MissionFinish = 10003,
        FamilyFarm = 11000,
        CreateIsle = 11001,
        Isle = 11002,
        IsleAltar = 11003,
        ISleStatue = 11004,
        IsleBulletin = 11005,
        IsleFishGround = 11006,
        IsleInfo = 11007,
        PKPalace = 11008,
        Pit = 11009,
        Ranch = 11010,
        Pasturage = 11011,
        Cook = 11012,
        Match = 11013,
        IsleFram = 11014,
        IslePasturage = 11015,
        IsleStorage = 11016,
        IsleChangeName = 11017,
        GameTimer = 12000,
        GameTimer2 = 12001,
        OpenCheckMarryDlg = 13000,
        OpenCheckMarryDlgItemMall = 13001,
        OpenCheckDivorceDlg = 13002,
        OpenCheckDivorceDlgItemMall = 13003
    };

    public enum ESNSConditionType
    {
        eSNST_None = 0,
        eSNST_RoleLevel = 1,
        eSNST_MissionComplete = 2,
        eSNST_LoverState = 3,
        eSNST_EquipStrengthenTo = 4,
        eSNST_RankList = 5,
        eSNST_ElfLeave = 6,
        eSNST_Max = 7
    };

    public enum ESocietyOption
    {
        eSO_None = 0,
        eSO_DisableSearch = 1,
        eSO_DisableInviteTeam = 2,
        eSO_Max = 3
    };

    public enum ESpecialControl
    {
        None = 0x0,
        NoAttack = 0x1,
        NoMove = 0x2,
        AttackLimit = 0x4,
        NoHitBack = 0x8,
        NoPull = 0x10
    };

    public enum ESpecialPointType
    {
        CoupleDollars = 0,
        ChivalrousPoints = 1,
        MiniGameCoin = 2,
        Max = 3
    };

    public enum ESpellFlag
    {
        None = 0,
        Attack = 1,
        Buff = 2,
        Restore = 3,
        Summon = 5,
        ChangeForm = 6,
        Max = 7
    };

    public enum ESpellTarget
    {
        None = 1,
        Self = 2,
        Pet = 3,
        Team = 4,
        Target = 5,
        Ground = 6,
        Max = 7
    };

    public enum ESpellType
    {
        None = 0,
        Physical = 1,
        PhysicalFinish = 2,
        Magic = 3,
        MagicFinish = 4,
        Passivity = 5,
        ChannelPhysical = 6,
        ChannelPhysicalFinish = 7,
        ChannelMagic = 8,
        ChannelMagicFinish = 9
    };

    public enum EStateActionDone
    {
        eSA_None = -1,
        eSA_Disable = 0,
        eSA_Replace = 1,
        eSA_Coexist = 2,
        eSA_Max = 3
    };

    public enum EStateActionID
    {
        Unconscious = 0,
        Weak = 1,
        Stun = 2,
        Sleep = 3,
        Chaos = 4,
        Train = 5,
        UsingItem = 6,
        Invincible = 7,
        ChinkInvincible = 8,
        Riding = 9,
        Sneak = 10,
        Stall = 11,
        Root = 12,
        Casting = 13,
        Vending = 14,
        Sitdown = 15,
        ZoneOut = 16,
        InBattle = 17,
        Transform = 18,
        Fishing = 19,
        Equip = 20,
        Move = 21,
        Attack = 22,
        BeAttack = 23,
        OpenPack = 24,
        Social = 25,
        Max = 26
    };

    public enum EStateID
    {
        None = -1,
        Unconscious = 0,
        Weak = 1,
        Stun = 2,
        Sleep = 3,
        Chaos = 4,
        Train = 5,
        UsingItem = 6,
        Invincible = 7,
        ChinkInvincible = 8,
        Riding = 9,
        Sneak = 10,
        Stall = 11,
        Root = 12,
        Casting = 13,
        Trade = 14,
        SitDown = 15,
        ZoneOut = 16,
        InBattle = 17,
        Transform = 18,
        Fishing = 19,
        Max = 20
    };

    public enum EStrengthenTransferFlags
    {
        eSTTF_None = 0x0,
        eSTTF_Strengthen = 0x1,
        eSTTF_Combo = 0x2,
        eSTTF_Weaken = 0x4
    };

    public enum ESummonType
    {
        eSMTT_None = 0,
        eSMTT_Idle = 1,
        eSMTT_Battle = 2,
        eSMTT_Dead = 3,
        eSMTT_Max = 4
    };

    public enum ESysSetup
    {
        eSS_None = 0,
        eSS_IniVersion = 1
    };

    public enum ETeamFightMonsterType
    {
        eTFMT_None = 0,
        eTFMT_MadType = 1,
        eTFMT_RecoverType = 2,
        eTFMT_SpeedType = 3,
        eTFMT_Max = 4
    };

    public enum ETerritoryType
    {
        eTT_None = 0,
        eTT_01 = 1,
        eTT_02 = 2,
        eTT_03 = 3,
        eTT_04 = 4,
        eTT_05 = 5,
        eTT_06 = 6,
        eTT_Max = 7
    };

    public enum ETimeType
    {
        None = 0,
        Sec = 1,
        Min = 2,
        RealHour = 3,
        RealDays = 4,
        NoDurationNoSave = 5,
        RealMin = 6,
        Max = 7
    };

    public enum EventTriggerType
    {
        eTT_Into = 0,
        eTT_Leave = 1,
        eTT_All = 2
    };

    public enum EWeather
    {
        eW_None = 0,
        eW_Rain = 1,
        eW_Snow = 2,
        eW_SandyWind = 3,
        eW_Max = 4
    };

    public enum EWorldType
    {
        eWT_0 = 0,
        eWT_1 = 1,
        eWT_2 = 2,
        eWT_3 = 3,
        eWT_Max = 4
    };

    public enum SBFOperation
    {
        eSBF_None = 0,
        eSBF_Create = 1,
        eSBF_Open = 2,
        eSBF_Close = 3,
        eSBF_Result = 4,
        eSBF_Invite = 5,
        eSBF_Refuse = 6,
        eSBF_Response = 7,
        eSBF_Exit = 8,
        eSBF_Max = 9
    };
}
