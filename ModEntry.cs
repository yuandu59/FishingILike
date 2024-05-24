using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using GenericModConfigMenu;
using StardewValley;
using System.Text.Json;
using StardewValley.Menus;
using StardewValley.Objects;
using System.Reflection.Emit;
using System.Collections.Generic;


namespace Ebbbb.FishingILike
{

/// <summary>模组入口点</summary>
public class ModEntry : Mod
{
    public ModConfig config = new();
    /// <summary>模组的入口点，在首次加载模组后自动调用</summary>
    /// <param name="helper">对象 helper 提供用于编写模组的简化接口</param>
    public override void Entry(IModHelper helper)
    {
        // I18n.Init(helper.Translation);
        config = Helper.ReadConfig<ModConfig>();

        helper.Events.GameLoop.GameLaunched += OnGameLaunched;
        helper.Events.Input.ButtonPressed += OnButtonPressed;
        helper.Events.GameLoop.OneSecondUpdateTicked += OnOneSecondUpdateTicked;
        helper.Events.GameLoop.DayStarted += OnDayStarted;
        helper.Events.Player.InventoryChanged += OnInventoryChanged;

        // add custom debug commands about console
        helper.ConsoleCommands.Add("debug_back_vanilla_rod", "Turn may new rod back into vanilla rod in your inventory", Debug.RecoverVanillaRod);
    }

    private void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
    {   

#region Gmcm Settings
        // get Generic Mod Config Menu's API (if it's installed)
        var configMenu = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
        if (configMenu is null)
            return;

        // register mod
        configMenu.Register(ModManifest,
            reset: () => config = new ModConfig(),
            save: () => Helper.WriteConfig(config)
        );

/*
        configMenu.AddSectionTitle(ModManifest, text: () => "Manage Key");

        configMenu.AddKeybind(ModManifest,
            name: () => "Open Fishing Rod Attachment UI",
            getValue: () => (SButton)config.AdjustRodKey,
            setValue: value => config.AdjustRodKey = value
        );

        configMenu.AddSectionTitle(ModManifest, text: () => "About Rod");

        configMenu.AddNumberOption(ModManifest, 
            name: () => "num of bait slots",
            tooltip: () => "",
            getValue: () => config.NumBaitSlots,
            setValue: value => config.NumBaitSlots = value,
            min: 0, max: MyConstant.maxBaitConst, interval: 1
        );

        configMenu.AddNumberOption(ModManifest, 
            name: () => "num of tackle slots",
            tooltip: () => "",
            getValue: () => config.NumTackleSlots,
            setValue: value => config.NumTackleSlots = value,
            min: 0, max: MyConstant.maxTackleConst, interval: 1
        );

        configMenu.AddTextOption(ModManifest,
            name: () => "Consume bait mode",
            tooltip: () => "",
            getValue: () => config.ModeConsumeBait.ToString(),
            setValue: value => config.ModeConsumeBait = (ModeConsume)Enum.Parse(typeof(ModeConsume), value),
            allowedValues: Enum.GetNames(typeof(ModeConsume))
        );

        configMenu.AddTextOption(ModManifest,
            name: () => "Consume Tackle mode",
            tooltip: () => "",
            getValue: () => config.ModeConsumeTackle.ToString(),
            setValue: value => config.ModeConsumeTackle = (ModeConsume)Enum.Parse(typeof(ModeConsume), value),
            allowedValues: Enum.GetNames(typeof(ModeConsume))
        );
*/

        configMenu.OnFieldChanged(ModManifest, (str, obj) => OnConfigChanged(str, obj));
#endregion

    }

    private void OnDayStarted(object? sender, DayStartedEventArgs e)
    {
/*
        // change rod in player's inventory
        int count = MyUtility.ChangeRodPlayerInventory(Game1.player, config);
        TestLog($"Success change count(when day start): {count}.");
*/
    }

    private void OnInventoryChanged(object? sender, InventoryChangedEventArgs e)
    {
/*
        int count = MyUtility.ChangeRodPlayerInventory(e.Player, config);
        TestLog($"Success change count(when inventory change): {count}.");
*/
    }

    public void OnConfigChanged(string str, object obj)
    {
/*
        MyUtility.UpdateRodPlayerInventory(Game1.player, config);
        TestLog($"Success update when config change.");
*/
    }

    private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
    {
        // 如果玩家还没有进入存档，则取消执行
        if (!Context.IsWorldReady)
            return;

/*        
        // press adjust key to show my custom inventory for rod
        if (e.Equals(config.AdjustRodKey) && Context.CanPlayerMove && 
            Game1.activeClickableMenu == null && !Game1.player.isEating && 
            (Game1.player.CurrentTool is MyFishingRod my_rod)) {
            // render my custom inventory
            my_rod.OpenMenu();
            TestLog("Now holding target rod and try to render inventory");
        }
*/
/*
        // debug
        if (e.Button.Equals(SButton.J)) {
            TestLog($"Vanilla Rod: {Debug.TestVanillaRodIndex}.");
            TestLog($"My Rod: {Debug.TestMyRodIndex}.");
        }
*/
    }

    private void OnOneSecondUpdateTicked(object? sender, OneSecondUpdateTickedEventArgs e)
    {
        if (!Context.IsWorldReady)
            return;

    }

    public void DebugLog(string message) {
        Monitor.Log(message, LogLevel.Debug);
    }

    public void TestLog(string message) {
        Monitor.Log(message, LogLevel.Trace);
    }
}

}