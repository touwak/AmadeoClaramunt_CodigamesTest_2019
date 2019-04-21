using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerNavigation : MonoBehaviour
{

  #region VARIABLES
  NavMeshAgent navAgent;
  float nextPositionRadius = 2.0f;
  Camera mainCamera;
  LayerMask terrainLayerMask;
  private Animator myAnimator;
  #endregion

  private void Start()
  {
    navAgent = GetComponent<NavMeshAgent>();
    myAnimator = GetComponent<Animator>();
    mainCamera = GameManager.instance.mainCamera;
    terrainLayerMask = 9;
  }

  void Update()
  {
    if (!GameManager.instance.gamePaused) {
      SetNewDestination();
      // Set the variables for the animator
      myAnimator.SetFloat("Speed", navAgent.velocity.magnitude / navAgent.speed);
    }
  }

  /// <summary>
  /// Detect the position on the screen and move the player
  /// </summary>
  void SetNewDestination()
  {
    if(Input.touchCount == 1)
    {
      if (Input.GetTouch(0).phase != TouchPhase.Moved)
      {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
          Ray screenRay = mainCamera.ScreenPointToRay(Input.GetTouch(0).position);
          RaycastHit hit;

          if (Physics.Raycast(screenRay, out hit))
          {
            Vector3 newDestination = RandomNavCircle(
            hit.point,
            nextPositionRadius,
            -1
            );

            navAgent.SetDestination(newDestination);
          }
        }
      }
    }
  }

  /// <summary>
  /// Return a position inside a circle
  /// </summary>
  /// <param name="_originPosition"> the desired position </param>
  /// <param name="_radius"> The radius of the circle </param>
  /// <param name="_layerMask"> Layered mask </param>
  /// <returns> A position inside a circle </returns>
  Vector3 RandomNavCircle(Vector3 _originPosition, float _radius, int _layerMask)
  {
    Vector3 randomDirection = Random.insideUnitCircle * _radius;
    randomDirection += _originPosition;

    NavMeshHit navHit;

    NavMesh.SamplePosition(randomDirection, out navHit, _radius, _layerMask);

    return navHit.position;
  }

}
