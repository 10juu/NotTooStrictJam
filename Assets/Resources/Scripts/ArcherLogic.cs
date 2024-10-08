using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherLogic : MonoBehaviour
{
    public MoveToPlayer moveToPlayer;
    private float theta, kappa,startTime;
    [SerializeField]private int range;
    public GameObject barrel, bulletPrefab;
    public float attack_speed, shotRange;
    private Vector2 origin,  right;
    Vector2 beta;

    // Start is called before the first frame update
    void Awake()
    {
        moveToPlayer = GetComponent<MoveToPlayer>();
        origin = (Vector2) transform.position;
        right = (Vector2)origin+Vector2.right;
        moveToPlayer.range = shotRange;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 direction = new Vector2(Mathf.Cos((theta)), Mathf.Sin(theta));
        theta += Time.deltaTime*10;
           RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, (Vector2)direction, range,LayerMask.GetMask("Tower"));
         if(startTime > 0)
            startTime -= Time.deltaTime;
        if (hit.collider  != null ){
            
            moveToPlayer.target = moveToPlayer.target ==null|| (moveToPlayer.target != null && GeneralManager.Instance.Magnitude(moveToPlayer.target.transform.position-transform.position) > GeneralManager.Instance.Magnitude(hit.collider.transform.position -transform.position))?hit.collider.gameObject:null;
        } 
         if(moveToPlayer.target != null){
            Aim(moveToPlayer.target.transform.position);
            if(startTime <= 0 && GeneralManager.Instance.Magnitude(moveToPlayer.target.transform.position-transform.position) <=shotRange)
                Attack();
         }
         if (hit.collider == null && moveToPlayer.target == null)
            moveToPlayer.target = moveToPlayer.Player;
    }


     void Aim(Vector2 enemy){
         beta = (Vector2)enemy-(Vector2)transform.position;
         
        
           Vector2 alpha =  Vector2.left;
            float num = DotProduct(beta, right);
        float denom = Determinant(beta, right);
        kappa = -Mathf.Rad2Deg*FindTheta( denom, num);
           
        kappa -= name == "Bow" || name == "Bow(Clone)"? -90:90;
        //NORMALIZE ANGLE TO 0 -360
           kappa = (kappa + 360) % 360;
            kappa = Mathf.Clamp(kappa, 0, 360);
            Debug.Log(kappa);
               
               
               // if(gameObject.name == "Archer")
           //crown.transform.localRotation= Quaternion.AngleAxis(kappa, Vector3.forward);//Quaternion.Slerp(crown.transform.rotation, Quaternion.AngleAxis(kappa, Vector3.forward), aimLerp);
            
    
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
    void Attack(){
            
       
            
             
           GameObject bullet = Instantiate(bulletPrefab, barrel.transform.position, Quaternion.Euler(0,0,kappa));
            
           bullet.GetComponent<ProjectileMovement>().direction = (Vector2)beta*range;
           
        
          
           startTime = attack_speed;
    }
}
