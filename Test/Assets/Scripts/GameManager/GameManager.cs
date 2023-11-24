using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int appleJuicePrice = 5;
    private int lemonJuicePrice = 2; 
    private int bananaJuicePrice = 10;

    [SerializeField]private int wallet;

    public TMP_Text walletTxt;


    private void Awake()
    {
        instance = this;
    }
    

    public void SellJuice(GameObject juice)
    {
        string juiceName = juice.name;

        switch (juiceName)
        {
            case "AppleJuice(Clone)":
                wallet += appleJuicePrice;
                UIManager.instance.UpdateWallet(wallet, walletTxt);
                break;
            case "LemonJuice(Clone)":
                wallet += lemonJuicePrice;
                UIManager.instance.UpdateWallet(wallet, walletTxt);
                break;
            case "BananaJuice":
                wallet += bananaJuicePrice;
                UIManager.instance.UpdateWallet(wallet, walletTxt);
                break;
        }
    }

}
