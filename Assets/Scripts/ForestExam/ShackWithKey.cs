using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShackWithKey : Powerup
{
    private bool playerInRange;

    private bool hasPlayerInteragiat = false;

    public Inventory playerInventory;

    public List<string> dialogues;
    public List<string> dialogues2;
    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerInRange)
        {
          

            if (hasPlayerInteragiat)
            {

                if (dialogManager.dialogBox.activeInHierarchy)
                {
                    dialogManager.EndDialog();
                }
                else
                {
                    dialogManager.StartDialog(dialogues2);
                }

            } else
            {
                if (dialogManager.dialogBox.activeInHierarchy)
                {
                    dialogManager.EndDialog();
                }
                else
                {
                    dialogManager.StartDialog(dialogues);
                    playerInventory.forestExamKeys += 1;
                    powerupSignal.Raise();
                }
            }
            hasPlayerInteragiat = true;
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
