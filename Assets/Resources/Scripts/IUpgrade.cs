using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgrade 
{
    public void UpgradeLegs();// may need prefab parameters
    public void UpgradeHealth();//may need float/int param
    public void UpgradeShield();//may need float/int param
    public void UpgradeCrown();//may need prefab param
}
