using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastChop : MonoBehaviour
{
public TreeController treeScript;
public RockController rockScript;
public ItemPickup itemScript;
public ParticleSystem particles;

void Update()
{
    Vector3 fwd = Vector3.forward;

    Ray theRay = new Ray(transform.position, transform.TransformDirection(fwd * 5));
    Debug.DrawRay(transform.position, transform.TransformDirection(fwd * 5));
    RaycastHit hit;


    if (Physics.Raycast(transform.position, fwd, 10))
    {
        if (Physics.Raycast (theRay, out hit))
        {
            if(hit.collider.gameObject.tag == "Tree")
            {
                print(hit.collider.gameObject.tag + " hit");
                treeScript = (TreeController)GameObject.Find(hit.collider.gameObject.name).GetComponent(typeof(TreeController));
                
                if(Input.GetButtonDown("Fire1"))
                {
                    print("Health decreased");
                    treeScript.health -= 1;
                    Instantiate(particles, transform.position, Quaternion.identity);
                }
            }
            else if(hit.collider.gameObject.tag == "Rock")
            {
                print(hit.collider.gameObject.tag + " hit");
                rockScript = (RockController)GameObject.Find(hit.collider.gameObject.name).GetComponent(typeof(RockController));

                if(Input.GetButtonDown("Fire1"))
                {
                    print("Health decreased");
                    rockScript.health -= 1;
                    Instantiate(particles, transform.position, Quaternion.identity);
                }
            }
            else if(hit.collider.gameObject.tag == "RockItem" )
            {
                print(hit.collider.gameObject.tag + " hit");
                itemScript = (ItemPickup)GameObject.Find(hit.collider.gameObject.name).GetComponent(typeof(ItemPickup));

                if(Input.GetButtonDown("Pick up"))
                {
                    itemScript.destroyed = true;
                }
            }
            else if(hit.collider.gameObject.tag == "LogItem")
            {
                print(hit.collider.gameObject.tag + " hit");
                itemScript = (ItemPickup)GameObject.Find(hit.collider.gameObject.name).GetComponent(typeof(ItemPickup));

                if(Input.GetButtonDown("Pick up"))
                {
                    itemScript.destroyed = true;
                }
            }

        }
    }



}
}