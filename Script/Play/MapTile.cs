using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    public enum Type
    {
        Normal, GetCard,  Battle, Item, Event,Last
    }

    public Type type;

    SpriteRenderer sr;

    private void OnEnable()
    {

        ColorSet();
    }

    private void Start()
    {
        ColorSet();
    }

    public void ColorSet()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();

        if (type == MapTile.Type.Normal) {
            sr.color = Color.white;
        }
        if (type == MapTile.Type.GetCard)
        {
            sr.color = Color.green;
        }
        if (type == MapTile.Type.Battle)
        {
            sr.color = Color.red;
        }
        if (type == MapTile.Type.Item)
        {
            sr.color = Color.yellow;
        }

        if (type == MapTile.Type.Event)
        {
            sr.color = Color.blue;
        }


        if (type == MapTile.Type.Last)
        {
            sr.color = Color.cyan;
        }

    }


}
