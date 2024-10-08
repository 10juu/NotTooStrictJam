using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDamage : MonoBehaviour,IDamage
{
    [SerializeField]Health health;
    [SerializeField]TMP_Text healthText;
      public SpriteRenderer spriteRenderer;
      public float startTime;
        void Awake(){
        spriteRenderer = TryGetComponent<SpriteRenderer>(out spriteRenderer)? spriteRenderer: GetComponentInChildren<SpriteRenderer>();
    }
   public void DoDamage(int damage){
    health.CurrentHealth -= damage;
    spriteRenderer.color = Color.red;
    startTime = (10f/60f);
   }
   void Update(){
    healthText.text = health.CurrentHealth.ToString();
   }
}
