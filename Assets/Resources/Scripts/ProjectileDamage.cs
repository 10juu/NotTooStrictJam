using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour//Rename to Damage for generic damage
{
    public int damage;
    void Awake(){
        Destroy(gameObject,5f);
    }
    void OnTriggerEnter2D(Collider2D collider){
        
        if (collider.TryGetComponent(out IDamage enemy)){
            enemy.DoDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
