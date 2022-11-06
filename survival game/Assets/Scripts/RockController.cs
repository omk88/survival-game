using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
public int health = 5;

public Transform rocks;
public GameObject rock;
public ParticleSystem particles;

public int speed1 = 8;

void Start()
{
	rock = this.gameObject;
}

void Update()
{
    if(health <= 0)
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed1);
        DestroyRock();
    }
}

void DestroyRock()
{
    new WaitForSeconds(5);

    for(int i = 0; i < (Random.Range(1, 4)); i++)
    {
        Transform rockObject = Instantiate(rocks, rock.transform.position, Quaternion.identity);
        rockObject.name = (Random.Range(-100.0f, 100.0f)).ToString();
    }
    Destroy(rock);
    Instantiate(particles, transform.position, Quaternion.identity);

}

}