using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Container playerContainer;

    public List<GameObject> apples = new List<GameObject>();
    public List<GameObject> lemons = new List<GameObject>();


    private void Awake()
    {
        playerContainer = GetComponent<Container>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            CollectFruit(other);
            SeparateFruits();
        }
    }


    private void CollectFruit(Collider other)
    {
        TreeManager treeManager = other.GetComponent<TreeManager>();

        if (treeManager != null)
        {
            List<GameObject> treeFruits = treeManager.treeContainer.fruits;

            if (treeManager.canProduce == false)
            {
                for (int i = 0; i < treeFruits.Count; i++)
                {
                    playerContainer.AddFruit(treeManager.tree.treeFruitPrefab);
                }
                treeManager.treeContainer.ResetFruitList();
                treeManager.tree.currentFruitCount = 0;
                StartCoroutine(treeManager.FruitProduction());
            }
        }
        
    }

    private void SeparateFruits()
    {
        foreach (GameObject fruit in playerContainer.fruits)
        {
            string fruitName = fruit.name.ToLower();

            if (fruitName.Contains("apple"))
            {
                apples.Add(fruit);
            }
            else if (fruitName.Contains("lemon"))
            {
                lemons.Add(fruit);
            }
        }
    }

}
