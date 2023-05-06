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
    public  class Rizznade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("RizzNade"); 
            Tooltip.SetDefault("Throws a rizzy grenade that explodes into crystals that damage enemies"
                +"\nIncreases its speed on the ground!");


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }
        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 10;
            Item.height = 24;
            Item.useTime = 37;
            Item.useAnimation = 37;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.value = Item.buyPrice(copper: 80);
            Item.rare = 9;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.maxStack = 999;
            Item.shoot = ModContent.ProjectileType<RizznadeProj>();
            Item.shootSpeed = 6f;
            Item.noMelee = true;
            Item.consumable = true;
            Item.noUseGraphic = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(15);
            recipe.AddIngredient(ModContent.ItemType<BijouBar>(), 6);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
