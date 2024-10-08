using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour
{
  void Awake(){
    if(!CreateGrid.Instance.mapAsNodes.ContainsKey((Vector2)transform.position))
          CreateGrid.Instance.mapAsNodes.Add((Vector2)transform.position, "nothing");//init all nodes to nothing until collision
      //  else
         // CreateGrid.Instance.mapAsNodes[(Vector2)transform.position] = "nothing";//init all nodes to nothing until collision
  }
    void OnTriggerEnter2D(Collider2D other)
   {
     Debug.Log(other);
    if(other.gameObject.layer ==LayerMask.NameToLayer("Map"))
    {
       // Debug.Log(CreateGrid.Instance);
       if(!CreateGrid.Instance.mapAsNodes.ContainsKey((Vector2)transform.position))
          CreateGrid.Instance.mapAsNodes.Add((Vector2)transform.position, other.gameObject.name );//just in case something messes up on Awake
        else
          CreateGrid.Instance.mapAsNodes[(Vector2)transform.position]= other.gameObject.name;
    }
   }
   
   }
