using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
     [SerializeField] public Vector2 direction;
    public float lerp_speed;
    

    // Update is called once per frame
    void Update()
    {
        if (direction != Vector2.zero)
           { 
            transform.position = Vector2.Lerp(transform.position, direction, lerp_speed*Time.deltaTime);}
    }
}
