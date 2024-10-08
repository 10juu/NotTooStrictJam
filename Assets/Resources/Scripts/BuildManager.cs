using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private GameObject towerToBuild;

    public GameObject prototypeTower;

    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    void Start() {
        towerToBuild = prototypeTower;
    }

    public GameObject GetTowerToBuild() {
        return towerToBuild;
    }

    public void CreateTower() {
        Debug.Log("Button Clicked");
    }

}
