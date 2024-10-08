using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
      public int coin;
    void Awake(){
        Destroy(gameObject,7f);
    }
    void OnTriggerEnter2D(Collider2D collider){
        
        if (collider.TryGetComponent(out ICoin player)){
            player.GainCoin(coin);
            Destroy(gameObject);
        }
        
    }
}
