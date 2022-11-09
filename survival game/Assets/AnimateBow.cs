using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimateBow : MonoBehaviour
{
    public GameObject Bow;
    public GameObject Arrow;
    private bool firingWeapon = false;
    void Update()
    {
        if (!Player.instance.isPaused)
        {
            var normTime = Bow.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (normTime >= 0.99f && firingWeapon)
            {
                fireArrow(1);
                firingWeapon = false;
            }

            if (Input.GetMouseButtonDown(0) && Player.instance.getItemCount("Arrow") >= 1)
            {
                firingWeapon = true;
                Bow.GetComponent<Animator>().Play("BowFire");
            }

            else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !firingWeapon)
            {
                Bow.GetComponent<Animator>().Play("BowMove");
            }
        }

        void fireArrow(float power)
        {
            Player.instance.inventory.Remove(Arrow.GetComponent<ItemObject>().item);
            var rot = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;
            power = Bow.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
            GameObject arrow = Instantiate(Arrow, transform.position, Quaternion.Euler(
                                        90 + rot.eulerAngles.x,
                                        rot.eulerAngles.y,
                                        rot.eulerAngles.z)
                                    );
            arrow.GetComponent<Rigidbody>().velocity = arrow.transform.rotation * Vector3.up * 10 * power;
        }
    }
}
