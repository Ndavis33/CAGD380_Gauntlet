using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Script : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(50f *Time.deltaTime, 0, 0);
    }
}
