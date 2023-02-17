using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private float speedNavigation = 5f;
    [SerializeField] private float turnSpeed = 3f;
    [SerializeField] private float health = 10f;
    [SerializeField] private float damage = 10f;
    public float startWaitTime = 4;
    //[SerializeField] private float degats = 5f;
    [SerializeField] private float radius = 10f;
    public float angle = 90;

    public LayerMask playerMask;
    public LayerMask obstacle;
    public float meshResolution = 1f;
    public int edgeIterations = 4;
    public float edgeDistance = 0.5f;

    public Transform[] waypoints;
    int currentWaypointIndex;

    Vector3 playerLastPosition = Vector3.zero;
    Vector3 playerPosition;

    float waitTime;
    float timeToRotate;
    bool playerInRange;
    bool playerNear;
    bool isPastrol;
    bool caughtPlayer;

    GameObject player;

    public Transform Target;
    public NavMeshAgent enemy;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = Vector3.zero;
        isPastrol = true;
        caughtPlayer = false;
        playerInRange = false;
        waitTime = startWaitTime;
        timeToRotate = turnSpeed;

        currentWaypointIndex = 0;

        enemy = GetComponent<NavMeshAgent>();

        enemy.isStopped = false;
        enemy.speed = speedNavigation;
        enemy.SetDestination(waypoints[currentWaypointIndex].position);

    }

    // Update is called once per frame
    void Update()
    {
        ////Target = GameObject.Find
        //Vector3 lookPos = player.transform.position - transform.position;
        //lookPos.y = 0;
        //Quaternion rotation = Quaternion.LookRotation(lookPos);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        //transform.position += transform.forward * Time.deltaTime * speed;

    }

    private void Chasing()
    {
        playerNear = false;
        playerLastPosition = Vector3.zero;

        if(!caughtPlayer)
        {
            Move(speedNavigation);
            enemy.SetDestination(playerPosition);
        }
        //if(enemy.remainingDistance <= enemy.stoppingDistance)
        //{
        //    if(waitTime <= 0 && !caughtPlayer && Vector3.Distance(transform.position, LayerMask.NameToLayer("Player").transform.position) >= 6f)
        //    {

        //    }
        //}
    }

    private void Patroling()
    {
        if(playerNear)
        {
            if(turnSpeed <= 0)
            {
                Move(speedNavigation);
                LookingPlayer(playerLastPosition);
            }
            else
            {
                Stop();
                timeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            playerNear = false;
            playerLastPosition = Vector3.zero;
            enemy.SetDestination(waypoints[currentWaypointIndex].position);
            if(enemy.remainingDistance < enemy.stoppingDistance)
            {
                if(waitTime <= 0)
                {
                    NextPoint();
                    Move(speedNavigation);
                    waitTime = startWaitTime;
                }
                else
                {
                    Stop();
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    void Move(float speed)
    {
        enemy.isStopped = false;
        enemy.speed = speed;
    }

    void Stop()
    {
        enemy.isStopped = true;
        enemy.speed = 0;
    }

    public void NextPoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        enemy.SetDestination(waypoints[currentWaypointIndex].position);
    }

    void CautghtPlayer()
    {
        caughtPlayer = true;
    }

    void LookingPlayer(Vector3 player)
    {
        enemy.SetDestination(player);
        if(Vector3.Distance(transform.position, player) <= 0.3)
        {
            if(waitTime <= 0)
            {
                playerNear = false;
                Move(speedNavigation);
                enemy.SetDestination(waypoints[currentWaypointIndex].position);
                waitTime = startWaitTime;
                timeToRotate = turnSpeed;
            }
            else
            {
                Stop();
                waitTime -= Time.deltaTime;
            }
        }
    }

    //void EnviromentView()
    //{
    //    Collider[] colliPlayer = Physics.OverlapSphere(transform.position, radius, playerMask);

    //    for (int i = 0; i < colliPlayer.Length; i++)
    //    {
    //        Transform player = colliPlayer[i].transform;
    //        Vector3 dirToPlayer = (player.position - transform.position).normalized;
    //        if(Vector3.Angle(transform.forward, dirToPlayer) < angle / 2)
    //        {
    //            float dstToPlayer = Vector3.Distance(transform.position, player.position);

    //             if(!Physics.Raycast(transform.position,dirToPlayer, dstToPlayer, obstacle))
    //            {
                    
    //                isPastrol = false;

    //            }
    //             else
    //            {
    //                colliPlayer = false;
    //            }
    //        }
    //        if(Vector3.Distance(transform.position, player.position) > radius)
    //        {
    //            playerInRange = player.transform.position;
    //        }
    //    }
    //}
}
