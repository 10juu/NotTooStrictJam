using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : Singleton<GeneralManager>
{
    public float Magnitude( Vector2 delta){
        return Mathf.Sqrt(Mathf.Pow(delta.x, 2)+Mathf.Pow(delta.y, 2));
    }
}
