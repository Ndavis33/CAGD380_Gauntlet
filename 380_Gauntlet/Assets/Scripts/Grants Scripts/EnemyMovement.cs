using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //private GameObject _warrior, _valkyrie, _wizard, _elf;
    private GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void FixedUpdate()
    {
        this.transform.Translate(player.transform.position);
    }
}
