using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    Image[] MyItem;


    [SerializeField]
    ItemSo Item_Image;

    public int nowItemNum=0;
    public bool fullItem=true;

    public bool GetItem(int num) {
        Debug.Log(nowItemNum);
        if (nowItemNum < 5)
        {
            MyItem[nowItemNum].sprite = Item_Image.Items[num].ItemImage;
            nowItemNum++;


        }
        else {
            fullItem = false;


        }


        return fullItem;

    
    }






}
