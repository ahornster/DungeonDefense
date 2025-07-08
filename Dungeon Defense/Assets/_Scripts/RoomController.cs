using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class RoomController : MonoBehaviour
{
    [SerializeField]
    public GameObject topDoor;
    public GameObject rightDoor;
    public GameObject bottomDoor;
    public GameObject leftDoor;

    public NavMeshController navMeshController;

    //[SerializeField]
    public RoomTemplate roomTemplate;
    public GameObject gameManager;

    public bool doorChosen;
    public int newRoomOpenedDoorID;
    public GameObject newRoomOpenedDoor;

    public GameObject defenderChest;
    public ChestController chestController;

    private int placementModifier = 27;

    private void Start()
    {
        
        navMeshController = FindAnyObjectByType<NavMeshController>();
        navMeshController.RebuildNavMesh();

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        roomTemplate = gameManager.GetComponent<RoomTemplate>();

        defenderChest = GameObject.FindGameObjectWithTag("TargetChest");
        chestController = defenderChest.GetComponent<ChestController>();

        //Debug.Log(gameManager);
        //Debug.Log(roomTemplate);

        
        doorChosen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRoom(int doorDirection)
    {
        //Debug.Log("SpawnRoom() triggered");
        //Debug.Log("doorDirection ID: " + doorDirection);

        Vector3 spawnLocation;
        if (doorChosen == false)
        {
            //Debug.Log("doorChosen passed");
            int randRoom = 0;
            GameObject nextRoom;
            GameObject newRoom;
            RoomController newRoomController;
            switch (doorDirection)
            {
                case 0:
                   // topDoor.SetActive(false); //disable door
                    //place new room to top of current
                    spawnLocation = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + placementModifier);
                    randRoom = Random.Range(0, roomTemplate.topRooms.Length);
                    nextRoom = roomTemplate.topRooms[randRoom];
                    newRoom = Instantiate(nextRoom, spawnLocation, Quaternion.identity);
                    newRoomController = newRoom.GetComponent<RoomController>();
                    //newRoomController.newRoomOpenedDoorID = 0;
                    newRoomController.bottomDoor.SetActive(false);
                    newRoomController.doorChosen = false;
                    //disable interactibleController or DoorController in all other doors
                    doorChosen = true;
                    chestController.RelocateChest(0, spawnLocation);
                    break;
                case 1:
                    //Debug.Log("case 1 triggered");
                    //rightDoor.SetActive(false);
                    //place new room to right of current
                    spawnLocation = new Vector3(this.gameObject.transform.position.x + placementModifier, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                    randRoom = Random.Range(0, roomTemplate.rightRooms.Length);
                    nextRoom = roomTemplate.rightRooms[randRoom];
                    newRoom = Instantiate( nextRoom, spawnLocation, Quaternion.identity);
                    newRoomController = newRoom.GetComponent<RoomController>();
                    //newRoomController.newRoomOpenedDoorID = 3;
                   // newRoomController.leftDoor.gameObject.SetActive(false); //Removes initial door but seems to trigger a bug where rooms spawn ontop of each other trapping the player inside with new doors
                    newRoomController.leftDoor.SetActive(false);
                   // Destroy(newRoomController.leftDoor);
                   // Destroy(newRoomController.leftDoor.gameObject);

                    newRoomController.doorChosen = false;
                    //Find a way to disable the other door

                    //disable interactibleController or DoorController in all other doors
                    doorChosen = true;
                    chestController.RelocateChest(1, spawnLocation);
                    break;
                case 2:
                   // bottomDoor.SetActive(false);
                    //place new room to bottom of current
                    spawnLocation = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z - placementModifier);
                    randRoom = Random.Range(0, roomTemplate.bottomRooms.Length);
                    nextRoom = roomTemplate.bottomRooms[randRoom];
                    newRoom = Instantiate(nextRoom, spawnLocation, Quaternion.identity);
                    newRoomController = newRoom.GetComponent<RoomController>();
                    //newRoomController.newRoomOpenedDoorID = 2;
                    newRoomController.topDoor.SetActive(false);
                    newRoomController.doorChosen = false;
                    //disable interactibleController or DoorController in all other doors
                    doorChosen = true;
                    chestController.RelocateChest(2, spawnLocation);
                    break;
                case 3:
                    //leftDoor.SetActive(false);
                    //place new room to left of current
                    spawnLocation = new Vector3(this.gameObject.transform.position.x - placementModifier, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                    randRoom = Random.Range(0, roomTemplate.leftRooms.Length);
                    nextRoom = roomTemplate.leftRooms[randRoom];
                    newRoom = Instantiate(nextRoom, spawnLocation, Quaternion.identity);
                    newRoomController = newRoom.GetComponent<RoomController>();
                    //newRoomController.newRoomOpenedDoorID = 1;
                    newRoomController.rightDoor.SetActive(false);
                    newRoomController.doorChosen = false;
                    //disable interactibleController or DoorController in all other doors
                    doorChosen = true;
                    chestController.RelocateChest(3, spawnLocation);
                    break;
            }
        }
    }
}
