using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDeath : MonoBehaviour
{
    [SerializeField]Health health;

    void Awake(){
        health = GetComponent<Health>();
    }
    void Update(){
        if (health.CurrentHealth <=0){
            Destroy(gameObject);
        }
    }
}
