using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : Singleton<UpgradeManager>
{

    const int LEGS = 0;
    const int HEALTH = 0;
    const int SHIELD = 0;
    const int CROWN = 0;
    // Start is called before the first frame update
   public Upgrade towerUpgrade;//upgrade component
   public CoinPurse playerCoin; 
   public List<int> CoinToUpgrade;//0 == LEGS ; 1 == HEALTH; 2 == SHIELD; 3 == CROWN;

    public List<int> UpgradeUpdate;

   public void onLegsUpgrade(/*anyparams*/){
    if(towerUpgrade.TryGetComponent(out IUpgrade tower) && CoinToUpgrade[0] <= playerCoin.coin){
        tower.UpgradeLegs(/*anyparams*/);
        playerCoin.coin -= CoinToUpgrade[LEGS];
        CoinToUpgrade[LEGS] +=UpgradeUpdate[LEGS];
    }
   }
   public void onHealthUpgrade(/*anyparams*/){

   }public void onShieldUpgrade(/*anyparams*/){

   }public void onCrownUpgrade(/*anyparams*/){

   }

}
