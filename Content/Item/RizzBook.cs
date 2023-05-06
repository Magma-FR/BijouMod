using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Audio;
using Terraria.Localization;
using Bijou.Content.Items.Blocks;

namespace Bijou.Content.Items
{
    public class RizzBook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bijou's Rizzly Box of Stats"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Opens up a quick statistics of Bijou's Youtube Stats." + "\nAppears in the chat log!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;


        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 60000;
            Item.rare = ItemRarityID.Master;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.UseSound = SoundID.AchievementComplete;
            Item.maxStack = 1;
            Item.noUseGraphic = true;
            Item.autoReuse = false;



        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BijouBar>(), 6);
            recipe.AddIngredient(ItemID.Book, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override bool CanUseItem(Player player)
        {


            if (Main.netMode != 2)
                Main.NewText(Language.GetTextValue($"[i:{ItemID.CellPhone}]Bijou's current subscriber count: 43.2k[i:{ItemID.CellPhone}]") 
                    + $"\n[i:{ItemID.FallenStar}]Most popular video: 'I spent 100 Days in Terraria's Calamity Mod and here's what happened!'[i:{ItemID.FallenStar}]"
                    + $"\n[i:{ItemID.ShinyRedBalloon}]Current total views approx: 4.04 million views'[i:{ItemID.ShinyRedBalloon}]"
                               , 30, 210, 240);


            return true;

        }
    }
}
