using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    public GameObject dialogBox;
    public Text dialogText;

    private List<string> dialogues;
    private int currentDialogueIndex;

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

    public void StartDialog(List<string> dialogues)
    {
        this.dialogues = dialogues;
        currentDialogueIndex = 0;
        ShowNextDialog();
    }

    public void ShowNextDialog()
    {
        if (currentDialogueIndex < dialogues.Count)
        {
            dialogBox.SetActive(true);
            dialogText.text = dialogues[currentDialogueIndex];
            currentDialogueIndex++;
        }
        else
        {
            EndDialog();
        }
    }

    public void EndDialog()
    {
        dialogBox.SetActive(false);
    }
}
