using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Bijou.Content.Items.Blocks;

namespace Bijou.Content.NPCC
{
    public class BijouSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bijou Slime");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 24;
            NPC.height = 20;
            NPC.damage = 10;
            NPC.lifeMax = 60;
            NPC.value = 50f;
            NPC.aiStyle = 1;
            NPC.HitSound = SoundID.DD2_WitherBeastCrystalImpact;
            NPC.DeathSound = SoundID.NPCDeath1;
            AIType = NPCID.JungleSlime;
            AnimationType = NPCID.GreenSlime;
            NPC.netAlways = true;
            NPC.netUpdate = true;

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Overworld.Chance * 0.23f;
        }
        private int dustTimer;

        public override void AI()
        {
            Lighting.AddLight(NPC.position, r: 0.3f, g: 1.3f, b: 2.1f);


            Player Player = Main.player[NPC.target];
            dustTimer++;
            if (dustTimer >= 50)
            {
                for (int i = 0; i < 60; i++)
                {
                    Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                    Dust d = Dust.NewDustPerfect(NPC.Center, DustID.BlueCrystalShard, speed * 10, Scale: 1f); ;
                    d.noGravity = true;
                }

                dustTimer = 0;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 20)
                NPC.frameCounter = 0;
            NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
                   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A slime covered in rizzly essence. Kill these scrumptious and elegant slimes or there will be no infernum playthrough"),

				// By default the last added IBestiaryBackgroundImagePathAndColorProvider will be used to show the background image.
				// The ExampleSurfaceBiome ModBiomeBestiaryInfoElement is automatically populated into bestiaryEntry.Info prior to this method being called
				// so we use this line to tell the game to prioritize a specific InfoElement for sourcing the background image.
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BijouOreItem>(), 1, 2, 4));
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 2, 6));

        }

        public override void HitEffect(int hitDirection, double damage)
        {

            for (int i = 0; i < 15; i++)
            {

                Vector2 speed = Main.rand.NextVector2Square(1f, 1f);

                Dust d = Dust.NewDustPerfect(NPC.position, DustID.BlueCrystalShard, speed * 5, Scale: 1.5f);
                d.noGravity = true;

            }

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y - 20, target.width, target.height), new Color(20, 120, 240, 110), "You got games on yo phone?", false, false);

        }
    }
}
