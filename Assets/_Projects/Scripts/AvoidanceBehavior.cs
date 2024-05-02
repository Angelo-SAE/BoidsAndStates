using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidanceBehavior : MonoBehaviour
{
    [SerializeField] private GameObject tempObj;
    [SerializeField] private LayerMask avoidLayers;
    [SerializeField] private float avoidanceDetectionRange, colliderRadius, movementSpeed, maxSpeed;
    private Collider2D[] avoidanceColliders;
    private float[] avoidanceDirections, goodDirections;
    private Rigidbody2D rb2d;
    private Vector3 finalDirection, tempDirection2;

    private void OnDrawGizmos()
    {
      Gizmos.DrawWireSphere(transform.position, avoidanceDetectionRange);
      Gizmos.DrawWireCube(transform.position, new Vector3(colliderRadius, colliderRadius, colliderRadius));
    }

    private void Start()
    {
      rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
      tempDirection2 = (tempObj.transform.position - transform.position).normalized;
      //DetectNearbyAvoidances();
      //GetAvoidanceInformation();
      //GetGoodDirections();
      //CalculateFinalDirection();
      BoiMovement();
    }

    private void DetectNearbyAvoidances()
    {
      avoidanceColliders = Physics2D.OverlapCircleAll(transform.position, avoidanceDetectionRange, avoidLayers);
    }

    private void GetAvoidanceInformation()
    {
      avoidanceDirections = new float[8];
      foreach(Collider2D avoidance in avoidanceColliders)
      {
        Vector2 avoidanceDirection = avoidance.ClosestPoint(transform.position) - (Vector2)transform.position;
        float distanceToWall = avoidanceDirection.magnitude;
        avoidanceDirection = avoidanceDirection.normalized;
        float weight = 0f;
        if(distanceToWall <= colliderRadius)
        {
          weight = 1f;
        } else {
          weight = (avoidanceDetectionRange - distanceToWall) / avoidanceDetectionRange;
        }
        int a = 0;
        foreach(Vector2 direction in DirectionsList.allDirections)
        {
          float result = Vector2.Dot(avoidanceDirection, direction);

          float dangerValue = result * weight;

          if(dangerValue > avoidanceDirections[a])
          {
            avoidanceDirections[a] = dangerValue;
          }
          a++;
        }
      }
    }

    private void GetGoodDirections()
    {
      goodDirections = new float[8];
      int a = 0;
      foreach(Vector2 direction in DirectionsList.allDirections)
      {
        float goodValue = Vector2.Dot(tempDirection2, direction);

        if(goodValue > 0)
        {
          if(goodValue > goodDirections[a])
          {
            goodDirections[a] = goodValue;
          }
        }
        a++;
      }
    }

    private void CalculateFinalDirection()
    {
      for(int a = 0; a < 8; a++)
      {
        goodDirections[a] = Mathf.Clamp(goodDirections[a] - avoidanceDirections[a], 0, 1);
      }

      Vector2 tempDirection = Vector2.zero;
      for(int a = 0; a < 8; a++)
      {
        tempDirection += DirectionsList.allDirections[a] * goodDirections[a];
      }
      finalDirection = tempDirection.normalized;
    }

    private void BoiMovement()
    {
      if(finalDirection != Vector3.zero)
      {
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, finalDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720f * Time.deltaTime);
      }
      transform.rotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z);
      if(rb2d.velocity.magnitude < maxSpeed)
      {
        rb2d.AddForce(tempDirection2 * movementSpeed);
      } else {
        rb2d.AddForce(tempDirection2 * -movementSpeed);
      }
    }
}

public static class DirectionsList
{
  public static List<Vector2> allDirections = new List<Vector2>
  {
    new Vector2(1f,0f),
    new Vector2(0f,1f),
    new Vector2(0f,-1f),
    new Vector2(-1f,0f),
    new Vector2(1f,1f),
    new Vector2(-1f,1f),
    new Vector2(1f,-1f),
    new Vector2(-1f,-1f)
  };
}
