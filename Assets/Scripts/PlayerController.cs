using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public float health;

    //private variables
    Vector2 moveAmount;
    private Rigidbody2D rb;
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = inputMove.normalized * moveSpeed;
        if (inputMove != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount*Time.fixedDeltaTime);
        //Debug.Log(rb.position);
    }
    public void TakeDamage(int damage) {

        damage -= 1;
    
    }
}
