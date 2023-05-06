using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Bijou.Content.Common
{
    public class Soundd : ModSystem
    {
        public static readonly SoundStyle BIJOU;
        public static readonly SoundStyle BowCharge;
        public static readonly SoundStyle BowShot;
        public static readonly SoundStyle au;





        static Soundd()
        {
            BIJOU = new SoundStyle("Bijou/Assets/Sounds/BIJOU", (SoundType)0);
            BowCharge = new SoundStyle("Bijou/Assets/Sounds/BowCharge", (SoundType)0);
            BowShot= new SoundStyle("Bijou/Assets/Sounds/BowShot", (SoundType)0);
            au = new SoundStyle("Bijou/Assets/Sounds/au", (SoundType)0);



        }
    }







}