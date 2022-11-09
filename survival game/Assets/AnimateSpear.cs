using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSpear : MonoBehaviour
{
    public GameObject Spear;
    void Update()
    {
        if (!Player.instance.isPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                int random = Random.Range(1, 2);

                if (random == 1)
                {
                    Spear.GetComponent<Animator>().Play("BowFire");
                    //StartCoroutine(Sleep());
                    //axe.GetComponent<Animator>().enabled = false;
                    print("anim0");
                }


                print(random);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                Spear.GetComponent<Animator>().Play("BowMove");
            }
        }
    }
}
