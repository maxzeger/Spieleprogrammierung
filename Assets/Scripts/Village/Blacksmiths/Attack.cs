using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool playerInRange;
    public Inventory playerInventory;


    public List<string> dialogues;
    public List<string> dialogues2;
    private DialogManager dialogManager;

    private CoinTextManager coinObject;


    // Start is called before the first frame update
    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        coinObject = FindObjectOfType<CoinTextManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerInRange)
        {


            if (playerInventory.coins < 3 * playerInventory.damage)
            {

                if (dialogManager.dialogBox.activeInHierarchy)
                {
                    dialogManager.EndDialog();
                }
                else
                {
                    dialogManager.StartDialog(dialogues2);
                }

            }
            else
            {
                if (dialogManager.dialogBox.activeInHierarchy)
                {
                    dialogManager.EndDialog();
                }
                else
                {
                    dialogManager.StartDialog(dialogues);
                    playerInventory.coins -= 3 * (int)playerInventory.damage;
                    playerInventory.damage += 1;
                    coinObject.UpdateCoinCount();
                }


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
