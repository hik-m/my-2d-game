using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

   public float cameraSpeed = 5.0f;

    public GameObject player;
   

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {

        Vector2 dir = player.transform.position - this.transform.position;
        Vector2 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        moveVector.y = (float)Math.Round(moveVector.y, 2);
        this.transform.Translate(moveVector);
        
        
    }
}