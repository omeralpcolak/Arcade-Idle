using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


[Serializable]
public class Tree
{
    public string treeName;
    public GameObject treePrefab;
    public GameObject treeFruitPrefab;
    public float treeMaxFruitNumberToProduce;
    public float fruitProductionTime;
    [HideInInspector]public float targetFill = 1;

    public TMP_Text fruitNumberTxt;
    public Image fruitNumberImg;
    

    [HideInInspector]public float fruitNumberImgFillSpeed = 0.5f;

    [HideInInspector] public float timeUntilNextFruit;
    public int currentFruitCount;
}
