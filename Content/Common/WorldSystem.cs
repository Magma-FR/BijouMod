using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.IO;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Generation;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using Bijou;
using Bijou.Content.Common;
using Bijou.Content.Items;

namespace Bijou.Content.Common
{

    public class WorldSystem : ModSystem
    {

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new BijouOrePass("BijouOrePass", 320f));
            }
            int shiniesIndex1 = tasks.FindIndex(genpass1 => genpass1.Name.Equals("Shinies"));

        }
        public override void PostWorldGen()
        {
            int[] goldenchest = { ItemType<RizzBag>() };
            int goldenchestchoice = 0;

            for (int gchestIndex = 0; gchestIndex < 1000; gchestIndex++)
            {
                Chest gchest = Main.chest[gchestIndex];
                // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
                if (gchest != null && Main.tile[gchest.x, gchest.y].TileType == TileID.Containers && Main.tile[gchest.x, gchest.y].TileFrameX == 1 * 36)
                {
                    for (int ginventoryIndex = 0; ginventoryIndex < 40; ginventoryIndex++)
                    {
                        if (gchest.item[ginventoryIndex].type == ItemID.None)
                        {
                            gchest.item[ginventoryIndex].SetDefaults(goldenchest[goldenchestchoice]);
                            goldenchestchoice = (goldenchestchoice + 1) % goldenchest.Length;
                            // Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
                            break;
                        }
                    }
                }
            }

            int[] waterchest = { ItemType<RizzBag>() };
            int waterchestchoice = 0;
            for (int WchestIndex = 0; WchestIndex < 1000; WchestIndex++)

            {

                Chest Wchest = Main.chest[WchestIndex];
                if (Wchest != null && Main.tile[Wchest.x, Wchest.y].TileType == TileID.Containers && Main.tile[Wchest.x, Wchest.y].TileFrameX == 0 * 36)
                {

                    for (int WinventoryIndex = 0; WinventoryIndex < 40; WinventoryIndex++)
                    {

                        if (Wchest.item[WinventoryIndex].type == ItemID.None)
                        {

                            Wchest.item[WinventoryIndex].SetDefaults(waterchest[waterchestchoice]);


                            waterchestchoice = (waterchestchoice + 1) % waterchest.Length;
                            //chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests;
                            break;
                        }
                    }
                }
            }


        }
    }
        
}
