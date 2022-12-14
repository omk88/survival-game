using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastChop : MonoBehaviour
{
public TreeController treeScript;
public RockController rockScript;
public EnemyController enemyScript;
public ItemPickup itemScript;
public ParticleSystem particles;
public GameObject axe;
public GameObject axeItem;
public GameObject pickaxe;
public GameObject pickaxeItem;
public Camera player;
//public Inventory inv;

void Start()
{
    Cursor.lockState = CursorLockMode.Locked;
}

void Update()
{
    if(axe.activeInHierarchy && Input.GetButtonDown("Drop"))
    {
        print("Axe Dropped");
        axe.SetActive(false);
        Instantiate(axeItem, player.transform.position, Quaternion.identity);
        itemScript.DropItem("AxeItem");
         //inv.inventory.Remove("AxeItem");
    }
    else if(pickaxe.activeInHierarchy && Input.GetButtonDown("Drop"))
    {
        print("Pickaxe Dropped");
        pickaxe.SetActive(false);
        Instantiate(pickaxeItem, player.transform.position, Quaternion.identity);
        itemScript.DropItem("PickaxeItem");
        //inv.inventory.Remove("PickaxeItem");
    }

    Vector3 fwd = Vector3.forward;

    Ray theRay = new Ray(transform.position, transform.TransformDirection(fwd * 5));
    Debug.DrawRay(transform.position, transform.TransformDirection(fwd * 5));
    //RaycastHit hit;

    if(Physics.Raycast(theRay, out RaycastHit hit, 5))
    {
            if(hit.collider.gameObject.tag == "Tree")
            {
                //print(hit.collider.gameObject.tag + " hit");
                treeScript = (TreeController)GameObject.Find(hit.collider.gameObject.name).GetComponent(typeof(TreeController));


                if(Input.GetButtonDown("Fire1") && axe.activeInHierarchy)
                {
                    print("Health decreased");
                    treeScript.health -= 1;
                    Instantiate(particles, transform.position, Quaternion.identity);
                }
            }
            else if(hit.collider.gameObject.tag == "Rock")
            {
                //print(hit.collider.gameObject.tag + " hit");
                rockScript = (RockController)GameObject.Find(hit.collider.gameObject.name).GetComponent(typeof(RockController));

                if(Input.GetButtonDown("Fire1") && pickaxe.activeInHierarchy)
                {
                    print("Health decreased");
                    rockScript.health -= 1;
                    Instantiate(particles, transform.position, Quaternion.identity);
                }
            }
            else if(hit.collider.gameObject.tag == "RockItem" )
            {
                //print(hit.collider.gameObject.tag + " hit");
                itemScript = (ItemPickup)GameObject.Find(hit.collider.gameObject.name).GetComponent(typeof(ItemPickup));

                if(Input.GetButtonDown("Pick up"))
                {
                    itemScript.itemName = hit.collider.gameObject.tag;
                    itemScript.destroyed = true;
                }
            }
            else if(hit.collider.gameObject.tag == "LogItem")
            {
                //print(hit.collider.gameObject.tag + " hit");
                itemScript = (ItemPickup)GameObject.Find(hit.collider.gameObject.name).GetComponent(typeof(ItemPickup));

                if(Input.GetButtonDown("Pick up"))
                {
                    itemScript.itemName = hit.collider.gameObject.tag;
                    itemScript.destroyed = true;
                }
            }
            else if(hit.collider.gameObject.tag == "AxeItem")
            {
                //print(hit.collider.gameObject.tag + " hit");
                itemScript = (ItemPickup)GameObject.Find(hit.collider.gameObject.name).GetComponent(typeof(ItemPickup));

                if(Input.GetButtonDown("Pick up"))
                {
                    if(pickaxe.activeInHierarchy)
                    {
                        itemScript.DropItem("PickaxeItem");
                        pickaxe.SetActive(false);
                        Instantiate(pickaxeItem, player.transform.position, Quaternion.identity);
                    }

                    itemScript.itemName = hit.collider.gameObject.tag;
                    itemScript.destroyed = true;
                    axe.SetActive(true);
                }
            }
            else if(hit.collider.gameObject.tag == "PickaxeItem")
            {
                //print(hit.collider.gameObject.tag + " hit");
                itemScript = (ItemPickup)GameObject.Find(hit.collider.gameObject.name).GetComponent(typeof(ItemPickup));

                if(Input.GetButtonDown("Pick up"))
                {
                    if(axe.activeInHierarchy)
                    {
                        itemScript.DropItem("AxeItem");
                        axe.SetActive(false);
                        Instantiate(axeItem, player.transform.position, Quaternion.identity);
                    }

                    itemScript.itemName = hit.collider.gameObject.tag;
                    itemScript.destroyed = true;
                    pickaxe.SetActive(true);
                }
            }
            else if(hit.collider.gameObject.tag == "BerriesItem")
            {
                //print(hit.collider.gameObject.tag + " hit");
                itemScript = (ItemPickup)GameObject.Find(hit.collider.gameObject.name).GetComponent(typeof(ItemPickup));

                if(Input.GetButtonDown("Pick up"))
                {
                    itemScript.itemName = hit.collider.gameObject.tag;
                    itemScript.destroyed = true;
                }
            }
            else if(hit.collider.gameObject.tag == "Enemy")
            {
                enemyScript = (EnemyController)GameObject.Find(hit.collider.gameObject.name).GetComponent(typeof(EnemyController));

                if(Input.GetButtonDown("Fire1"))
                {
                    enemyScript.health-=15;
                }
            }
    }
}
}