using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum EnemyState{
        idle,
        walk,
        attack,
        stagger
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

    private void TakeDamage(float damage){
        if(!invincible){
            health -= damage;
            if(health <= 0){
                this.gameObject.SetActive(false);
            }
            invincible = true;
        }

    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage){
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime){
        if(myRigidbody != null){
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
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
}
