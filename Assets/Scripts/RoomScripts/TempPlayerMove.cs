using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Vector2 dir; 

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal"); 
        dir.y = Input.GetAxisRaw("Vertical");   
    }

    void FixedUpdate()
    {
        transform.Translate(dir * moveSpeed * Time.fixedDeltaTime);
    }
}
