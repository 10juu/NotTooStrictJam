using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField]public GameObject Player;
    public float lerp_speed;
    Damage damage;
    public float range;
    void Awake(){
        damage = GetComponent<Damage>();
        Player = GameObject.Find("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (damage.startTime <0 )
            damage.spriteRenderer.color = Color.white;
        else
            damage.startTime -= Time.deltaTime;
        if(name != "Archer" || (target  !=null && GeneralManager.Instance.Magnitude(target.transform.position-transform.position) >range))
            transform.position = Vector2.Lerp(transform.position,  target.transform.position , lerp_speed*Time.deltaTime);
    
        if(target == null){
            target = Player;
        }
    }
}
