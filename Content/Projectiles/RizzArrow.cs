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
    public class RizzArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rizz Arrow");

        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 10;

            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 3;
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.timeLeft = 450;
            Projectile.netImportant = true;
            Projectile.netUpdate = true;

        }
        public override void Kill(int timeleft)
        {
            for (var i = 0; i < 12; i++)
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 0, default, 1f);
            Collision.AnyCollision(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);

        }
        public override void AI()
        {
            Lighting.AddLight(Projectile.position, 0.2f, 0.7f, 1f);
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.IceTorch, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, Scale: 0.8f);   //spawns dust behind it, this is a spectral light blue dust


        }
        
    }
}
