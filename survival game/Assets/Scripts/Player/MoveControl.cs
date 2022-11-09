using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public CharacterController controller;
    private bool canJump = true;
    public float moveSpeed = 5F;
    public float jumpForce;
    private float yVel;



    void Update()
    {
        canJump = controller.isGrounded;
        if (canJump && yVel < 0)
        {
            yVel = 0f;
        }

        controller.Move(updateMove() * Time.deltaTime * moveSpeed);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            yVel += Mathf.Sqrt(jumpForce * 9.81f);
        }

        yVel += -9.81f * Time.deltaTime;
        controller.Move(new Vector3(0, yVel, 0) * Time.deltaTime);
    }

    Vector3 updateMove()
    {

        Vector3 changePos = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            changePos += new Vector3(-transform.right.x, 0, -transform.right.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            changePos += new Vector3(transform.right.x, 0, transform.right.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            changePos += new Vector3(transform.forward.x, 0, transform.forward.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            changePos += new Vector3(-transform.forward.x, 0, -transform.forward.z);
        }

        return changePos;
    }
}
