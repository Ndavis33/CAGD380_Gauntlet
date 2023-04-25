using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private float speed = 5f;
    private Vector3 playerPos;

    private void Start()
    {
        playerPos = this.transform.position;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerPos += Vector3.left * speed * Time.deltaTime;
            this.transform.position = playerPos;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerPos += Vector3.right * speed * Time.deltaTime;
            this.transform.position = playerPos;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerPos += Vector3.back * speed * Time.deltaTime;
            this.transform.position = playerPos;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerPos += Vector3.forward * speed * Time.deltaTime;
            this.transform.position = playerPos;
        }
    }

}
