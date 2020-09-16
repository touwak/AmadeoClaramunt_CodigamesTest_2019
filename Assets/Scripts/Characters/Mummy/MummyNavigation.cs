using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MummyNavigation : Character
{
    override public void Updater()
    {
        GoToNextPoint();
    }

    private void GoToNextPoint()
    {
        if (!m_navAgent.pathPending && m_navAgent.remainingDistance < 0.5f)
        {
            m_navAgent.SetDestination(m_points[m_destPoint].position);
            m_destPoint = (m_destPoint + 1) % m_points.Length;
        }
    }

    [SerializeField]
    private NavMeshAgent m_navAgent;
    [SerializeField]
    private Transform[] m_points;
    private int m_destPoint = 0;
}
