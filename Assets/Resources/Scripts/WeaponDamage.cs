using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
   public int damage, splashDamage;
   public bool isSplash;
   
    void OnTriggerEnter2D(Collider2D collider){
        
        if (collider.TryGetComponent(out IDamage enemy)){
            enemy.DoDamage(damage);
            
        }
        
    }
     void OnTriggerStay2D(Collider2D collider){
        
        if (collider.TryGetComponent(out IDamage enemy) && isSplash){
            enemy.DoDamage(splashDamage);
           
        }
        
    }
}
