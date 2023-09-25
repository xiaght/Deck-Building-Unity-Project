using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemySo", menuName = "Scriptable Object/EnemySo")]
public class EnemySo : ScriptableObject
{

    public EnemyList[] Enemys;
}

[System.Serializable]
public class EnemyList
{

    public int EnemyNum;
    public string EnemyName;
    public int EnemyHp;
    public int Grade;
    public int AttackPower;
    public Sprite EnemyImage;


    public enum Pattern
    {
        Attack, Skil,Debuff,PlayerHandPlus
    }


    public Pattern[] PatternList;


}

