using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{

    Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.forward = rb.velocity;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
