﻿plugins = {
	actions = {
		-- { type = "PlayerRotateItem", opentibiaid = 1740, filename = "rotate item.lua" },
		-- { type = "PlayerUseItem", opentibiaid = 1740, filename = "use item.lua" },
		-- { type = "PlayerUseItemWithItem", opentibiaid = 2580, allowfaruse = true, filename = "use item with item.lua" },
		-- { type = "PlayerUseItemWithCreature", opentibiaid = 2580, allowfaruse = true, filename = "use item with creature.lua" },
		-- { type = "PlayerMoveItem", opentibiaid = 1740, filename = "move item.lua" },
		-- { type = "PlayerMoveCreature", name = "Monster Name", filename = "move creature.lua" }
	},
	movements = {
		-- { type = "CreatureStepIn", opentibiaid = 446, filename = "step in.lua" },
		-- { type = "CreatureStepOut", opentibiaid = 446, filename = "step out.lua" },
		-- { type = "InventoryEquip", opentibiaid = 2125, filename = "equip.lua" },
		-- { type = "InventoryDeEquip", opentibiaid = 2125, filename = "deequip.lua" }
	},
	talkactions = {
		-- { type = "PlayerSay", message = "/hello", filename = "say.lua" }
	},
	creaturescripts = {
		{ type = "PlayerLogin", filename = "login.lua" },
		{ type = "PlayerLogout", filename = "logout.lua" }
	},
	npcs = {
		-- { type = "Dialogue", name = "Npc Name", filename = "default.lua" }
	},
	spells = {
		{ words = "exani tera", name = "Magic Rope", group = "Support", cooldown = 2, groupcooldown = 2, level = 9, mana = 20, soul = 0, premium = true, vocations = { vocation.knight, vocation.paladin, vocation.druid, vocation.sorcerer, vocation.eliteknight, vocation.royalpaladin, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.MagicRopeSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exani hur up", name = "Levitate", group = "Support", cooldown = 2, groupcooldown = 2, level = 12, mana = 50, soul = 0, premium = true, vocations = { vocation.knight, vocation.paladin, vocation.druid, vocation.sorcerer, vocation.eliteknight, vocation.royalpaladin, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.LevitateUpSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exani hur down", name = "Levitate", group = "Support", cooldown = 2, groupcooldown = 2, level = 12, mana = 50, soul = 0, premium = true, vocations = { vocation.knight, vocation.paladin, vocation.druid, vocation.sorcerer, vocation.eliteknight, vocation.royalpaladin, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.LevitateDownSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "utevo lux", name = "Light", group = "Support", cooldown = 2, groupcooldown = 2, level = 8, mana = 20, soul = 0, premium = false, vocations = { vocation.knight, vocation.paladin, vocation.druid, vocation.sorcerer, vocation.eliteknight, vocation.royalpaladin, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.LightSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "utevo gran lux", name = "Great Light", group = "Support", cooldown = 2, groupcooldown = 2, level = 13, mana = 60, soul = 0, premium = false, vocations = { vocation.knight, vocation.paladin, vocation.druid, vocation.sorcerer, vocation.eliteknight, vocation.royalpaladin, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.GreatLightSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "utevo vis lux", name = "Ultimate Light", group = "Support", cooldown = 2, groupcooldown = 2, level = 26, mana = 140, soul = 0, premium = true, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.UltimateLightSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "utana vid", name = "Invisible", group = "Support", cooldown = 2, groupcooldown = 2, level = 35, mana = 440, soul = 0, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.InvisibleSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "utani hur", name = "Haste", group = "Support", cooldown = 2, groupcooldown = 2, level = 14, mana = 60, soul = 0, premium = true, vocations = { vocation.knight, vocation.paladin, vocation.druid, vocation.sorcerer, vocation.eliteknight, vocation.royalpaladin, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.HasteSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "utani gran hur", name = "Strong Haste", group = "Support", cooldown = 2, groupcooldown = 2, level = 20, mana = 100, soul = 0, premium = true, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.StrongHasteSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "utamo vita", name = "Magic Shield", group = "Support", cooldown = 14, groupcooldown = 2, level = 14, mana = 50, soul = 0, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.MagicShieldSpellPlugin, mtanksl.OpenTibia.Plugins" },

		{ words = "exana pox", name = "Cure Poison", group = "Healing", cooldown = 6, groupcooldown = 1, level = 10, mana = 30, soul = 0, premium = false, vocations = { vocation.knight, vocation.paladin, vocation.druid, vocation.sorcerer, vocation.eliteknight, vocation.royalpaladin, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.CurePoisonSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exura", name = "Light Healing", group = "Healing", cooldown = 1, groupcooldown = 1, level = 8, mana = 20, soul = 0, premium = false, vocations = { vocation.paladin, vocation.druid, vocation.sorcerer, vocation.royalpaladin, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.LightHealingSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exura gran", name = "Intense Healing", group = "Healing", cooldown = 1, groupcooldown = 1, level = 20, mana = 70, soul = 0, premium = false, vocations = { vocation.paladin, vocation.druid, vocation.sorcerer, vocation.royalpaladin, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.IntenseHealingSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exura ico", name = "Wound Cleansing", group = "Healing", cooldown = 1, groupcooldown = 1, level = 8, mana = 40, soul = 0, premium = false, vocations = { vocation.knight, vocation.eliteknight }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.WoundCleansingSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exura san", name = "Divine Healing", group = "Healing", cooldown = 1, groupcooldown = 1, level = 35, mana = 160, soul = 0, premium = false, vocations = { vocation.paladin, vocation.royalpaladin }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.DivineHealingSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exura vita", name = "Ultimate Healing", group = "Healing", cooldown = 1, groupcooldown = 1, level = 30, mana = 160, soul = 0, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.UltimateHealingSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exura gran mas res", name = "Mass Healing", group = "Healing", cooldown = 2, groupcooldown = 1, level = 36, mana = 150, soul = 0, premium = true, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.MassHealingSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exura sio", name = "Heal Friend", group = "Healing", cooldown = 1, groupcooldown = 1, level = 18, mana = 140, soul = 0, premium = true, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = true, filename = "OpenTibia.Plugins.Spells.HealFriendSpellPlugin, mtanksl.OpenTibia.Plugins" },

		{ words = "exori mort", name = "Death Strike", group = "Attack", cooldown = 2, groupcooldown = 2, level = 16, mana = 20, soul = 0, premium = true, vocations = { vocation.sorcerer, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.DeathStrikeSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exori flam", name = "Flame Strike", group = "Attack", cooldown = 2, groupcooldown = 2, level = 14, mana = 20, soul = 0, premium = true, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.FlameStrikeSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exori vis", name = "Energy Strike", group = "Attack", cooldown = 2, groupcooldown = 2, level = 12, mana = 20, soul = 0, premium = true, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.EnergyStrikeSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo flam hur", name = "Fire Wave", group = "Attack", cooldown = 4, groupcooldown = 2, level = 18, mana = 25, soul = 0, premium = false, vocations = { vocation.sorcerer, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.FireWaveSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo vis lux", name = "Energy Beam", group = "Attack", cooldown = 4, groupcooldown = 2, level = 23, mana = 40, soul = 0, premium = false, vocations = { vocation.sorcerer, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.EnergyBeamSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo gran vis lux", name = "Great Energy Beam", group = "Attack", cooldown = 6, groupcooldown = 2, level = 29, mana = 110, soul = 0, premium = false, vocations = { vocation.sorcerer, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.GreatEnergyBeamSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo vis hur", name = "Energy Wave", group = "Attack", cooldown = 8, groupcooldown = 2, level = 38, mana = 170, soul = 0, premium = false, vocations = { vocation.sorcerer, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.EnergyWaveSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo gran mas vis", name = "Rage of the Skies", group = "Attack", cooldown = 40, groupcooldown = 4, level = 55, mana = 600, soul = 0, premium = true, vocations = { vocation.sorcerer, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.RageOfTheSkiesSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo gran mas flam", name = "Hell's Core", group = "Attack", cooldown = 40, groupcooldown = 4, level = 60, mana = 1100, soul = 0, premium = true, vocations = { vocation.sorcerer, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.HellsCoreSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo gran mas tera", name = "Wrath of Nature", group = "Attack", cooldown = 40, groupcooldown = 4, level = 55, mana = 700, soul = 0, premium = true, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.WrathOfNatureSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo gran mas frigo", name = "Eternal Winter", group = "Attack", cooldown = 40, groupcooldown = 4, level = 60, soul = 0, mana = 1050, premium = true, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.EternalWinterSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exori mas", name = "Groundshaker", group = "Attack", cooldown = 8, groupcooldown = 2, level = 33, mana = 160, soul = 0, premium = true, vocations = { vocation.knight, vocation.eliteknight }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.GroundshakerSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exori", name = "Berserk", group = "Attack", cooldown = 4, groupcooldown = 2, level = 35, mana = 115, soul = 0, premium = true, vocations = { vocation.knight, vocation.eliteknight }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.BerserkSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exori gran", name = "Fierce Berserk", group = "Attack", cooldown = 6, groupcooldown = 2, level = 90, mana = 340, soul = 0, premium = true, vocations = { vocation.knight, vocation.eliteknight }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.FierceBerserkSpellPlugin, mtanksl.OpenTibia.Plugins" },

		{ words = "exevo pan", name = "Food", group = "Support", cooldown = 2, groupcooldown = 2, level = 14, mana = 120, soul = 1, premium = false, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.FoodSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo con", name = "Conjure Arrow", group = "Support", cooldown = 2, groupcooldown = 2, level = 13, mana = 100, soul = 1, conjureopentibiaid = 2544, conjurecount = 10, premium = false, vocations = { vocation.paladin, vocation.royalpaladin }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureItemSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo con pox", name = "Poisoned Arrow", group = "Support", cooldown = 2, groupcooldown = 2, level = 16, mana = 130, soul = 2, conjureopentibiaid = 2545, conjurecount = 7, premium = false, vocations = { vocation.paladin, vocation.royalpaladin }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureItemSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo con flam", name = "Explosive Arrow", group = "Support", cooldown = 2, groupcooldown = 2, level = 25, mana = 290, soul = 3, conjureopentibiaid = 2546, conjurecount = 8, premium = false, vocations = { vocation.paladin, vocation.royalpaladin }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureItemSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo con hur", name = "Conjure Sniper Arrow", group = "Support", cooldown = 2, groupcooldown = 2, level = 24, mana = 160, soul = 3, conjureopentibiaid = 7364, conjurecount = 5, premium = true, vocations = { vocation.paladin, vocation.royalpaladin }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureItemSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo con mort", name = "Conjure Bolt", group = "Support", cooldown = 2, groupcooldown = 2, level = 17, mana = 140, soul = 2, conjureopentibiaid = 2543, conjurecount = 5, premium = true, vocations = { vocation.paladin, vocation.royalpaladin }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureItemSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo con grav", name = "Conjure Piercing Bolt", group = "Support", cooldown = 2, groupcooldown = 2, level = 33, mana = 180, soul = 3, conjureopentibiaid = 7363, conjurecount = 5, premium = true, vocations = { vocation.paladin, vocation.royalpaladin }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureItemSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "exevo con vis", name = "Power Bolt", group = "Support", cooldown = 2, groupcooldown = 2, level = 59, mana = 700, soul = 4, conjureopentibiaid = 2547, conjurecount = 10, premium = true, vocations = { vocation.paladin, vocation.royalpaladin }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureItemSpellPlugin, mtanksl.OpenTibia.Plugins" },

		{ words = "adevo grav pox", name = "Poison Field Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 14, mana = 200, soul = 1, conjureopentibiaid = 2285, conjurecount = 3, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adori min vis", name = "Light Magic Missile Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 15, mana = 120, soul = 1, conjureopentibiaid = 2287, conjurecount = 10, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adevo grav flam", name = "Fire Field Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 15, mana = 240, soul = 1, conjureopentibiaid = 2301, conjurecount = 3, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adori flam", name = "Fireball Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 27, mana = 460, soul = 3, conjureopentibiaid = 2302, conjurecount = 5, premium = true, vocations = { vocation.sorcerer, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adevo grav vis", name = "Energy Field Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 18, mana = 320, soul = 2, conjureopentibiaid = 2277, conjurecount = 3, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adori tera", name = "Stalagmite Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 24, mana = 350, soul = 2, conjureopentibiaid = 2292, conjurecount = 10, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adori mas flam", name = "Great Fireball Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 30, mana = 530, soul = 3, conjureopentibiaid = 2304, conjurecount = 4, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adori vis", name = "Heavy Magic Missile Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 25, mana = 350, soul = 2, conjureopentibiaid = 2311, conjurecount = 10, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adevo mas pox", name = "Poison Bomb Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 25, mana = 520, soul = 2, conjureopentibiaid = 2286, conjurecount = 2, premium = true, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adevo mas flam", name = "Fire Bomb Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 27, mana = 600, soul = 4, conjureopentibiaid = 2305, conjurecount = 2, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adevo res flam", name = "Soulfire Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 27, mana = 420, soul = 3, conjureopentibiaid = 2308, conjurecount = 3, premium = true, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adevo mas grav pox", name = "Poison Wall Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 29, mana = 640, soul = 3, conjureopentibiaid = 2289, conjurecount = 4, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adevo mas hur", name = "Explosion", group = "Support", cooldown = 2, groupcooldown = 2, level = 31, mana = 570, soul = 4, conjureopentibiaid = 2313, conjurecount = 6, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adevo mas grav flam", name = "Fire Wall Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 33, mana = 780, soul = 4, conjureopentibiaid = 2303, conjurecount = 4, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adevo mas vis", name = "Energy Bomb Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 37, mana = 880, soul = 5, conjureopentibiaid = 2262, conjurecount = 2, premium = true, vocations = { vocation.sorcerer, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adevo mas grav vis", name = "Energy Wall Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 41, mana = 1000, soul = 5, conjureopentibiaid = 2279, conjurecount = 4, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adori gran mort", name = "Sudden Death Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 45, mana = 985, soul = 5, conjureopentibiaid = 2268, conjurecount = 3, premium = false, vocations = { vocation.sorcerer, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adana pox", name = "Cure Poison Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 15, mana = 200, soul = 1, conjureopentibiaid = 2266, conjurecount = 1, premium = false, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adura gran", name = "Intense Healing Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 15, mana = 120, soul = 2, conjureopentibiaid = 2265, conjurecount = 1, premium = false, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adura vita", name = "Ultimate Healing Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 24, mana = 400, soul = 3, conjureopentibiaid = 2273, conjurecount = 1, premium = false, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adeta sio", name = "Convince Creature Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 16, mana = 200, soul = 3, conjureopentibiaid = 2290, conjurecount = 1, premium = false, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adana mort", name = "Animate Dead Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 27, mana = 600, soul = 5, conjureopentibiaid = 2316, conjurecount = 1, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adevo ina", name = "Chameleon Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 27, mana = 600, soul = 2, conjureopentibiaid = 2291, conjurecount = 1, premium = false, vocations = { vocation.druid, vocation.sorcerer, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adito grav", name = "Destroy Field Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 17, mana = 120, soul = 2, conjureopentibiaid = 2261, conjurecount = 3, premium = false, vocations = { vocation.paladin, vocation.druid, vocation.sorcerer, vocation.royalpaladin, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adito tera", name = "Disintegrate Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 21, mana = 200, soul = 3, conjureopentibiaid = 2310, conjurecount = 3, premium = true, vocations = { vocation.paladin, vocation.druid, vocation.sorcerer, vocation.royalpaladin, vocation.elderdruid, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adevo grav tera", name = "Magic Wall Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 32, mana = 750, soul = 5, conjureopentibiaid = 2293, conjurecount = 3, premium = true, vocations = { vocation.sorcerer, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },		
		{ words = "adevo grav vita", name = "Wild Growth Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 27, mana = 600, soul = 5, conjureopentibiaid = 2269, conjurecount = 2, premium = true, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adana ani", name = "Paralyse Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 54, mana = 1400, soul = 3, conjureopentibiaid = 2278, conjurecount = 1, premium = true, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adori frigo", name = "Icicle Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 28, mana = 460, soul = 3, conjureopentibiaid = 2271, conjurecount = 5, premium = true, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adori mas frigo", name = "Avalanche Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 30, mana = 530, soul = 3, conjureopentibiaid = 2274, conjurecount = 4, premium = false, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adori mas tera", name = "Stone Shower Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 28, mana = 430, soul = 3, conjureopentibiaid = 2288, conjurecount = 4, premium = true, vocations = { vocation.druid, vocation.elderdruid }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adori mas vis", name = "Thunderstorm Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 28, mana = 430, soul = 3, conjureopentibiaid = 2315, conjurecount = 4, premium = true, vocations = { vocation.sorcerer, vocation.mastersorcerer }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" },
		{ words = "adori san", name = "Holy Missile Rune", group = "Support", cooldown = 2, groupcooldown = 2, level = 27, mana = 300, soul = 3, conjureopentibiaid = 2295, conjurecount = 5, premium = true, vocations = { vocation.paladin, vocation.royalpaladin }, requirestarget = false, filename = "OpenTibia.Plugins.Spells.ConjureRuneSpellPlugin, mtanksl.OpenTibia.Plugins" }
	},
	runes = {
		{ opentibiaid = 2266, name = "Cure Poison Rune", group = "Healing", groupcooldown = 2, level = 15, magiclevel = 0, requirestarget = true, filename = "OpenTibia.Plugins.Runes.CurePoisonRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2265, name = "Intense Healing Rune", group = "Healing", groupcooldown = 2, level = 15, magiclevel = 1, requirestarget = true, filename = "OpenTibia.Plugins.Runes.IntenseHealingRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2273, name = "Ultimate Healing Rune", group = "Healing", groupcooldown = 2, level = 24, magiclevel = 4, requirestarget = true, filename = "OpenTibia.Plugins.Runes.UltimateHealingRunePlugin, mtanksl.OpenTibia.Plugins" },

		{ opentibiaid = 2287, name = "Light Magic Missile Rune", group = "Attack", groupcooldown = 2, level = 15, magiclevel = 0, requirestarget = true, filename = "OpenTibia.Plugins.Runes.LightMagicMissileRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2311, name = "Heavy Magic Missile Rune", group = "Attack", groupcooldown = 2, level = 25, magiclevel = 3, requirestarget = true, filename = "OpenTibia.Plugins.Runes.HeavyMagicMissileRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2292, name = "Stalagmite Rune", group = "Attack", groupcooldown = 2, level = 24, magiclevel = 3, requirestarget = true, filename = "OpenTibia.Plugins.Runes.StalagmiteRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2271, name = "Icicle Rune", group = "Attack", groupcooldown = 2, level = 28, magiclevel = 4, requirestarget = true, filename = "OpenTibia.Plugins.Runes.IcicleRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2268, name = "Sudden Death Rune", group = "Attack", groupcooldown = 2, level = 45, magiclevel = 15, requirestarget = true, filename = "OpenTibia.Plugins.Runes.SuddenDeathRunePlugin, mtanksl.OpenTibia.Plugins" },

		{ opentibiaid = 2285, name = "Poison Field Rune", group = "Attack", groupcooldown = 2, level = 14, magiclevel = 0, requirestarget = false, filename = "OpenTibia.Plugins.Runes.PoisonFieldRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2286, name = "Poison Bomb Rune", group = "Attack", groupcooldown = 2, level = 25, magiclevel = 4, requirestarget = false, filename = "OpenTibia.Plugins.Runes.PoisonBombRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2289, name = "Poison Wall Rune", group = "Attack", groupcooldown = 2, level = 29, magiclevel = 5, requirestarget = false, filename = "OpenTibia.Plugins.Runes.PoisonWallRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2301, name = "Fire Field Rune", group = "Attack", groupcooldown = 2, level = 15, magiclevel = 1, requirestarget = false, filename = "OpenTibia.Plugins.Runes.FireFieldRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2305, name = "Fire Bomb Rune", group = "Attack", groupcooldown = 2, level = 27, magiclevel = 5, requirestarget = false, filename = "OpenTibia.Plugins.Runes.FireBombRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2303, name = "Fire Wall Rune", group = "Attack", groupcooldown = 2, level = 33, magiclevel = 6, requirestarget = false, filename = "OpenTibia.Plugins.Runes.FireWallRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2277, name = "Energy Field Rune", group = "Attack", groupcooldown = 2, level = 18, magiclevel = 3, requirestarget = false, filename = "OpenTibia.Plugins.Runes.EnergyFieldRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2262, name = "Energy Bomb Rune", group = "Attack", groupcooldown = 2, level = 37, magiclevel = 10, requirestarget = false, filename = "OpenTibia.Plugins.Runes.EnergyBombRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2279, name = "Energy Wall Rune", group = "Attack", groupcooldown = 2, level = 41, magiclevel = 9, requirestarget = false, filename = "OpenTibia.Plugins.Runes.EnergyWallRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2302, name = "Fireball Rune", group = "Attack", groupcooldown = 2, level = 27, magiclevel = 4, requirestarget = false, filename = "OpenTibia.Plugins.Runes.FireballRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2304, name = "Great Fireball Rune", group = "Attack", groupcooldown = 2, level = 30, magiclevel = 4, requirestarget = false, filename = "OpenTibia.Plugins.Runes.GreatFireballRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2274, name = "Avalanche Rune", group = "Attack", groupcooldown = 2, level = 30, magiclevel = 4, requirestarget = false, filename = "OpenTibia.Plugins.Runes.AvalancheRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2315, name = "Thunderstorm Rune", group = "Attack", groupcooldown = 2, level = 28, magiclevel = 4, requirestarget = false, filename = "OpenTibia.Plugins.Runes.ThunderstormRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2288, name = "Stone Shower Rune", group = "Attack", groupcooldown = 2, level = 28, magiclevel = 4, requirestarget = false, filename = "OpenTibia.Plugins.Runes.StoneShowerRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2313, name = "Explosion Rune", group = "Attack", groupcooldown = 2, level = 31, magiclevel = 6, requirestarget = false, filename = "OpenTibia.Plugins.Runes.ExplosionRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2261, name = "Destroy Field Rune", group = "Support", groupcooldown = 2, level = 17, magiclevel = 3, requirestarget = false, filename = "OpenTibia.Plugins.Runes.DestroyFieldRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2293, name = "Magic Wall Rune", group = "Support", groupcooldown = 2, level = 27, magiclevel = 9, requirestarget = false, filename = "OpenTibia.Plugins.Runes.MagicWallRunePlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2269, name = "Wild Growth Rune", group = "Support", groupcooldown = 2, level = 27, magiclevel = 8, requirestarget = false, filename = "OpenTibia.Plugins.Runes.WildGrowthRunePlugin, mtanksl.OpenTibia.Plugins" }
	},
	weapons = {
		{ opentibiaid = 2187, level = 33, mana = 13, vocations = { vocation.sorcerer, vocation.mastersorcerer }, filename = "OpenTibia.Plugins.Weapons.WandOfInfernoWeaponPlugin, mtanksl.OpenTibia.Plugins" },		
		{ opentibiaid = 2188, level = 19, mana = 5, vocations = { vocation.sorcerer, vocation.mastersorcerer }, filename = "OpenTibia.Plugins.Weapons.WandOfPlagueWeaponPlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2189, level = 26, mana = 8, vocations = { vocation.sorcerer, vocation.mastersorcerer }, filename = "OpenTibia.Plugins.Weapons.WandOfCosmicEnergyWeaponPlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2190, level = 7, mana = 2, vocations = { vocation.sorcerer, vocation.mastersorcerer }, filename = "OpenTibia.Plugins.Weapons.WandOfVortexWeaponPlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2191, level = 13, mana = 3, vocations = { vocation.sorcerer, vocation.mastersorcerer }, filename = "OpenTibia.Plugins.Weapons.WandOfDragonbreathWeaponPlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2181, level = 26, mana = 8, vocations = { vocation.druid, vocation.elderdruid }, filename = "OpenTibia.Plugins.Weapons.QuagmireRodWeaponPlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2182, level = 6, mana = 2, vocations = { vocation.druid, vocation.elderdruid }, filename = "OpenTibia.Plugins.Weapons.SnakebiteRodWeaponPlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2183, level = 33, mana = 13, vocations = { vocation.druid, vocation.elderdruid }, filename = "OpenTibia.Plugins.Weapons.TempestRodWeaponPlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2185, level = 19, mana = 5, vocations = { vocation.druid, vocation.elderdruid }, filename = "OpenTibia.Plugins.Weapons.VolcanicRodWeaponPlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2186, level = 13, mana = 3, vocations = { vocation.druid, vocation.elderdruid }, filename = "OpenTibia.Plugins.Weapons.MoonlightRodWeaponPlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 7366, level = 0, mana = 0, vocations = { vocation.knight, vocation.paladin, vocation.druid, vocation.sorcerer, vocation.eliteknight, vocation.royalpaladin, vocation.elderdruid, vocation.mastersorcerer }, filename = "OpenTibia.Plugins.Weapons.ViperStarWeaponPlugin, mtanksl.OpenTibia.Plugins" }		
	},
	ammunitions = {
		{ opentibiaid = 2545, filename = "OpenTibia.Plugins.Ammunitions.PoisonArrowAmmunitionPlugin, mtanksl.OpenTibia.Plugins" },
		{ opentibiaid = 2546, filename = "OpenTibia.Plugins.Ammunitions.BurstArrowAmmunitionPlugin, mtanksl.OpenTibia.Plugins" }
	}
}