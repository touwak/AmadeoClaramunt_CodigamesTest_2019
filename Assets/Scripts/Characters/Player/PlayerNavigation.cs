using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerNavigation : Character
{
    private void Start()
    {
        m_mainCamera = Camera.main;
    }

    override public void Updater()
    {
        SetNewDestination();
    }

    private void SetNewDestination()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                m_startMovement = false;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                m_startMovement = true;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (m_startMovement)
                {
                    Ray screenRay = m_mainCamera.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit hit;

                    if (Physics.Raycast(screenRay, out hit))
                    {
                        m_navAgent.SetDestination(RandomNavPoint(hit.point, -1));
                    }
                }
            }
        }

        if (m_navAgent.velocity.magnitude > 0f)
        {
            m_playerAnimator.SetFloat("Speed", m_navAgent.velocity.magnitude / m_navAgent.speed);
        }
    }

    private Vector3 RandomNavPoint(Vector3 originPosition, int layerMask)
    {
        Vector3 randomPosition = Random.insideUnitSphere * k_nextPositionRadius;
        randomPosition += originPosition;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPosition, out navHit, k_nextPositionRadius, layerMask);

        return navHit.position;
    }

    [SerializeField]
    private NavMeshAgent m_navAgent;
    [SerializeField]
    private Animator m_playerAnimator;
    
    private Camera m_mainCamera;
    private bool m_startMovement = false;
    
    private const float k_nextPositionRadius = 2.0f;
}
