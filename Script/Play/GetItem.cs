using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GetItem : MonoBehaviour
{
    [SerializeField]
    Image[] Items;

    [SerializeField]
    TextMeshProUGUI[] ItemName;


    [SerializeField]
    ItemSo ItemSo;

    [SerializeField]
    Sprite CloseImage;

    public List<int> ItemList;

    private void OnEnable()
    {
        SetCard();
        for (int i = 0; i < 3; i++)
        {
            Button temp = Items[i].GetComponent<Button>();
            temp.enabled = true;

        }
    }

    public void SetCard()
    {
        int num = ItemSo.Items.Length;
        for (int i = 0; i < 3; i++)
        {
            int ran = Random.Range(1, num);
            Items[i].sprite = ItemSo.Items[ran].ItemImage;
            ItemName[i].text = ItemSo.Items[ran].ItemName;
            ItemList.Add(ran);

        }

    }

    public void OnClickGetItem(int num)
    {


        if (SingletonManager.Instance.inventory.GetItem(ItemList[num])){
            Items[num].sprite = CloseImage;
            Button temp = Items[num].GetComponent<Button>();
            temp.enabled = false;
        }



    }
    private void OnDisable()
    {
        ItemList.Clear();
    }



    /*    public void OnClickGetCard(int num)
        {

            Items[num].sprite = CloseImage;
            SingletonManager.Instance.player.PlayerCardList.Add(ItemList[num]);

        }
        private void OnDisable()
        {
            CardList.Clear();
        }*/

}
