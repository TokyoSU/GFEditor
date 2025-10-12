using GFEditor.Specific;

namespace GFEditor.Structs
{
    public class ItemData
    {
        [JsonProperty("id")]
        public IdType m_nId;
        [JsonProperty("iconFilename")]
        public string m_kIconFilename = string.Empty;
        [JsonProperty("modelFilename")]
        public string m_nModelFilename = string.Empty;
        [JsonProperty("dropFilename")]
        public string m_nDropFilename = string.Empty;
        [JsonProperty("weaponEffectId")]
        public IdType m_nWeaponEffectId;
        [JsonProperty("flyEffectId")]
        public IdType m_nFlyEffectId;
        [JsonProperty("usedEffectId")]
        public IdType m_nUsedEffectId;
        [JsonProperty("usedSoundName")]
        public string m_nUsedSoundName = string.Empty;
        [JsonProperty("enhanceEffectId")]
        public IdType m_nEnhanceEffectId;
        [JsonProperty("name")]
        public string m_kName = string.Empty;
        [JsonProperty("itemType")]
        public EItemType m_eItemType;
        [JsonProperty("equipType")]
        public EEquipType m_eEquipType;
        [JsonProperty("opFlags")]
        public EItemOpFlags m_nOpFlags;
        [JsonProperty("opFlagsPlus")]
        public EItemOpFlagsPlus m_nOpFlagsPlus;
        [JsonProperty("target")]
        public EItemTarget m_eTarget;
        [JsonProperty("restrictGender")]
        public EGender m_eRestrictGender;
        [JsonProperty("restrictLevel")]
        public LevelType m_nRestrictLevel;
        [JsonProperty("restrictMaxLevel")]
        public LevelType m_nRestrictMaxLevel;
        [JsonProperty("rebirthCount")]
        public short m_nRebirthCount;
        [JsonProperty("rebirthScore")]
        public short m_nRebirthScore;
        [JsonProperty("rebirthMaxScore")]
        public short m_nRebirthMaxScore;
        [JsonProperty("restrictAlign")]
        public EAlignement m_eRestrictAlign;
        [JsonProperty("restrictPrestige")]
        public ulong m_nRestrictPrestige;
        [JsonProperty("restrictClass")]
        public ERestrictClass m_nRestrictClass;
        [JsonProperty("itemQuality")]
        public EItemQuality m_eItemQuality;
        [JsonProperty("itemGroup")]
        public ushort m_nItemGroup;
        [JsonProperty("castingTime")]
        public TimeType m_nCastingTime;
        [JsonProperty("coolDownTime")]
        public TimeType m_nCoolDownTime;
        [JsonProperty("coolDownGroup")]
        public ushort m_nCoolDownGroup;
        [JsonProperty("maxHp")]
        public ulong m_nMaxHp;
        [JsonProperty("maxMp")]
        public ulong m_nMaxMp;
        [JsonProperty("str")]
        public BaseAttrType m_nStr;
        [JsonProperty("con")]
        public BaseAttrType m_nVit;
        [JsonProperty("int")]
        public BaseAttrType m_nInt;
        [JsonProperty("vol")]
        public BaseAttrType m_nWil;
        [JsonProperty("dex")]
        public BaseAttrType m_nDex;
        [JsonProperty("avgPhysicoDamage")]
        public ulong m_nAvgPhysicalDamage;
        [JsonProperty("randPhysicoDamage")]
        public ulong m_nRandPhysicalDamage;
        [JsonProperty("attackRange")]
        public GridType m_nAttackRange;
        [JsonProperty("attackSpeed")]
        public AttackSpeedType m_nAttackSpeed;
        [JsonProperty("attack")]
        public ulong m_nAttack;
        [JsonProperty("rangeAttack")]
        public ulong m_nRangeDamage;
        [JsonProperty("physicoDefence")]
        public ulong m_nPhysicalDefence;
        [JsonProperty("magicDamage")]
        public ulong m_nMagicDamage;
        [JsonProperty("magicDefence")]
        public ulong m_nMagicDefence;
        [JsonProperty("hitRate")]
        public RateType m_nHitRate;
        [JsonProperty("dodgeRate")]
        public RateType m_nDodgeRate;
        [JsonProperty("physicoCriticalRate")]
        public short m_nPhysicalCriticalRate;
        [JsonProperty("physicoCriticalDamage")]
        public ulong m_nPhysicalCriticalDamage;
        [JsonProperty("magicCriticalRate")]
        public short m_nMagicCriticalRate;
        [JsonProperty("magicCriticalDamage")]
        public ulong m_nMagicCriticalDamage;
        [JsonProperty("physicalPenetration")]
        public short m_nPhysicalPenetration;
        [JsonProperty("magicalPenetration")]
        public short m_nMagicalPenetration;
        [JsonProperty("physicalPenetrationDefence")]
        public short m_nPhysicalPenetrationDefence;
        [JsonProperty("magicalPenetrationDefence")]
        public short m_nMagicalPenetrationDefence;
        [JsonProperty("attribute")]
        public EAttrResist m_eAttribute;
        [JsonProperty("attributeRate")]
        public short m_nAttributeRate;
        [JsonProperty("attributeDamage")]
        public ulong m_nAttributeDamage;
        [JsonProperty("attributeResist")]
        public ulong m_nAttributeResist;
        [JsonProperty("specialType")]
        public EMonsterType m_eSpecialType;
        [JsonProperty("specialRate")]
        public short m_nSpecialRate;
        [JsonProperty("specialDamage")]
        public ulong m_nSpecialDamage;
        [JsonProperty("dropRate")]
        public RateType m_nDropRate;
        [JsonProperty("dropIndex")]
        public IdType m_nDropIndex;
        [JsonProperty("treasureBuffs1")]
        public int m_kTreasureBuffs1;
        [JsonProperty("treasureBuffs2")]
        public int m_kTreasureBuffs2;
        [JsonProperty("treasureBuffs3")]
        public int m_kTreasureBuffs3;
        [JsonProperty("treasureBuffs4")]
        public int m_kTreasureBuffs4;
        [JsonProperty("enchantType")]
        public EBuffIconType m_eEnchantType;
        [JsonProperty("enchantId")]
        public BuffType m_nEnchantId;
        [JsonProperty("expertLevel")]
        public short m_nExpertLevel;
        [JsonProperty("expertEnchantId")]
        public BuffType m_nExpertEnchantId;
        [JsonProperty("elfSkillId")]
        public ushort m_nElfSkillId;
        [JsonProperty("enchantTimeType")]
        public ETimeType m_eEnchantTimeType;
        [JsonProperty("enchantDuration")]
        public TimeType m_nEnchantDuration;
        [JsonProperty("limitType")]
        public ELimitTimeType m_nLimitType;
        [JsonProperty("dueDateTime")]
        public RentType m_nDueDateTime;
        [JsonProperty("backpackSize")]
        public byte m_nBackpackSize;
        [JsonProperty("maxSocket")]
        public byte m_nMaxSocket;
        [JsonProperty("socketRate")]
        public RateType m_nSocketRate;
        [JsonProperty("maxDurability")]
        public ushort m_nMaxDurability;
        [JsonProperty("maxStack")]
        public ushort m_nMaxStack;
        [JsonProperty("shopPriceType")]
        public EShopPriceType m_nShopPriceType;
        [JsonProperty("sysPrice")]
        public ulong m_nSysPrice; /// First 000000 is gold, next 00 is silver and last 00 is copper. !
        [JsonProperty("restrictEventPosId")]
        public string m_nRestrictEventPosId = string.Empty;
        [JsonProperty("missionPosId")]
        public IdType m_nMissionPosId;
        [JsonProperty("blockRate")]
        public RateType m_nBlockRate;
        [JsonProperty("logLevel")]
        public byte m_nLogLevel;
        [JsonProperty("auctionType")]
        public EAuctionType m_eAuctionType;
        [JsonProperty("extraData1")]
        public long m_kExtraData1;
        [JsonProperty("extraData2")]
        public long m_kExtraData2;
        [JsonProperty("extraData3")]
        public long m_kExtraData3;
        [JsonProperty("tip")]
        public string m_kTip = string.Empty;

