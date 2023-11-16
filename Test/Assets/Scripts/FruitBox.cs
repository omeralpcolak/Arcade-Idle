using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBox : MonoBehaviour
{

    Container fruitBoxContainer;
    Animator fruitBoxAnim;

    public GameObject appleJuice;
    //public GameObject lemonJuice;

    private int appleNumber;
    //private int lemonNumber;

    private bool canProduceJuice;

    public Transform juiceSpawnPos;

    private void Awake()
    {
        fruitBoxContainer = GetComponent<Container>();
        fruitBoxAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        fruitBoxContainer.UpdatingUiAndFruitsCount();

        appleNumber = fruitBoxContainer.appleCount;
        //lemonNumber = fruitBoxContainer.lemonCount;

        CheckingForProduceJuice();
    }

    private void CheckingForProduceJuice()
    {
        canProduceJuice = appleNumber >= 3;

        if (canProduceJuice)
        {
            StartCoroutine(ProduceFruit(appleJuice));
        }
    }

    IEnumerator ProduceFruit(GameObject juice)
    {
        while (canProduceJuice)
        {
            Instantiate(juice, juiceSpawnPos.position, Quaternion.identity);

            fruitBoxContainer.ReduceFruitCount("apple", 3);

            canProduceJuice = false;

            yield return new WaitForSeconds(1f);

            canProduceJuice = true;



        }
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
