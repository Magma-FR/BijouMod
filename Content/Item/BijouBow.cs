using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Bijou;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Audio;
using Bijou.Content.Tiles;
using Bijou.Content.Items.Blocks;
using Bijou.Content.Projectiles;
using Terraria.DataStructures;

namespace Bijou.Content.Items
{
    public class BijouBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bijou Bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Gradually charge up a bow that shoots three 'rizz' arrows that have high velocity and pierce up to 3 enemies"
            + "\n'Certified Rizz Classic :smug:'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.knockBack = 3;
            Item.value = 60000;
            Item.rare = ItemRarityID.Cyan;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<BijouBowHeld>();
            Item.shootSpeed = 30f;
            Item.noMelee = true;
            Item.UseSound = new SoundStyle($"{nameof(Bijou)}/Assets/Sounds/BowCharge");

            Item.channel = true;
            Item.noUseGraphic = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                position += muzzleOffset;

            for (int i = 0; i < 80; i++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                Dust d = Dust.NewDustPerfect(Main.LocalPlayer.Center, DustID.BlueCrystalShard, speed * 10, Scale: 1.3f); ;
                d.noGravity = true;
            }
            return true;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
          
          
         
            recipe.AddIngredient(ModContent.ItemType<BijouBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();


            
        }




        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(5, 0);
            return offset;
        }
    }
}
