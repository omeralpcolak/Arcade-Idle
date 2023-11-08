using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Container playerContainer;


    private void Awake()
    {
        playerContainer = GetComponent<Container>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            TreeManager treeManager = other.GetComponent<TreeManager>();
            List<GameObject> treeFruits = treeManager.treeContainer.fruits;
            

            if (treeManager.canProduce == false)
            {

                for(int i=0; i<treeFruits.Count; i++)
                {
                    playerContainer.AddFruit(treeManager.tree.treeFruitPrefab);
                }
                
                
                treeManager.treeContainer.ResetFruitList();
                treeManager.tree.currentFruitCount = 0;
                StartCoroutine(treeManager.FruitProduction());

            }
        }
    }

}
