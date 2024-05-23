using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using Ebbbb.FishingILike;

namespace Ebbbb.FishingILike
{
    public sealed class ModConfig
    {
        public int NumBaitSlots {get; set; } = 1;

        public int NumTackleSlots {get; set; } = 2;

        public ModeConsume ModeConsumeBait {get; set; } = ModeConsume.AllConsume;

        public ModeConsume ModeConsumeTackle {get; set; } = ModeConsume.AllConsume;

        public SButton? AdjustRodKey { get; set; } = SButton.K;

        // public bool ToggleThiefRingEffectStackable {get; set; } = false;

        // public float RateSlingShotNoConsume {get; set; } = 0f;

        // public bool ToggleEnableElectricHandleAutoCast {get; set} = true;

        // public int DistanceWhenAutoCast {get; set; } = 0;
    }
}