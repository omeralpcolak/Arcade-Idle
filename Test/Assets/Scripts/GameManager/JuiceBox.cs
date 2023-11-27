using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JuiceBox : MonoBehaviour
{
    public List<GameObject> juices = new List<GameObject>();
    public CashierDialogs cashierDialogs;
    [SerializeField] int juiceCapacity;
    [SerializeField] int moveDuration;

    private BoxCollider boxCollider;

    public Transform firstPos;
    public Transform finPos;

    public bool canGiveJuice;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        canGiveJuice = true;
    }

    private void Update()
    {
        CheckingCanGiveJuice();
    }

    private void CheckingCanGiveJuice()
    {
        if (juices.Count == 0)
        {
            canGiveJuice = false;
        }
        else
        {
            canGiveJuice = true;
        }

        if (canGiveJuice)
        {
            boxCollider.enabled = true;
        }
        else if (!canGiveJuice)
        {
            boxCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && canGiveJuice)
        {
            StartCoroutine(GiveJuiceToTruck(moveDuration));
        }
    }

    public void AddJuice(GameObject juice)
    {
        juices.Add(juice);
    }

    public IEnumerator GiveJuiceToTruck(float moveDuration)
    {
        canGiveJuice = false;

        while (!canGiveJuice)
        {
            yield return transform.DOMoveX(finPos.position.x, moveDuration).WaitForKill();

            Debug.Log("juicebox is working");

            foreach (GameObject juice in juices)
            {
                GameManager.instance.SellJuice(juice);
                Destroy(juice);
            }
            juices.Clear();

            cashierDialogs.RandomDialogue();

            yield return transform.DOMoveX(firstPos.position.x, moveDuration).WaitForKill();

            canGiveJuice = true;
        }
        
    }

}
