using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Note,
        Potion1,
        Potion2,
        Potion3,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Note: return ItemAssets.Instance.noteSprite;
            case ItemType.Potion1: return ItemAssets.Instance.potion1Sprite;
            case ItemType.Potion2: return ItemAssets.Instance.potion2Sprite;
            case ItemType.Potion3: return ItemAssets.Instance.potion3Sprite;
        }
    }
}
