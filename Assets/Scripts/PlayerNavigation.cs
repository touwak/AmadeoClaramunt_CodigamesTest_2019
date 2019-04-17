using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavigation : MonoBehaviour
{

  #region VARIABLES
  NavMeshAgent navAgent;
  float nextPositionRadius = 2.0f;

  Camera mainCamera;

  LayerMask terrainLayerMask;
  #endregion

  private void Awake()
  {
    navAgent = GetComponent<NavMeshAgent>();
    mainCamera = Camera.main;
    terrainLayerMask = 9;
  }

  void Update()
  {
    SetNewDestination();
  }


  void SetNewDestination()
  {
    for (int i = 0; i < Input.touchCount; i++)
    {
      if(Input.GetTouch(i).phase == TouchPhase.Ended)
      {
        Ray screenRay = mainCamera.ScreenPointToRay(Input.GetTouch(i).position);
        RaycastHit hit;

        if (Physics.Raycast(screenRay, out hit))
        {
          Vector3 newDestination = RandomNavSphere(
          hit.point,
          nextPositionRadius,
          -1
          );

          Debug.Log("Destination: " + hit.point);

          navAgent.SetDestination(newDestination);
        }
      }
    }
  }

  Vector3 RandomNavSphere(Vector3 _originPosition, float _radius, int _layerMask)
  {
    Vector3 randomDirection = Random.insideUnitSphere * _radius;
    randomDirection += _originPosition;

    NavMeshHit navHit;

    NavMesh.SamplePosition(randomDirection, out navHit, _radius, _layerMask);

    return navHit.position;
  }

}
