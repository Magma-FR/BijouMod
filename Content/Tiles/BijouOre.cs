using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Bijou.Content.Items.Blocks;
using Microsoft.Xna.Framework;
using static Terraria.ID.ContentSamples.CreativeHelper;
using Terraria.ID;
using Terraria.Audio;

namespace Bijou.Content.Tiles
{
    public class BijouOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;

            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileShine[Type] = 900;
            Main.tileShine2[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 350;



            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Bijore");
            AddMapEntry(new Color(21, 170, 235), name);

            DustType = DustID.BlueCrystalShard;
            ItemDrop = ModContent.ItemType<BijouOreItem>();

            //HitSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/OldGoldTink");

            HitSound = SoundID.DD2_WitherBeastCrystalImpact;
            MineResist = 1f;
            MinPick = 35;
        }
    }
}