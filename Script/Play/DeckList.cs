using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckList : MonoBehaviour
{

    [SerializeField]
    Card card;

    [SerializeField]
    Transform DeckParent;

    List<int> cardList;
    List<int> battleList;

    public bool eventTpye=false;
    public bool battleTpye;

    private void OnEnable()
    {
        battleTpye = SingletonManager.Instance.battlePhase.gameObject.activeSelf;

            SetMyDeck();


        
    }
    private void OnDisable()
    {
        eventTpye = false;
 //       battleTpye = false;
    }
    public void SetMyDeck() {
        cardList = SingletonManager.Instance.player.PlayerCardList;
        battleList = SingletonManager.Instance.battlePhase.Shuffle;
        for (int i = 0; i < DeckParent.childCount; i++) {

            GameObject temp = DeckParent.GetChild(i).gameObject;
//            temp.SetActive(false);
//오브젝트 풀링
            Destroy(temp);
        }

        if (battleTpye)
        {
            for (int i = 0; i < battleList.Count; i++)
            {
                //Debug.Log(cardList[i]);
                Card TempObjectList = Instantiate(card);
                TempObjectList.transform.localScale = new Vector3(3, 3, 3);
                TempObjectList.transform.SetParent(DeckParent);

                if (eventTpye)
                {

                    Button btn = TempObjectList.gameObject.AddComponent<Button>();

                }

                TempObjectList.CardSet(battleList[i], eventTpye);
            }
        }
        else {
            for (int i = 0; i < cardList.Count; i++)
            {
                //Debug.Log(cardList[i]);
                Card TempObjectList = Instantiate(card);
                TempObjectList.transform.localScale = new Vector3(3, 3, 3);
                TempObjectList.transform.SetParent(DeckParent);

                if (eventTpye)
                {

                    Button btn = TempObjectList.gameObject.AddComponent<Button>();

                }

                TempObjectList.CardSet(cardList[i], eventTpye);
            }
        }



    }





}
