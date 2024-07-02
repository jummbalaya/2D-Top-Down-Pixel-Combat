using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirTime = 2.0f;
    [SerializeField] private float attackRange = 0f;
    [SerializeField] private MonoBehaviour enemyType;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private bool stopmovementWhileAttacking;

    private enum State
    {
        Roaming,
        Attacking
    }

    private Vector2 roamPosition;
    private float timeRoaming = 0f;

    private float aggroRange;

    private bool canAttack = true;

    private State state;
    private EnemyPathfinding enemyPathfinding;


    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
    }

    private void Start()
    {
        //StartCoroutine(RoamingRoutine());
        roamPosition = GetRoamingPosition();
    }

    private void Update()
    {
        MovementStateControl();
        aggroRange = Vector2.Distance(transform.position, PlayerController.Instance.transform.position);
    }

    private void MovementStateControl()
    {
        switch (state)
        {
            default:
            case State.Roaming:
                Roaming();
                break;
            case State.Attacking:
                Attacking();
                break;
        }
    }

    private void Roaming()
    {
        timeRoaming += Time.deltaTime;
        enemyPathfinding.MoveTo(roamPosition);

        if (aggroRange < attackRange)
        {
            state = State.Attacking;
        }

        if (timeRoaming > roamChangeDirTime)
        {
            roamPosition = GetRoamingPosition();
        }
    }

    private void Attacking()
    {
        if (aggroRange > attackRange)
        {
            state = State.Roaming;
        }

        if (attackRange != 0 && canAttack)
        {
            canAttack = false;
            (enemyType as IEnemy).Attack();

            if (stopmovementWhileAttacking)
            {
                enemyPathfinding.StopMoving();
            }
            else
            {
                enemyPathfinding.MoveTo(roamPosition);
            }

            StartCoroutine(AttackCooldownRoutine());
        }

    }

    private IEnumerator AttackCooldownRoutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private Vector2 GetRoamingPosition()
    {
        timeRoaming = 0;
        return new Vector2(UnityEngine.Random.Range(1f, -1f), UnityEngine.Random.Range(1f, -1f)).normalized;
    }
}
