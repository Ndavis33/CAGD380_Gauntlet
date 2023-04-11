using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Quaternion rotation;
    // Update is called once per frame

    private void Start()
    {
        rotation = this.transform.rotation;
    }
    void Update()
    {
        this.transform.rotation = rotation;
    }
}
