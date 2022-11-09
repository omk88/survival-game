using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 start;
    public bool isDropped = false;

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
        if (!isDropped)
        {
            if (collision.transform.tag.Equals("Floor") || collision.transform.tag.Equals("Wall"))
            {
                onHit();
                Destroy(transform.gameObject);
            }
            

            if (collision.transform.tag.Equals("Enemy"))
            {
                Debug.Log("HIT ENEMY!!!");
                collision.transform.GetComponent<EnemyAI>().health -= transform.GetComponent<Rigidbody>().velocity.magnitude;
                if (collision.transform.GetComponent<EnemyAI>().health <= 0f)
                {
                    onHit();
                    Destroy(collision.transform.gameObject);
                }
            }
        }
    }

    private void onHit()
    {
        var a = Instantiate(this, new Vector3(transform.position.x, 
            transform.position.y + 0.5f, transform.position.z), 
            Quaternion.Euler(10, 10, 10));
        a.GetComponent<Bullet>().isDropped = true;
        a.GetComponent<Collider>().isTrigger = false;
    }
}
