using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed,
        turnSmoothTime,
        turnSmoothVelocity;
    private float gravity = 10.5f;
    private float vSpeed = 0f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (controller.isGrounded)
            vSpeed = 0f;

        vSpeed -= gravity * Time.deltaTime;

        if (direction.magnitude >= 0.1f && controller.enabled)
        {
            GetComponent<PlayerController>().anim.SetBool("Running", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir.y = vSpeed;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
            GetComponent<PlayerController>().anim.SetBool("Running", false);
    }
}
