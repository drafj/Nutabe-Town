using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed,
        jumpSpeed,
        turnSmoothTime,
        turnSmoothVelocity;
    private float gravity = -20f;
    private Vector3 moveVel;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f && controller.isGrounded)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            


            moveVel = moveDir;

        }
        else if (!controller.isGrounded)
        {
            if (horizontal >= 0.1)
                moveVel.x = cam.right.x * speed;
            else if (horizontal <= -0.1)
                moveVel.x = cam.right.x * -speed;
            if (vertical >= 0.1)
                moveVel.z = cam.forward.z * speed;
            else if (vertical <= -0.1)
                moveVel.z = cam.forward.z * -speed;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            moveVel.y = jumpSpeed;
        }

        if (moveVel.z >= 0.1)
        {
            //GetComponent<PlayerController>().anim.SetBool("Running", true);
        }
        /*else
            GetComponent<PlayerController>().anim.SetBool("Running", false);*/

        moveVel.y += gravity * Time.deltaTime;
        controller.Move(moveVel.normalized * speed * Time.deltaTime);
    }
}
