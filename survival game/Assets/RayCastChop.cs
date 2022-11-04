using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastChop : MonoBehaviour
{
public TreeController treeScript;

void Update()
{
    Vector3 fwd = transform.TransformDirection(Vector3.forward);

    if (Physics.Raycast(transform.position, fwd, 30))
    {

        if(Input.GetButtonDown("Fire1"))
        {
            treeScript.treeHealth -= 1;
        }
    }

}
}