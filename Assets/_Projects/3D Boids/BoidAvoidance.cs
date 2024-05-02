using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidAvoidance : MonoBehaviour
{
  [SerializeField] private float radius;
  [SerializeField] private float repulsionForce;
  [SerializeField] private Collider[] walls;
  [SerializeField] private LayerMask wallLayer;

  [SerializeField] private Boid cboid;

  private void OnDrawGizmos()
  {
    Gizmos.DrawWireSphere(transform.position, radius);
  }

  private void Update()
  {
    CheckForWalls();
    ApplyRepulsionForce();
  }

  private void CheckForWalls()
  {
    walls = Physics.OverlapSphere(transform.position, radius, wallLayer);
  }

  private void ApplyRepulsionForce()
  {
    Vector3 average = Vector3.zero;
    int found = 0;

    foreach(Collider wall in walls)
    {
      Vector3 closestPoint = Physics.ClosestPoint(transform.position, wall, wall.transform.position, wall.transform.rotation);
      Vector3 difference = closestPoint - transform.position;
      if(difference.magnitude < radius)
      {
        average += difference;
        found++;
      }
    }

    if(found > 0)
    {
      average = average/found;
      cboid.velocity -= Vector3.Lerp(Vector3.zero, average, average.magnitude/radius) * repulsionForce;
    }

  }
}
