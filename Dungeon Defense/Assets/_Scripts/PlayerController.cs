using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*  Title: PlayerController
     *  
     *  Summary: A script intended to control movement keys of the player character. 
     *  This particular script follows the Forward, Backwards, and horizontal rotation style of movement. 
     *  This means no side strafing movement was intended in the design.
     */
    float moveSpeed;
    float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){

        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){

        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){

        }
    }

    void MoveForward()
    {

    }
    void MoveBackward()
    {

    }
    void RotateLeft()
    {

    }
    void RotateRight()
    {

    }


}
