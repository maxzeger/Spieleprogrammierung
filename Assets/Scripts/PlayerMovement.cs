using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float MovementSpeed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger){
            StartCoroutine(AttackCO());
        }else if(currentState == PlayerState.walk || currentState == PlayerState.idle){
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCO(){
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        yield return new WaitForSeconds(.5f);
        animator.SetBool("attacking", false);
        currentState = PlayerState.walk;
    }

    private IEnumerator KnockCo(float knockTime){
        if(myRigidbody != null){
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
        }
    }

    public void Knock(float knockTime){
        StartCoroutine(KnockCo(knockTime));
    }

    void UpdateAnimationAndMove()
    {
        if(change != Vector3.zero){
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }else animator.SetBool("moving", false);
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * MovementSpeed * Time.deltaTime
        );
    }
}
