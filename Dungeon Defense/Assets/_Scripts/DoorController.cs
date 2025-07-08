using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    [Range(0f,3f)]
    int openDirection; // 0 top, 1 right, 2 bottom, 3 left.

    bool isNearDoor;

    public RoomController roomController;
    GUIController guiController;


    private void Awake()
    {
        
        
    }

    private void Start()
    {
        guiController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GUIController>();
        //roomController = gameObject.GetComponentInParent<RoomController>();
    }

    private void Update()
    {
        if (isNearDoor && Input.GetKeyDown(KeyCode.E))
        {
            guiController.HideDirectionalPrompt();
            Destroy(this.gameObject);
            //OpenDoor();
            
        }
    }

    public void OpenDoor()
    {
        //Debug.Log(roomController);
        //Debug.Log("Direction ID: " + openDirection);
        roomController.SpawnRoom(openDirection);
        //this.gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !roomController.doorChosen)
        {
            guiController.DisplayDirectionalPrompt("Press [E] to open next room. (Costs 100 Coins).");

            isNearDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiController.HideDirectionalPrompt();

            isNearDoor = false;
        }
    }

    private void OnDestroy()
    {
        OpenDoor();
    }
}
