using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBox : MonoBehaviour
{
    [System.Serializable]
    public class ProductMatching
    {
        public ProductConfig sourceProduct;
        public ProductConfig targetProduct;
    }

    public List<ProductMatching> productMatches = new List<ProductMatching>();
    public void Generate(ProductItem item)
    {
        StartCoroutine(Animate());
        IEnumerator Animate()
        {
            yield return new WaitForSeconds(1f);
            ProductMatching found = productMatches.Find(x => x.sourceProduct == item.config);
            ProductItem newItem = found.targetProduct.Generate(transform);
            Destroy(item.gameObject);
        }
    }

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
