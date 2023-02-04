using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform target;
    public float speed,
        jumpSpeed,
        turnSmoothTime,
        turnSmoothVelocity;
    private float gravity = 250f;
    private Vector3 moveVel;
    private Vector3 playerInput;
    private bool jumping;
    private Vector3 camRight;
    private Vector3 camForward;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        playerInput = new Vector3(horizontal, 0f, vertical);

        //if (controller.isGrounded)
        //{
            playerInput = Vector3.ClampMagnitude(playerInput, 1f);

            camDir();


            moveVel = playerInput.x * camRight + playerInput.z * camForward;
        target.transform.LookAt(target.transform.position + moveVel);
        if (moveVel.magnitude >= 0.1f)
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, 5 * Time.deltaTime);
        SetGravity();
        controller.Move(moveVel * speed * Time.deltaTime);

        //controller.transform.LookAt(controller.transform.position + moveVel);
        jumping = false;
            /*float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;*/
            //moveVel = moveDir;

            



        //}
        /*else if (!controller.isGrounded && jumping)
        {
            float n = 0.4f;
            if (horizontal >= n)
                moveVel.x = target.right.x * speed;
            else if (horizontal <= -n)
                moveVel.x = target.right.x * -speed;
            if (vertical >= n)
                moveVel.z = target.forward.z * speed;
            else if (vertical <= -n)
                moveVel.z = target.forward.z * -speed;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            moveVel.y = jumpSpeed;
            jumping = true;
        }*/

        if (moveVel.z >= 0.1)
        {
            //GetComponent<PlayerController>().anim.SetBool("Running", true);
        }
        /*else
            GetComponent<PlayerController>().anim.SetBool("Running", false);*/

        //moveVel.y += gravity * Time.deltaTime;
    }

    void SetGravity()
    {
        moveVel.y = -gravity * Time.deltaTime;
    }

    void camDir()
    {
        camForward = Camera.main.transform.forward;
        camRight = Camera.main.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
