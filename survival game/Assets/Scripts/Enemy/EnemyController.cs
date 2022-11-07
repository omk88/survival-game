using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public PlayerManager player;
    public Transform playerPosition;
    public NavMeshAgent agent;
    public float health {get; set;}
    public float visionRadius = 10f;

    public float moveSpeed = 4f;
    public float rotationSpeed = 100f;
    public float cooldown = 1f;
    public float lastAttacked = -9999f;

    private bool isFollowing = false;
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        health = Random.Range(75,125);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(transform.gameObject);
        }
        
        float distance = Vector3.Distance(playerPosition.position, transform.position);
        if (distance <= visionRadius) 
        {
            isFollowing = true;
            agent.SetDestination(playerPosition.position);
            if (distance <= agent.stoppingDistance)
            {
                LookAtTarget();
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
            }

            if (distance <= agent.stoppingDistance + 0.5)
            {
                if (Time.time > lastAttacked + cooldown) 
                {
                    player.player.health -= 5;
                    lastAttacked = Time.time;
                }
            }
        }

        else {
            if (isWandering == false)
            {
                StartCoroutine(Wander());
            }

            if (isRotatingLeft == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
            }

            if (isRotatingRight == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
            }

            if (isWalking == true)
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
        }
    }

    void LookAtTarget()
    {
        Vector3 direction = (playerPosition.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = rotation;
    }
    
    void AttackPlayer()
    {

    }

    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1,3);
        int rotationWait = Random.Range(1, 3);
        int rotationLeftorRight = Random.Range(1,2);
        int walkWait = Random.Range(1,2);
        int walkTime = Random.Range(1, 6);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotationWait);

        if (rotationLeftorRight == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }
        if (rotationLeftorRight == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }

        isWandering = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.player.health -= 10;
        }
    }

}
