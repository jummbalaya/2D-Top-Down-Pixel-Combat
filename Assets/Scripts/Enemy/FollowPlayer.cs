using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowPlayer : MonoBehaviour
{
    public bool HasAggro { get; private set; }

    [SerializeField] private float pullDistance = 5.0f;
    [SerializeField] private float moveSpeed = 2;
    [SerializeField] private float accelerationRate = 1;

    private Vector3 moveDirection;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 playerPosition = PlayerController.Instance.transform.position;

        if (Vector3.Distance(transform.position, playerPosition) < pullDistance) { HasAggro = true; }

        if (Vector3.Distance(transform.position, playerPosition) < pullDistance)
        {
            moveDirection = (playerPosition - transform.position).normalized;
            moveSpeed += accelerationRate;
        }
        else
        {
            moveDirection = Vector3.zero;
            moveSpeed = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed * Time.deltaTime;
    }
}
