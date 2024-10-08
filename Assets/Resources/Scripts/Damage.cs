using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour, IDamage
{

    public Health health;
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    
    void Awake(){
        spriteRenderer = TryGetComponent<SpriteRenderer>(out spriteRenderer)? spriteRenderer: GetComponentInChildren<SpriteRenderer>();
    }
   public float startTime  =0;
   public void DoDamage(int damage){
    health.CurrentHealth -=damage;
    spriteRenderer.color = Color.red;
    startTime = (10f/60f);
   }

   void Update(){
  
    if (health.CurrentHealth <=0)
        Destroy(gameObject);
   }
}
