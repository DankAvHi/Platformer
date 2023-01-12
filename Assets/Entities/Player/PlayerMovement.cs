using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float jumpForce = 10.0f;
    private Rigidbody2D playerRigidbody;
    private bool isGrounded;

    void Start()
    {
        this.playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && IsGrounded()){
            playerRigidbody.velocity = new Vector2(0, jumpForce * speed);
        }

        float horizontalMovement = Input.GetAxis("Horizontal") * speed;

        playerRigidbody.velocity = new Vector2(horizontalMovement * speed, playerRigidbody.velocity.y) * Time.fixedDeltaTime;
    }

    private bool IsGrounded()
    {
        var groundCheck = Physics2D.Raycast(transform.position, -Vector2.up, gameObject.GetComponent<CapsuleCollider2D>().bounds.extents.y +0.1f);
       
        return groundCheck.collider != null && groundCheck.collider.CompareTag("Ground");
    }
}
