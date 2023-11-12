using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;


public class Container: MonoBehaviour
{

    public List<GameObject> fruits;

   
    public void AddFruit(GameObject fruit)
    {
        fruits.Add(fruit);
    }

    public void ResetFruitList()
    {
        foreach(GameObject fruit in fruits)
        {
            fruit.transform.DOScale(0, 1f).OnComplete(delegate
            {
                Destroy(fruit);
            });
        }
        fruits.Clear();
    }

    public int CountingFruits(string searchingFruitName)
    {
        int counter = 0;

        foreach (GameObject fruit in fruits)
        {
            string fruitName = fruit.name.ToLower();

            if (fruitName.Contains(searchingFruitName.ToLower()))
            {
                counter++;
            }
        }

        return counter;
    }
    
}
