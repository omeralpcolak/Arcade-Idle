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

    private void Awake()
    {
        treeContainer = GetComponent<Container>();
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
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&& !canProduce)
        {
            tree.currentFruitCount = 0;
            canProduce = true;
            StartCoroutine(FruitProduction());
        }
    }

    IEnumerator FruitProduction()
    {
        while(tree.currentFruitCount < tree.treeMaxFruitNumberToProduce)
        {
            yield return new WaitForSeconds(tree.fruitProductionTime);
            SpawnFruit();
        }
    }

    private void SpawnFruit()
    {
        Vector3 fruitPos = tree.treePrefab.transform.position + new Vector3(Random.Range(-1f, 1f), 1, Random.Range(-1f, 1f));
        GameObject fruit = Instantiate(tree.treeFruitPrefab, fruitPos, Quaternion.identity);
        treeContainer.AddFruit(fruit);
        tree.currentFruitCount++;
    }

}