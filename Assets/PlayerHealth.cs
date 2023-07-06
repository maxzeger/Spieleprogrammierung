using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public GameObject[] hearts;
    // Start is called before the first frame update
    void Start(){
        for(int i = (int) Health; i < 10; i++){
            hearts[i].SetActive(false);
        }
    }

    public void hit(float damage){
        Health = Health - damage;
        hearts[(int) Health].SetActive(false);
        if(Health <= 0){
            Destroy(gameObject);
        }
    }
}
