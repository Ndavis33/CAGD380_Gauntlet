using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing_Object : MonoBehaviour
{
    public float rotate = 100;
    
    public GameObject player;
    public int Damage;
    private PlayerMovement _player;

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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Demon")
        {
            Destroy(this.gameObject);
           Destroy(collision.collider.gameObject);
        }
        
        if (collision.gameObject.tag == "Ghost")
        {
            Destroy(this.gameObject);
            Destroy(collision.collider.gameObject);
        }

        if (collision.gameObject.tag == "Grunt")
        {
            Destroy(this.gameObject);
            Destroy(collision.collider.gameObject);
        }

        if (collision.gameObject.tag == "Lobber")
        {
            Destroy(this.gameObject);
            Destroy(collision.collider.gameObject);
        }

        if (collision.gameObject.tag == "Sorcerer")
        {
            Destroy(this.gameObject);
            Destroy(collision.collider.gameObject);
        }

        if (collision.gameObject.tag == "Thief")
        {
            Destroy(this.gameObject);
            Destroy(collision.collider.gameObject);
        }
        if (collision.gameObject.tag == "Generator")
        {
            Destroy(this.gameObject);
            Destroy(collision.collider.gameObject);
        }

        if (collision.gameObject.tag == "Death")
        {
            Destroy(this.gameObject);
           
        }

    }

}
