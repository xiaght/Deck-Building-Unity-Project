using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool CanMove;
    public int MoveNum;

    bool voidmove;

    public List<int[]> maplist;


    public int Gold;
    public int Hp;
    public int FullHp;

 /*   public int Ad;
    public int Ap;*/
    public int Cost;
    public int FullCost;
    public int DrawCard;

    public int Defense;

    public List<int> PlayerCardList;


    private void Awake()
    {
        CanMove = false;
        MoveNum = 0;
        voidmove = false;
        maplist = new List<int[]>();

        DrawCard = 5;

        Defense = 0;
    }

    public void SetMapList() {

        maplist = SingletonManager.Instance.mapgen.maplist;
    }

    public void SetDiceMove(int num) {

        MoveNum += num;
        CanMove = true;
    }
    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.RightArrow)&&CanMove)
        {
            CheckMove(1);

            if (voidmove) {
                transform.Translate(1, 0, 0);
                voidmove = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && CanMove)
        {
            CheckMove(2);
            if (voidmove)
            {
                transform.Translate(0, 1, 0);
                voidmove = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && CanMove)
        {
            CheckMove(3);
            if (voidmove)
            {
                transform.Translate(-1, 0, 0);
                voidmove = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && CanMove)
        {
            CheckMove(4);
            if (voidmove)
            {
                transform.Translate(0, -1, 0);
                voidmove = false;
            }

        }

    }

    public void CheckMove(int dir ) {

        int[] myposition = new int[2] {(int)gameObject.transform.position.x, (int)gameObject.transform.position.y };
        int finalPos=0;
        switch (dir)
        {
            case 1:
                myposition[0]++;
                break;

            case 2:

                myposition[1]++;
                break;
            case 3:

                myposition[0]--;
                break;
            case 4:

                myposition[1]--;
                break;
        }
        for (int j = 0; j < maplist.Count; j++)
        {

            if (maplist[j][0] == myposition[0] && maplist[j][1] == myposition[1])
            {
                //Debug.Log("중복");
                voidmove = true;
                finalPos = j;
                continue;

            }

        }

        if (voidmove) {
            MoveNum--;
            MapTile temp;

            if (finalPos - 1 < 0)
            {
                temp = SingletonManager.Instance.mapgen.MapObjectList[0];
            }
            else {
                temp = SingletonManager.Instance.mapgen.MapObjectList[finalPos - 1];
            }


            if (temp.type == MapTile.Type.Last)
            {
                MoveNum = 0;
                SingletonManager.Instance.battlePhase.BossStage = true;
                SingletonManager.Instance.reward.isBoss = true;
                SingletonManager.Instance.tileEvent.LastEvent();
                Debug.Log("보스 출현");

            }
            if (MoveNum <= 0)
            {



                Debug.Log(temp.type);
                SingletonManager.Instance.tileEvent.Event(temp.type.ToString());
                temp.type = MapTile.Type.Normal;
                temp.ColorSet();

                CanMove = false;
                SingletonManager.Instance.moveManager.DiceRollButtonSet();
            }
            SingletonManager.Instance.moveManager.SetDiceNumText(MoveNum);
        }

    }





}
