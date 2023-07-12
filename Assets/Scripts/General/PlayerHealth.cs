using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private float Health;
    public GameObject[] hearts;
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start(){
        setHearts();
    }

    public void setHearts()
    {
        Health = playerInventory.hearts;
        Debug.Log(Health);

        for (int i = 0; i < 10; i++)
        {
            hearts[i].SetActive(true);
        }

        for (int i = (int)Health; i < 10; i++)
        {
            hearts[i].SetActive(false);
        }
    }

    public void hit(float damage){
        Health = Health - damage;
        if(Health <= 0){
            SceneManager.LoadScene("Menu");
        }
        else{
            for(int i = (int) Health; i<10; i++){
                hearts[i].SetActive(false);
            }
        }
        
    }
}
