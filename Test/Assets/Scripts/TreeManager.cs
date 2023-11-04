using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TreeManager : MonoBehaviour
{
    public Tree tree;
    public bool treeCreated;
    public List<GameObject> producedFruits = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(InstantiateTree());
    }


    IEnumerator InstantiateTree()
    {
        Instantiate(tree.treePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        tree.treePrefab.transform.DOScale(0.7f, 1f).OnComplete(delegate
        {
            treeCreated = true;
            StartCoroutine(FruitProduction());
        });
    }

   
    IEnumerator FruitProduction()
    {
        while (producedFruits.Count < tree.treeMaxFruitNumberToProduce)
        {
            yield return new WaitForSeconds(tree.fruitProductionTime);
            SpawnFruit();
            
        }
    }

    private void SpawnFruit()
    {
        Vector3 fruitPosition = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 1.5f), Random.Range(-1f, 1f));
        GameObject fruit = Instantiate(tree.treeFruitPrefab, fruitPosition, Quaternion.identity);
        producedFruits.Add(fruit);
    }

}
