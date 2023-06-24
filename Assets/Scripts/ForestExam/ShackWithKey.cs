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


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerInRange)
        {
          

            if (hasPlayerInteragiat)
            {

                if (DialogManager.instance.dialogBox.activeInHierarchy)
                {
                    DialogManager.instance.EndDialog();
                }
                else
                {
                    DialogManager.instance.StartDialog(dialogues2);
                }

            } else
            {
                if (DialogManager.instance.dialogBox.activeInHierarchy)
                {
                    DialogManager.instance.EndDialog();
                }
                else
                {
                    DialogManager.instance.StartDialog(dialogues);
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
            DialogManager.instance.EndDialog();
        }
    }

}
