using UnityEngine;

public class PlayerNavigator : MonoBehaviour
{
    private void Start()
    {
        m_mainCamera = Camera.main;
    }

    public Vector3 GetTouchPosition()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            m_startMovement = true;
            m_clickPosition = Input.mousePosition;
        }

        if (m_startMovement)
        {
            if (Vector3.Distance(Input.mousePosition, m_clickPosition) > k_maxGap)
            {
                m_startMovement = false;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (m_startMovement)
                {
                    Ray screenRay = m_mainCamera.ScreenPointToRay(m_clickPosition);
                    RaycastHit hit;

                    if (Physics.Raycast(screenRay, out hit))
                    {
                        m_touchParticle.gameObject.transform.position = hit.point;
                        m_touchParticle.Play();

                        return hit.point;
                    }
                }
            }
        }

        return Vector3.zero;
#else
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
                        m_touchParticle.gameObject.transform.position = hit.point;
                        m_touchParticle.Play();

                        return hit.point;
                    }
                }
            }
        }

        return Vector3.zero;
#endif
    }

    [SerializeField]
    private ParticleSystem m_touchParticle;

    private Camera m_mainCamera;
    private bool m_startMovement = false;

#if UNITY_EDITOR
    private Vector3 m_clickPosition;
    private const float k_maxGap = 2;
#endif
}
