using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    private int remainingCasts;
    public bool shielded;
    public GameObject spell;
    public GameObject SceneSwitcher;
    private bool firstDeath = true;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        remainingCasts = 10;
        shielded = true;
        invincible = true;

        InvokeRepeating("castSpell", 3.0f, 2.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentState == EnemyState.dead && firstDeath){
            SceneSwitcher.SetActive(true);
            firstDeath = false;
        }
        CheckDistance();
    }

    void CheckDistance() {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if(currentState == EnemyState.idle || currentState == EnemyState.walk){
                anim.SetBool("moving", true);
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * (shielded ? 1 : -1) * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }else{
                anim.SetBool("moving", false);
            }
            
        }else if(Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) < attackRadius - 0.5f)
        {
            if(currentState == EnemyState.idle || currentState == EnemyState.walk){
                anim.SetBool("moving", true);
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * -1 * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }else{
                anim.SetBool("moving", false);
            }
            
        }else{
            anim.SetBool("moving", false);
        }
    }

    private void castSpell(){
        if(remainingCasts <= 0){
            StartCoroutine(ShieldCo());
            remainingCasts = 10;
        }
        anim.SetTrigger("attacking");
        StartCoroutine(FreezeCo());
        Vector3 attackPoint = new Vector3(target.transform.position.x + Random.Range(0.0f,2.0f), target.transform.position.y + Random.Range(0.0f,2.0f), target.transform.position.z);
        GameObject cast1 = Instantiate(spell, attackPoint, Quaternion.identity);
        Destroy(cast1, 1.9f);
        remainingCasts--;
    }

    private void SetAnimFloat(Vector2 setVector){
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    private void changeAnim(Vector2 direction){
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
            if(direction.x > 0){
                SetAnimFloat(Vector2.right);
            }else if(direction.x < 0){
                SetAnimFloat(Vector2.left);
            }
        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
            if(direction.y > 0){
                SetAnimFloat(Vector2.up);
            }else if(direction.y < 0){
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState){
        if(currentState != newState){
            currentState = newState;
        }
    }

    public IEnumerator ShieldCo(){
        GetComponent<Animator>().SetTrigger("shieldOff");
        shielded = false;
        invincible = false;
        yield return new WaitForSeconds(5);
        GetComponent<Animator>().SetTrigger("shieldOn");
        shielded = true;
        invincible = true;

    }

    public IEnumerator FreezeCo(){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(0.6f);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
