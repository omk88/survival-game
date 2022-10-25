using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;

    //public bool followX;
    //public bool followY;
    //public bool followZ;

    public bool followPos;

    public bool followYaw;
    public bool followPitch;
    public bool followRoll;

    public bool followRot;

    void Update()
    {
        if (followPos)
        {
            this.transform.position = objectToFollow.transform.position;
        }

        if (followYaw)
        {
            transform.rotation = Quaternion.Euler(0, objectToFollow.transform.rotation.eulerAngles.y, 0);
        }

        if (followRot)
        {
            this.transform.rotation = objectToFollow.transform.rotation;
        }
    }
}
