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
    public float treeMaxFruitNumberToProduce;
    public float fruitProductionTime;

    [HideInInspector] public float timeUntilNextFruit;
    //[HideInInspector] public int currentFruitCount;
}
