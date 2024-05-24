using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using Ebbbb.FishingILike;
using StardewValley.Tools;

namespace Ebbbb.FishingILike
{
    public class Debug
    {

        // console command
        public static void RecoverVanillaRod(string command, string[] args)
        {
            Farmer who = Game1.player;
            for (int i = 0; i < who.MaxItems; i++) {
                if (who.Items[i] != null && who.Items[i].ItemId == "(T)AdvancedIridiumRod" && who.Items[i] is MyFishingRod my_rod) {
                    FishingRod vanilla_rod = my_rod;
                    who.Items[i] = vanilla_rod;
                }
            }
        }

        // invoke when press debug key
        public static List<int> TestVanillaRodIndex(Farmer who)
        {
            List<int> rst = new();
            for (int i = 0; i < who.MaxItems; i++) {
                if (who.Items[i] != null && who.Items[i].ItemId == "(T)AdvancedIridiumRod" && who.Items[i] is not MyFishingRod) {
                    rst.Add(i); 
                }
            }
            return rst;
        }

        // invoke when press debug key
        public static List<int> TestMyRodIndex(Farmer who)
        {
            List<int> rst = new();
            for (int i = 0; i < who.MaxItems; i++) {
                if (who.Items[i] != null && who.Items[i].ItemId == "(T)AdvancedIridiumRod" && who.Items[i] is MyFishingRod) {
                    rst.Add(i); 
                }
            }
            return rst;
        }
    }
}