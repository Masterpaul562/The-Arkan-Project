using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Lobber : MonoBehaviour
{
    public Transform target;
    [SerializeField] private GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, 5 * Time.deltaTime);
    }
    private void Move()
    {

    }
    private void Fire()
    {

    }
}
