using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Bijou.Content.Projectiles;
using Bijou.Content.Items.Blocks;

namespace Bijou.Content.Items
{
    public class RizzHatchet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rizz Hatchet");
            Tooltip.SetDefault("Throws a overly heavy hatchet that can be thrown far but is heavly affected by gravity");


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 10;
            Item.height = 24;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = 1;
            Item.knockBack = 4f;
            Item.value = Item.buyPrice(silver:80, copper: 80);
            Item.rare = 9;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.maxStack = 999;
            Item.shoot = ModContent.ProjectileType<RizzHatchetProj>();
            Item.shootSpeed = 14f;
            Item.noMelee = true;
            Item.consumable = true;
            Item.noUseGraphic = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(35);
            recipe.AddIngredient(ModContent.ItemType<BijouBar>(), 8);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
