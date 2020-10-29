using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMov : MonoBehaviour{
    
    /*public float moveSpeed;
    [HideInInspector] public bool mustPatrol;
    private bool mustTurn;
    public Rigidbody2D myRigidbody;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;


    void Start(){
        mustPatrol = true;
    }

    void Update(){
        if(mustPatrol){
            Patrol();
        }
    }

    private void FixedUpdate(){
        if(mustPatrol){
            mustTurn = !Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
        }
    }

    void Patrol(){
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer)){
            Flip();
        }
        myRigidbody.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, myRigidbody.velocity.y);
    }

    void Flip(){
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        moveSpeed *= -1;
        mustPatrol = true;

    }*/

    public float speed;
    private bool movingRight = false;
    public Transform groundCheck;
    public Collider2D bodyCollider;
    public LayerMask groundLayer;

    void Update(){
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f);
        if(groundInfo.collider == false || bodyCollider.IsTouchingLayers(groundLayer)){
            if(movingRight){
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;
            }else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

}
