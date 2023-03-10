using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Diagnostics;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speedNavigation = 5f;
    [SerializeField] private float turnSpeed = 2.5f;

    public Transform player;
    public NavMeshAgent enemy;

    public float chase = 10f;
    public float lookRadius = 10f;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attack
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange = 2f, attackRange = 5f;
    public bool playerInSightRange, playerInAttackRange;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance > chase)
        {
            Patroling();
        }
        if (distance < chase)
        {

            Chasing();
        }
        if (distance < attackRange)
        {
            Attack();
        }
    }

    private void Chasing()
    {
        enemy.SetDestination(player.position);
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            enemy.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void Attack()
    {
        //Enemy attack and doesn't move
        enemy.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Rigidbody rb = Instantiate(missile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
