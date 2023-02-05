using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform target;
    public float speed,
        jumpForce,
        turnSmoothTime,
        turnSmoothVelocity;
    public Animator anim;
    public LayerMask layer;
    private bool isJumping,
        isGrounded;
    private float gravity = 10f;
    private float fallVelocity;
    private Vector3 moveVel;
    private Vector3 playerInput;
    private Vector3 camRight;
    private Vector3 camForward;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        playerInput = new Vector3(horizontal, 0f, vertical);

        playerInput = Vector3.ClampMagnitude(playerInput, 1f);

        camDir();


        moveVel = playerInput.x * camRight + playerInput.z * camForward;
        target.transform.LookAt(target.transform.position + moveVel);
        if (moveVel.magnitude >= 0.4f)
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, 5 * Time.deltaTime);
        SetGravity();
        JumpVerifier();
        controller.Move(moveVel * speed * Time.deltaTime);

        if (moveVel.magnitude >= 0.2 && controller.isGrounded)
        {
            anim.SetBool("IsMoving", true);
        }
        else if (controller.isGrounded)
        {
            anim.SetBool("IsMoving", false);
        }

        if (controller.isGrounded)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit, 4, ~layer))
            {
                if (hit.transform.CompareTag("Plataform"))
                {
                    transform.parent = hit.transform;
                }
            }

            isGrounded = true;
            anim.SetBool("IsGrounded", isGrounded);
            isJumping = false;
            anim.SetBool("IsJumping", isJumping);
            anim.SetBool("IsFalling", false);
        }
        else
        {
            Vector3 direction = -transform.up;
            if (!Physics.Raycast(transform.position, direction, 2, ~layer))
            {
                isGrounded = false;
                anim.SetBool("IsGrounded", isGrounded);
                anim.SetBool("IsFalling", true);
                transform.parent = null;
            }
        }
    }

    void SetGravity()
    {
        if (controller.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            moveVel.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            moveVel.y = fallVelocity;
        }
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

    void JumpVerifier()
    {
        if (isGrounded && !isJumping && Input.GetKeyDown(KeyCode.Space) || isGrounded && !isJumping && Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            transform.parent = null;
            fallVelocity = jumpForce;
            moveVel.y = fallVelocity;
            isJumping = true;
            anim.SetBool("IsJumping", isJumping);
            anim.SetBool("IsFalling", true);
        }
    }
}
