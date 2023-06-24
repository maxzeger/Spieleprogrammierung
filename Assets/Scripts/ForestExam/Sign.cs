using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public List<string> dialogues;

    private bool playerInRange;
    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerInRange)
        {
            if (dialogManager.dialogBox.activeInHierarchy)
            {
                dialogManager.ShowNextDialog();
            }
            else
            {
                dialogManager.StartDialog(dialogues);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogManager.EndDialog();
        }
    }
}
