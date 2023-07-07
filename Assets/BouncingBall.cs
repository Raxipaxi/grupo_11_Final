using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;


public class BouncingBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    private Rigidbody rb;
    [SerializeField] private Vector2 normal;
    [SerializeField] private LayerMask isHittable;
    [SerializeField] private LayerMask pLayerMask;
    [SerializeField] private Transform anchorPoint;

    // Start is called before the first frame update
    void Start()
    {
       
        normal = transform.right;
        direction = transform.right;
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
       transform.position += transform.right * speed * Time.deltaTime;

    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (GameUtilities.IsGoInLayerMask(collision.gameObject, pLayerMask))
    //     {
    //         transform.position = anchorPoint.position;
    //     }
    //     normal = collision.GetContact(0).normal;
    //     direction = Vector2.Reflect(direction, normal);
    // }
}
