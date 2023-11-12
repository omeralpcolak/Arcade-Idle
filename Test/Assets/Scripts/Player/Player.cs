using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    Container playerContainer;

    private string appleName = "apple";
    private string lemonName = "lemon";

    [SerializeField] private TMP_Text appleCountTxt;
    [SerializeField] private TMP_Text lemonCountTxt;

    
    private int appleCount;
    private int lemonCount;


    private void Awake()
    {
        playerContainer = GetComponent<Container>();
    }

    private void Update()
    {
        appleCount = playerContainer.CountingFruits(appleName);
        lemonCount = playerContainer.CountingFruits(lemonName);

        UIManager.instance.DisplayFruitCounts(appleCount, appleCountTxt);
        UIManager.instance.DisplayFruitCounts(lemonCount, lemonCountTxt);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            CollectFruit(other);
        }

        if (other.gameObject.CompareTag("FruitBox"))
        {
            GiveFruit(other);
        }
    }

    /*private int CountingFruits(string searchingFruitName)
    {
        
        int counter = 0;

        foreach (GameObject fruit in playerContainer.fruits)
        {
            string fruitName = fruit.name.ToLower();

            if (fruitName.Contains(searchingFruitName.ToLower()))
            {
                counter++;
            }
        }

        return counter;
    }*/

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

    private void GiveFruit(Collider other)
    {
        Container boxContainer = other.GetComponent<Container>();

        if (boxContainer != null)
        {
            for(int i = 0; i < playerContainer.fruits.Count; i++)
            {
                boxContainer.fruits.Add(playerContainer.fruits[i]);
            }

            playerContainer.fruits.Clear();
        }
    }
}
