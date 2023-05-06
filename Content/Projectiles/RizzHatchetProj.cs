using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Audio;

namespace Bijou.Content.Projectiles
{
    public class RizzHatchetProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rizz Hatchet");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;
            Projectile.light = 0;
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.IceGolem, Projectile.velocity.X * 0.7f, Projectile.velocity.Y * 0.7f, Alpha:160, Scale: 0.6f) ;
            Projectile.rotation += 0.09f;
            Projectile.velocity.X *= 0.96f;
            Projectile.velocity.Y *= 0.95f;


        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item53);
            Gore.NewGore(Projectile.GetSource_Death(), Projectile.Center, Vector2.Zero, Mod.Find<ModGore>("HatchetGore1").Type, 1f);
            Gore.NewGore(Projectile.GetSource_Death(), Projectile.Center, Vector2.Zero, Mod.Find<ModGore>("HatchetGore2").Type, 1f);
            if (Main.rand.Next(0, 4) == 0)
                Item.NewItem(Projectile.GetSource_DropAsItem(), (int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height,
                    ModContent.ItemType<Items.RizzHatchet>(), 1, false, 0, false, false);

            for (int i = 0; i < 15; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueCrystalShard, Scale: 0.6f, Alpha: 120);
            }
        }
    }
}
