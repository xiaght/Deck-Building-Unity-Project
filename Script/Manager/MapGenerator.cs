using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    MapTile MapTile;
    
    [SerializeField]
    int minnum;
    
    [SerializeField]
    int maxnum;

    [SerializeField]
    Transform MapParent;

    [SerializeField]
    public List<MapTile> MapObjectList = new List<MapTile>();
    [SerializeField]
    public List<int[]> maplist;
    [SerializeField]
    List<int> ranlist;


    public List<GameObject> poolLIst;



    private void Awake()
    {



    }


    public void OnEnable()
    {

        MapGen();
    }

    public void OnDisable()
    {
        maplist.Clear();
        ranlist.Clear();

        MapObjectList[MapObjectList.Count - 1].type = MapTile.Type.Normal;


        for (int i = 0; i < MapObjectList.Count; i++) {
            poolLIst[i].SetActive(false);
        }
        MapObjectList.Clear();
    }




    public void MapGen()
    {

        minnum += SingletonManager.Instance.gameManager.Stage * 100;
        maxnum += SingletonManager.Instance.gameManager.Stage * 100;


        int ran = Random.Range(minnum, maxnum);
      //  Debug.Log(ran);
        int x = 0;
        int y = 0;
        maplist = new List<int[]>();
       
        ranlist = new List<int>();

        int[] first = new int[2] { 0, 0 };
        maplist.Add(first);

        for (int i = 0; i < ran; i++) {

            int randir = Random.Range(0,4);
            ranlist.Add(randir);

            if (i>=1&&(ranlist[i] - ranlist[i - 1] == 2 || ranlist[i] - ranlist[i - 1] == -2)) {
               // Debug.Log("반대");
                continue;
            }
         
            if (randir == 0) {
                x++;
            }
            if (randir == 1)
            {
                y++;
            }
            if (randir == 2)
            {
                x--;
            }
            if (randir == 3)
            {
                y--;
            }
            int[] mapindex = new int[2] { x, y };

            bool contains = false;

            for (int j = 0; j < maplist.Count; j++) {

                if (maplist[j][0] == mapindex[0]&& maplist[j][1] == mapindex[1]) {
                   // Debug.Log("중복");
                    contains = true;
                    continue;
                }
            
            }
            if (contains) {
                continue;
            }


            if (maplist.Contains(mapindex)) {
               // Debug.Log("중복");
                continue;
            }

            maplist.Add(mapindex);

            if (MapObjectList.Count >= poolLIst.Count)
            {                    
                GameObject TempObject = Instantiate(MapTile.gameObject, new Vector3(x, y, 0), Quaternion.identity);
                TempObject.transform.SetParent(MapParent);
                poolLIst.Add(TempObject);

            }





            MapTile TempObjectList = poolLIst[MapObjectList.Count].GetComponent<MapTile>();






/*            MapTile TempObjectList = Instantiate(MapTile, new Vector3(x, y, 0), Quaternion.identity);
            TempObjectList.transform.SetParent(MapParent);*/

            int ranMapTile = Random.Range(0, 5);
            switch (ranMapTile)
            {
                case 0:

                    TempObjectList.type = MapTile.Type.Normal;
                    break;

                case 1:
                    TempObjectList.type = MapTile.Type.GetCard;

                    break;
                case 2:

                    //
                    //TempObjectList.type = MapTile.Type.Item;
                    TempObjectList.type = MapTile.Type.Battle;

                    break;
                case 3:

                    TempObjectList.type = MapTile.Type.Battle;
                    break;
                case 4:
                    TempObjectList.type = MapTile.Type.Event;
                    break;
            }
            poolLIst[MapObjectList.Count].SetActive(true);
            poolLIst[MapObjectList.Count].transform.position = new Vector3(x, y, 0);
            MapObjectList.Add(TempObjectList);
         
        }
        
        MapObjectList[MapObjectList.Count - 1].type = MapTile.Type.Last;

        poolLIst[MapObjectList.Count - 1].SetActive(false);
        poolLIst[MapObjectList.Count - 1].SetActive(true);
        SingletonManager.Instance.player.SetMapList();
    }


    /*       for (int i = 0; i < maplist.Count; i++) {

            Debug.Log(ranlist[i]);
            
        }

        for (int i = 0; i < maplist.Count; i++)
        {

            Debug.Log("{" + maplist[i][0] + "," + maplist[i][1] + "}");

        }*/


    //MapObjectList[MapObjectList.Count-1].transform.localScale = new Vector3(1, 1, 1);


    /*        if (ran > poolLIst.Count)
            {
                int num = ran - poolLIst.Count;

                for (int i = 0; i < num; i++) {
                     GameObject TempObject = Instantiate(MapTile.gameObject, new Vector3(x, y, 0), Quaternion.identity);
                    poolLIst.Add(TempObject);
                    TempObject.transform.SetParent(MapParent);

                }

            }*/



    /*        int i = 0;

            while (i<ran) {

                int randir = Random.Range(0, 4);
                ranlist.Add(randir);

                if (i >= 1 && (ranlist[i] - ranlist[i - 1] == 2 || ranlist[i] - ranlist[i - 1] == -2))
                {
                    Debug.Log("반대");
                    continue;
                }

                if (randir == 0)
                {
                    x++;
                }
                if (randir == 1)
                {
                    y++;
                }
                if (randir == 2)
                {
                    x--;
                }
                if (randir == 3)
                {
                    y--;
                }
                int[] mapindex = new int[2] { x, y };

                bool contains = false;

                for (int j = 0; j < maplist.Count; j++)
                {

                    if (maplist[j][0] == mapindex[0] && maplist[j][1] == mapindex[1])
                    {
                        Debug.Log("중복");
                        contains = true;
                        continue;
                    }

                }
                if (contains)
                {
                    continue;
                }

                *//*
                            if (maplist.Contains(mapindex)) {
                                Debug.Log("중복");
                                continue;
                            }*//*

                maplist.Add(mapindex);

                GameObject TempObjectList = Instantiate(MapTile, new Vector3(x, y, 0), Quaternion.identity);
                TempObjectList.transform.SetParent(MapParent);
                MapObjectList.Add(TempObjectList);
                i++;


            }
    */


}
