using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
public int treeHealth = 5;

public Transform logs;
public GameObject tree;

public int speed = 8;
public bool fell = false;

//public Vector3 position = Vector3(Random.Range(-1.0, 1.0), 0, Random.Range(-1.0, 1.0));

void Start()
{
	tree = this.gameObject;
	GetComponent<Rigidbody>().isKinematic = true;
}

void Update()
{
    if(treeHealth <= 0 && fell == false)
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

    Instantiate(logs, tree.transform.position, Quaternion.identity);

    Destroy(tree);

}

}


