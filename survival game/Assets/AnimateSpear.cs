using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSpear : MonoBehaviour
{
    private bool firingWeapon = false;
    private bool isItem = false;

    private void Start()
    {
        if (!isItem)
        {
            GetComponent<Collider>().isTrigger = true;
        }
        else
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }

    void Update()
    {
        if (!Player.instance.isPaused)
        {
            var normTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (normTime >= 0.99f && firingWeapon)
            {
                firingWeapon = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                firingWeapon = true;
                GetComponent<Animator>().Play("SpearAttack");
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && !firingWeapon)
            {
                GetComponent<Animator>().Play("SpearWalk");
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag.Equals("Enemy"))
        {
            Debug.Log("HIT ENEMY!!!");
            collision.transform.GetComponent<EnemyController>().health -= 20;
            if (collision.transform.GetComponent<EnemyController>().health <= 0f)
            {
                Destroy(collision.transform.gameObject);
            }
        }
    }
}
