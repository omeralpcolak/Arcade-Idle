using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CashierDialogs : MonoBehaviour
{
    public TMP_Text dialogueTxt;
    public List<string> dialogs = new List<string>();


    public void RandomDialogue()
    {
        UIManager.instance.RandomCashierDialog(dialogueTxt, dialogs);
    }
}
