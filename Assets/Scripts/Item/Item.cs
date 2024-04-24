using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    HealthPortion,
    BulletAddportion,
    ExpAddportion
}

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public int ItemId;
    public string ItemEngName;
    public string ItemKorName;
    public Sprite ItemSprite;
    public int ItemQuantity;
    public int ItemValue;
    public bool Stackable; //겹쳐(포개어) 쌓아 올릴 수 있는지에 대한 여부
    public ItemType ItemType;
}