        // Editor only:

        public Dictionary<EItemOpFlags, bool> m_bOpFlagsArray = [];
        public Dictionary<EItemOpFlagsPlus, bool> m_bOpFlagsPlusArray = [];
        public Dictionary<ERestrictClass, bool> m_bClassRestrictionArray = [];
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Generates a serialized string representation of the object's data.
        /// </summary>
        /// <remarks>The returned string contains a pipe-delimited sequence of the object's properties and
        /// fields. Each value is serialized in a specific order and format, which is consistent across calls. This
        /// method is typically used for exporting or logging the object's state.</remarks>
        /// <returns>A <see cref="string"/> containing the serialized representation of the object's data.</returns>
        public string GetString(long version, char delimiter = '|')
        {
            var sb = new StringBuilder();
            sb.AppendGF(m_nId).Append(delimiter);
            sb.AppendGF(m_kIconFilename).Append(delimiter);
            sb.AppendGF(m_nModelFilename).Append(delimiter);
            sb.AppendGF(m_nDropFilename).Append(delimiter);
            sb.AppendGF(m_nWeaponEffectId).Append(delimiter);
            sb.AppendGF(m_nFlyEffectId).Append(delimiter);
            sb.AppendGF(m_nUsedEffectId).Append(delimiter);
            sb.AppendGF(m_nUsedSoundName).Append(delimiter);
            sb.AppendGF(m_nEnhanceEffectId).Append(delimiter);
            sb.AppendGF(m_kName).Append(delimiter); // Placeholder for m_kName, only required if you don't have editor support xD (also reduce the size of the file by a lot !)
            sb.AppendGF((int)m_eItemType).Append(delimiter);
            sb.AppendGF((int)m_eEquipType).Append(delimiter);
            sb.AppendGF(m_nOpFlags).Append(delimiter);
            if (version >= 12) sb.AppendGF(m_nOpFlagsPlus).Append(delimiter);
            sb.AppendGF((int)m_eTarget).Append(delimiter);
            sb.AppendGF((int)m_eRestrictGender).Append(delimiter);
            sb.AppendGF(m_nRestrictLevel).Append(delimiter);
            if (version >= 9) sb.AppendGF(m_nRestrictMaxLevel).Append(delimiter);
            if (version >= 14)
            {
                sb.AppendGF(m_nRebirthCount).Append(delimiter);
                sb.AppendGF(m_nRebirthScore).Append(delimiter);
                sb.AppendGF(m_nRebirthMaxScore).Append(delimiter);
            }
            sb.AppendGF((int)m_eRestrictAlign).Append(delimiter);
            sb.AppendGF(m_nRestrictPrestige).Append(delimiter);
            sb.AppendGF(m_nRestrictClass).Append(delimiter);
            sb.AppendGF((int)m_eItemQuality).Append(delimiter);
            sb.AppendGF(m_nItemGroup).Append(delimiter);
            sb.AppendGF(m_nCastingTime).Append(delimiter);
            sb.AppendGF(m_nCoolDownTime).Append(delimiter);
            sb.AppendGF(m_nCoolDownGroup).Append(delimiter);
            sb.AppendGF(m_nMaxHp).Append(delimiter);
            sb.AppendGF(m_nMaxMp).Append(delimiter);
            sb.AppendGF(m_nStr).Append(delimiter);
            sb.AppendGF(m_nVit).Append(delimiter);
            sb.AppendGF(m_nInt).Append(delimiter);
            sb.AppendGF(m_nWil).Append(delimiter);
            sb.AppendGF(m_nDex).Append(delimiter);
            sb.AppendGF(m_nAvgPhysicalDamage).Append(delimiter);
            sb.AppendGF(m_nRandPhysicalDamage).Append(delimiter);
            sb.AppendGF(m_nAttackRange).Append(delimiter);
            sb.AppendGF(m_nAttackSpeed).Append(delimiter);
            sb.AppendGF(m_nAttack).Append(delimiter);
            sb.AppendGF(m_nRangeDamage).Append(delimiter);
            sb.AppendGF(m_nPhysicalDefence).Append(delimiter);
            sb.AppendGF(m_nMagicDamage).Append(delimiter);
            sb.AppendGF(m_nMagicDefence).Append(delimiter);
            sb.AppendGF(m_nHitRate).Append(delimiter);
            sb.AppendGF(m_nDodgeRate).Append(delimiter);
            sb.AppendGF(m_nPhysicalCriticalRate).Append(delimiter);
            sb.AppendGF(m_nPhysicalCriticalDamage).Append(delimiter);
            sb.AppendGF(m_nMagicCriticalRate).Append(delimiter);
            sb.AppendGF(m_nMagicCriticalDamage).Append(delimiter);
            if (version >= 15)
            {
                sb.AppendGF(m_nPhysicalPenetration).Append(delimiter);
                sb.AppendGF(m_nMagicalPenetration).Append(delimiter);
                sb.AppendGF(m_nPhysicalPenetrationDefence).Append(delimiter);
                sb.AppendGF(m_nMagicalPenetrationDefence).Append(delimiter);
            }
            sb.AppendGF((int)m_eAttribute).Append(delimiter);
            sb.AppendGF(m_nAttributeRate).Append(delimiter);
            sb.AppendGF(m_nAttributeDamage).Append(delimiter);
            sb.AppendGF(m_nAttributeResist).Append(delimiter);
            sb.AppendGF((int)m_eSpecialType).Append(delimiter);
            sb.AppendGF(m_nSpecialRate).Append(delimiter);
            sb.AppendGF(m_nSpecialDamage).Append(delimiter);
            sb.AppendGF(m_nDropRate).Append(delimiter);
            sb.AppendGF(m_nDropIndex).Append(delimiter);
            sb.AppendGF(m_kTreasureBuffs1).Append(delimiter);
            sb.AppendGF(m_kTreasureBuffs2).Append(delimiter);
            sb.AppendGF(m_kTreasureBuffs3).Append(delimiter);
            sb.AppendGF(m_kTreasureBuffs4).Append(delimiter);
            sb.AppendGF((int)m_eEnchantType).Append(delimiter);
            sb.AppendGF(m_nEnchantId).Append(delimiter);
            if (version >= 16)
            {
                sb.AppendGF(m_nExpertLevel).Append(delimiter);
                sb.AppendGF(m_nExpertEnchantId).Append(delimiter);
            }
            if (version >= 11)
                sb.AppendGF(m_nElfSkillId).Append(delimiter);
            sb.AppendGF((int)m_eEnchantTimeType).Append(delimiter);
            sb.AppendGF(m_nEnchantDuration).Append(delimiter);
            sb.AppendGF((int)m_nLimitType).Append(delimiter);
            sb.AppendGF(m_nDueDateTime).Append(delimiter);
            sb.AppendGF(m_nBackpackSize).Append(delimiter);
            sb.AppendGF(m_nMaxSocket).Append(delimiter);
            sb.AppendGF(m_nSocketRate).Append(delimiter);
            sb.AppendGF(m_nMaxDurability).Append(delimiter);
            sb.AppendGF(m_nMaxStack).Append(delimiter);
            if (version >= 9)
                sb.AppendGF((int)m_nShopPriceType).Append(delimiter);
            sb.AppendGF(m_nSysPrice).Append(delimiter);
            sb.AppendGF(m_nRestrictEventPosId).Append(delimiter);
            sb.AppendGF(m_nMissionPosId).Append(delimiter);
            sb.AppendGF(m_nBlockRate).Append(delimiter);
            sb.AppendGF(m_nLogLevel).Append(delimiter);
            sb.AppendGF((int)m_eAuctionType).Append(delimiter);
            if (version >= 13)
            {
                sb.AppendGF(m_kExtraData1).Append(delimiter);
                sb.AppendGF(m_kExtraData2).Append(delimiter);
                sb.AppendGF(m_kExtraData3).Append(delimiter);
            }
            sb.AppendGF(m_kTip).Append(delimiter); // Placeholder for m_kTip, only required if you don't have editor support xD (also reduce the size of the file by a lot !)
            var result = sb.ToString();
#if DEBUG
            var expected = GetExpectedSerializedParameterCount(version);
            var actual = CountChars(result, delimiter);
            if (actual != expected)
                m_Log.Error($"ItemData.GetString: Expected {expected} parameters for version {version}, but produced {actual}.");
#endif
            return result;
        }

