using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BattlePhase : MonoBehaviour
{
    public List<int> PlayerCardList;
    public Player player;

    public TextMeshProUGUI PlayerCost;
    public Image PlayerHp;
    public TextMeshProUGUI PlayerHp_Text;


    [SerializeField]
    Card card;


    [SerializeField]
    Transform DeckParent;




    public List<int> Deck;
    public List<int> Shuffle;
    public List<int> MyHand;
    public List<int> Graveyard;


    public List<Card> CardObject;
    public List<GameObject> poolLIst;


    public Enemy Enemy;
    public int EnemyNum;
    public Image EnemyHp;
    public TextMeshProUGUI EnemyHp_Text;
    public int EnemyHp_Int;










    Button btn;


    int discardNum;
    int discardNum_Now;
    public Transform DiscardPanel;
    public Transform DiscardUpParent;
    public Transform DiscardDownParent;
    public Button DiscardCheckBtn;

    public List<int> discards_Up;
    public List<int> discards_Down;

    public TextMeshProUGUI GoldText;
    public Image PlayeyDefense;


    public TextMeshProUGUI LogText;

    public bool BossStage=false;
    private void OnEnable()
    {


        if (BossStage)
        {
            BossSet();
        }
        else {
            EnemySet();
        }


        player = SingletonManager.Instance.player;
        ListClear();
        DeckCopy();
        SetBattle();

        PlayerHpUpdate();
        CostTextUpdate();
        GoldUpdate();
        DefenseUpUpdate();
        EnemyHp.fillAmount = 1;
        SingletonManager.Instance.deckList.battleTpye = true;
        //정보 초기화

        //        DrawCard();
    }
/*    private void OnDisable()
    {

        SingletonManager.Instance.deckList.battleTpye = false;
    }*/
    /// <summary>
    /// 카드 효과 적용
    /// 
    /// 
    /// </summary>
    /// 


    public void LogTextUpdate(string text) {
        LogText.text += text + "\n";
        RectTransform temp = LogText.GetComponent<RectTransform>();     
        Vector2 tempv = new Vector2(0, 52);
        temp.sizeDelta +=tempv;


    }



    public void CostTextUpdate()
    {
        PlayerCost.text = "Cost:" + SingletonManager.Instance.player.Cost;

    }

    public void GoldUpdate()
    {

        GoldText.text = "Gold:" + player.Gold;

    }
    public void DefenseUpUpdate()
    {

        float defense = (float)player.Defense / player.FullHp;
        PlayeyDefense.fillAmount = defense;
        //player.Defense
        PlayerHp_Text.text = player.Hp + "/" + player.FullHp + "+(" + player.Defense + ")";


    }
    public void PlayerHpUpdate()
    {

        float hp = (float)player.Hp / (float)player.FullHp;
        Debug.Log(hp);
        PlayerHp.fillAmount = hp;
        PlayerHp_Text.text = player.Hp + "/" + player.FullHp;
    }

    /// <summary>
    /// 패버리기 구현
    /// 
    /// 
    /// </summary>
    /// <param name="num"></param>


    public void DiscardPanelOpen(int num)
    {

        DiscardPanel.gameObject.SetActive(true);
        discardNum = num;
        discardNum_Now = 0;
        for (int i = 0; i < MyHand.Count; i++)
        {
//   Debug.Log("패드랍 테스트" + i);
            Card TempObjectList = Instantiate(card);
            TempObjectList.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            TempObjectList.transform.SetParent(DiscardUpParent);
            TempObjectList.CardSet(MyHand[i],false);
            btn = TempObjectList.GetComponent<Button>();

            discards_Up.Add(MyHand[i]);

            btn.onClick.RemoveAllListeners();
            if (btn == null)
            {

            }
            else
            {
                btn.onClick.AddListener(() => DiscardUPOnClick(TempObjectList));

            }

        }
    }

    public void DiscardUPOnClick(Card temp)
    {

        temp.transform.SetParent(DiscardDownParent);
        //        temp.gameObject.SetActive(false);
        btn = temp.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();

        if (btn == null)
        {
        }
        else
        {
            btn.onClick.AddListener(() => DiscardDownClick(temp));
        }
        discardNum_Now++;
        discards_Up.Remove(temp.CardNum);
        discards_Down.Add(temp.CardNum);
        CheckDiscardButton();

    }
    public void DiscardDownClick(Card temp)
    {
        temp.transform.SetParent(DiscardUpParent);
        //        temp.gameObject.SetActive(false);
        btn = temp.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();

        if (btn == null)
        {
        }
        else
        {
            btn.onClick.AddListener(() => DiscardUPOnClick(temp));
        }
        discardNum_Now--;
        discards_Up.Add(temp.CardNum);
        discards_Down.Remove(temp.CardNum);
        CheckDiscardButton();
    }

    public void CheckDiscardButton()
    {
        if (discardNum == discardNum_Now)
        {
            DiscardCheckBtn.gameObject.SetActive(true);

        }
        else
        {
            DiscardCheckBtn.gameObject.SetActive(false);

        }

    }

    public void DiscardButtonOnClick()
    {
        for (int i = 0; i < discards_Down.Count; i++)
        {
            Graveyard.Add(discards_Down[i]);
            MyHand.Remove(discards_Down[i]);


            for (int j = 0; j < CardObject.Count; j++)
            {
         //       Debug.Log("다운" + discards_Down[i]);
         //       Debug.Log("패" + CardObject[j].CardNum);
                if (discards_Down[i] == CardObject[j].CardNum)
                {

                    if (CardObject[j].gameObject.activeSelf)
                    {
                        CardObject[j].gameObject.SetActive(false);
                        break;
                    }



                }

            }



        }

        for (int i = 0; i < DiscardUpParent.childCount; i++)
        {

            Destroy(DiscardUpParent.GetChild(i).gameObject);
        }
        for (int i = 0; i < DiscardDownParent.childCount; i++)
        {

            Destroy(DiscardDownParent.GetChild(i).gameObject);
        }


        discards_Down.Clear();
        discards_Up.Clear();





        DiscardPanel.gameObject.SetActive(false);

    }




    /// <summary>
    /// 적 셋팅
    /// </summary>
    /// <param name="attackPow"></param>

    public void EnemyState(int attackPow)
    {
        EnemyHp_Int -= attackPow;
        if (EnemyHp_Int <= 0)
        {
            gameObject.SetActive(false);
            if (BossStage) {
                SingletonManager.Instance.gameManager.Stage++;
                SingletonManager.Instance.mapgen.gameObject.SetActive(false);
                SingletonManager.Instance.mapgen.gameObject.SetActive(true);
                SingletonManager.Instance.uIManager.SetStage();
                player.transform.position = new Vector2(0, 0);
            }
            SingletonManager.Instance.reward.isBoss = BossStage;
            SingletonManager.Instance.reward.gameObject.SetActive(true);
        }
        float hp = (float)EnemyHp_Int / (float)Enemy.EnemyHp;
       // Debug.Log(hp);
        EnemyHp.fillAmount = hp;
        EnemyHp_Text.text = Enemy.EnemyHp + "/" + EnemyHp_Int;
    }
    public void EnemySet()
    {
        EnemyNum = Random.Range(1, Enemy.EnemySo.Enemys.Length);
        Enemy.EnemySet(EnemyNum);
        EnemyHp_Int = Enemy.EnemyHp;
        EnemyHp_Text.text = Enemy.EnemyHp + "/" + EnemyHp_Int;
        //EnemyHp.fillAmount = 1f;
    }
    public void BossSet() {
        EnemyNum = Random.Range(1, Enemy.BossSo.Enemys.Length);
        Enemy.BossSet(EnemyNum);
        EnemyHp_Int = Enemy.EnemyHp;
        EnemyHp_Text.text = Enemy.EnemyHp + "/" + EnemyHp_Int;

    }
    /// <summary>
    /// 덱 셋팅
    /// </summary>

    public void ListClear()
    {
        Deck.Clear();
        CardObject.Clear();
        Shuffle.Clear();
        MyHand.Clear();
        Graveyard.Clear();
    }


    public void DeckCopy()
    {
        for (int i = 0; i < SingletonManager.Instance.player.PlayerCardList.Count; i++)
        {

            Deck.Add(SingletonManager.Instance.player.PlayerCardList[i]);

        }
    }




    public void SetBattle()
    {
        //Deck = SingletonManager.Instance.player.PlayerCardList;


        //덱 인식



        for (int i = 0; i < DeckParent.childCount; i++)
        {

            GameObject temp = DeckParent.GetChild(i).gameObject;
            temp.SetActive(false);
            //오브젝트 풀링
            // Destroy(temp);
        }

        /*        for (int i = 0; i < DeckParent.childCount; i++)
                {
                    //Debug.Log(cardList[i]);
                    Card TempObjectList = Instantiate(card);
                    Debug.Log("i:" + i);
                    CardObject.Add(TempObjectList);
                }*/

        for (int i = 0; i < Deck.Count; i++)
        {

            Shuffle.Add(Deck[i]);


        }



        Shuffle = ShuffleList(Shuffle);

        for (int i = 0; i < SingletonManager.Instance.player.DrawCard; i++)
        {
            DrawCard();

        }




    }
    public void DrawCard()
    {


        if (Shuffle.Count == 0)
        {
            SingletonManager.Instance.uIManager.UpdateLog("카드가 없습니다");
            Debug.Log("카드가 없습니다");
            return;
        }

        int activeCard = DeckParent.childCount;
        int activeCard_True = 0;
        int activeCard_False = 0;

        for (int i = 0; i < activeCard; i++)
        {

            if (DeckParent.GetChild(i).gameObject.activeSelf)
            {
                activeCard_True++;
            }
            else
            {
                activeCard_False++;
            }
        }
        Card TempObjectList;
        if (activeCard_True == activeCard)
        {

            TempObjectList = Instantiate(card);
        }
        else
        {



            TempObjectList = DeckParent.GetChild(0).GetComponent<Card>();

            for (int i = 0; i < activeCard; i++)
            {
                if (!DeckParent.GetChild(i).gameObject.activeSelf)
                {
                    TempObjectList = DeckParent.GetChild(i).GetComponent<Card>();

                }

            }


            TempObjectList.gameObject.SetActive(true);
        }



        TempObjectList.transform.SetParent(DeckParent);
        TempObjectList.CardSet(Shuffle[0],false);

        TempObjectList.transform.localScale = new Vector3(.8f, .8f, .8f);
        Button ButtonTemp = TempObjectList.GetComponent<Button>();

        CardObject.Add(TempObjectList);

        MyHand.Add(Shuffle[0]);

        Shuffle.RemoveAt(0);
        for (int i = 0; i < MyHand.Count; i++)
        {


        }


    }



    public void TurnEnd()
    {

        if (!Enemy.isStun)
        {
            if (BossStage)
            {
                int ran = Random.Range(0, 3);
                for (int i = 0; i < ran; i++) {
                    Enemy.BossTurn();

                }
            }
            else {
                Enemy.EnemyTurn();

            }
        }
        PlayerHpUpdate();
        CostTextUpdate();
        GoldUpdate();
        DefenseUpUpdate();

        player.Defense = 0;
        Enemy.isStun = false;
        DefenseUpUpdate();


        for (int i = 0; i < DeckParent.childCount; i++)
        {

            GameObject temp = DeckParent.GetChild(i).gameObject;
            temp.SetActive(false);
            //오브젝트 풀링
            //Destroy(temp);
        }
        NextTurn();
        //        DrawCard(SingletonManager.Instance.player.DrawCard);
    }

    public void NextTurn()
    {
        ListClearTurnEnd();
        SetBattle();

        player.Cost = player.FullCost;
        CostTextUpdate();
    }


    public void ListClearTurnEnd()
    {

        CardObject.Clear();
        Shuffle.Clear();
        MyHand.Clear();
        Graveyard.Clear();


    }


    public List<int> ShuffleList(List<int> deck)
    {




        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = deck[k];
            deck[k] = deck[n];
            deck[n] = temp;
        }

        /* int random_1;
         int random_2;

         int temp;

         for (int i = 0; i < deck.Count; i++) {

             random_1 = Random.Range(0, deck.Count);
             random_2 = Random.Range(0, deck.Count);

             temp = deck[random_1];
             deck[random_1] = deck[random_2];
             deck[random_2] = temp;
         }*/

        return deck;


    }











}
