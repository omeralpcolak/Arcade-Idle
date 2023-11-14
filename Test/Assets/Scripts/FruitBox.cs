using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBox : MonoBehaviour
{

    Container fruitBoxContainer;
    Animator fruitBoxAnim;

    private void Awake()
    {
        fruitBoxContainer = GetComponent<Container>();
        fruitBoxAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        fruitBoxContainer.UpdatingUiAndFruitsCount();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fruitBoxAnim.SetBool("open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        fruitBoxAnim.SetBool("open",false);
    }


}
