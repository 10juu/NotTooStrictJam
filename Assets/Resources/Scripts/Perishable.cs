using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perishable : MonoBehaviour
{
 public void DestroyMe(){
    Destroy(gameObject);
 }
}