        public void DrawProperties(EditorTranslate translate, ItemDataTranslated itemTranslate, long version)
        {
            string emptyStr = string.Empty;

            ImGuiUtils.Label(translate.HeaderItemIndex + ": " + m_nId, false);
            ImGuiUtils.InputText(translate.HeaderItemName + ": ", ref m_kName);
            if (itemTranslate != null) ImGuiUtils.InputText("Translated Name: ", ref itemTranslate.m_kName);
            else ImGuiUtils.InputText("Translated Name: ", ref emptyStr, true);

            ImGuiUtils.InputText(translate.HeaderItemModel + ": ", ref m_nModelFilename);
            ImGuiUtils.InputText(translate.HeaderItemIcon + ":", ref m_kIconFilename);
            var image = IconItem.GetByName(m_kIconFilename);
            if (image != null)
            {
                ImGui.SameLine();
                ImGuiUtils.Image(image, false);
            }

            ImGuiUtils.InputText("Used sound name: ", ref m_nUsedSoundName);
            ImGui.SameLine();
            if (ImGui.Button("Play Sound") && m_nUsedSoundName.IsValid())
            {
                AudioDevice.Play(m_nUsedSoundName);
            }

            if (ImGui.CollapsingHeader("Description"))
            {
                ImGuiUtils.InputTextMultiline("TI1", ref m_kTip, new Vector2(1024, 512));
                if (itemTranslate != null) ImGuiUtils.InputTextMultiline("TI2", ref itemTranslate.m_kTip, new Vector2(1024, 512));
                else ImGuiUtils.InputTextMultiline("TI2", ref emptyStr, new Vector2(1024, 512), true);
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemBasics))
            {
                ImGuiUtils.ComboBoxEnum(translate.ItemQualityName, ref Constants.QualityIndex, out m_eItemQuality, EItemQuality.Max);
                ImGuiUtils.ComboBoxEnum(translate.ItemTypeName, ref Constants.ItemTypeIndex, out m_eItemType, EItemType.OpenUIStart, EItemType.OpenUIEnd, EItemType.Max);
                ImGuiUtils.ComboBoxEnum(translate.EquipTypeName, ref Constants.EquipTypeIndex, out m_eEquipType, EEquipType.Unknown, EEquipType.Max);
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemDrop))
            {
                ImGuiUtils.InputUInt(translate.DropIndexName, ref m_nDropIndex);
                ImGuiUtils.InputChar(translate.DropRateName, ref m_nDropRate);
                ImGuiUtils.InputText(translate.HeaderDropName, ref m_nDropFilename);
                ImGuiUtils.ComboBoxEnum(translate.DropTypeName, ref Constants.DropTypeIndex, out EChestType dropType, EChestType.Max);
                if (m_nDropFilename.IsValid())
                {
                    var drop = ImageChest.GetByName(m_nDropFilename);
                    if (drop != null)
                    {
                        ImGui.SameLine();
                        ImGuiUtils.ImageSized(drop, new Vector2(128, 128));
                    }
                }
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemEffects))
            {
                ImGuiUtils.InputUInt("Weapon effect", ref m_nWeaponEffectId);
                ImGuiUtils.InputUInt("Fly effect", ref m_nFlyEffectId);
                ImGuiUtils.InputUInt("Used effect", ref m_nUsedEffectId);
                ImGuiUtils.InputUInt("Enchanced effect", ref m_nEnhanceEffectId);
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemRestriction))
            {
                ImGuiUtils.InputUShort("Item Group", ref m_nItemGroup);
                ImGuiUtils.InputByte("Minimum Level", ref m_nRestrictLevel);
                if (version >= 9)
                    ImGuiUtils.InputByte("Maximum Level", ref m_nRestrictMaxLevel);
                ImGuiUtils.InputUShort("Stack Size", ref m_nMaxStack);

                ImGuiUtils.SetOffsetPos(new Vector2(15f, 0f));
                if (ImGui.CollapsingHeader(translate.HeaderItemRestrictionTime))
                {
                    ImGuiUtils.ComboBoxEnum("Time Limit Type", ref Constants.TimeLimitTypeIndex, out m_nLimitType, ELimitTimeType.Max);
                    ImGuiUtils.InputULong("Time Limit", ref m_nDueDateTime);
                }

                ImGuiUtils.SetOffsetPos(new Vector2(15f, 0f));
                if (ImGui.CollapsingHeader(translate.HeaderItemClass))
                {
                    ItemEditorUtils.DrawClassCheckbox(this, ERestrictClass.Novice, 30f);
                    ItemEditorUtils.DrawClassSection(this, translate.FighterSection, 2f, ERestrictClass.Fighter, BasicClassType.Fighter);
                    ItemEditorUtils.DrawClassSection(this, translate.HunterSection, 2f, ERestrictClass.Hunter, BasicClassType.Hunter);
                    ItemEditorUtils.DrawClassSection(this, translate.AcolyteSection, 2f, ERestrictClass.Acolyte, BasicClassType.Acolyte);
                    ItemEditorUtils.DrawClassSection(this, translate.SpellcasterSection, 2f, ERestrictClass.Spellcaster, BasicClassType.Spellcaster);
                    ItemEditorUtils.DrawClassSection(this, translate.MechanicSection, 2f, ERestrictClass.Mechanic, BasicClassType.Mechanic);
                    ItemEditorUtils.DrawClassSection(this, translate.WandererSection, 2f, ERestrictClass.Wanderer, BasicClassType.Wanderer);
                }
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemFlags))
            {
                ImGuiUtils.SetOffsetPos(new Vector2(15f, 0f));
                if (ImGui.CollapsingHeader(translate.OpFlags))
                {
                    var opFlags = Enum.GetValues<EItemOpFlags>();
                    foreach (var opFlag in opFlags)
                    {
                        if (opFlag == EItemOpFlags.None) continue;
                        ItemEditorUtils.DrawOpFlagParameter(this, opFlag.ToString(), opFlag);
                    }
                    ProcessOnlyAndReplaceableFlags();
                }

                if (version >= 12)
                {
                    ImGuiUtils.SetOffsetPos(new Vector2(15f, 0f));
                    if (ImGui.CollapsingHeader(translate.OpFlagsPlus))
                    {
                        var opFlagsPlus = Enum.GetValues<EItemOpFlagsPlus>();
                        foreach (var opFlagPlus in opFlagsPlus)
                        {
                            if (opFlagPlus == EItemOpFlagsPlus.None) continue;
                            ItemEditorUtils.DrawOpFlagPlusParameter(this, opFlagPlus.ToString(), opFlagPlus);
                        }
                    }
                }
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemReputation))
            {
                ImGuiUtils.ComboBoxEnum("Reputation Type", ref Constants.AlignementIndex, out m_eRestrictAlign, EAlignement.End, EAlignement.GroupEnd);
                ImGuiUtils.InputULong("Reputation Value", ref m_nRestrictPrestige);
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemStats))
            {
                ImGuiUtils.InputULong("Health", ref m_nMaxHp);
                ImGuiUtils.InputULong("Mana", ref m_nMaxMp);
                ImGuiUtils.InputShort("Str", ref m_nStr);
                ImGuiUtils.InputShort("Vit", ref m_nVit);
                ImGuiUtils.InputShort("Int", ref m_nInt);
                ImGuiUtils.InputShort("Wil", ref m_nWil);
                ImGuiUtils.InputShort("Agi", ref m_nDex);
                ImGuiUtils.InputLong("Casting Time", ref m_nCastingTime);
                ImGuiUtils.InputULong("Physical Attack", ref m_nAttack);
                ImGuiUtils.InputULong("Ranged Attack", ref m_nRangeDamage);
                ImGuiUtils.InputULong("Magical Attack", ref m_nMagicDamage);
                ImGuiUtils.InputULong("Physical Attack (Average)", ref m_nAvgPhysicalDamage);
                ImGuiUtils.InputULong("Physical Attack (Random)", ref m_nRandPhysicalDamage);
                ImGuiUtils.InputULong("Physical Defence", ref m_nPhysicalDefence);
                ImGuiUtils.InputULong("Magical Defence", ref m_nMagicDefence);
                if (version >= 15)
                {
                    ImGuiUtils.InputShort("Physical Penetration", ref m_nPhysicalPenetration);
                    ImGuiUtils.InputShort("Magical Penetration", ref m_nMagicalPenetration);
                    ImGuiUtils.InputShort("Physical Penetration Defence", ref m_nPhysicalPenetrationDefence);
                    ImGuiUtils.InputShort("Magical Penetration Defence", ref m_nMagicalPenetrationDefence);
                }
                ImGuiUtils.InputUShort("Attack Range", ref m_nAttackRange);
                if (m_nAttackSpeed < 8) // Can't be less than 0.8 or the server crash !
                    m_nAttackSpeed = 8;
                ImGuiUtils.InputUShort("Attack Speed", ref m_nAttackSpeed);
                ImGuiUtils.InputChar("Hit Rate", ref m_nHitRate);
                ImGuiUtils.InputChar("Dodge Rate", ref m_nDodgeRate);
                ImGuiUtils.InputChar("Block Rate", ref m_nBlockRate);
                ImGuiUtils.InputShort("Physical Critical Rate", ref m_nPhysicalCriticalRate);
                ImGuiUtils.InputShort("Magical Critical Rate", ref m_nMagicCriticalRate);
                ImGuiUtils.InputULong("Physical Critical Damage", ref m_nPhysicalCriticalDamage);
                ImGuiUtils.InputULong("Magical Critical Damage", ref m_nMagicCriticalDamage);
                ImGuiUtils.InputUShort("Durability", ref m_nMaxDurability);
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemAttribute))
            {
                ImGuiUtils.ComboBoxEnum("Attribute Type", ref Constants.AttributeIndex, out m_eAttribute, EAttrResist.Max);
                ImGuiUtils.InputULong("Attribute Damage", ref m_nAttributeDamage);
                ImGuiUtils.InputShort("Attribute Rate", ref m_nAttributeRate);
                ImGuiUtils.InputULong("Attribute Resistance", ref m_nAttributeResist);
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemEnchantments))
            {
                ImGuiUtils.ComboBoxEnum("Enchant Type", ref Constants.EnchantTypeIndex, out m_eEnchantType, EBuffIconType.Max);
                ImGuiUtils.InputInt("Enchant Index", ref m_nEnchantId);
                ImGuiUtils.ComboBoxEnum("Enchant Time Type", ref Constants.EnchantTimeTypeIndex, out m_eEnchantTimeType, ETimeType.Max);
                ImGuiUtils.InputLong("Enchant Duration", ref m_nEnchantDuration);
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemCooldown))
            {
                ImGuiUtils.InputLong("Cooldown Time", ref m_nCoolDownTime);
                ImGuiUtils.InputUShort("Cooldown Group", ref m_nCoolDownGroup);
            }

            if (version >= 11)
            {
                if (ImGui.CollapsingHeader(translate.HeaderItemElf))
                {
                    ImGuiUtils.InputUShort("Elf Skill", ref m_nElfSkillId);
                }
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemSpecial))
            {
                ImGuiUtils.ComboBoxEnum("Special Type", ref Constants.SpecialIndex, out m_eSpecialType);
                ImGuiUtils.InputULong("Special Damage", ref m_nSpecialDamage);
                ImGuiUtils.InputShort("Special Rate", ref m_nSpecialRate);
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemPrice))
            {
                if (version >= 9) ImGuiUtils.ComboBoxEnum("Price Type", ref Constants.PriceIndex, out m_nShopPriceType);
                ImGuiUtils.InputULong("Price", ref m_nSysPrice);
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemSockets))
            {
                ImGuiUtils.InputByte("Socket Max", ref m_nMaxSocket);
                ImGuiUtils.InputChar("Socket Rate", ref m_nSocketRate);
            }

            if (version >= 14)
            {
                if (ImGui.CollapsingHeader(translate.HeaderItemRebirth))
                {
                    ImGuiUtils.InputShort("Minimum Required", ref m_nRebirthCount);
                    ImGuiUtils.InputShort("Max Score", ref m_nRebirthMaxScore);
                    ImGuiUtils.InputShort("Score", ref m_nRebirthScore);
                }
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemMiscellaneous))
            {
                ImGuiUtils.InputByte("Backpack Size", ref m_nBackpackSize);
                ImGuiUtils.InputInt("Treasure Buffs 1", ref m_kTreasureBuffs1);
                ImGuiUtils.InputInt("Treasure Buffs 2", ref m_kTreasureBuffs2);
                ImGuiUtils.InputInt("Treasure Buffs 3", ref m_kTreasureBuffs3);
                ImGuiUtils.InputInt("Treasure Buffs 4", ref m_kTreasureBuffs4);
                if (version >= 13)
                {
                    ImGuiUtils.InputLong("Extra Data 1", ref m_kExtraData1);
                    ImGuiUtils.InputLong("Extra Data 2", ref m_kExtraData2);
                    ImGuiUtils.InputLong("Extra Data 3", ref m_kExtraData3);
                }
                ImGuiUtils.InputByte("Log Level", ref m_nLogLevel);
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemAuction))
            {
                ImGuiUtils.ComboBoxEnum("Auction Type", ref Constants.AuctionTypeIndex, out m_eAuctionType, EAuctionType.Max);
            }

            if (version >= 16)
            {
                if (ImGui.CollapsingHeader(translate.HeaderItemExperience))
                {
                    ImGuiUtils.InputShort("Expert Max Level", ref m_nExpertLevel);
                    ImGuiUtils.InputInt("Expert Enchant Index", ref m_nExpertEnchantId);
                }
            }

            if (ImGui.CollapsingHeader(translate.HeaderItemMissionAndEvents))
            {
                ImGuiUtils.InputUInt("Mission Position ID", ref m_nMissionPosId);
                ImGuiUtils.InputText("Restrict Event Position IDs", ref m_nRestrictEventPosId);
            }

            ProcessClassRestriction();
            ProcessOpFlags();
            ProcessOpFlagsPlus();
        }

        #region Utilities

