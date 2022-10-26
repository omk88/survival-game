using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 start;

    private void Start()
    {
        start = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(start, transform.position) > 100)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag.Equals("Floor") || collision.transform.tag.Equals("Wall")) { Destroy(transform.gameObject); }
        if (collision.transform.tag.Equals("Enemy"))
        {
            Debug.Log("HIT ENEMY!!!");
            collision.transform.GetComponent<EnemyAI>().health -= transform.GetComponent<Rigidbody>().velocity.magnitude;
            if (collision.transform.GetComponent<EnemyAI>().health <= 0f)
            {
                Destroy(collision.transform.gameObject);
            }
        }
    }
}
