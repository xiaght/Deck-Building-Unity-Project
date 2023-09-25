using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    private static SingletonManager _instance;
    // �ν��Ͻ��� �����ϱ� ���� ������Ƽ
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
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
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
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // �Ʒ��� �Լ��� ����Ͽ� ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʴ´�.
        DontDestroyOnLoad(gameObject);
    }



}
