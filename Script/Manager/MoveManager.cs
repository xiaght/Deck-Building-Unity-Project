using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveManager : MonoBehaviour
{

    public TextMeshProUGUI DiceNum;
    public Button DiceRollButton;
    public void DiceRoll() {

        int ran = Random.Range(4, 21);

        Debug.Log("주사위"+ran);
        SingletonManager.Instance.uIManager.UpdateLog("주사위" + ran + "!");

        SingletonManager.Instance.player.SetDiceMove(ran);

        SetDiceNumText(ran);
        DiceRollButton.gameObject.SetActive(false);
    
    }
    public void DiceRollButtonSet() {

        DiceRollButton.gameObject.SetActive(true);

    }





    public void SetDiceNumText(int num) {

        DiceNum.SetText("Dice:" + num);

    }

}
