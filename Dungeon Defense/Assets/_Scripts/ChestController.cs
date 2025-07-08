using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Vector3 startChestPosition;
    public Vector3 newChestPositon;
    public int distanceFromCenter = 10;
    // Start is called before the first frame update
    void Start()
    {
        startChestPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //relocates the chest, intended to be called when new room is spawned so that its further away from the enemy spawn
    public void RelocateChest(int newlocationID, Vector3 newRoomPositon) //newlocationID should be set so that 0 = up, 1 = right, 2 = down, 3 = left.
    {
        switch(newlocationID){
            case 0:
                newChestPositon = new Vector3(newRoomPositon.x, startChestPosition.y, newRoomPositon.z + distanceFromCenter);
                this.gameObject.transform.position = newChestPositon;
                this.gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, 0, 0f);
                break;
            case 1:
                newChestPositon = new Vector3(newRoomPositon.x + distanceFromCenter, startChestPosition.y, newRoomPositon.z);
                this.gameObject.transform.position = newChestPositon;
                this.gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, 90, 0f);
                break;

            case 2:
                newChestPositon = new Vector3(newRoomPositon.x, startChestPosition.y, newRoomPositon.z - distanceFromCenter);
                this.gameObject.transform.position = newChestPositon;
                this.gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, 180, 0f);
                break;

            case 3:
                newChestPositon = new Vector3(newRoomPositon.x - distanceFromCenter, startChestPosition.y, newRoomPositon.z);
                this.gameObject.transform.position = newChestPositon;
                this.gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, 270, 0f);
                break;
        }
    }
}
