using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private Material playerMaterial;
    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask ballLayer;
    private IPlayerState currentState;
    private GameObject closestBall;

    public BaseState baseState = new BaseState();
    public ScaredState scaredState = new ScaredState();
    public SadState sadState = new SadState();
    public HappyState happyState = new HappyState();
    public ConfusedState confusedState = new ConfusedState();
    public GameObject ClosestBall => closestBall;
    public Material PlayerMaterial => playerMaterial;

    private void OnDrawGizmos()
    {
      Gizmos.color = Color.green;
      Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    private void Awake()
    {
      currentState = baseState;
    }

    private void Update()
    {
      CheckForBall();
      currentState = currentState.DoState(this);
    }

    private void CheckForBall()
    {
      Collider tempClosest = null;
      float closestDistance = Mathf.Infinity;
      Collider[] tempBalls = Physics.OverlapSphere(transform.position, detectionRadius, ballLayer);
      foreach(Collider ball in tempBalls)
      {
        float tempDistance = Vector3.Distance(ball.transform.position, transform.position);
        if(tempDistance < closestDistance)
        {
          closestDistance = tempDistance;
          tempClosest = ball;
        }
      }
      if(tempClosest is not null)
      {
        closestBall = tempClosest.gameObject;
      } else {
        closestBall = null;
      }

    }

}

public interface IPlayerState
{
  IPlayerState DoState(PlayerState player);
}
