using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent agent;
    public bool isFollowing;
    public int health;
    public float visionRadius = 5f;

    public float moveSpeed = 3f;
    public float rotationSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        health = Random.Range(75,125);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= visionRadius) 
        {
            isFollowing = true;
            agent.SetDestination(player.position);
            if (distance <= agent.stoppingDistance)
            {
                LookAtTarget();
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
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = rotation;
    }

    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1,3);
        int rotationWait = Random.Range(1, 4);
        int rotationLeftorRight = Random.Range(1,2);
        int walkWait = Random.Range(1,5);
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

}
