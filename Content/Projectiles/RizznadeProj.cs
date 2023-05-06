﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.GameContent.Creative;
using ReLogic.Content;
using Terraria.Audio;
using static Bijou.Content.ModPlayerr;

namespace Bijou.Content.Projectiles
{
    public class RizznadeProj : ModProjectile
    {

        public bool Exploded { get => Projectile.ai[0] != 0; set => Projectile.ai[0] = !value ? 0 : 1; }


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rizznade");

            Main.projFrames[Projectile.type] = 2;


        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.extraUpdates = 1;
            Projectile.hostile = false;
            Projectile.timeLeft = 260;
            Projectile.penetrate = 2;
            Projectile.DamageType = DamageClass.Ranged;


            Projectile.ownerHitCheck = true;
        }

        public override void AI()
        {
            Projectile.rotation += 0.04f * Projectile.velocity.X;
            Projectile.velocity.Y += 0.1f;
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.IceGolem, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, Scale: 0.4f);

            if (++Projectile.frameCounter >= 25f)//the amount of ticks the game spends on each frame
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }


            if (Projectile.timeLeft < 4 && !Exploded)
            {
                const int ExplosionSize = 250;

                Projectile.position -= new Vector2(ExplosionSize / 2f) - Projectile.Size / 2f;
                Projectile.width = Projectile.height = ExplosionSize;
                Projectile.hostile = true;
                Projectile.friendly = true;
                Projectile.hide = true;
                SoundEngine.PlaySound(SoundID.DD2_WitherBeastDeath);
                Exploded = true;

            }
            int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 100, default, 1f);
            Main.dust[dustIndex].scale = 0.1f + Main.rand.Next(5) * 0.1f;
            Main.dust[dustIndex].fadeIn = 1.5f + Main.rand.Next(5) * 0.1f;
            Main.dust[dustIndex].noGravity = true;
            Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2)).RotatedBy(Projectile.rotation, default) * 1.1f;
            dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.IceTorch, 0f, 0f, 100, default, 1f);
            Main.dust[dustIndex].scale = 1f + Main.rand.Next(5) * 0.1f;
            Main.dust[dustIndex].noGravity = true;
            Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2 - 6)).RotatedBy(Projectile.rotation, default) * 1.1f;


        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X)
                Projectile.velocity.X = -oldVelocity.X;

            if (Projectile.velocity.Y != oldVelocity.Y)
                Projectile.velocity.Y = -oldVelocity.Y * 0.25f;

            Projectile.velocity.X *= 1f;

            return false;

        }

       

        public override bool? CanHitNPC(NPC target) => !target.friendly;
        public override void Kill(int timeLeft)
        {

            Player player = Main.player[Projectile.owner];
            player.GetModPlayer<Screenshake>().SmallScreenshake = true;
            Collision.AnyCollision(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);

            for (int i = 0; i < 50; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 100, default, 2f);
                Main.dust[dustIndex].velocity *= 1.4f;
            }
            // Fire Dust spawn
            for (int i = 0; i < 80; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.IceGolem, 0f, 0f, 150, default, 1.2f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
                dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.IceTorch, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].velocity *= 3f;

            }


            int RumGore1 = Mod.Find<ModGore>("RizzGore1").Type;
            int RumGore2 = Mod.Find<ModGore>("RizzGore2").Type;
            int RumGore3 = Mod.Find<ModGore>("RizzGore3").Type;

            var entitySource = Projectile.GetSource_Death();
            if (Main.netMode != NetmodeID.Server)
            {
                for (int i = 0; i < 3; i++)
                {
                    Gore.NewGore(entitySource, Projectile.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), RumGore1);
                    Gore.NewGore(entitySource, Projectile.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), RumGore2);
                    Gore.NewGore(entitySource, Projectile.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), RumGore3);

                }
            }
        }
    }
}
