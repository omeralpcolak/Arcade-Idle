using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBox : MonoBehaviour
{

    Container fruitBoxContainer;
    Animator fruitBoxAnim;
    public JuiceBox juiceBox;

    public GameObject juiceBoxObj;
    public GameObject appleJuice;
    public GameObject lemonJuice;

    private int appleNumber;
    private int lemonNumber;

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
        lemonNumber = fruitBoxContainer.lemonCount;

        CheckingForProduceJuice();
    }

    private void CheckingForProduceJuice()
    {
        if (appleNumber >= 5 && !canProduceJuice)
        {
            canProduceJuice = true;
            StartCoroutine(ProduceJuice(appleJuice, appleNumber,5,"apple"));
        }

        if(lemonNumber >=2 &&!canProduceJuice)
        {
            canProduceJuice = true;
            StartCoroutine(ProduceJuice(lemonJuice, lemonNumber, 2,"lemon"));
        }
    }

    IEnumerator ProduceJuice(GameObject juice, int numberOfFruits, int fruitsPerJuice, string fruitName)
    {
        int juicesToProduce = numberOfFruits / fruitsPerJuice; 

        for (int i = 0; i < juicesToProduce; i++)
        {
            GameObject juiceBottle = Instantiate(juice, juiceSpawnPos.position, Quaternion.identity);
            juiceBottle.transform.SetParent(juiceBox.transform);
            juiceBox.AddJuice(juiceBottle);
            fruitBoxContainer.ReduceFruitCount(fruitName, fruitsPerJuice); 

            yield return new WaitForSeconds(1f);
        }

        canProduceJuice = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && fruitBoxContainer.fruits.Count != 0)
        {
            fruitBoxAnim.SetBool("open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        fruitBoxAnim.SetBool("open",false);
    }

    

}
