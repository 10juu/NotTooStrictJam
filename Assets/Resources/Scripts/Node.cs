using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Color hoverColor;
    private Color startColor;
    private GameObject turret;
    
    private Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown() {
        if (turret != null) {
            Debug.Log("Can't build there! - Todo: display on screen");
            return;
        }
        Debug.Log("Down");
        // GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        // turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter() {
        Debug.Log("Enter");
        rend.material.color = hoverColor;
    }

    void OnMouseExit() {
        Debug.Log("Exit");
        rend.material.color = startColor;
    }
}
