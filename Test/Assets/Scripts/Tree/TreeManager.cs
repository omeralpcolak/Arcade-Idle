using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TreeManager : MonoBehaviour
{
    public Tree tree;
    public Container treeContainer;

    public bool canProduce = true;

    private BoxCollider boxCollider;

    private void Awake()
    {
        treeContainer = GetComponent<Container>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        StartCoroutine(FruitProduction());
    }


    private void Update()
    {
        UIManager.instance.UpdateTreeProduceUI(tree);

        if (tree.currentFruitCount == tree.treeMaxFruitNumberToProduce)
        {
            canProduce = false;
            boxCollider.enabled = true;
        }
        else
        {
            canProduce = true;
            boxCollider.enabled = false;
        }
    }

    public IEnumerator FruitProduction()
    {
        while(tree.currentFruitCount < tree.treeMaxFruitNumberToProduce)
        {
            yield return new WaitForSeconds(tree.fruitProductionTime);
            SpawnFruit();
        }
    }

    private void SpawnFruit()
    {
        Vector3 fruitPos = tree.treePrefab.transform.position + new Vector3(Random.Range(-1f, 1f), 1.5f, Random.Range(-1f, 1f));
        GameObject fruit = Instantiate(tree.treeFruitPrefab, fruitPos, Quaternion.identity);
        treeContainer.AddFruit(fruit);
        tree.currentFruitCount++;
    }

}