#if DEBUG
        // Helpers to validate parameter counts per version.
        public static int GetExpectedSerializedParameterCount(long version)
        {
            int n = 0;
            n += 1; // m_nId
            n += 1; // m_kIconFilename
            n += 1; // m_nModelFilename
            n += 1; // m_nDropFilename
            n += 1; // m_nWeaponEffectId
            n += 1; // m_nFlyEffectId
            n += 1; // m_nUsedEffectId
            n += 1; // m_nUsedSoundName
            n += 1; // m_nEnhanceEffectId
            n += 1; // m_kName
            n += 1; // m_eItemType
            n += 1; // m_eEquipType
            n += 1; // m_nOpFlags
            if (version >= 12) n += 1; // m_nOpFlagsPlus
            n += 1; // m_eTarget
            n += 1; // m_eRestrictGender
            n += 1; // m_nRestrictLevel
            if (version >= 9) n += 1; // m_nRestrictMaxLevel
            if (version >= 14) n += 3; // m_nRebirthCount, m_nRebirthScore, m_nRebirthMaxScore
            n += 1; // m_eRestrictAlign
            n += 1; // m_nRestrictPrestige
            n += 1; // m_nRestrictClass
            n += 1; // m_eItemQuality
            n += 1; // m_nItemGroup
            n += 1; // m_nCastingTime
            n += 1; // m_nCoolDownTime
            n += 1; // m_nCoolDownGroup
            n += 1; // m_nMaxHp
            n += 1; // m_nMaxMp
            n += 1; // m_nStr
            n += 1; // m_nVit
            n += 1; // m_nInt
            n += 1; // m_nWil
            n += 1; // m_nDex
            n += 1; // m_nAvgPhysicalDamage
            n += 1; // m_nRandPhysicalDamage
            n += 1; // m_nAttackRange
            n += 1; // m_nAttackSpeed
            n += 1; // m_nAttack
            n += 1; // m_nRangeDamage
            n += 1; // m_nPhysicalDefence
            n += 1; // m_nMagicDamage
            n += 1; // m_nMagicDefence
            n += 1; // m_nHitRate
            n += 1; // m_nDodgeRate
            n += 1; // m_nPhysicalCriticalRate
            n += 1; // m_nPhysicalCriticalDamage
            n += 1; // m_nMagicCriticalRate
            n += 1; // m_nMagicCriticalDamage
            if (version >= 15) n += 4; // penetration stats
            n += 1; // m_eAttribute
            n += 1; // m_nAttributeRate
            n += 1; // m_nAttributeDamage
            n += 1; // m_nAttributeResist
            n += 1; // m_eSpecialType
            n += 1; // m_nSpecialRate
            n += 1; // m_nSpecialDamage
            n += 1; // m_nDropRate
            n += 1; // m_nDropIndex
            n += 1; // m_kTreasureBuffs1
            n += 1; // m_kTreasureBuffs2
            n += 1; // m_kTreasureBuffs3
            n += 1; // m_kTreasureBuffs4
            n += 1; // m_eEnchantType
            n += 1; // m_nEnchantId
            if (version >= 16) n += 2; // m_nExpertLevel, m_nExpertEnchantId
            if (version >= 11) n += 1; // m_nElfSkillId
            n += 1; // m_eEnchantTimeType
            n += 1; // m_nEnchantDuration
            n += 1; // m_nLimitType
            n += 1; // m_nDueDateTime
            n += 1; // m_nBackpackSize
            n += 1; // m_nMaxSocket
            n += 1; // m_nSocketRate
            n += 1; // m_nMaxDurability
            n += 1; // m_nMaxStack
            if (version >= 9) n += 1; // m_nShopPriceType
            n += 1; // m_nSysPrice
            n += 1; // m_nRestrictEventPosId
            n += 1; // m_nMissionPosId
            n += 1; // m_nBlockRate
            n += 1; // m_nLogLevel
            n += 1; // m_eAuctionType
            if (version >= 13) n += 3; // m_kExtraData1..3
            n += 1; // m_kTip
            return n;
        }

        public int GetActualSerializedParameterCount(long version, char delimiter = '|')
        {
            var s = GetString(version, delimiter);
            return CountChars(s, delimiter);
        }

        private static int CountChars(string s, char target)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
                if (s[i] == target) count++;
            return count;
        }
