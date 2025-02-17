using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using Ebbbb.FishingILike;
using StardewValley.Tools;
using StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6;
using StardewValley.GameData;
using StardewValley.Locations;
using System.Text.Json;

namespace Ebbbb.FishingILike
{
    public enum ModeConsume
    {
        AllConsume,
        NoConsume,
        RandomlyConsume,
        OnlyConsumeFirst
    }

    public enum TypeRodAttachment
    {
        Bait,
        Tackle
    }

    public class MyConstant
    {
        public const int maxBaitConst = 8;

        public const int maxTackleConst = 8;
    }


    public class MyUtility
    {
        public static int ChangeRodPlayerInventory(Farmer who, ModConfig config) {
            if (who == null) {
                return 0;
            }

            int sum = 0;
            for (int i = 0; i < who.MaxItems; i++) {
                if (who.Items[i] != null && who.Items[i].ItemId == "(T)AdvancedIridiumRod" && who.Items[i] is not MyFishingRod) {
                    var origin_json = JsonSerializer.Serialize(who.Items[i]);
                    MyFishingRod? new_rod = JsonSerializer.Deserialize<MyFishingRod>(origin_json);
                    if (new_rod is not null) {
                        new_rod.Update(config);

                        // TODO: inherit attachment and enchantment info
                        
                        who.Items[i] = new_rod;
                        sum += 1;
                    }
                }
            }
            return sum;
        }

        public static int UpdateRodPlayerInventory(Farmer who, ModConfig config)
        {
            if (who == null) {
                return 0;
            }

            int sum = 0;
            for (int i = 0; i < who.MaxItems; i++) {
                if (who.Items[i] != null && who.Items[i] is MyFishingRod my_rod) {
                    my_rod.Update(config);
                    sum += 1;
                }
            }
            return sum;
        }

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
    }
}