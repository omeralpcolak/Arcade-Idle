using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new product",menuName ="omer/product config")]
public class ProductConfig : ScriptableObject
{
    public GameObject prefab;
    public string title;

    public ProductItem Generate(Transform parent)
    {
        ProductItem item = Instantiate(prefab, parent).AddComponent<ProductItem>();
        item.config = this;
        return item;
    }
}
