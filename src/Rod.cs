using System;
using Microsoft.Xna.Framework.Graphics;
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

public class MyFishingRod : FishingRod
{
    private int numBaitSlots {get; set; } = 1;
    private int numTackleSlots {get; set; } = 2;

    private ModeConsume modeConsumeBait {get; set; } = ModeConsume.AllConsume;
    private ModeConsume modeConsumeTackle {get; set; } = ModeConsume.AllConsume;

    private int maxBait {get; set; } = MyConstant.maxBaitConst;
    private int maxTackle {get; set; } = MyConstant.maxTackleConst;

    private int slotPixelSize {get; set; } = 68;

    private Item?[] BaitAttachments;
    private Item?[] TackleAttachments;

    // private toggleAutoCast

    // private distanceAutoCast

    public MyFishingRod() {
        BaitAttachments = new Item[maxBait];
        for (int i = 0; i < maxBait; i++) {
            BaitAttachments[i] = null;
        }
        TackleAttachments = new Item[maxTackle];
        for (int i = 0; i < maxTackle; i++) {
            TackleAttachments[i] = null;
        }

    }

    public void Update(ModConfig config) {
        numBaitSlots = Math.Min(Math.Max(0, config.NumBaitSlots), maxBait);
        numTackleSlots = Math.Min(Math.Max(0, config.NumTackleSlots), maxTackle);
        modeConsumeBait = config.ModeConsumeBait;
        modeConsumeTackle = config.ModeConsumeTackle;
    }

    // draw all attachments on rod when cursor hovering
    // 一个槽一个槽地画，只画附件
    public override void drawAttachments(SpriteBatch b, int x, int y)
    {
        int draw_x = x;
        int draw_y = y;
        draw_y += (enchantments.Count > 0) ? 8 : 4;
        for (int i = 0; i < numBaitSlots; i++) {
            DrawAttachmentSlot(i, b, draw_x, draw_y);
            draw_x += slotPixelSize;
        }
        draw_x = x;
        draw_y += slotPixelSize;
        for (int i = 0; i < numTackleSlots; i++)
        {
            DrawAttachmentSlot(maxBait + i, b, draw_x, draw_y);
            draw_x += slotPixelSize;
        }
    }

    /// <summary>Draw an attachment slot at the given position.</summary>
    /// <param name="slot">The attachment slot index.</param>
    /// <param name="b">The sprite batch being drawn.</param>
    /// <param name="x">The X position at which to draw the slot.</param>
    /// <param name="y">The Y position at which to draw the slot.</param>
    /// <remarks>This should draw a 64x64 slot.</remarks>
    protected override void DrawAttachmentSlot(int slot, SpriteBatch b, int x, int y)
    {
        Vector2 pixel = new Vector2(x, y);

        // get variable: texture and sourceRect
        // 大概是在画槽位而不是物品，slot参数没用
        GetAttachmentSlotSprite(slot, out var texture, out var sourceRect);
        // draw slot rectangle
        b.Draw(texture, pixel, sourceRect, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.86f);
        
        // draw item
        // 画具体物品而不是槽位
        if (slot >= 0 && slot < maxBait) {
            BaitAttachments[slot]?.drawInMenu(b, pixel, 1f);
        }
        if (slot >= maxBait && slot < maxBait + maxTackle) {
            TackleAttachments[slot]?.drawInMenu(b, pixel, 1f);
        }
    }

    public void OpenMenu()
    {
        // TODO: manage menu
        return;
    }

    // 右键快捷添加视为向0位添加，既实现快捷添加，又实现精准添加
    public void AddBait(Item target, int target_index) {
        if (target_index < 0 || target_index >= numBaitSlots) {
            return;
        }
        // TODO
    }

    public void AddTackle(Item target, int target_index) {
        if (target_index < 0 || target_index >= numTackleSlots) {
            return;
        }
        // TODO
    }
}

}