using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    private float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 1 * speed * Time.deltaTime, 0);
    }
}
