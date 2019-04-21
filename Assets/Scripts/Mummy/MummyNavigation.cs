using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MummyNavigation : MonoBehaviour
{
  #region VARIABLES
  public Transform[] points;
  private int destPoint = 0;
  private NavMeshAgent navAgent;
  #endregion

  private void Start()
  {
    navAgent = GetComponent<NavMeshAgent>();
    // Don't decelerate when arrive to the destination
    navAgent.autoBraking = false;
  }

  private void Update()
  {
    if (!GameManager.instance.gamePaused) {
      if (!navAgent.pathPending && navAgent.remainingDistance < 0.5f) {
        GoToNextPoint();
      }
    } else {
      navAgent.SetDestination(transform.position);
    }
  }

  /// <summary>
  /// Set the agent to go to the next position
  /// </summary>
  private void GoToNextPoint()
  {
    if(points.Length == 0)
    {
      return;
    }

    // Set the agent to go to current destination
    navAgent.SetDestination(points[destPoint].position);

    // Choose the next point
    destPoint = (destPoint + 1) % points.Length;
  }
}
