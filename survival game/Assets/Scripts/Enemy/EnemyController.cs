using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float visionRadius = 10f;
    public Transform player;
    public NavMeshAgent agent;
    public bool isFollowing;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= visionRadius) {
            isFollowing = true;
            agent.SetDestination(player.position);
            if (distance <= agent.stoppingDistance){
                LookAtTarget();
            }
        }
    }

    void LookAtTarget(){
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = rotation;
    }

}
