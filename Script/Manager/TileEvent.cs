using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TileEvent : MonoBehaviour
{

    [SerializeField]
    Image NormalPanel;
    [SerializeField]
    Image GetCardPanel;
    [SerializeField]
    Image BattlePanel;
    [SerializeField]
    Image ItemPanel;
    [SerializeField]
    Image EventPanel;
    [SerializeField]
    Image LastPanel;



    public void Event(string type) {

        switch (type)
        {
            case "Normal":
                Debug.Log("normal");
                NormalPanel.gameObject.SetActive(true);
                break;
            case "GetCard":
                Debug.Log("GetCard");

                GetCardPanel.gameObject.SetActive(true);
                break;
            case "Battle":
                Debug.Log("Battle");
                SingletonManager.Instance.battlePhase.BossStage = false;
                BattlePanel.gameObject.SetActive(true);
                break;
            case "Item":
                Debug.Log("Item");

                ItemPanel.gameObject.SetActive(true);
                break;
            case "Event":
                Debug.Log("Event");

                EventPanel.gameObject.SetActive(true);
                break;


        }
    }

    public void CloseButton(GameObject thisPanel) {
        thisPanel.SetActive(false);
   
    }

    public void LastEvent() {

        LastPanel.gameObject.SetActive(true);
        Debug.Log("LastEvent");

    }
    













}
