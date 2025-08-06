namespace GFEditor
{
    public enum EChestType
    {
        eCT_None = 0,
        eCT_G1 = 1,
        eCT_G2 = 2,
        eCT_G3 = 3,
        eCT_G4 = 4,
        eCT_G5 = 5,
        eCT_G6 = 6,
        eCT_G7 = 7,
        eCT_G8 = 8,
        eCT_G9 = 9,
        eCT_G10 = 10,
        eCT_Max = 11
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
        eA_None = 0,
        eA_KaslowRoyalFamily = 1,
        eA_IlyaSenate = 2,
        eA_JaleSteamCorporation = 3,
        eA_Elsaland = 4,
        eA_FourSeaTradeConcil = 5,
        eA_RedCoconutParadise = 6,
        eA_DeepFanthomExpedition = 7,
        //eA_City08 = 8,
        //eA_City09 = 9,
        //eA_City10 = 10,
        eA_QuillPublishing = 11,
        eA_IronStoneAssociation = 12,
        eA_MagicAcademy = 13,
        eA_TreasureAppraisalCommittee = 14,
        eA_DemonHunters = 15,
        eA_SaphaelsHeart = 16,
        eA_DarkSprite = 17,
        eA_CrystalGuardian = 18,
        eA_PKClub = 19,
        eA_GuardianOfSaphael = 20,
        eA_SpriteMessenger = 21,
        eA_BodorGrasslandKing = 22,
        eA_AliceForestQueen = 23,
        eA_RontoDukeOfSand = 24,
        eA_SmulcaHighlandLord = 25,
        eA_EwanGeneralOfSpirits = 26,
        eA_BahadoSouthSeaKing = 27,
        eA_QuillHurricanPrince = 28,
        eA_MosunkElderOfSerenity = 29,
        eA_JundoEternalMother = 30,
        eA_SiropasUnderworldKing = 31,
        eA_IlaniaPrincessOfFrost = 32,
        eA_GinnyMiracleSprings = 33,
        // Seem like not exist (v751 only?) !
        //eA_Elf14 = 34,
        //eA_Elf15 = 35,
        //eA_Elf16 = 36,
        eA_ClassReputation = 100,
        eA_KaslowHolyRoyalResistance = 200,
        eA_IlyaCultVengeance = 201,
        eA_JaleSteamMachineMercenaries = 202,
        eA_GasAssociation = 203,
        eA_ArtAndCultureAssociation = 204,
        eA_GroupEnd = 299,
        eA_End = 300
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
        eAR_None = 0,
        eAR_Light = 1,
        eAR_Dark = 2,
        eAR_Lightning = 3,
        eAR_Fire = 4,
        eAR_Ice = 5,
        eAR_Nature = 6,
        eAR_Max = 7,
    };

    public enum EAuctionType
    {
        eAT_None = 0,
        eAT_Sword = 1,
        eAT_Mace = 2,
        eAT_Axe = 3,
        eAT_Claymore = 4,
        eAT_WarHammer = 5,
        eAT_BattleAxe = 6,
        eAT_Bow = 7,
        eAT_Gun = 8,
        eAT_HolyItem = 9,
        eAT_Staff = 10,
        eAT_Shield = 11,
        eAT_KusoOneHand = 12,
        eAT_KusoTwoHand = 13,
        eAT_Head = 14,
        eAT_Chest = 15,
        eAT_Pants = 16,
        eAT_Glove = 17,
        eAT_Feet = 18,
        eAT_Back = 19,
        eAT_Trinket = 20,
        eAT_Backpack = 21,
        eAT_KusoHead = 22,
        eAT_KusoBack = 23,
        eAT_Mining = 24,
        eAT_Plant = 25,
        eAT_Hunting = 26,
        eAT_Arrow = 27,
        eAT_MissionItem = 28,
        eAT_Water = 29,
        eAT_Prestige = 30,
        eAT_Special = 31,
        eAT_Innate = 32,
        eAT_Rune = 33,
        eAT_ElfEquip = 34,
        eAT_ElfFurniture = 35,
        eAT_ElfCard = 36,
        eAT_Elf = 37,
        eAT_Ride = 38,
        eAT_Scroll = 39,
        eAT_Etc = 40,
        eAT_Machine = 41,
        eAT_HeavyMachine = 42,
        eAT_Cannon = 43,
        eAT_SpecialSet = 44,
        eAT_CrystalKatana = 45,
        eAT_CrystalKey = 46,
        eAT_Chair = 47,
        eAT_GodAreaEquip = 48,
        eAT_Gas = 49,
        eAT_Pigment = 50,
        eAT_PostCard = 51,
        eAT_Souvenir = 52,
        eAT_Max = 53
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
        eBT_None = 0,
        eBT_Buff = 1,
        eBT_Max = 2
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
        eC_Novice = 0,
        eC_Fighter = 1,
        eC_Warrior = 2,
        eC_Berserker = 3,
        eC_Paladin = 4,
        eC_Hunter = 5,
        eC_Archer = 6,
        eC_Ranger = 7,
        eC_Assassin = 8,
        eC_Acolyte = 9,
        eC_Cleric = 10,
        eC_Templar = 11,
        eC_Sage = 12,
        eC_Caster = 13,
        eC_Magician = 14,
        eC_Wizard = 15,
        eC_Necromancer = 16,
        eC_DevilWarrior = 17,
        eC_SkyKnight = 18,
        eC_TreasureHunter = 19,
        eC_Killer = 20,
        eC_Bishop = 21,
        eC_Prophet = 22,
        eC_Archmage = 23,
        eC_DevilMaster = 24,
        eC_Recruit = 25,
        eC_Soldier = 26,
        eC_Assault = 27,
        eC_SpecialAgent = 28,
        eC_Assault4 = 29,
        eC_SpecialAgent4 = 30,
        eC_All = 31,
        eC_DevilWarrior5 = 32,
        eC_SkyKnight5 = 33,
        eC_TreasureHunter5 = 34,
        eC_Killer5 = 35,
        eC_Bishop5 = 36,
        eC_Prophet5 = 37,
        eC_Archmage5 = 38,
        eC_DevilMaster5 = 39,
        eC_DevilWarrior6 = 40,
        eC_SkyKnight6 = 41,
        eC_TreasureHunter6 = 42,
        eC_Killer6 = 43,
        eC_Bishop6 = 44,
        eC_Prophet6 = 45,
        eC_Archmage6 = 46,
        eC_DevilMaster6 = 47,
        eC_Assault5 = 48,
        eC_SpecialAgent5 = 49,
        eC_Assault6 = 50,
        eC_SpecialAgent6 = 51,
        eC_NoviceTraveler = 52,
        eC_Traveler = 53,
        eC_SpaceTraveler3 = 54,
        eC_TimeTraveler3 = 55,
        eC_SpaceTraveler4 = 56,
        eC_TimeTraveler4 = 57,
        eC_SpaceTraveler5 = 58,
        eC_TimeTraveler5 = 59,
        eC_SpaceTraveler6 = 60,
        eC_TimeTraveler6 = 61,
        eC_MaxClass = 62,
        eC_Pet = 63,
        eC_Max = 64
    };

    public enum ECombineItemType
    {
        eCIT_None = 0,
        eCIT_Head = 1,
        eCIT_Chest = 2,
        eCIT_Pants = 3,
        eCIT_Glove = 4,
        eCIT_Feet = 5,
        eCIT_Back = 6,
        eCIT_Sword = 7,
        eCIT_Claymore = 8,
        eCIT_Mace = 9,
        eCIT_WarHammer = 10,
        eCIT_Axe = 11,
        eCIT_BattleAxe = 12,
        eCIT_Bow = 13,
        eCIT_Gun = 14,
        eCIT_HolyItem = 15,
        eCIT_Staff = 16,
        eCIT_Shield = 17,
        eCIT_Trinket = 18,
        eCIT_IK_Back = 19,
        eCIT_IK_Head = 20,
        eCIT_IK_Suit = 21,
        eCIT_IK_Shield = 22,
        eCIT_IK_OneHand = 23,
        eCIT_IK_TwoHand = 24,
        eCIT_GK_Back = 25,
        eCIT_GK_Head = 26,
        eCIT_GK_Suit = 27,
        eCIT_GK_Shield = 28,
        eCIT_GK_OneHand = 29,
        eCIT_GK_TwoHand = 30,
        eCIT_Machine = 31,
        eCIT_HeavyMachine = 32,
        eCIT_Cannon = 33,
        eCIT_Katana = 34,
        eCIT_Key = 35,
        eCIT_Rune = 36,
        eCIT_CrystalCombo = 37,
        eCIT_Souvenir = 38,
        eCIT_Max = 39
    };

    public enum ECropCategory
    {
        eCC_Family = 0,
        eCC_Elf = 1,
        eCC_IsleFish = 2,
        eCC_Mineral = 3,
        eCC_Plant = 4,
        eCC_Cattle = 5,
        eCC_Max = 6
    };

    public enum ECursorType
    {
        eCT_None = 1,
        eCT_Talk = 2,
        eCT_Examine = 3,
        eCT_Transport = 4,
        eCT_Repair = 5,
        eCT_Auction = 6,
        eCT_Mail = 7,
        eCT_Max = 8
    };

    public enum EElfCombineType
    {
        eECT_None = 0,
        eECT_Strong = 1,
        eECT_Combine = 2,
        eECT_Make = 3,
        eECT_Cook = 4,
        eECT_Match = 5,
        eECT_Max = 6
    };

    public enum EElfWorkType
    {
        eEWT_None = 0,
        eEWT_Combine = 1,
        eEWT_Collect = 2,
        eEWT_Train = 3,
        eEWT_Leave = 4,
        eEWT_Lottery = 5,
        eEWT_Unknown = 6,
        eEWT_Game = 7,
        eEWT_Travel = 8,
        eEWT_Max = 9
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
        eEST_None = 0,
        eEST_Mining = 1,
        eEST_Plant = 2,
        eEST_Hunting = 3,
        eEST_Decompose = 4,
        eEST_Sword = 5,
        eEST_Axe = 6,
        eEST_Mace = 7,
        eEST_Bow = 8,
        eEST_Gun = 9,
        eEST_Staff = 10,
        eEST_Shield = 11,
        eEST_Relic = 12,
        eEST_Fighter = 13,
        eEST_Hunter = 14,
        eEST_Caster = 15,
        eEST_Acolyte = 16,
        eEST_Machine = 17,
        eEST_HeavyMachine = 18,
        eEST_Mech = 19,
        eEST_CrystalKatana = 20,
        eEST_CrystalKey = 21,
        eEST_CrystalEquip = 22,
        eEST_Gas = 23,
        eEST_Pigment = 24,
        eEST_Map = 25,
        eEST_SoulCrystal = 26,
        eEST_Gas1 = 27,
        eEST_Gas2 = 28,
        eEST_Gas3 = 29,
        eEST_Gas4 = 30,
        eEST_Gas5 = 31,
        eEST_Gas6 = 32,
        eEST_Gas7 = 33,
        eEST_Gas8 = 34,
        eEST_Gas9 = 35,
        eEST_Gas10 = 36,
        eEST_Gas11 = 37,
        eEST_Gas12 = 38,
        eEST_Pigment1 = 39,
        eEST_Pigment2 = 40,
        eEST_Pigment3 = 41,
        eEST_Pigment4 = 42,
        eEST_Pigment5 = 43,
        eEST_Pigment6 = 44,
        eEST_Pigment7 = 45,
        eEST_Pigment8 = 46,
        eEST_Pigment9 = 47,
        eEST_Pigment10 = 48,
        eEST_Pigment11 = 49,
        eEST_Pigment12 = 50,
        eEST_Map1 = 51,
        eEST_Map2 = 52,
        eEST_Map3 = 53,
        eEST_Map4 = 54,
        eEST_Map5 = 55,
        eEST_Map6 = 56,
        eEST_Map7 = 57,
        eEST_Map8 = 58,
        eEST_Map9 = 59,
        eEST_Map10 = 60,
        eEST_Map11 = 61,
        eEST_Map12 = 62,
        eEST_SoulCrystal1 = 63,
        eEST_SoulCrystal2 = 64,
        eEST_SoulCrystal3 = 65,
        eEST_SoulCrystal4 = 66,
        eEST_SoulCrystal5 = 67,
        eEST_SoulCrystal6 = 68,
        eEST_SoulCrystal7 = 69,
        eEST_SoulCrystal8 = 70,
        eEST_SoulCrystal9 = 71,
        eEST_SoulCrystal10 = 72,
        eEST_SoulCrystal11 = 73,
        eEST_SoulCrystal12 = 74,
        eEST_Travel = 75,
        eEST_Max = 76
    };

    public enum EElfType
    {
        eET_Original = 0,
        eET_Return = 1,
        eET_Max = 2
    };

    [Flags]
    public enum EEnchantFlag
    {
        eEF_None = 0x00,
        eEF_RemoveAttack = 0x01,
        eEF_RemoveBeAttacked = 0x02,
        eEF_RemoveHurt = 0x04,
        eEF_EnchantReserve = 0x08,
        eEF_CantAbandon = 0x10,
        eEF_DieReserve = 0x20,
        eEF_VultureOnly = 0x40,
        eEF_WolfOnly = 0x80,
        eEF_GorillaOnly = 0x100,
        eEF_NoBoss = 0x200,
        eEF_NoTransNode = 0x400,
        eEF_DailyType = 0x800,
        eEF_MachineOnly = 0x1000,
        eEF_NoUseItem = 0x2000,
        eEF_NoTotem = 0x4000,
        eEF_HideIcon = 0x8000,
        eEF_VIP = 0x10000,
        eEF_NoMove = 0x20000,
        eEF_Heal = 0x40000,
        eEF_NoRebirth = 0x80000,
        eEF_NoBattlefield = 0x100000,
        eEF_NoWarningMsg = 0x200000,
        eEF_NoStack = 0x400000
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
        eENT_None = 0,
        eENT_Buff = 1,
        eENT_Debuff = 2,
        eENT_Max = 3
    };

    public enum EEquipTrainItemType
    {
        eEqPIT_Sword = 0,
        eEqPIT_Axe = 1,
        eEqPIT_Mace = 2,
        eEqPIT_Claymore = 3,
        eEqPIT_BattleAxe = 4,
        eEqPIT_WarHammer = 5,
        eEqPIT_Staff = 6,
        eEqPIT_Bow = 7,
        eEqPIT_Gun = 8,
        eEqPIT_HolyItem = 9,
        eEqPIT_Shield = 10,
        eEqPIT_Head = 11,
        eEqPIT_Chest = 12,
        eEqPIT_Pants = 13,
        eEqPIT_Glove = 14,
        eEqPIT_Feet = 15,
        eEqPIT_Trinket = 16,
        eEqPIT_Back = 17,
        eEqPIT_Ride = 18,
        eEqPIT_Machine = 19,
        eEqPIT_HeavyMachine = 20,
        eEqPIT_Cannon = 21,
        eEqPIT_CrystalKatana = 22,
        eEqPIT_CrystalKey = 23,
        eEqPIT_Max = 24
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
        eEPT_Unknown = -1,
        eEPT_None = 0,
        eEPT_Head = 1,
        eEPT_Chest = 2,
        eEPT_Pants = 3,
        eEPT_Glove = 4,
        eEPT_Feet = 5,
        eEPT_Back = 6,
        eEPT_OneHand = 7,
        eEPT_LeftHand = 8,
        eEPT_TwoHands = 9,
        eEPT_Shoot = 10,
        eEPT_Accessory = 11,
        eEPT_Ammo = 13,
        eEPT_BackPack = 14,
        eEPT_SpellStoneA = 15,
        eEPT_SpellStoneB = 16,
        eEPT_SpellStoneC = 17,
        eEPT_SpellStoneD = 18,
        eEPT_ElfStoneA = 19,
        eEPT_ElfStoneB = 20,
        eEPT_ElfCap = 21,
        eEPT_ElfClothes = 22,
        eEPT_ElfFurnitureA = 23,
        eEPT_ElfFurnitureB = 24,
        eEPT_ElfFurnitureC = 25,
        eEPT_ElfFloor = 26,
        eEPT_ElfWall = 27,
        eEPT_OneHandOnly = 28, // This accept only 1 onehand of the same name.
        eEPT_AccessoryOnly = 29, // This accept only 1 accessory of the same name.
        eEPT_SpellStoneE = 30,
        eEPT_SpellStoneF = 31,
        eEPT_SpellStoneG = 32,
        eEPT_SpellStoneH = 33,
        eEPT_IsleEquipA = 34,
        eEPT_IsleEquipB = 35,
        eEPT_IsleEquipC = 36,
        eEPT_IsleEquipD = 37,
        eEPT_IsleEquipE = 38,
        eEPT_IsleEquipF = 39,
        eEPT_IKRide = 40,
        eEPT_GKRide = 41,
        eEPT_SoulCrystal = 42,
        eEPT_Souvenir = 43,
        eEPT_Max = 44
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
        eHC_None = 0x0,
        eHC_HateSummon = 0x1,
        eHC_WeakAttack = 0x2,
        eHC_NotReset = 0x4,
    };

    [Flags]
    public enum EItemOpFlags : ulong
    {
        eIOF_None = 0x00,
        eIOF_CanUse = 0x01,
        eIOF_NoDecrease = 0x02,
        eIOF_NoTrade = 0x04,
        eIOF_NoDiscard = 0x08,
        eIOF_NoEnhance = 0x10,
        eIOF_NoRepair = 0x20,
        eIOF_Combineable = 0x40,
        eIOF_BindOnEquip = 0x80,
        eIOF_AccumTime = 0x100,
        eIOF_NoSameBuff = 0x200,
        eIOF_NoInBattle = 0x400,
        eIOF_NoInTown = 0x800,
        eIOF_NoInCave = 0x1000,
        eIOF_NoInInstance = 0x2000,
        eIOF_LinkToQuest = 0x4000,
        eIOF_ForDead = 0x8000,
        eIOF_Only1 = 0x10000,
        eIOF_Only2 = 0x20000,
        eIOF_Only3 = 0x40000,
        eIOF_Only4 = 0x80000,
        eIOF_Only5 = 0x100000,
        eIOF_Only = eIOF_Only1 | eIOF_Only2 | eIOF_Only3 | eIOF_Only4 | eIOF_Only5,
        eIOF_Replaceable1 = 0x200000,
        eIOF_Replaceable2 = 0x400000,
        eIOF_Replaceable3 = 0x800000,
        eIOF_Replaceable4 = 0x1000000,
        eIOF_Replaceable5 = 0x2000000,
        eIOF_Replaceable = eIOF_Replaceable1 | eIOF_Replaceable2 | eIOF_Replaceable3 | eIOF_Replaceable4 | eIOF_Replaceable5,
        eIOF_NoInBattlefield = 0x4000000,
        eIOF_NoInField = 0x8000000,
        eIOF_NoTransNode = 0x10000000,
        eIOF_UnBindItem = 0x20000000,
        eIOF_Unknown = 0x40000000,
        eIOF_OnlyEquip = 0x80000000
    };

    [Flags]
    public enum EItemOpFlagsPlus : ulong
    {
        eIOFP_None = 0x00,
        eIOFP_IKCombine = 0x01,
        eIOFP_GKCombine = 0x02,
        eIOFP_EquipShow = 0x04,
        eIOFP_PurpleWLimit = 0x08,
        eIOFP_PurpleALimit = 0x10,
        eIOFP_UseBind = 0x20,
        eIOFP_OneStack = 0x40,
        eIOFP_RideCombineIK = 0x80,
        eIOFP_RideCombineGK = 0x100,
        eIOFP_ISRideCombine = 0x180,
        eIOFP_VIP = 0x200,
        eIOFP_ChairCombineIK = 0x800,
        eIOFP_ChairCombineGK = 0x1000,
        eIOFP_ISChairCombine = 0x1800,
        eIOFP_RedWLimit = 0x2000,
        eIOFP_RedALimit = 0x4000,
        eIOFP_CrystalCombo = 0x8000,
        eIOFP_SouvenirCombo = 0x10000,
        eIOFP_GodAreaCombo = 0x20000
    };

    public enum EItemQuality
    {
        eIQ_White = 0,
        eIQ_Gray = 1,
        eIQ_Green = 2,
        eIQ_Blue = 3,
        eIQ_Orange = 4,
        eIQ_Yellow = 5,
        eIQ_Purple = 6,
        eIQ_Red = 7,
        eIQ_Max = 8
    };

    public enum EItemTarget
    {
        eIT_None = 1,
        eIT_ToSelf = 2,
        eIT_ToElf = 3,
        eIT_ToChar = 4,
        eIT_ToItem = 5,
        eIT_ToCrop = 6,
        eIT_ToFarm = 7,
        eIT_ToIsleScene = 8,
        eIT_ToIsleStatue = 9,
        eIT_ToHiredFarm = 10,
        eIT_ToFishGround = 11,
        eIT_ToFish = 12,
        eIT_ToPit = 13,
        eIT_ToMineral = 14,
        eIT_ToPlant = 15,
        eIT_ToIsleFarm = 16,
        eIT_ToCattle = 17,
        eIT_ToPasturage = 18,
        eIT_ToESShortcut = 19,
        eIT_ToMonster = 20,
        eIT_ToNPC = 21,
        eIT_ToSpellAA = 22,
        eIT_Max = 23
    };

    public enum EItemType
    {
        eIIT_None = 0,
        eIIT_Head = 1,
        eIIT_Chest = 2,
        eIIT_Pants = 3,
        eIIT_Glove = 4,
        eIIT_Feet = 5,
        eIIT_Back = 6,
        eIIT_Sword = 7,
        eIIT_Claymore = 8,
        eIIT_Mace = 9,
        eIIT_WarHammer = 10,
        eIIT_Axe = 11,
        eIIT_BattleAxe = 12,
        eIIT_Bow = 13,
        eIIT_Gun = 14,
        eIIT_HolyItem = 15,
        eIIT_Staff = 16,
        eIIT_Shield = 17,
        eIIT_Trinket = 18,
        eIIT_Arrow = 19,
        eIIT_Bullet = 20,
        eIIT_Backpack = 21,
        eIIT_Item = 22,
        eIIT_Material = 23,
        eIIT_Rune = 24,
        eIIT_Scroll = 25,
        eIIT_SpellStone = 26,
        eIIT_EquipSet = 27,
        eIIT_Treasure = 28,
        eIIT_LuckyBag = 29,
        eIIT_ElfStone = 30,
        eIIT_ElfEquip = 31,
        eIIT_Chip = 32,
        eIIT_Formula = 33,
        eIIT_Crystal = 34,
        eIIT_Kuso = 35,
        eIIT_KusoOneHand = 36,
        eIIT_KusoTwoHand = 37,
        eIIT_KusoStaff = 38,
        eIIT_KusoBow = 39,
        eIIT_KusoGun = 40,
        eIIT_KusoShield = 41,
        eIIT_KusoSuit = 42,
        eIIT_ElfGameItem = 43,
        eIIT_WitchCraft = 44,
        eIIT_Building = 45,
        eIIT_UnBindItem = 46,
        eIIT_ElfBackpack = 47,
        eIIT_Food = 48,
        eIIT_MatchItem = 49,
        eIIT_KusoTrinket = 50,
        eIIT_ElfBook1 = 51,
        eIIT_ElfBook2 = 52,
        eIIT_ElfBook3 = 53,
        eIIT_Machine = 54,
        eIIT_HeavyMachine = 55,
        eIIT_Cannon = 56,
        eIIT_Artillery = 57,
        eIIT_KusoSoulCrystal = 58,
        eIIT_CrystalKatana = 59,
        eIIT_CrystalKey = 60,
        eIIT_PostCard = 61,
        eIIT_Souvenir = 62,
        eIIT_OptionalLuckyBag = 63,
        eIIT_CombineRate = 8001,
        eIIT_StrengthenRate = 8002,
        eIIT_CookRate = 8003,
        eIIT_MatchRate = 8004,
        eIIT_StrengthenTransfer = 8005,
        eIIT_RideCombinePoint = 8006,
        eIIT_OpenUIStart = 9001,
        eIIT_OpenUIEnd = 9999,
        eIIT_Max = 10000
    };

    [Flags]
    public enum EItemTypeForDB
    {
        eITFD_Head = 0x01,
        eITFD_Chest = 0x02,
        eITFD_Pants = 0x04,
        eITFD_Glove = 0x08,
        eITFD_Feet = 0x10,
        eITFD_Back = 0x20,
        eITFD_Sword = 0x40,
        eITFD_Claymore = 0x80,
        eITFD_Mace = 0x100,
        eITFD_WarHammer = 0x200,
        eITFD_Axe = 0x400,
        eITFD_BattleAxe = 0x800,
        eITFD_Bow = 0x1000,
        eITFD_Gun = 0x2000,
        eITFD_HolyItem = 0x4000,
        eITFD_Staff = 0x8000,
        eITFD_Shield = 0x10000,
        eITFD_Trinket = 0x20000,
        eITFD_Machine = 0x40000,
        eITFD_HeavyMachine = 0x80000,
        eITFD_Cannon = 0x100000,
        eITFD_CrystalKatana = 0x200000,
        eITFD_CrystalKey = 0x400000
    };

    public enum ElfBattleOperation
    {
        eElfNone = 0,
        eElfBattleOpenEquip = 1,
        eElfBattleMode = 2,
        eElfAction = 3,
        eElfControl = 4,
        eElfSpellCast = 5,
        eElfPick = 6,
        eElfMax = 7
    };

    public enum ELimitTimeType
    {
        eLTT_None = 0,
        eLTT_Use_Min = 1,
        eLTT_Use_Hour = 2,
        eLTT_Use_Day = 3,
        eLTT_Get_Min = 4,
        eLTT_Get_Hour = 5,
        eLTT_Get_Day = 6,
        eLTT_Max = 7
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
        eMUT_None = 0,
        eMUT_Self = 1,
        eMUT_Mentor = 2,
        eMUT_Student = 4,
        eMUT_Full = 7,
        eMUT_Delete = 512
    };

    public enum EMHPMP2AttrType
    {
        eMHPMP2A_None = 0,
        eMHPMP2A_MHP2MeleeDamage = 1,
        eMHPMP2A_MMP2MeleeDamage = 2,
        eMHPMP2A_MHP2RangeDamage = 3,
        eMHPMP2A_MMP2RangeDamage = 4,
        eMHPMP2A_MHP2MagicDamage = 5,
        eMHPMP2A_MMP2MagicDamage = 6,
        eMHPMP2A_MHP2Str = 7,
        eMHPMP2A_MMP2Str_2 = 8,
        eMHPMP2A_MHP2Int = 9,
        eMHPMP2A_MMP2Int_2 = 10,
        eMHPMP2A_MHP2Dex = 11,
        eMHPMP2A_MMP2Dex_2 = 12,
        eMHPMP2A_Max = 13
    };

    public enum EMissionFlag
    {
        eMF_None = 0x0,
        eMF_NoAbandon = 0x1,
        eMF_NoShare = 0x2,
        eMF_Reaccept = 0x4,
        eMF_AutoAccept = 0x8,
        eMF_NoRebirthReset = 0x10
    };

    public enum EMissionType
    {
        eMT_None = 0,
        eMT_Personal = 1,
        eMT_Emergent = 2,
        eMT_Class = 3,
        eMT_Team = 4,
        eMT_Guild = 5,
        eMT_Pvp = 6,
        eMT_Max = 7
    };

    public enum EMonsterAlign
    {
        eMA_None = 0,
        eMA_Normal = 1,
        eMA_Savage = 2,
        eMA_Npc = 3,
        eMA_PlayerRed = 4,
        eMA_PlayerBlue = 5,
        eMA_Max = 6
    };

    public enum EMonsterRank
    {
        eMMR_None = 0,
        eMMR_Monster = 1,
        eMMR_Elite = 2,
        eMMR_Boss = 3,
        eMMR_SceneObj = 4,
        eMMR_InstanceElite = 5,
        eMMR_FieldBoss = 6,
        eMMR_Attacker = 7,
        eMMR_Defender = 8,
        eMMR_TerritoryCrystal = 9,
        eMMR_PBBoss = 10,
        eMMR_AltarStart = 100,
        eMMR_AltarA = 101,
        eMMR_AltarB = 102,
        eMMR_AltarC = 103,
        eMMR_AltarD = 104,
        eMMR_AltarE = 105,
        eMMR_AltarF = 106,
        eMMR_AltarG = 107,
        eMMR_AltarEnd = 108
    };

    public enum EMonsterType
    {
        eET_None = 0x0,
        eET_Animal = 0x1,
        eET_Plant = 0x2,
        eET_Human = 0x4,
        eET_Size = 0x7, // ?
        eET_Element = 0x8,
        eET_Machine = 0x10,
        eET_Undead = 0x20,
        eET_Demon = 0x40
    };

    public enum ENodeType
    {
        eNT_None = 0,
        eNT_Field = 1,
        eNT_Cave = 2,
        eNT_Town = 3,
        eNT_Instance = 4,
        eNT_Battlefield = 5,
        eNT_RaidInstance = 6,
        eNT_FamilyInstance = 7,
        eNT_FamilyBattle = 8,
        eNT_FamilyInstance2 = 9,
        eNT_GMMap = 10,
        eNT_Territory = 11,
        eNT_Arena = 12,
        eNT_RaidFamilyInstance2 = 13,
        eNT_Private = 14,
        eNT_Dungeon = 15,
        eNT_FamilyTreeInstance = 16,
        eNT_MentorInstance = 17,
        eNT_HuntingGround = 18,
        eNT_BeastsTower = 19,
        eNT_LoveChallengeInstance1 = 20,
        eNT_LoveChallengeInstance2 = 21,
        eNT_ElfTempleInstance = 22,
        eNT_CrossZoneHuntingGround = 23,
        eNT_Max = 24
    };

    public enum EPVPDamageType
    {
        ePD_Physic = 0,
        ePD_Magic = 1,
        ePD_Max = 2
    };

    public enum ERankAwardType
    {
        eRA_None = 0,
        eRA_TotalRank = 1,
        eRA_MonterKill = 2,
        eRA_Mission = 3,
        eRA_Festival = 4,
        eRA_MVP = 5,
        eRA_HightKill = 6,
        eRA_Altar = 7,
        eRA_Cure = 8,
        eRA_KillCount = 9,
        eRA_PKPalace = 10,
        eRA_Lorekeeper = 11,
        eRA_ElfGladiator = 12,
        eRA_FunBattlefield = 13,
        eRA_Race = 998,
        eRA_DynamicEvent = 999
    };

    public enum ERecommendEventsType
    {
        eRET_FirstKillMonster = 0,
        eRET_FirstKillTreasure = 1,
        eRET_KillMonster = 2,
        eRET_CompleteBattlefield = 3,
        eRET_BattlefieldVictory = 4,
        eRET_GeneralRefinery = 5,
        eRET_ColorfulRefinery = 6,
        eRET_SpecialPoints = 7,
        eRET_EquipmentStrengthen = 8,
        eRET_CompleteTask = 9,
        eRET_GetEnchant = 10,
        eRET_GreenEquipment = 11,
        eRET_OrangeEquipment = 12,
        eRET_YellowEquipment = 13,
        eRET_Marquee = 14,
        eRET_OpenLuckyBag = 15,
        eRET_ItemCombine = 16,
        eRET_KillPlayer = 17,
        eRET_ElfTeamFight = 18,
        eRET_LotteryRecord = 19,
        eRET_LevelUp = 20,
        eRET_RepairIsle = 21,
        eRET_Fishing = 22,
        eRET_Islend = 23,
        eRET_UseUnBindItem = 24,
        eRET_LuckyStarBet = 25,
        eRET_LuckyStarWinMoney = 26,
        eRET_LuckyBarBet = 27,
        eRET_LuckyBarWinMoney = 28,
        eRET_LotteryGoItem = 29,
        eRET_LotteryGoItemMall = 30,
        eRET_FightKing = 31,
        eRET_GladiatorCount = 32,
        eRET_Max = 33
    };

    public enum ERideComboQuality
    {
        eRCQ_None = 0,
        eRCQ_White = 1,
        eRCQ_Green = 2,
        eRCQ_Blue = 3,
        eRCQ_Orange = 4,
        eRCQ_Yellow = 5,
        eRCQ_Max = 6
    };

    public enum ERideComboType
    {
        eRCT_None = 0,
        eRCT_IK = 1,
        eRCT_GK = 2,
        eRCT_Max = 3
    };

    public enum EScheduleDayType
    {
        eSD_None = -1,
        eSD_Monday = 1,
        eSD_Tuesday = 2,
        eSD_Wednesday = 3,
        eSD_Thursday = 4,
        eSD_Friday = 5,
        eSD_Saturday = 6,
        eSD_Sunday = 7,
        eSD_Allday = 8
    };

    public enum EScheduleFunctionType
    {
        eSF_None = 0,
        eSF_Territory1 = 1,
        eSF_Territory2 = 2,
        eSF_Territory3 = 3,
        eSF_Territory4 = 4,
        eSF_Territory5 = 5,
        eSF_Territory6 = 6,
        eSF_Battlefield1 = 100,
        eSF_Battlefield2 = 101,
        eSF_Battlefield3 = 102,
        eSF_Battlefield4 = 103,
        eSF_Battlefield5 = 104,
        eSF_Battlefield6 = 105,
        eSF_Battlefield7 = 106,
        eSF_Battlefield8 = 107,
        eSF_Battlefield9 = 108,
        eSF_Battlefield14 = 109,
        eSF_Battlefield15 = 110,
        eSF_Battlefield16 = 111,
        eSF_Colosseum = 200,
        eSF_Arena = 300,
        eSF_PKPalace = 400,
        eSF_Wedding = 500,
        eSF_ElfSchool = 600,
        eSF_BeastsTower = 700
    };

    public enum EScreenMessageType
    {
        eSMT_None = 0,
        eSMT_Zone = 1,
        eSMT_World = 2,
        eSMT_HeroMonster = 3,
        eSMT_HeroActivity = 4,
        eSMT_Winner = 5,
        eSMT_Discovery = 6,
        eSMT_Bulletin = 7,
        eSMT_Megaphone = 8,
        eSMT_Striking = 9,
        eSMT_Notify = 10,
        eSMT_ElfSchool = 11,
        eSMT_DynamicEvent = 12,
        eSMT_Max = 13
    };

    public enum EShopPriceType
    {
        eSPT_None = 0,
        eSPT_Gold = 1,
        eSPT_Battlefield = 2,
        eSPT_Achievement = 3,
        eSPT_Love = 4,
        eSPT_FamilyBattle = 5,
        eSPT_HuntStamp = 6,
        eSPT_FortuneCoin = 7,
        eSPT_Transport = 8,
        eSPT_PKPalace = 9,
        eSPT_Group11 = 10,
        eSPT_Group12 = 11,
        eSPT_Group13 = 12
    };

    public enum EShopType
    {
        eMS_None = 0,
        eMS_Spell = 1,
        eMS_Weapon = 2,
        eMS_Armor = 3,
        eMS_Newbie = 4,
        eMS_Item = 5,
        eMS_Rider = 6,
        eMS_Elf = 7,
        eMS_Family = 8,
        eMS_Bank = 9,
        eMS_Mail = 10,
        eMS_TPA = 11,
        eMS_Strengthen = 12,
        eMS_Combine = 13,
        eMS_Auction = 14,
        eMS_ElfReturn = 15,
        eMS_MessageBoard = 16,
        eMS_FamilyStorage = 17,
        eMS_FamilyFlag = 18,
        eMS_FamilyBattleSchedule = 19,
        eMS_FamilyRecruit = 20,
        eMS_LuckyBar = 21,
        eMS_ElfBoxing = 22,
        eMS_KusoCombine = 23,
        eMS_WishingWell = 24,
        eMS_ItemMall1 = 51,
        eMS_ItemMall2 = 52,
        eMS_ItemMall3 = 53,
        eMS_ItemMall4 = 54,
        eMS_ItemMall5 = 55,
        eMS_ItemMall6 = 56,
        eMS_ItemMall7 = 57,
        eMS_ItemMall8 = 58,
        eMS_FamilyBattleSchedule1 = 59,
        eMS_Progress = 60,
        eMS_StrengthenTransfer = 61,
        eMS_FamilyBattleSchedule2 = 62,
        eMS_RideCombine = 63,
        eMS_FamilyTransform = 64,
        eMS_FamilyBattleSchedule3 = 65,
        eMS_SpellStorage = 66,
        eMS_SpellReturn = 67,
        eMS_ElfRacing_1 = 68,
        eMS_ElfRacing_2 = 69,
        eMS_ElfRacing_3 = 70,
        eMS_Rebirth = 71,
        eMS_ItemExchange = 72,
        eMS_ChairCombine = 73,
        eMS_ChairSell = 74,
        eMS_Awake = 75,
        eMS_RuneReCombo = 76,
        eMS_CrystalCombo = 77,
        eMS_SouvenirCombo = 78,
        eMS_GodAreaCombo = 79,
        eMS_MissionOpen = 10000,
        eMS_MissionReward = 10001,
        eMS_MissionOnGoing = 10002,
        eMS_MissionFinish = 10003,
        eMS_FamilyFarm = 11000,
        eMS_CreateIsle = 11001,
        eMS_Isle = 11002,
        eMS_IsleAltar = 11003,
        eMS_ISleStatue = 11004,
        eMS_IsleBulletin = 11005,
        eMS_IsleFishGround = 11006,
        eMS_IsleInfo = 11007,
        eMS_PKPalace = 11008,
        eMS_Pit = 11009,
        eMS_Ranch = 11010,
        eMS_Pasturage = 11011,
        eMS_Cook = 11012,
        eMS_Match = 11013,
        eMS_IsleFram = 11014,
        eMS_IslePasturage = 11015,
        eMS_IsleStorage = 11016,
        eMS_IsleChangeName = 11017,
        eMS_GameTimer = 12000,
        eMS_GameTimer2 = 12001,
        eMS_OpenCheckMarryDlg = 13000,
        eMS_OpenCheckMarryDlgItemMall = 13001,
        eMS_OpenCheckDivorceDlg = 13002,
        eMS_OpenCheckDivorceDlgItemMall = 13003
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
        eSC_None = 0x0,
        eSC_NoAttack = 0x1,
        eSC_NoMove = 0x2,
        eSC_AttackLimit = 0x4,
        eSC_NoHitBack = 0x8,
        eSC_NoPull = 0x10
    };

    public enum ESpecialPointType
    {
        eSPT_CoupleDollars = 0,
        eSPT_ChivalrousPoints = 1,
        eSPT_MiniGameCoin = 2,
        eSPT_Max = 3
    };

    public enum ESpellFlag
    {
        eSSF_None = 0,
        eSSF_Attack = 1,
        eSSF_Buff = 2,
        eSSF_Restore = 3,
        eSSF_Summon = 5,
        eSSF_ChangeForm = 6,
        eSSF_Max = 7
    };

    public enum ESpellTarget
    {
        eST_None = 1,
        eST_Self = 2,
        eST_Pet = 3,
        eST_Team = 4,
        eST_Target = 5,
        eST_Ground = 6,
        eST_Max = 7
    };

    public enum ESpellType
    {
        eSST_None = 0,
        eSST_Physical = 1,
        eSST_PhysicalFinish = 2,
        eSST_Magic = 3,
        eSST_MagicFinish = 4,
        eSST_Passivity = 5,
        eSST_ChannelPhysical = 6,
        eSST_ChannelPhysicalFinish = 7,
        eSST_ChannelMagic = 8,
        eSST_ChannelMagicFinish = 9
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
        eAID_Unconscious = 0,
        eAID_Weak = 1,
        eAID_Stun = 2,
        eAID_Sleep = 3,
        eAID_Chaos = 4,
        eAID_Train = 5,
        eAID_UsingItem = 6,
        eAID_Invincible = 7,
        eAID_ChinkInvincible = 8,
        eAID_Riding = 9,
        eAID_Sneak = 10,
        eAID_Stall = 11,
        eAID_Root = 12,
        eAID_Casting = 13,
        eAID_Vending = 14,
        eAID_Sitdown = 15,
        eAID_ZoneOut = 16,
        eAID_InBattle = 17,
        eAID_Transform = 18,
        eAID_Fishing = 19,
        eAID_Equip = 20,
        eAID_Move = 21,
        eAID_Attack = 22,
        eAID_BeAttack = 23,
        eAID_OpenPack = 24,
        eAID_Social = 25,
        eAID_Max = 26
    };

    public enum EStateID
    {
        eSID_None = -1,
        eSID_Unconscious = 0,
        eSID_Weak = 1,
        eSID_Stun = 2,
        eSID_Sleep = 3,
        eSID_Chaos = 4,
        eSID_Train = 5,
        eSID_UsingItem = 6,
        eSID_Invincible = 7,
        eSID_ChinkInvincible = 8,
        eSID_Riding = 9,
        eSID_Sneak = 10,
        eSID_Stall = 11,
        eSID_Root = 12,
        eSID_Casting = 13,
        eSID_Trade = 14,
        eSID_SitDown = 15,
        eSID_ZoneOut = 16,
        eSID_InBattle = 17,
        eSID_Transform = 18,
        eSID_Fishing = 19,
        eSID_Max = 20
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
        eTIT_None = 0,
        eTIT_Sec = 1,
        eTIT_Min = 2,
        eTIT_RealHour = 3,
        eTIT_RealDays = 4,
        eTIT_NoDurationNoSave = 5,
        eTIT_RealMin = 6,
        eTIT_Max = 7
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
