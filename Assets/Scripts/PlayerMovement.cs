using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(change);
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if(change != Vector3.zero){
            MoveCharacter();
            myAnimator.SetFloat("MoveX", change.x);
            myAnimator.SetFloat("MoveY", change.y);
            myAnimator.SetBool("Moving", true);
        }else myAnimator.SetBool("Moving", false);
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * MovementSpeed * Time.deltaTime
        );
    }
}
