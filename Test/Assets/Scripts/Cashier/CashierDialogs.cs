using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CashierDialogs : MonoBehaviour
{
    Animator cashierAnim;

    public TMP_Text dialogueTxt;
    public Image dialogueBubble;
    public List<string> dialogs = new List<string>();


    private void Awake()
    {
        cashierAnim = GetComponent<Animator>();
    }

    public void RandomDialogue()
    {
        UIManager.instance.RandomCashierDialog(dialogueTxt, dialogs,dialogueBubble);
        Debug.Log("random dialogue is worked");
        cashierAnim.SetTrigger("dancing");
    }
}
