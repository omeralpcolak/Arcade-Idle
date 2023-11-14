using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{

    public static EffectController instance;

    public Transform playerEffectPos;

    public GameObject collectTextEffect;


    private void Awake()
    {
        instance = this;
    }

    public void CollectTextEffect()
    {
        Instantiate(collectTextEffect, playerEffectPos.position, Quaternion.identity);
    }


}
