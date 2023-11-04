using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TreeManager : MonoBehaviour
{
    public Tree tree;

    public bool treeCreated;
    public bool canCollect;

    public List<GameObject> producedFruits = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(InstantiateTree());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&& canCollect==true)
        {
            Collect();
            canCollect = false;
            StartCoroutine(FruitProduction());
        }
    }

    private void Update()
    {
        if(producedFruits.Count == tree.treeMaxFruitNumberToProduce)
        {
            canCollect = true;
        }
    }

    private void Collect()
    {
        foreach(GameObject fruit in producedFruits)
        {
            fruit.transform.DOScale(0f, 1f).OnComplete(delegate
            {
                Destroy(fruit.gameObject);
            });
            producedFruits.Remove(fruit);
        }
        
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
