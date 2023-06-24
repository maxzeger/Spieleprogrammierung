using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public List<string> dialogues;

    private bool playerInRange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerInRange)
        {
            if (DialogManager.instance.dialogBox.activeInHierarchy)
            {
                DialogManager.instance.ShowNextDialog();
            }
            else
            {
                DialogManager.instance.StartDialog(dialogues);
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
            DialogManager.instance.EndDialog();
        }
    }
}
