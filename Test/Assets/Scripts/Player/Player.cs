using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    Container playerContainer;
    
    private int appleCount;
    private int lemonCount;

    private void Awake()
    {
        playerContainer = GetComponent<Container>();
    }

    private void Update()
    {
        playerContainer.UpdatingUiAndFruitsCount();        
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

        EffectController.instance.CollectTextEffect();

    }

    private void GiveFruit(Collider other)
    {
        Container boxContainer = other.GetComponent<Container>();
        FruitBox fruitBox = other.GetComponent<FruitBox>();

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
