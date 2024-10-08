using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPurse : MonoBehaviour, ICoin//IShop
{
    public int coin;
    [SerializeField]TMP_Text coinText;
    // Start is called before the first frame update
    public void GainCoin(int Coin)
    {
        coin += Coin;
    }
    //

    // Update is called once per frame
    void Update(){
        coinText.text = coin.ToString();
    }
}
