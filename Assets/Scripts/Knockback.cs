using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    public float thrust;
    public float knockTime;
    public Inventory playerInventory;
    public float damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        damage = playerInventory.damage;
        Debug.Log(damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player")){
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null){

                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                
                if(other.gameObject.CompareTag("enemy")){
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                if(other.gameObject.CompareTag("Player") && hit.GetComponent<PlayerMovement>().currentState != PlayerState.stagger){
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    other.GetComponent<PlayerMovement>().Knock(knockTime);
                    other.GetComponent<PlayerHealth>().hit(damage);
                }
                
            }
        }
    }


}
