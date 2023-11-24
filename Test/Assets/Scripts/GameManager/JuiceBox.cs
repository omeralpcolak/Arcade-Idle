using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JuiceBox : MonoBehaviour
{
    public List<GameObject> juices = new List<GameObject>();

    [SerializeField] int juiceCapacity;

    public Transform firstPos;
    public Transform finPos;

    public bool canGiveJuice;

    private void Start()
    {

    }

    private void Update()
    {
        if (canGiveJuice)
        {
            StartCoroutine(GiveJuiceToTruck());
            canGiveJuice = false;
        }
    }

    public void AddJuice(GameObject juice)
    {
        juices.Add(juice);
    }

    IEnumerator GiveJuiceToTruck()
    {

        transform.DOMoveX(finPos.position.x, 5f);

        yield return new WaitForSeconds(6f);

        foreach(GameObject juice in juices)
        {
            GameManager.instance.SellJuice(juice);
            Destroy(juice);
        }
        juices.Clear();

        transform.DOMoveX(firstPos.position.x, 5f);
    }

}
