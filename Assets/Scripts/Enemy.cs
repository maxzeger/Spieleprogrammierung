using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum EnemyState{
        idle,
        walk,
        attack,
        stagger,
        dead
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth; 
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    private bool invincible;

    public GameObject dropCoin; // Das Objekt, das mehrmals abgelegt werden soll
    public int dropCount; // Anzahl der abzulegenden Objekte
    public float spawnRadius;

    private void TakeDamage(Rigidbody2D myRigidbody, float damage){
        if(!invincible){
            health -= damage;
            if(health <= 0){
                myRigidbody.velocity = Vector2.zero;
                myRigidbody.isKinematic = true;
                currentState = EnemyState.dead;
                StartCoroutine(DeathCo(myRigidbody));
            }
            invincible = true;
        }

    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage){
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(myRigidbody, damage);
    }

    private IEnumerator DeathCo(Rigidbody2D myRigidbody){
        GetComponent<Animator>().SetBool("dead", true);
        DropItems();
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime){
        if(myRigidbody != null){
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            if(currentState != EnemyState.dead){
                currentState = EnemyState.idle;
            }
            invincible = false;
        }
    }

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DropItems()
    {
        for (int i = 0; i < dropCount; i++)
        {
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            Instantiate(dropCoin, spawnPosition, Quaternion.identity);
        }

    }
}
