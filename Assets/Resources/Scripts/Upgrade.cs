using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour,IUpgrade
{
    //WHATEVER PARAMS ARE NEEDED TO UPGRADE TOWER VISUALLY AND DIGITALLY

    public bool isLegLocked = false;
    public List<int> CoinToUpgrade;//0 == LEGS ; 1 == HEALTH; 2 == SHIELD; 3 == CROWN;

    public List<int> UpgradeUpdate;
    
    //PARAM END

    public void UpgradeLegs()// may need prefab parameters
    {
        if (isLegLocked){

            isLegLocked = !isLegLocked;
            return;
        } 
        //UPgrades
        //speed
        //wings
        //wheels
        
        //downgrades
        //extra weapon  leglocked
    
    }

public void UpgradeHealth()// may need prefab parameters
    {
        if (isLegLocked){

            isLegLocked = !isLegLocked;
            return;
        } 
        //UPgrades
        //speed
        //wings
        //wheels
        
        //downgrades
        //extra weapon  leglocked
    
    }

public void UpgradeShield()// may need prefab parameters
    {
        if (isLegLocked){

            isLegLocked = !isLegLocked;
            return;
        } 
        //UPgrades
        //speed
        //wings
        //wheels
        
        //downgrades
        //extra weapon  leglocked
    
    }

public void UpgradeCrown()// may need prefab parameters
    {
        if (isLegLocked){

            isLegLocked = !isLegLocked;
            return;
        } 
        //UPgrades
        //speed
        //wings
        //wheels
        
        //downgrades
        //extra weapon  leglocked
    
    }
  //  public void UpgradeHealth();//may need float/int param
    //public void UpgradeShield();//may need float/int param
    //public void UpgradeCrown();
    
}
