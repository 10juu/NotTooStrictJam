using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour
{
    public int damageAmount;
    public string colliderName;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.TryGetComponent(out IDamage damage) && (collider.gameObject.name == colliderName || collider.gameObject.name == colliderName+"(Clone)")){
            damage.DoDamage(damageAmount);
        }
    }
}