#endif

        public void Initialize()
        {
            var restrictList = Enum.GetValues<ERestrictClass>();
            for (int index = 0; index < restrictList.Length; index++)
            {
                var value = restrictList[index];
                m_bClassRestrictionArray.TryAdd(value, m_nRestrictClass.HasFlag(value));
            }

            var opFlagList = Enum.GetValues<EItemOpFlags>();
            for (int index = 0; index < opFlagList.Length; index++)
            {
                var value = opFlagList[index];
                m_bOpFlagsArray.TryAdd(value, m_nOpFlags.HasFlag(value));
            }

            var opFlagPlusList = Enum.GetValues<EItemOpFlagsPlus>();
            for (int index = 0; index < opFlagPlusList.Length; index++)
            {
                var value = opFlagPlusList[index];
                m_bOpFlagsPlusArray.TryAdd(value, m_nOpFlagsPlus.HasFlag(value));
            }
        }

        private void AddOrRemoveClassRestrict(ERestrictClass cls)
        {
            if (m_bClassRestrictionArray[cls]) m_nRestrictClass |= cls;
            else m_nRestrictClass &= ~cls;
        }

        private void AddOrRemoveOpFlags(EItemOpFlags cls)
        {
            if (m_bOpFlagsArray[cls]) m_nOpFlags |= cls;
            else m_nOpFlags &= ~cls;
        }

        private void AddOrRemoveOpFlagsPlus(EItemOpFlagsPlus cls)
        {
            if (m_bOpFlagsPlusArray[cls]) m_nOpFlagsPlus |= cls;
            else m_nOpFlagsPlus &= ~cls;
        }

        public void ProcessClassRestriction()
        {
            var list = Enum.GetValues<ERestrictClass>();
            foreach (var value in list)
                AddOrRemoveClassRestrict(value);
        }

        public void ProcessOpFlags()
        {
            var list = Enum.GetValues<EItemOpFlags>();
            foreach (var value in list)
                AddOrRemoveOpFlags(value);
        }

        public void ProcessOpFlagsPlus()
        {
            var list = Enum.GetValues<EItemOpFlagsPlus>();
            foreach (var value in list)
                AddOrRemoveOpFlagsPlus(value);
        }

        // If all only or replaceable are selected, remove them and enable all with the only/replaceable flags.
        public void ProcessOnlyAndReplaceableFlags()
        {
            if (m_bOpFlagsArray[EItemOpFlags.Only1] &&
                m_bOpFlagsArray[EItemOpFlags.Only2] &&
                m_bOpFlagsArray[EItemOpFlags.Only3] &&
                m_bOpFlagsArray[EItemOpFlags.Only4] &&
                m_bOpFlagsArray[EItemOpFlags.Only5])
            {
                m_bOpFlagsArray[EItemOpFlags.Only1] = false;
                m_bOpFlagsArray[EItemOpFlags.Only2] = false;
                m_bOpFlagsArray[EItemOpFlags.Only3] = false;
                m_bOpFlagsArray[EItemOpFlags.Only4] = false;
                m_bOpFlagsArray[EItemOpFlags.Only5] = false;
                m_bOpFlagsArray[EItemOpFlags.Only] = true;
            }

            if (m_bOpFlagsArray[EItemOpFlags.Replaceable1] &&
                m_bOpFlagsArray[EItemOpFlags.Replaceable2] &&
                m_bOpFlagsArray[EItemOpFlags.Replaceable3] &&
                m_bOpFlagsArray[EItemOpFlags.Replaceable4] &&
                m_bOpFlagsArray[EItemOpFlags.Replaceable5])
            {
                m_bOpFlagsArray[EItemOpFlags.Replaceable1] = false;
                m_bOpFlagsArray[EItemOpFlags.Replaceable2] = false;
                m_bOpFlagsArray[EItemOpFlags.Replaceable3] = false;
                m_bOpFlagsArray[EItemOpFlags.Replaceable4] = false;
                m_bOpFlagsArray[EItemOpFlags.Replaceable5] = false;
                m_bOpFlagsArray[EItemOpFlags.Replaceable] = true;
            }
        }

        public override string ToString()
        {
            return $"{m_nId}";
        }

        #endregion
    }
}
