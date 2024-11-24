using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Vector2 dir; 

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal"); // Left/Right or A/D keys
        dir.y = Input.GetAxisRaw("Vertical");   // Up/Down or W/S keys
    }

    void FixedUpdate()
    {
        transform.Translate(dir * moveSpeed * Time.fixedDeltaTime);
    }
}
