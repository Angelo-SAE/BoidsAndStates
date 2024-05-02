using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Boid))]
public class BoidAlignment : MonoBehaviour
{
  [SerializeField] private float radius;
  [SerializeField] private float repulsionForce;

  [SerializeField] private Boid cboid;

  private void Update()
  {
    FindBoidsInRadius();
  }

  private void FindBoidsInRadius()
  {
    Vector3 average = Vector3.zero;
    int found = 0;

    for(int a = 0; a < cboid.boidHolder.boids.Count(); a++)
    {
      Boid boid = cboid.boidHolder.boids.GetElementAt(a);
      Vector3 difference = boid.transform.position - this.transform.position;
      if(difference.magnitude < radius)
      {
        average += boid.velocity;
        found++;
      }
    }

    if(found > 0)
    {
      average = average/found;
      cboid.velocity += Vector3.Lerp(cboid.velocity, average, Time.deltaTime) * repulsionForce;
    }
  }
}
