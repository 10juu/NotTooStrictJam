using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnColliderAtRuntime : MonoBehaviour
{
    
    Collider2D collider;

    // Update is called once per frame
    void Update()
    {
        if (collider == null)
           collider=  GetComponent<Collider2D>();
      if (!collider.enabled)
        collider.enabled = true;
    }
}
