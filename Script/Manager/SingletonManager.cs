using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    private static SingletonManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public GameManager gameManager;
    public Player player;
    public MapGenerator mapgen;
    public MoveManager moveManager;
    public TileEvent tileEvent;
    public CardManager cardManager;
    public Inventory inventory;
    public BattlePhase battlePhase;
    public UIManager uIManager;
    public DeckList deckList;
    public Reward reward;

    public Enemy enemy;

    public static SingletonManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(SingletonManager)) as SingletonManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }



}
