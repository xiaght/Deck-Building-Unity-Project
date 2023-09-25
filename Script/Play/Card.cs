using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Card : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI CardName;
    [SerializeField]
    TextMeshProUGUI Cost;
    [SerializeField]
    TextMeshProUGUI CardText;
    [SerializeField]
    Image CardImage;

    [SerializeField]
    CardSo CardSo_This;

    [SerializeField]
    int CardGrade;

    
    public int CardNum;

    [SerializeField]
    Enemy enemy;
    [SerializeField]
    Player player;


    BattlePhase battle;

    //  int enemyHp;
    Button btn;
    /*    private void OnEnable()
        {
            CardSet(CardNum);
        }

    */
    public void CardSet(int CardNum_This,bool eventSet)
    {

        CardNum = CardNum_This;

        CardGrade = 1;
        CardName.text = CardSo_This.Cards[CardNum_This].CardName;
        Cost.text = CardSo_This.Cards[CardNum_This].Cost.ToString();

        CardText.text = CardSo_This.Cards[CardNum_This].Attack_Star.ToString() + "/" + CardSo_This.Cards[CardNum_This].Hp.ToString() + "\n" +
            CardSo_This.Cards[CardNum_This].CardText.ToString();
        CardImage.sprite = CardSo_This.Cards[CardNum_This].CardImage;

        // gameObject.component

        btn = GetComponent<Button>();
        if (btn == null)
        {

        }
        else {
            if (eventSet)
            {

                btn.onClick.AddListener(() => Extinction_Deck(CardNum_This));


            }
            else { 
            
                btn.onClick.AddListener(() => CardEffect(CardNum_This));
            
            }

        }
    }

    public void Extinction_Deck(int num)
    {
        SingletonManager.Instance.player.PlayerCardList.Remove(num);
        SingletonManager.Instance.uIManager.DeckListOpen.gameObject.SetActive(false);
//        SingletonManager.Instance.deckList.gameObject.SetActive(false);

        
    }


    private void OnEnable()
    {
        battle = SingletonManager.Instance.battlePhase;
        player = SingletonManager.Instance.player;
        enemy = SingletonManager.Instance.enemy;
    }

    public void CardEffect(int CardNum)
    {
        Debug.Log(CardNum);

        battle.LogTextUpdate(CardSo_This.Cards[CardNum].CardName + "사용!");
        if (player.Cost < CardSo_This.Cards[CardNum].Cost) {
            Debug.Log("코스트가 부족합니다");
            battle.LogTextUpdate("코스트가 부족합니다");
            return;

        }
        player.Cost -= CardSo_This.Cards[CardNum].Cost;



        battle.Graveyard.Add(CardNum);
        battle.MyHand.Remove(CardNum);

        battle.CostTextUpdate();





        int effectnum = CardSo_This.Cards[CardNum].EffectList.Length;

        for (int i = 0; i < effectnum; i++) {

            switch (CardSo_This.Cards[CardNum].EffectList[i])
            {
                case CardState.EffectType.DrawCard:
                    DrawCard(CardSo_This.Cards[CardNum].EffectNum[i]);
                    break;

                case CardState.EffectType.EnemyAttack:
                    EnemyAttack(CardSo_This.Cards[CardNum].EffectNum[i]);
                    break;

                case CardState.EffectType.CostUp:
                    CostUp(CardSo_This.Cards[CardNum].EffectNum[i]);
                    break;


                case CardState.EffectType.PlayerHpUp:
                    PlayerHpUp(CardSo_This.Cards[CardNum].EffectNum[i]);
                    break;

                case CardState.EffectType.PlayerHpDown:
                    PlayerHpDown(CardSo_This.Cards[CardNum].EffectNum[i]);
                    break;

                case CardState.EffectType.Discard:
                    Discard(CardSo_This.Cards[CardNum].EffectNum[i]);
                    break;

                case CardState.EffectType.GoldUp:
                    GoldUp(CardSo_This.Cards[CardNum].EffectNum[i]);
                    break;
                case CardState.EffectType.GoldDown:
                    GoldDown(CardSo_This.Cards[CardNum].EffectNum[i]);
                    break;
                case CardState.EffectType.Extinction:
                    Extinction(CardSo_This.Cards[CardNum].EffectNum[i]);
                    break;

                case CardState.EffectType.DefenseUp:
                    DefenseUp(CardSo_This.Cards[CardNum].EffectNum[i]);
                    break;

                case CardState.EffectType.EnemyStun:
                    EnemyStun(CardSo_This.Cards[CardNum].EffectNum[i]);
                    break;


                /*                case CardState.EffectType.Buff:
                                    break;

                                case CardState.EffectType.Debuff:
                                    break;
                */
                default:
                    break;
            }

        }

    }
    public void DrawCard(int num)
    {
        for (int i = 0; i < num; i++)
        {
            SingletonManager.Instance.battlePhase.DrawCard();
        }

        gameObject.SetActive(false);
    }
    public void CostUp(int num) {
        player.Cost += num;
        battle.CostTextUpdate();


        gameObject.SetActive(false);
    }

    public void PlayerHpUp(int num)
    {
        player.Hp += num;
        battle.PlayerHpUpdate();

        gameObject.SetActive(false);
    }
    public void PlayerHpDown(int num)
    {
        player.Hp -= num;
        battle.PlayerHpUpdate();

        gameObject.SetActive(false);
    }

    public void Discard(int num) {
        if (num > battle.MyHand.Count) {

            gameObject.SetActive(true);
            Debug.Log("패가 부족합니다");
            return;
        }

        gameObject.SetActive(false);
        battle.DiscardPanelOpen(num);




    }





    public void EnemyAttack(int AttackPow) {

        SingletonManager.Instance.battlePhase.EnemyState(AttackPow);

        gameObject.SetActive(false);
    }

    public void GoldUp(int num) {
        player.Gold += num;
        battle.GoldUpdate();

        gameObject.SetActive(false);

    }
    
    public void GoldDown(int num) {
        player.Gold -= num;
        battle.GoldUpdate();

        gameObject.SetActive(false);

    }

    public void DefenseUp(int num) {
        player.Defense += num;
        battle.DefenseUpUpdate();
        gameObject.SetActive(false);

    }

    public void EnemyStun(int num) {

        enemy.isStun = true;

        gameObject.SetActive(false);

    }

    public void Extinction(int num) {
        battle.Deck.Remove(num);

        gameObject.SetActive(false);

    }


    private void OnDisable()
    {

        if (btn == null)
        {

        }
        else
        {
            btn.onClick.RemoveAllListeners();

        }
    }

}
