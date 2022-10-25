using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    private bool canJump = true;
    public float moveSpeed = 5F;
    public Vector3 jumpForce;

    private Rigidbody rb;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position += updateMove();

        if (Input.GetKey(KeyCode.Space))
        {
            if (canJump)
            {
                if (rb.velocity.y <= 0.1 && rb.velocity.y >= -0.1)
                {
                    rb.velocity = jumpForce;
                    canJump = false;
                }
            }
        }
    }

    Vector3 updateMove()
    {

        Vector3 changePos = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            changePos += new Vector3(-transform.right.x, 0, -transform.right.z) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            changePos += new Vector3(transform.right.x, 0, transform.right.z) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            changePos += new Vector3(transform.forward.x, 0, transform.forward.z) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            changePos += new Vector3(-transform.forward.x, 0, -transform.forward.z) * Time.deltaTime * moveSpeed;
        }

        return changePos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            canJump = true;
        }
    }
}
