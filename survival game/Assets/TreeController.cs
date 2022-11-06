using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
public int health = 5;

public Transform logs;
public GameObject tree;

public int speed = 8;
public bool fell = false;

void Start()
{
	tree = this.gameObject;
	GetComponent<Rigidbody>().isKinematic = true;
}

void Update()
{
    if(health <= 0 && fell == false)
    {
        fell = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        DestroyTree();
    }
}

void DestroyTree()
{
    new WaitForSeconds(5);

    Transform logObject = Instantiate(logs, tree.transform.position, Quaternion.identity);

    logObject.name = (Random.Range(-100.0f, 100.0f)).ToString();

    Destroy(tree);

}

}


