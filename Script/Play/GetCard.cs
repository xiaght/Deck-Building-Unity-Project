using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetCard : MonoBehaviour
{
    [SerializeField]
    Image[] Cards;
    [SerializeField]
    TextMeshProUGUI[] CardsName;



    [SerializeField]
    CardSo CardSo;

    [SerializeField]
    Sprite CloseImage;

    public List<int> CardList;

    private void OnEnable()
    {
        SetCard();

        for (int i = 0; i < 5; i++) {
            Button temp = Cards[i].GetComponent<Button>();
            temp.enabled = true;

        }

    }

    public void SetCard()
    {
        int num=CardSo.Cards.Length;
        for (int i = 0; i < 5; i++) {
            int ran = Random.Range(1, num);
            Cards[i].sprite = CardSo.Cards[ran].CardImage;
            CardsName[i].text= CardSo.Cards[ran].CardName+"\n"+CardSo.Cards[ran].Gold+"Gold";
            CardList.Add(ran);
       
        }

    }

    public void OnClickGetCard(int num) {

        if (SingletonManager.Instance.player.Gold >= CardSo.Cards[CardList[num]].Gold)
        {
            SingletonManager.Instance.player.Gold -= CardSo.Cards[CardList[num]].Gold;
            SingletonManager.Instance.uIManager.SetGold();
            Cards[num].sprite = CloseImage;
            SingletonManager.Instance.player.PlayerCardList.Add(CardList[num]);
            Button temp = Cards[num].GetComponent<Button>();
            temp.enabled = false;

        }
        else {
            SingletonManager.Instance.uIManager.UpdateLog("골드가 부족합니다");
            Debug.Log("골드가 부족합니다");
        
        }

        
    }
    private void OnDisable()
    {
        CardList.Clear();
    }




}
