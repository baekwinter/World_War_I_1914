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
    public bool Stackable; //����(������) �׾� �ø� �� �ִ����� ���� ����
    public ItemType ItemType;
}
