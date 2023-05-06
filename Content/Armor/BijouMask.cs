using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using Bijou.Content.Common;
using Bijou.Content.Items.Blocks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Bijou.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]

    public class BijouMask: ModItem
    {
        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Bijou's Mask");
            Tooltip.SetDefault("You gain 100% Rizz when equipping this magnificent and scrumptious mask"
                +"\nDiscount on all shop items"
                +"\n3+ Base Damage on all weapons"
                +"\nYou give off a cyan glow!");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            // If your head equipment should draw hair while drawn, use one of the following:
            // ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
            // ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
            // ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
            // ArmorIDs.Head.Sets.DrawBackHair[Item.headSlot] = true;
            // ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true; 
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 10); // How many coins the item is worth
            Item.rare = ItemRarityID.Cyan; // The rarity of the item
            Item.defense = 2; // The amount of defense the item will give when equipped
        }
        int Watertimer = 0;

        public override void EquipFrameEffects(Player player, EquipType type)
            => Lighting.AddLight(player.position, 0.4f, 1.6f, 2.3f);

        public override void UpdateEquip(Player player)
        {
            

            player.GetDamage(DamageClass.Generic).Base += 3f;
            Lighting.AddLight(player.Top, 0.1f, 1.3f, 2.1f);
            Lighting.Brightness(2, 2);
            Watertimer++;

            if (Watertimer == 20)
            {
                int d = Dust.NewDust(player.Top, player.width, player.height, DustID.BlueCrystalShard);
                Main.dust[d].scale = 1f;
                Main.dust[d].velocity *= 0.6f;
                Main.dust[d].noLight = false;


                Watertimer = 0;
            }
            player.discount = true;
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
     

        public override void UpdateArmorSet(Player player)
        {
            
        }

        public override bool OnPickup(Player player)
        {
            SoundEngine.PlaySound(Soundd.BIJOU);
            return true;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;

            Rectangle frame;

            if (Main.itemAnimations[Item.type] != null)
                frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            else
                frame = texture.Frame();

            Vector2 frameOrigin = frame.Size() / 2f;
            Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
            Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

            float time = Main.GlobalTimeWrappedHourly;
            float timer = Item.timeSinceItemSpawned / 240f + time * 0.04f;

            time %= 4f;
            time /= 2f;

            if (time >= 1f)
                time = 2f - time;

            time = time * 0.5f + 0.5f;

            for (float i = 0f; i < 1f; i += 0.25f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(30, 240, 230, 70), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            for (float i = 0f; i < 1f; i += 0.34f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 4f).RotatedBy(radians) * time, frame, new Color(126, 120, 240, 77), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()

            .AddIngredient(ModContent.ItemType<BijouBar>(), 6)
            .AddTile(TileID.WorkBenches)
            .Register();


        }

    }
}
