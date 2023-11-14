using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


[System.Serializable]
public class Tree
{
    public string treeName;
    public string fruitType; //apple,banana etc.

    public GameObject treePrefab;
    public GameObject treeFruitPrefab;

    public float treeMaxFruitNumberToProduce;
    public float fruitProductionTime;

    public int currentFruitCount;

    public TMP_Text fruitNumberTxt;
    public Image fruitNumberImg;
    
    [HideInInspector]public float fruitNumberImgFillSpeed = 0.5f;
    [HideInInspector] public float targetFill = 1;
    [HideInInspector] public float timeUntilNextFruit;
    
}
