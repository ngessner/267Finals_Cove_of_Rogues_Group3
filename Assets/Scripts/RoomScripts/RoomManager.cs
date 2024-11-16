using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject enemyRoom;
    public GameObject lootRoom;
    public GameObject exitRoom;
    public int gridWidth = 5;
    public int gridHeight = 5;
    public float roomWidth = 10f;  
    public float roomHeight = 6f; 


    private void Start()
    {
        generateRooms();
    }

    void generateRooms()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector2 roomPosition = new Vector2(x * roomWidth, y * roomHeight);
                createRoom(roomPosition);
            }
        }
    }

    void createRoom(Vector2 position)
    {
        int roomType = Random.Range(0, 3); 

        // 0 = enemy, 1 = loot, 2 = exit
        if (roomType == 0)
        {
            Instantiate(enemyRoom, new Vector2(position.x, position.y), Quaternion.identity);
        }
        else if (roomType == 1)
        {
            Instantiate(lootRoom, new Vector2(position.x, position.y), Quaternion.identity);
        }
        else if (roomType == 2)
        {
            Instantiate(exitRoom, new Vector2(position.x, position.y), Quaternion.identity);
        }
    }
}

