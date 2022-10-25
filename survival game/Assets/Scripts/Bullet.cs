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
        if (collision.transform.tag.Equals("Floor") || collision.transform.tag.Equals("Wall")) { Debug.Log("HIT!!!");  Destroy(transform.gameObject); }
    }
}
