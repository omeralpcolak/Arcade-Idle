using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TreeManager : MonoBehaviour
{
    public Tree tree;
    public bool treeCreated;


    private void Update()
    {
        FruitProduction();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("is working");

            if(!treeCreated)
            {
                StartCoroutine(InstantiateTree());
            }
        }
    }

   IEnumerator InstantiateTree()
    {
        Instantiate(tree.treePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        tree.treePrefab.transform.DOScale(0.7f, 1f).OnComplete(delegate
        {
            treeCreated = true;
        });
    }
   
    private void FruitProduction()
    {
        if (treeCreated)
        {
            if (tree.timeUntilNextFruit <= 0)
            {
                for (int i = 0; i < tree.treeFruitNumber; i++)
                {
                    Vector3 fruitPosition = new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(1f,2.5f), transform.position.z + Random.Range(-1f, 1f));
                    GameObject fruit = Instantiate(tree.treeFruitPrefab, fruitPosition, Quaternion.identity);
                }
                tree.timeUntilNextFruit = tree.fruitProductionTime;
            }
            else
            {
                tree.timeUntilNextFruit -= Time.deltaTime;
            }
        }
    }

}
