using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public Transform cam;
    private const float gravity = 25f;
    private Vector3 dir;
    private Vector3 gravDir;
    float hSpeed;
    Animator anim;
    public float turnSmoothing = 0.1f;
    float turnSmoothVelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        dir = Vector3.zero;
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Movement();
    }

    void Movement()
    {

        float h = Input.GetAxisRaw("Horizontal"); // Get WASD/Up Down Left Right Input
        float v = Input.GetAxisRaw("Vertical");
        dir = new Vector3(h, 0f, v).normalized; // find direction

        if (dir.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // get rotation angle as based on camera
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothing);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // change move direction into direction of camera
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            Vector3 hVel = controller.velocity; // Get velocty of player
            hVel = new Vector3(controller.velocity.x, 0, controller.velocity.z);
            hSpeed = hVel.magnitude;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 12f;
            }
            else { speed = 6f; }
        }

        anim.SetFloat("Speed", hSpeed);

        /* #region  Gravity */
        hSpeed = 0;
        gravDir.y -= gravity * Time.deltaTime; // Gravity Function
        controller.Move(gravDir * Time.deltaTime);
        /* #endregion */
    }
}
