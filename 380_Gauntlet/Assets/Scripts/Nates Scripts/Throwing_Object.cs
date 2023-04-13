using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing_Object : MonoBehaviour
{
    public float rotate = 100;
    private int speed = 10;
    public GameObject player;


    private void Start()
    {
       
    }
    private void FixedUpdate()
    {
        StartCoroutine(Throw());
       
      
        transform.position += transform.forward * Time.deltaTime;
        //  transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    public IEnumerator Throw()
    {
        transform.position += transform.forward;
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
        
    }

}
