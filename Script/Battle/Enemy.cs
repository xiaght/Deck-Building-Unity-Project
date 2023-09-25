using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

    public EnemySo EnemySo;
    public EnemySo BossSo;


    public Image EnemyImage;
    public int EnemyNum;
    public string EnemyName;
    public int EnemyHp;
    public int Grade;
    public int AttackPower;
    //    public Sprite EnemyImage;

    public bool isStun;


    Player player;
    BattlePhase battle;

    public void EnemySet(int enemynum_This) {

        EnemyNum = EnemySo.Enemys[enemynum_This].EnemyNum;
        EnemyImage.sprite = EnemySo.Enemys[enemynum_This].EnemyImage;
        EnemyName = EnemySo.Enemys[enemynum_This].EnemyName;
        EnemyHp = EnemySo.Enemys[enemynum_This].EnemyHp;
        Grade = EnemySo.Enemys[enemynum_This].Grade;
        AttackPower = EnemySo.Enemys[enemynum_This].AttackPower;

        player = SingletonManager.Instance.player;
        battle = SingletonManager.Instance.battlePhase;
    }

    public void BossSet(int bossNum_This) {
        EnemyNum = BossSo.Enemys[bossNum_This].EnemyNum;
        EnemyImage.sprite = BossSo.Enemys[bossNum_This].EnemyImage;
        EnemyName = BossSo.Enemys[bossNum_This].EnemyName;
        EnemyHp = BossSo.Enemys[bossNum_This].EnemyHp;
        Grade = BossSo.Enemys[bossNum_This].Grade;
        AttackPower = BossSo.Enemys[bossNum_This].AttackPower;

        player = SingletonManager.Instance.player;
        battle = SingletonManager.Instance.battlePhase;


    }



    public void EnemyTurn() {

        int ran = Random.Range(0, EnemySo.Enemys[EnemyNum].PatternList.Length);



        switch (EnemySo.Enemys[EnemyNum].PatternList[ran])
        {
            case EnemyList.Pattern.Attack:
                AttackPlayer();
                break;
            case EnemyList.Pattern.Debuff:
                AttackPlayer();
                break;
            case EnemyList.Pattern.Skil:
                EnemySkil();
                break;

            case EnemyList.Pattern.PlayerHandPlus:
                PlayerHandPlus();
                break;
            default:
                break;

        }
       // EnemyList.Pattern temp= EnemySo.Enemys[EnemyNum].PatternList[ran];
    
    }

    public void BossTurn()
    {

        int ran = Random.Range(0, BossSo.Enemys[EnemyNum].PatternList.Length);



        switch (BossSo.Enemys[EnemyNum].PatternList[ran])
        {
            case EnemyList.Pattern.Attack:
                AttackPlayer();
                break;
            case EnemyList.Pattern.Debuff:
                AttackPlayer();
                break;
            case EnemyList.Pattern.Skil:
                EnemySkil();
                break;

            case EnemyList.Pattern.PlayerHandPlus:
                PlayerHandPlus();
                break;
            default:
                break;

        }
        // EnemyList.Pattern temp= EnemySo.Enemys[EnemyNum].PatternList[ran];

    }


    public void AttackPlayer() {
    
        int hpDown=player.Defense - AttackPower;
        if (hpDown >= 0)
        {
            player.Defense -= AttackPower;
        }
        else {
            player.Defense = 0;
            player.Hp += hpDown;
        
        }

        battle.LogTextUpdate("플레이어에게 "+AttackPower+"데미지!");
    }

    public void EnemySkil() { 


    
    }
    public void PlayerHandPlus() {
        battle.LogTextUpdate("쓰레기 투척");
        battle.Deck.Add(9);
    }

}
