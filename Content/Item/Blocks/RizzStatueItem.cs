﻿using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Bijou.Content.Tiles;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Bijou.Content.Items.Blocks
{
    internal class RizzStatueItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Grand Head of Bijou");
            Tooltip.SetDefault("All hail Chadface of Rizz");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.SortingPriorityMaterials[Type] = 45;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.value = Item.buyPrice(platinum:2);
            Item.rare = ItemRarityID.Cyan;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;


            Item.createTile = ModContent.TileType<Tiles.RizzStatuR>();
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
            .AddIngredient(Mod, "BijouBar", 20)
            .AddTile(TileID.Furnaces)
            .Register();

        }
    }
}
