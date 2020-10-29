using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMov : MonoBehaviour{
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
