using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 up, forward;
    public float speed;
    PlayerDamage damage;
   [SerializeField]Rigidbody2D body;
   int LayerMap, LayerTower;

   bool[] isBlocked;
   void Awake(){
    damage = GetComponent<PlayerDamage>();
    LayerMap = LayerMask.NameToLayer("Map");
    LayerTower = LayerMask.NameToLayer("Tower");
    isBlocked = new bool[4];
   }
    // Update is called once per frame
    void Update(){
         if (damage.startTime <0 )
            damage.spriteRenderer.color = Color.white;
        else
            damage.startTime -= Time.deltaTime;
    }
    void FixedUpdate()
    {

        up = !isBlocked[0] && Input.GetAxis("Vertical") > 0? Vector3.up*Time.deltaTime*Input.GetAxis("Vertical")*speed:  !isBlocked[1] && Input.GetAxis("Vertical") < 0?Vector3.up*Time.deltaTime*Input.GetAxis("Vertical")*speed: Vector2.zero;
        forward = !isBlocked[2] && Input.GetAxis("Horizontal") > 0? Vector3.right*Time.fixedDeltaTime*Input.GetAxis("Horizontal")*speed :!isBlocked[3] && Input.GetAxis("Horizontal") < 0? Vector3.right*Time.fixedDeltaTime*Input.GetAxis("Horizontal")*speed :Vector2.zero ;
        body.MovePosition(body.position+(Vector2)(up+forward));
       // transform.position += up;
       // transform.position +=forward;
    }
   /**/ 
   float Magnitude( Vector2 delta){
        return Mathf.Sqrt(Mathf.Pow(delta.x, 2)+Mathf.Pow(delta.y, 2));
    }
   void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.layer == LayerMap || collider.gameObject.layer == LayerTower){
            Vector2 closestPoint = collider.ClosestPoint(transform.position);
            if(closestPoint.y  > transform.position.y){
                isBlocked[0] = true;
            }
            if(closestPoint.y  < transform.position.y){
                isBlocked[1] = true;
            }
              if(closestPoint.x  > transform.position.x){
                isBlocked[2] = true;
            }
            if(closestPoint.x  < transform.position.x){
                isBlocked[3] = true;
            }
        }
    }
   void OnTriggerStay2D(Collider2D collider){
        if(collider.gameObject.layer == LayerMap || collider.gameObject.layer == LayerTower){
            Vector2 closestPoint = collider.ClosestPoint(transform.position);
           
           if(closestPoint.y  > transform.position.y){
                isBlocked[0] = true;
            }
            if(closestPoint.y  < transform.position.y){
                isBlocked[1] = true;
            }
            if(closestPoint.x  > transform.position.x){
                isBlocked[2] = true;
            }
            if(closestPoint.x  < transform.position.x){
                isBlocked[3] = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.layer == LayerMap || collider.gameObject.layer == LayerTower){
          for ( int i =0; i< isBlocked.Length; i++){

                isBlocked[i] = false;
          }
            
            
        }
    }
}
