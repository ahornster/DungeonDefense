using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*  Title: PlayerController
     *  
     *  Summary: A script intended to control movement keys of the player character. 
     *  This particular script utilizes the CharacterController component
     */

    public CharacterController characterController;
    public Transform cam;

    public float moveSpeed = 6f;
    public float turnSmoothTime = 0.1f;

    public float StartHeight;

    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        StartHeight = transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > StartHeight)
        {
            transform.position = new Vector3(transform.position.x, StartHeight, transform.position.z);
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, smoothedAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            characterController.Move(moveDir * moveSpeed * Time.deltaTime);
        }
    }

    


}
