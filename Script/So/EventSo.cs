using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "EventSo", menuName = "Scriptable Object/EventSo")]
public class EventSo : ScriptableObject
{

    public EventList[] Events;
}


[System.Serializable]
public class EventList
{

    public string EventName;
    public int EventNum;
    public enum EventType
    {
        Common, Cost
    }
    public EventType Type;

    //public int Cost;
    //public int Reward;

    public enum CostType
    {
        PlayerHp,PlayerGold
    }
    public CostType[] CostList;
    public int[] CostNum;

    public enum RewardType
    {
        PlayerHp,PlayerGold, SpecialCard,Item, Extinction
    }

    public RewardType[] RewardList;
    public int[] RewardNum;

    public Sprite EventImage;

    public string EventText;

}


