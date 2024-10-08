using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerMovement : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] public MapPosition mapPosition;

    [SerializeField]SpriteRenderer legLock;
    Vector2 clickPosition = Vector2.zero;
    float t = 0f;
    public bool isSelected =false;
   public bool isOver = false;
    [SerializeField]float maxSpeed = 0f;
   [SerializeField]SpriteRenderer spriteRenderer;
   public Animator animator;
   Upgrade upgrade;
   Damage damage;
   
    void Awake(){
        damage =GetComponent<Damage>();
        Physics2D.queriesHitTriggers = true;
        upgrade = GetComponent<Upgrade>();
    }
    // Update is called once per frame
    void Update()
    {
        if (damage.startTime <0 && !isSelected)
            spriteRenderer.color = Color.white;
        else if (isSelected && damage.startTime <0)
            spriteRenderer.color = Color.grey;
        else
            damage.startTime -= Time.deltaTime;
        if (isSelected && damage.startTime <0)
            spriteRenderer.color = Color.grey;

        FadeLegLock();
       // Debug.Log(EnemyFactory.realFactory);
        if(Input.GetMouseButton(0) && !isOver)
           { spriteRenderer.color = Color.white;
            isSelected = false;}
        if(mapPosition.isClicked && isSelected && !upgrade.isLegLocked)
            Move();
        isOver = false;
    }

    void FadeLegLock(){
        if(legLock.color.a != 0&& !upgrade.isLegLocked)
        {

            Color temp = legLock.color;
            temp.a -= Time.deltaTime;
            legLock.color = temp;
        }
           
    }
    void Move(){
       // Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
      //  Vector2 rightMovement = right *moveSpeed *Time.deltaTime;//*Input.GetAxis("Horizontal");
        //Vector2 upMovement = forward * moveSpeed * Time.deltaTime;//*Input.GetAxis("Vertical");
        Vector2 mapVector = new Vector2(mapPosition.clickPosition.x, mapPosition.clickPosition.y);
        Vector2 interpolatedPosition = Vector2.Lerp(transform.position, mapVector, t );

       transform.position = interpolatedPosition;

       t+=Time.deltaTime/duration;
       animator.SetTrigger("Walk");

       if (t>= maxSpeed || Vector2Int.FloorToInt(transform.position) == Vector2Int.FloorToInt(mapVector))
       { t=0f;mapPosition.isClicked = false;
        animator.SetTrigger("Idle");
       }
        

    }
    
 void OnMouseDown(){
    
        UpgradeManager.Instance.CoinToUpgrade = upgrade.CoinToUpgrade;
        UpgradeManager.Instance.UpgradeUpdate = upgrade.UpgradeUpdate;
        UpgradeManager.Instance.towerUpgrade = upgrade;
        isSelected = true;
        //highlighter outline
        spriteRenderer.color = Color.grey;
        mapPosition.clickPosition = transform.position;
       
    }
    void OnMouseOver(){
       // if (Input.GetMouseButton(0))


       
            isOver = true;
            
    }
}
