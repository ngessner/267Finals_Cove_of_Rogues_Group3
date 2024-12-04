using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GameObject RoomPos;
    public ShiftRoomCam cameraRoomShift; // Reference to the camera movement script
    public Vector2 playerOffset; // Offset to apply to the player after transitioning

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {          
            cameraRoomShift.ShiftToRoom(RoomPos);
            TeleportPlayer(other.transform);
        }
    }

    private void TeleportPlayer(Transform playerTransform)
    {  
        playerTransform.position += new Vector3(playerOffset.x, playerOffset.y, 0);
    }
}
