using System.Collections;
using System.Collections.Generic;
using UnityEngine;    

public class AnimateAxe : MonoBehaviour
{

    public GameObject axe;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int random = Random.Range(1,2);

            if(random == 1)
            {
                axe.GetComponent<Animator>().Play("axeSwing0");
                //StartCoroutine(Sleep());
                //axe.GetComponent<Animator>().enabled = false;
                print("anim0");
            }


            print(random);
        }

        IEnumerator Sleep()
        {
            yield return new WaitForSeconds(4);
        }
    }
}