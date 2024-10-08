using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemy : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    float  startTime;
    float theta = 0;
    public float range = 10f,attack_speed = 0f, rangelimit =0f;
    public int damage = 0;
    public GameObject crown;
    public Health targetHealth;
    public Animator animator;
    public GameObject barrel;
     private Vector2 origin,  right;
    void Awake(){
        origin = (Vector2) transform.position;
        right = (Vector2)origin+Vector2.left;
    }
    // Update is called once per frame
   void FixedUpdate()
    {
        origin = (Vector2) transform.position;
        right = (Vector2)origin+Vector2.left;
        // Cast a ray straight down.0,

        Vector2 direction = new Vector2(Mathf.Cos((theta)), Mathf.Sin(theta));
        theta += Time.deltaTime*10;
        
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, (Vector2)direction, range,LayerMask.GetMask("Enemy"));
        if(startTime > 0)
            startTime -= Time.deltaTime;
        //Finding target...
        if (hit.collider != null && Mathf.Ceil(startTime) == 0 && targetHealth == null )
        {
            // Calculate the distance from the surface and the "error" relative
            // to the floating height.
            
                
            if (hit.collider.name != "Player")// && (targetHealth == null || ( GeneralManager.Instance.Magnitude(hit.collider.transform.position - transform.position) < GeneralManager.Instance.Magnitude(targetHealth.transform.position - transform.position))))
                hit.collider.TryGetComponent(out targetHealth);
           
           // Aim(hit.collider.transform.position);
            //Attack(hit.collider.transform.position);

        }  
        
        
        if(targetHealth != null ){
            Aim(targetHealth.transform.position);
        }if(targetHealth != null &&Mathf.Ceil(startTime) == 0 ){
            if (Magnitude(beta) > rangelimit)
                Attack(targetHealth.transform.position);
        }  
         Vector2 forward = transform.TransformDirection(direction) * range;
        Debug.DrawRay(transform.position, forward, Color.green);

       
}

    float Magnitude( Vector2 delta){
        return Mathf.Sqrt(Mathf.Pow(delta.x, 2)+Mathf.Pow(delta.y, 2));
    }
    float kappa;
    Vector2 beta;

     
    void Aim(Vector2 enemy){
         beta = (Vector2)enemy-(Vector2)transform.position;
         if(name == "Sword" || name == "Sword(Clone)")
            return;
        
           Vector2 alpha =  Vector2.left;
            float num = DotProduct(beta, right);
        float denom = Determinant(beta, right);
        kappa = -Mathf.Rad2Deg*FindTheta( denom, num);
           
        kappa -= name == "Bow"? -75:90;
        //NORMALIZE ANGLE TO 0 -360
           kappa = (kappa + 360) % 360;
            kappa = Mathf.Clamp(kappa, 0, 360);
            Debug.Log(kappa);
               
               
               // if(gameObject.name == "Archer")
           crown.transform.localRotation= Quaternion.AngleAxis(kappa, Vector3.forward);//Quaternion.Slerp(crown.transform.rotation, Quaternion.AngleAxis(kappa, Vector3.forward), aimLerp);
            
    
    }
 float DotProduct(Vector2 a, Vector2 b){
        return Vector2.Dot(a, b);
    }
    float FindTheta(float numerator, float denominator){
        return Mathf.Atan2(numerator,denominator);
    }
      float Determinant(Vector2 a , Vector2 b){
        return a.x*b.y - a.y*b.x;
    }
    void Attack(Vector2 direction){
            
        if (name != "Sword" && name != "Sword(Clone)"){
            
             
           GameObject bullet = Instantiate(bulletPrefab, barrel.transform.position, gameObject.name == "Cannon"?Quaternion.identity :Quaternion.Euler(0,0,kappa));
            
           bullet.GetComponent<ProjectileMovement>().direction = (Vector2)beta*range;
            bullet.GetComponent<ProjectileDamage>().damage = damage;
        } else {
            transform.localScale = beta.x>0?new Vector3(-1.5f,1.5f,1.5f):new Vector3(1.5f,1.5f,1.5f);//FLIPS SWORDTOWER
            animator.SetTrigger("Attack");
        }
          
           startTime = attack_speed;
    }

}

/*


*/
