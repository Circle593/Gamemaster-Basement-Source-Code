
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GameMasterAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject chaseMusic;
    public Transform player;
    public GameObject thePlayer;

    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject[] points;
    GameObject currentPoint;
    int index;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    bool isChasing;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }

    private void Update()
    {
        if(isChasing == false)
        {
            chaseMusic.SetActive(false);
        }
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();


        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            if (Hit.collider.gameObject.tag == "Player")
            {
                ChasePlayer();
            }
        }
        
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[index].transform.position;
        index = Random.Range(0, points.Length);
        currentPoint = points[index];

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        isChasing = true;
        if(isChasing)
        {
            agent.speed = 7.5f;
            chaseMusic.SetActive(true);
        }
        sightRange = 50;
    }

    private void AttackPlayer()
    {
        GlobalHealth.currentHealth = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
