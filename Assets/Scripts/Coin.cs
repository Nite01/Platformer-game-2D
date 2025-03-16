using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 10; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<AudioManager>().PlaySound("PickUpCoin");
            UIManager.Instance.AddScore(coinValue); 
            Destroy(gameObject); 
        }
    }

}
