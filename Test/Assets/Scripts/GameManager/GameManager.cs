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

    private void Start()
    {
        wallet = PlayerPrefs.GetInt("Wallet",0);
        UIManager.instance.UpdateWallet(wallet, walletTxt);
    }

    private void SaveWallet()
    {
        PlayerPrefs.SetInt("Wallet", wallet);
        PlayerPrefs.Save();
    }

    public void SellJuice(GameObject juice)
    {
        string juiceName = juice.name;

        switch (juiceName)
        {
            case "AppleJuice(Clone)":
                wallet += appleJuicePrice;
                UIManager.instance.UpdateWallet(wallet, walletTxt);
                SaveWallet();
                break;
            case "LemonJuice(Clone)":
                wallet += lemonJuicePrice;
                UIManager.instance.UpdateWallet(wallet, walletTxt);
                SaveWallet();
                break;
            case "BananaJuice":
                wallet += bananaJuicePrice;
                UIManager.instance.UpdateWallet(wallet, walletTxt);
                SaveWallet();
                break;
        }
    }

}
