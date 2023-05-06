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
    public class RizzyDrink : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rizzy Drink"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A tasty blend of absolute determination in quality, visuals and commentary mixed into a fine drink'"
            + "\nRizzy Fizzy!!"
            + "\nHeals 60 life");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;


            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
                new Color(30, 200,200),
                new Color(20, 230, 180),
                new Color(20, 140, 20)
            };
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.AppleJuice);
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 99;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = 10000;
            Item.rare = ItemRarityID.Cyan;
            Item.UseSound = SoundID.Item3;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.healLife = 60;
        }



        

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient(ModContent.ItemType<BijouOreItem>(), 5);
            recipe.AddIngredient(ItemID.BottledWater, 3);

            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "RizzyDrink", "'Rizzy Fizzy!!'")
            {
                OverrideColor = new Color(20, 200, 240)

            };
            tooltips.Add(line);

        }
    }
}

