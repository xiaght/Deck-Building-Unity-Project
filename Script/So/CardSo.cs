using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName ="CardSo",menuName ="Scriptable Object/CardSo")]
public class CardSo : ScriptableObject
{

    public CardState[] Cards;
}


[System.Serializable]
public class CardState {

    public string CardName;
    public int CardNum;


    public int Cost;
    public string CardText;

    public int Gold;

    public int Hp;
    public int Attack_Star;

    public enum EffectType
    {
        DrawCard, CostUp, PlayerHpUp,PlayerHpDown, Discard, GoldUp,GoldDown, Consumable, DefenseUp,
        Extinction,
        EnemyAttack, EnemyStun
    }

    public EffectType[] EffectList;
    public int[] EffectNum;

    public Sprite CardImage;


}


