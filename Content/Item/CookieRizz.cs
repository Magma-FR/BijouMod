using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Bijou.Content.Items.Blocks;

namespace Bijou.Content.Items
{
    public class CookieRizz : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Rizz Cookie"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Cooked to perfection, with a delicious peppermint taste and hint of sweet dark chocolate!'"
            + "\nGives Medium Improvements to all stats"
            + "\nHeals 80 life");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;


            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
                new Color(30, 200,200),
                new Color(20, 230, 180),
                new Color(20, 140, 20)
            };
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 99;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item2;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.healLife = 80;
            
        }


        public override bool CanUseItem(Player player)
        {
            player.AddBuff(BuffID.WellFed2, 4800);
            return true;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BijouOreItem>(), 5);
            recipe.AddTile(TileID.CookingPots);
            recipe.Register();
        }
    }
}

