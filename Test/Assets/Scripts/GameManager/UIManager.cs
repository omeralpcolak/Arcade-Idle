using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    

    private void Awake()
    {
        instance = this;
    }

    public void UpdateTreeProduceUI(Tree tree)
    {
        tree.fruitNumberTxt.text = tree.currentFruitCount.ToString() + " / " + tree.treeMaxFruitNumberToProduce.ToString();

        tree.targetFill = tree.currentFruitCount / tree.treeMaxFruitNumberToProduce;

        tree.fruitNumberImg.fillAmount = Mathf.MoveTowards(tree.fruitNumberImg.fillAmount, tree.targetFill, tree.fruitNumberImgFillSpeed * Time.deltaTime);

    }


    public void DisplayFruitCounts(int fruitNumber, TMP_Text fruitNumberText)
    {
        fruitNumberText.text = fruitNumber.ToString();
    }

    public void UpdateWallet(int walletBalance, TMP_Text walletTxt)
    {
        walletTxt.text = walletBalance.ToString();
    }

    public void RandomCashierDialog(TMP_Text dialogueText,List<string> dialogue, Image textBubble)
    {
        int randomIndex = Random.Range(0, dialogue.Count);
        dialogueText.text = dialogue[randomIndex];
        textBubble.GetComponent<CanvasGroup>().DOFade(1, 1f).OnComplete(delegate
        {
            textBubble.GetComponent<CanvasGroup>().DOFade(0, 1f);
        });
        
    }
    
}
