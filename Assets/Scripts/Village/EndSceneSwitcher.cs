using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneSwitcher : MonoBehaviour
{

    public GameObject gameObject;
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        if(inventory.EndExamKeys < 2)
        {
            gameObject.SetActive(false);
        }
    }
}
