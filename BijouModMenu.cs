using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;
using Bijou;

using System;
using Bijou.Content.Common;
using Bijou.Content.Items;
using Bijou.Content.Tiles;

namespace Bijou
{
    public class BijouModMenu : ModMenu
    {
        private const string menuAssetPath = "Bijou/Assets/Menu"; // Creates a constant variable representing the texture path, so we don't have to write it out multiple times

        public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>("Bijou/Assets/Menu/Rizzy", (AssetRequestMode)2);

        public override Asset<Texture2D> SunTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/RizzySun");

        public override Asset<Texture2D> MoonTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/RizzyMoon");

        //   public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/TheUnknown1");

        //   public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.GetInstance<SurfaceBack>();

        public override string DisplayName => "Bijou's Amazing Intro";


        float floatX;
        float floatY;
        public override void OnSelected()
        {
            SoundEngine.PlaySound(Soundd.BIJOU);

        }





        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            logoScale = 0.7f;

           /* Texture2D MenuBG = (Texture2D)ModContent.Request<Texture2D>($"{menuAssetPath}/MenuBackground");//Background

            Vector2 zero = Vector2.Zero;
            float width = (float)Main.screenWidth / (float)MenuBG.Width;
            float height = (float)Main.screenHeight / (float)MenuBG.Height;


            spriteBatch.Draw(MenuBG, new Vector2(zero.X + MathHelper.Lerp(-98, -82, floatX), zero.Y + MathHelper.Lerp(-50, -47, floatY)), (Rectangle?)null, Color.White, 0f, Vector2.Zero, width * 1.1f, (SpriteEffects)0, 0f);
           */


            return true;


        }
    }
}