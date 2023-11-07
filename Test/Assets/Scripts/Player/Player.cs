using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Container playerContainer;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            Debug.Log("trigger is working");
            TreeManager treeManager = other.GetComponent<TreeManager>();
            List<GameObject> treeFruits = treeManager.treeContainer.fruits;

            foreach (GameObject fruit in treeFruits)
            {
                Debug.Log("working!");
                playerContainer.AddFruit(fruit);
            }

            // Clear the fruits from the tree
            treeManager.treeContainer.ResetFruitList();
        }
    }

}
