using UnityEngine;

public class PlayerNavigator : MonoBehaviour
{
    private void Start()
    {
        m_mainCamera = Camera.main;
    }

    public Vector3 GetTouchPosition()
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
                        m_touchParticle.gameObject.transform.position = hit.point;
                        m_touchParticle.Play();

                        return hit.point;
                    }
                }
            }
        }

        return Vector3.zero;
    }

    [SerializeField]
    private ParticleSystem m_touchParticle;

    private Camera m_mainCamera;
    private bool m_startMovement = false;
}
