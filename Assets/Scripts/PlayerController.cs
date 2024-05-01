using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.5f;

    private PlayerControls playerControls;
    private Vector2 movemment;
    private Rigidbody2D rb;
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    //player moves function, uses rigidbody
    private void Move()
    {
        rb.MovePosition(rb.position + movemment * (moveSpeed * Time.fixedDeltaTime));
    }

    //handles player input controls, gets a vector2 from the player input
    private void PlayerInput()
    {
        movemment = playerControls.Movement.Move.ReadValue<Vector2>();

        playerAnimator.SetFloat("moveX", movemment.x);
        playerAnimator.SetFloat("moveY", movemment.y);
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePosition.x < playerScreenPoint.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
