using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]private int _maxHealth, _currentHealth;
    public int MaxHealth{
        get{ return _maxHealth;}

        set{
            _maxHealth = value;

        }
    }


    public int CurrentHealth{
        get{return _currentHealth; }
        set{
            _currentHealth = Mathf.Clamp(value, 0 , MaxHealth);
        }
    }
    float inviciblityTime = 2f;
    void Update(){
        if(inviciblityTime >0)
            {CurrentHealth = Mathf.Clamp(CurrentHealth, MaxHealth, MaxHealth);
             inviciblityTime -= Time.deltaTime;}
    }
}
