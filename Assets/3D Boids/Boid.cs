using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float maxVelocity;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask boidLayer;
    [SerializeField] public BoidHolder boidHolder;
    public Vector3 velocity;

    private void Start()
    {
      boidHolder.boids.AddToBack(this);
      rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      MoveBoid();
    }

    private void MoveBoid()
    {
      if(velocity.magnitude > maxVelocity)
      {
        velocity = velocity.normalized * maxVelocity;
      }
      rb.velocity = velocity;
      transform.rotation = Quaternion.LookRotation(velocity);
    }
}
