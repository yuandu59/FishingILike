using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using Ebbbb.FishingILike;

namespace Ebbbb.FishingILike
{
    public class ThiefRingEffectStackable
    {
        public bool toggle {get; set; } = true;

    }

    public class SlingShotConsumeRate
    {
        public float RateSlingShotNoConsume {get; set; } = 0.9f;
    }
}