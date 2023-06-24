using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portcullis : MonoBehaviour
{
    private bool playerInRange;
    public Inventory playerInventory;
    public GameObject objectToDisable;
    public GameObject objectToDisable2;
    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerInRange)
        {
            if (playerInventory.forestExamKeys >= 2)
            {
                this.gameObject.SetActive(false);
                objectToDisable.SetActive(false);
                objectToDisable2.SetActive(false);
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
