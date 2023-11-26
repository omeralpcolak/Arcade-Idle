using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CashierDialogs : MonoBehaviour
{
    public TMP_Text dialogueTxt;
    public Image dialogueBubble;
    public List<string> dialogs = new List<string>();


    public void RandomDialogue()
    {
        UIManager.instance.RandomCashierDialog(dialogueTxt, dialogs,dialogueBubble);
        Debug.Log("random dialogue is worked");
    }
}
