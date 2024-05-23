using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using Ebbbb.FishingILike;

namespace Ebbbb.FishingILike
{
    public class Debug
    {
        public static string DebugTestMyFishingRodInventory(Farmer who)
        {
            string rst = "";
            for (int i = 0; i < who.MaxItems; i++) {
                if (who.Items[i] != null && who.Items[i].ItemId == "(T)AdvancedIridiumRod" && who.Items[i] is MyFishingRod) {
                    rst = string.Concat(rst, $"In inventory index: {i} is new rod." + Environment.NewLine);
                }
            }
            return rst;
        }
    }
}