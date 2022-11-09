using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{
    public GameObject TestPrefab;
    public GameObject[] Prefabs;
    public Vector3 WeaponOffset;
    public Vector3 RotationOffset;
    public GameObject PlayerManager;
    private GameObject Weapon;
    private GameObject inWorldObject;

    // Update is called once per frame
    void Update()
    {
        if (inWorldObject != null) {
            return;
        }

        inWorldObject = Instantiate(
            TestPrefab, transform.position + WeaponOffset,
            transform.rotation * Quaternion.Euler(RotationOffset.x,RotationOffset.y,RotationOffset.z)
            );

        inWorldObject.transform.parent = this.transform;

        PlayerManager.GetComponent<Player>().equippedItem = TestPrefab.GetComponent<ItemObject>().item;
        //This checks what item the player currently has equipped and then sets that to be the prefab that will then be displayed.
        var weapon = PlayerManager.GetComponent<Player>().equippedItem;
        foreach (var a in Prefabs) {
            if (a.name.Equals(weapon.Name))
            {
                Weapon = a;
            }
        }

        if (Weapon == null)
        {
            return;
        }

        //GameObject inWorldObject = Instantiate(Weapon, transform.position + WeaponOffset, Quaternion.identity);
    }
}
