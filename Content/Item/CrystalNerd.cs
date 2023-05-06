using Bijou.Content.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Bijou.Content.Projectiles;
using Bijou.Content.Buffs;
using Bijou.Content.Items.Blocks;
using System.Collections.Generic;

namespace Bijou.Content.Items
{
    public class CrystalNerd : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Names and descriptions of all ExamplePetX classes are defined using .hjson files in the Localization folder

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;


        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BoneKey); // Copy the Defaults of the Zephyr Fish Item.

            Item.shoot = ModContent.ProjectileType<PetProj>(); // "Shoot" your pet projectile.
            Item.buffType = ModContent.BuffType<ChadPetBuff>(); // Apply buff upon usage of the Item.

        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600);
            }
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "CrystalNerd", "'All moderators in Bijou's server'")
            {
                OverrideColor = new Color(20, 201, 240)

            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "CrystalNerd", "'Bro has a spinning GitGuWO (IM SORRY GIT)'")
            {
                OverrideColor = new Color(20, 201, 240)

            };
            tooltips.Add(line);

        }
        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BijouBar>(), 6);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
