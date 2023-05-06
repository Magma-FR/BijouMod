using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ObjectData;
using Terraria.GameContent.ObjectInteractions;
using Terraria.Enums;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Bijou.Content.Items.Blocks;

namespace Bijou.Content.Tiles
{
    public class RizzStatuR : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Properties
            Main.tileSolidTop[Type] = true;

            Main.tileSpelunker[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1200;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;


            MineResist = 10f;
            MinPick = 30;

            DustType = DustID.IceGolem;

            // Names
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 6;
            TileObjectData.newTile.Width = 5;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16 };
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Bijou Head Monument");
            AddMapEntry(new Color(30, 200, 200), name);


            // Placement
          
           
            //      ChestDrop = ModContent.ItemType<TatteredBarrelItem>();


          
            TileObjectData.addTile(Type);
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY) => offsetY = 2;



        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 1;
        }

        public override void KillMultiTile(int x, int y, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<RizzStatueItem>(), Main.rand.Next(1, 1));

            if (Main.netMode != NetmodeID.Server)
            {

                int BGore1 = Mod.Find<ModGore>("HeadGore1").Type;
                int BGore2 = Mod.Find<ModGore>("HeadGore2").Type;

                var entitySource = new EntitySource_TileBreak(x, y);

                // We don't want Mod.Find<ModGore> to run on servers as it will crash because gores are not loaded on servers


                for (int i = 0; i < 1; i++)
                {
                    Gore.NewGore(entitySource, new Vector2(x * 16, y * 16), new Vector2(Main.rand.Next(0, 0), Main.rand.Next(0, 0)), BGore1);
                    Gore.NewGore(entitySource, new Vector2(x * 16, y * 16), new Vector2(Main.rand.Next(0,0), Main.rand.Next(0, 0)), BGore2);

                }
            }


        }
    }
}