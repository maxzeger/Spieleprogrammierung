using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    public GameObject dialogBox;
    public Text dialogText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartDialog(string dialog)
    {
        dialogBox.SetActive(true);
        dialogText.text = dialog;
    }

    public void EndDialog()
    {
        dialogBox.SetActive(false);
    }
}
