using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateTreeProduceUI(Tree tree)
    {
        tree.fruitNumberTxt.text = tree.currentFruitCount.ToString() + " / " + tree.treeMaxFruitNumberToProduce.ToString();

        tree.targetFill = tree.currentFruitCount / tree.treeMaxFruitNumberToProduce;

        tree.fruitNumberImg.fillAmount = Mathf.MoveTowards(tree.fruitNumberImg.fillAmount, tree.targetFill, tree.fruitNumberImgFillSpeed * Time.deltaTime);

    }
}