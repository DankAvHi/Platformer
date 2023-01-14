using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody2D;
    [SerializeField] private Collider2D playerColider2D;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask layerMask;
    private Vector2 boxSize;
    private float maxJumpAvailableDistance = 0.1f;


    void Start()
    {
        if (playerRigidbody2D == null && playerColider2D == null)
        {
            playerRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            playerColider2D = gameObject.GetComponent<Collider2D>();
            if (playerRigidbody2D == null && playerColider2D == null)
            {
                throw new System.Exception("Some components is not added to gameObject and PlayerMovement script");
            }
        }
        boxSize = playerColider2D.bounds.size;

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) jump();

        movement();

    }

    private void movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        playerRigidbody2D.velocity = new Vector2(horizontalInput * speed, playerRigidbody2D.velocity.y);

    }

    private void jump()
    {
        playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, jumpForce);
    }


    private bool isGrounded() => Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxJumpAvailableDistance, layerMask);

}
