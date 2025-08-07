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
    public GUIController guiController;


    public float moveSpeed = 6f;
    public float turnSmoothTime = 0.1f;

    public float StartHeight;

    float turnSmoothVelocity;

    public bool cursorLocked;
    public bool pauseMenuShowing;

    // Start is called before the first frame update
    void Start()
    {
        StartHeight = transform.position.y; 

        //lock cursor to screen
        LockCursor();
        pauseMenuShowing = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(guiController == null)
        {
            guiController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GUIController>();
        }
        

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

        if(Input.GetKeyDown(KeyCode.L))
        {
            if (cursorLocked)
            {
                UnlockCursor();
            }
            else
            {
                LockCursor();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuShowing)
            {
                Time.timeScale = 1f;
                guiController.HidePauseMenu();
                LockCursor();
                pauseMenuShowing = false;
            }
            else
            {
                Time.timeScale = 0f;
                guiController.DisplayPauseMenu();
                UnlockCursor();
                pauseMenuShowing = true;
            }
        }

    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cursorLocked = true;
        //Debug.Log("Cursor attempted to lock. Current state should be:" +cursorLocked);
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursorLocked = false;
        //Debug.Log("Cursor attempted to unlock. Current state should be:" + cursorLocked);
    }

    


}
