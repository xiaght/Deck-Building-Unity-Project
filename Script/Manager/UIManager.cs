using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    public Transform DeckListOpen;


    [SerializeField]
    TextMeshProUGUI Gold;

    [SerializeField]
    TextMeshProUGUI Hp;

    public TextMeshProUGUI Stage;

    public TextMeshProUGUI Log;

    private void OnEnable()
    {
        SetGold();
        SetHp();
        SetStage();
    }
    public void SetStage() {

        Stage.text = "Stage:" + SingletonManager.Instance.gameManager.Stage;
    }

    public void UpdateLog(string text) {

        Log.text = text;
        StartCoroutine(Disappearance());
    }

    IEnumerator Disappearance() {
        yield return new WaitForSeconds(2);
        Log.text = "";
    
    }


    public void DeckOpen() {
        if (DeckListOpen.gameObject.activeSelf) {
            DeckListOpen.gameObject.SetActive(false);

        }
        else{
            DeckListOpen.gameObject.SetActive(true);

        }
    }

    public void DeckOpenInBattle()
    {
        if (DeckListOpen.gameObject.activeSelf)
        {
            DeckListOpen.gameObject.SetActive(false);

        }
        else
        {
            DeckListOpen.gameObject.SetActive(true);

        }
    }

    public void SetGold() {
        Gold.SetText( "Gold:" + SingletonManager.Instance.player.Gold);
    }

    public void SetHp()
    {
        Hp.SetText("Hp:" + SingletonManager.Instance.player.Hp);
    }




}
