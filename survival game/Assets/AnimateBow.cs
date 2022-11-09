using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimateBow : MonoBehaviour
{
    public GameObject Arrow;
    private bool firingWeapon = false;
    void Update()
    {
        if (!Player.instance.isPaused)
        {
            var normTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (normTime >= 0.99f && firingWeapon)
            {
                Player.instance.removeItem(Arrow.GetComponent<ItemObject>().item, 1);
                var rot = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;
                GameObject arrow = Instantiate(Arrow, transform.position, Quaternion.Euler(
                                            90 + rot.eulerAngles.x,
                                            rot.eulerAngles.y,
                                            rot.eulerAngles.z)
                                        );
                arrow.GetComponent<Rigidbody>().velocity = arrow.transform.rotation * Vector3.up * 30;
                firingWeapon = false;
            }

            if (Input.GetMouseButtonDown(0) && Player.instance.getItemCount("Arrow") >= 1)
            {
                firingWeapon = true;
                GetComponent<Animator>().Play("BowFire");
            }

            else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !firingWeapon)
            {
                GetComponent<Animator>().Play("BowMove");
            }
        }

    }
}
