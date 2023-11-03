using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Tree
{
    public string treeName;
    public GameObject treePrefab;
    public GameObject treeFruitPrefab;
    public float treeFruitNumber;
    public float fruitProductionTime;
    public int treePrice;

    [HideInInspector] public float timeUntilNextFruit;
    //[HideInInspector] public int currentFruitCount;
}
