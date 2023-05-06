using Bijou.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bijou.Content.Projectiles
{
    public class PetProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(197); // Copy the stats of the Zephyr Fish

            AIType = 197; // Copy the AI of the Zephyr Fish.
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];

            player.zephyrfish = false; // Relic from aiType

            return true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            // Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
            if (!player.dead && player.HasBuff(ModContent.BuffType<ChadPetBuff>()))
            {
                Projectile.timeLeft = 2;
            }
        }
    }
}
