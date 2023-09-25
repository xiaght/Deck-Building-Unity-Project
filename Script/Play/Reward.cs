using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{


    public bool isBoss;
    public Transform CardReward;

    private void OnEnable()
    {
        if (isBoss)
        {
            CardReward.gameObject.SetActive(true);

        }
        else {
            CardReward.gameObject.SetActive(false);

        }


    }

    public void OnClickGoldButton() {
        if (isBoss)
        {
            SingletonManager.Instance.player.Gold += 30;

        }
        else {
            SingletonManager.Instance.player.Gold += 10;
        }
        SingletonManager.Instance.uIManager.SetGold();
        gameObject.SetActive(false);
        

    
    }
    public void OnClickHpButton()
    {
        if (isBoss)
        {
            SingletonManager.Instance.player.Hp = SingletonManager.Instance.player.FullHp;
        }
        else {
            SingletonManager.Instance.player.Hp += 10;
            if (SingletonManager.Instance.player.Hp > SingletonManager.Instance.player.FullHp) {
                SingletonManager.Instance.player.Hp = SingletonManager.Instance.player.FullHp;
            }

        }

        SingletonManager.Instance.uIManager.SetHp();
        gameObject.SetActive(false);


    }
    public void OnClickCardButton()
    {

        SingletonManager.Instance.player.PlayerCardList.Add(10);
        gameObject.SetActive(false);


    }


}
