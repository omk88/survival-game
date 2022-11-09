using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private Vector3 LastKnown;
    public NavMeshAgent agent;
    public int Damage;
    public float AttackSpeed;
    private float attackCountDown;
    private bool CanAttack = true;
    public float health;
    private bool onFloor = false;

    private void Start()
    {
        attackCountDown = AttackSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(transform.gameObject);
        }

        float maxRange = 50;
        RaycastHit hit;

        if (Vector3.Distance(transform.position, player.transform.position) < maxRange)
        {
            Debug.DrawRay(transform.position, (player.transform.position - transform.position), Color.yellow);
            if (Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit, maxRange))
            {
                if (hit.transform.tag.Equals("Player")) {
                    if (hit.transform.parent.name.Equals("Player"))
                    {
                        
                        LastKnown = player.transform.position;
                        if (onFloor)
                        {
                            agent.SetDestination(LastKnown);
                        }

                        if (hit.distance <= 2 && CanAttack)
                        {
                            Player.instance.health -= Damage;
                            CanAttack = false;
                        }
                    }
                }
            }
        }

        if (attackCountDown > 0)
        {
            attackCountDown -= Time.deltaTime;
        }
        else
        {
            CanAttack = true;
            attackCountDown = AttackSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            onFloor = true;
        }
    }
}
