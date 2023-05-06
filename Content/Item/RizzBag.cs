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
using Terraria.GameContent.ItemDropRules;

namespace Bijou.Content.Items
{
    public class RizzBag: ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bag 'O Bijou"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Open up a bag of rizzly perfection"
            + "\nBelow are the items you could get from the bag:"
+ $"\n[i:{ItemID.CopperOre}][i:{ItemID.IronOre}][i:{ItemID.TinOre}][i:{ItemID.LeadOre}][i:{ItemID.GoldOre}][i:{ItemID.PlatinumOre}]"
             + $"\n[i:{ItemID.Bomb}][i:{ItemID.Dynamite}][i:{ItemID.Torch}][i:{ItemID.MiningPotion}][i:{ItemID.SpelunkerPotion}]"
                          + $"\n[i:{ItemID.Amethyst}][i:{ItemID.Emerald}][i:{ItemID.Sapphire}][i:{ItemID.Ruby}][i:{ItemID.Diamond}][i:{ItemID.Topaz}][i:{ItemID.Amber}]"

             + $"\n[i:{ModContent.ItemType<BijouBar>()}][i:{ModContent.ItemType<Rizznade>()}][i:{ModContent.ItemType<RizzyDrink>()}][i:{ModContent.ItemType<CookieRizz>()}]");
        
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;


        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.maxStack = 99;
            Item.value = Item.buyPrice(gold: 3);
            Item.rare = ItemRarityID.Cyan;
            Item.consumable = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }


        public override void ModifyItemLoot(ItemLoot itemLoot)
        {

            itemLoot.Add(ItemDropRule.Common(ItemID.CopperOre, 4, 15, 20));
            itemLoot.Add(ItemDropRule.Common(ItemID.IronOre, 4, 15, 20));
            itemLoot.Add(ItemDropRule.Common(ItemID.TinOre, 4, 15, 20));
            itemLoot.Add(ItemDropRule.Common(ItemID.LeadOre, 4, 15, 20));
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldOre, 4, 15, 20));
            itemLoot.Add(ItemDropRule.Common(ItemID.PlatinumOre, 4, 15, 20));
            itemLoot.Add(ItemDropRule.Common(ItemID.Torch, 4, 20, 26));
            itemLoot.Add(ItemDropRule.Common(ItemID.MiningPotion, 4, 2, 3));
            itemLoot.Add(ItemDropRule.Common(ItemID.Bomb, 4, 8, 10));
            itemLoot.Add(ItemDropRule.Common(ItemID.Dynamite, 4, 4, 6));
            itemLoot.Add(ItemDropRule.Common(ItemID.SpelunkerPotion, 4, 2, 3));

            itemLoot.Add(ItemDropRule.Common(ItemID.Amethyst, 4, 3, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.Emerald, 4, 3, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.Sapphire, 4, 3, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.Ruby, 4, 3, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.Diamond, 4, 3, 5));

            itemLoot.Add(ItemDropRule.Common(ItemID.Topaz, 4, 3, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.Amber, 4, 3, 5));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BijouBar>(), 4, 8, 12));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Rizznade>(), 4, 16, 20));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<RizzyDrink>(), 4, 2, 3));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CookieRizz>(), 4, 2, 3));


        }



       
       
    }
}

