using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPosition : MonoBehaviour
{
    public bool isClicked = false;
    public Vector2 clickPosition;
    public Collider2D collider;
    public GameObject clickPrefab;
    //  NEEDS TO BE IN A GET POSITION FUNCTION
   
    void OnMouseOver(){
        Debug.Log("over");
        if(Input.GetMouseButton(1))
            { clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             
             isClicked = true;
            }
        
    }
    bool oneClick = false;
    void Update(){

        //HACK TO CIRCUMVENT UNITY'S COLLIDER MIX UP ON MOUSE EVENT
        if(Input.GetMouseButton(0))
           collider.enabled = false;
           
        if(Input.GetMouseButton(1))
           { collider.enabled = true;
           
           }
        if(Input.GetMouseButton(1) || Input.GetMouseButton(0)){
           if (!oneClick){
                Vector2 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(clickPrefab,mousePosition, Quaternion.identity);
                oneClick = true;
                }
           } else if (!(Input.GetMouseButton(1) || Input.GetMouseButton(0))){
            oneClick = false;
           }
    }
    
}
