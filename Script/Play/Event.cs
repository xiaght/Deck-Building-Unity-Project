using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Event : MonoBehaviour
{
    public EventSo events;
    public TextMeshProUGUI EventTitle;
    public TextMeshProUGUI EventText;

    public Button CostButton;
    int ran;
    public int EventNum;

    public Transform MyDeck;

    Player player;
    UIManager uIManager;
    private void OnEnable()
    {

        player = SingletonManager.Instance.player;
        uIManager = SingletonManager.Instance.uIManager;

        ran = Random.Range(1, events.Events.Length);
        EventNum = ran;
        EventTitle.text = events.Events[ran].EventName;
        EventText.text = events.Events[ran].EventText;

    }

    public void OnClickEventButton()
    {

        for (int i = 0; i < events.Events[EventNum].CostList.Length; i++)
        {


            switch (events.Events[EventNum].CostList[i])
            {
                case EventList.CostType.PlayerHp:
                    CostPlayerHp(events.Events[EventNum].CostNum[i]);
                    break;
                case EventList.CostType.PlayerGold:
                    CostPlayerGold(events.Events[EventNum].CostNum[i]);
                    break;
                default:
                    break;

            }
        }

        for (int i = 0; i < events.Events[EventNum].RewardList.Length; i++)
        {


            switch (events.Events[EventNum].RewardList[i])
            {
                case EventList.RewardType.Item:
                    RewardItem(events.Events[EventNum].RewardNum[i]);
                    break;

                case EventList.RewardType.PlayerGold:
                    RewardPlayerGold(events.Events[EventNum].RewardNum[i]);
                    break;
                case EventList.RewardType.PlayerHp:
                    RewardPlayerHp(events.Events[EventNum].RewardNum[i]);
                    break;
                case EventList.RewardType.SpecialCard:
                    RewardSpecialCard(events.Events[EventNum].RewardNum[i]);
                    break;

                case EventList.RewardType.Extinction:
                    Extinction(events.Events[EventNum].RewardNum[i]);
                    break;

                default:
                    break;

            }
        }

        gameObject.SetActive(false);



    }







    public void CostPlayerHp(int num) {
        player.Hp -= num;
        uIManager.SetHp();
    }
    public void CostPlayerGold(int num)
    {
        player.Gold -= num;
        uIManager.SetGold();

    }


    public void RewardItem(int num) {
        player.Hp -= num;
        uIManager.SetHp();

    }
    public void RewardPlayerGold(int num)
    {
        player.Gold += num;
        uIManager.SetGold();

    }
    public void RewardPlayerHp(int num)
    {
        player.Hp += num;
        uIManager.SetHp();
    }
    public void RewardSpecialCard(int num)
    {
        player.PlayerCardList.Add(num);
    }
    public void Extinction(int num) {
        SingletonManager.Instance.deckList.eventTpye=true;
        MyDeck.gameObject.SetActive(true);
    
    }





}
