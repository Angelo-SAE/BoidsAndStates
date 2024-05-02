using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Boid))]
public class BoidCohesion : MonoBehaviour
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
          average += difference;
          found++;
        }
      }

      if(found > 0)
      {
        average = average/found;
        cboid.velocity += Vector3.Lerp(Vector3.zero, average, average.magnitude / radius) * repulsionForce;
      }
    }
}
