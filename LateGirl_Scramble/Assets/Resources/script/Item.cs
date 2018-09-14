using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    pan,
    sukebo,
}

public class Item : MonoBehaviour {
    
    private Player player;
    public ItemType itemName;//アイテムの名前を入れる箱
    private float positionY;
    float up;
    private void Awake()
    {
        positionY = transform.position.y;
        up = -0.01f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーだったら破壊
        if (collision.gameObject.tag != "Player") return;
		gameObject.SetActive(false);
    }
    //アイテムの名前を呼び出す
    public int HeyItemName() {

        if (itemName == ItemType.pan)
        {
            return 1;
        }
        else if (itemName == ItemType.sukebo)
        {
            return 2;
        }
        return 0;
    }
    private void Update()
    {
        if (positionY + 0.5f < transform.position.y)
        {
            up = -0.01f;
        }
        if (positionY - 0.5f > transform.position.y)
        {
            up = 0.01f;
        }
        transform.Translate(0, up, 0);
    }

}

