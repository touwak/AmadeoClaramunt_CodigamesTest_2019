using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerBehaviour : Character
{
    override public void Navigation(Vector3 position)
    {
        if (!m_isDead)
        {
            SetNewDestination(position);
        }
    }

    private void SetNewDestination(Vector3 position)
    {
        if (position != Vector3.zero)
        {
            m_navAgent.SetDestination(RandomNavPoint(position, -1));
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Mummy"))
        {
            StartCoroutine(Dying());
        }
    }

    private IEnumerator Dying()
    {
        if (!m_isDead)
        {
            m_isDead = true;
            m_playerAnimator.SetTrigger("Dying");
            m_deadParticle.Play();
            m_navAgent.isStopped = true;

            yield return m_dyingTime;

            m_gameManager.RemovePlayer();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            m_playerAnimator.SetTrigger("PickUp");
            m_pickUpParticle.Play();
        }
    }

    [SerializeField]
    private NavMeshAgent m_navAgent;
    [SerializeField]
    private Animator m_playerAnimator;
    [SerializeField]
    private GameManager m_gameManager;
    
    [Space(10)]
    
    [SerializeField]
    private ParticleSystem m_deadParticle;
    [SerializeField]
    private ParticleSystem m_pickUpParticle;

    private bool m_isDead = false;
    private WaitForSeconds m_dyingTime = new WaitForSeconds(2.3f);
    
    private const float k_nextPositionRadius = 2.0f;
}
