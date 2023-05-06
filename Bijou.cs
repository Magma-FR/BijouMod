using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Bijou.Content.Items;

namespace Bijou
{
	public class Bijou : Mod
	{
	}


    public class NPClist : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            // This example does not use the AppliesToEntity hook, as such, we can handle multiple npcs here by using if statements.
            if (type == NPCID.Merchant)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<RizzBag>());
                nextSlot++; // Don't forget this line, it is essential.

                // We can use shopCustomPrice and shopSpecialCurrency to support custom prices and currency. Usually a shop sells an item for item.value.
                // Editing item.value in SetupShop is an incorrect approach.

                // This shop entry sells for 2 Defenders Medals.

                nextSlot++;


            }
        }
    }
}