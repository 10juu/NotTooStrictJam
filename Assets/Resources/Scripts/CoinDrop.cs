using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
   [SerializeField]GameObject coinPrefab;
    [SerializeField]int Coin;
    // Update is called once per frame
    void OnDestroy()
    {
       GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coin.GetComponent<CoinCollision>().coin = Coin;
    }
}
