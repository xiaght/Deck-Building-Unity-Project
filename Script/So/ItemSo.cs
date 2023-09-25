using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSo", menuName = "Scriptable Object/ItemSo")]
public class ItemSo : ScriptableObject
{

    public ItemList[] Items;
}


[System.Serializable]
public class ItemList
{

    public string ItemName;

    public enum ItemType
    {
        Consumable, Buff
    }

    public ItemType itemType;
    public enum EffectType
    {
        PlayerHp, Buff, Battle
    }
    public EffectType[] EffectList;
    public int[] EffectNum;
    public Sprite ItemImage;
    public int ItemNum;


}