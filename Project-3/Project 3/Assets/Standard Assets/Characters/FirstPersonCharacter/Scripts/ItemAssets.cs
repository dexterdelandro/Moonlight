using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite noteSprite;
    public Sprite potion1Sprite;
    public Sprite potion2Sprite;
    public Sprite potion3Sprite;
}
