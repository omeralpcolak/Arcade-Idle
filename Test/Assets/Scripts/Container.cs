using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using TMPro;

public class Container: MonoBehaviour
{
    private string appleName = "apple";
    private string lemonName = "lemon";

    [SerializeField] private TMP_Text appleCountTxt;
    [SerializeField] private TMP_Text lemonCountTxt;


    private int appleCount;
    private int lemonCount;

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


    public void UpdatingUiAndFruitsCount()
    {
        appleCount = CountingFruits(appleName);
        lemonCount = CountingFruits(lemonName);

        UIManager.instance.DisplayFruitCounts(appleCount, appleCountTxt);
        UIManager.instance.DisplayFruitCounts(lemonCount, lemonCountTxt);
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
