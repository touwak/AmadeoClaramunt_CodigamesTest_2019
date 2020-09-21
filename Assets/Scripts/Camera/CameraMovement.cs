using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public void MoveCamera()
    {
#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            m_clickPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            m_delta = Input.mousePosition - m_clickPosition;

            m_delta = new Vector2(m_delta.x / Screen.width, m_delta.y / Screen.height) * k_mouseCameraSpeed;
            Vector3 deltaPosFixed = new Vector3(m_delta.x, 0, m_delta.y);
            transform.position -= deltaPosFixed;

            m_clickPosition = Input.mousePosition;
        }

#else
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Translate(-touchDeltaPosition.x * m_speed, 0, -touchDeltaPosition.y * m_speed, Space.Self);
            }
        }
#endif
    }

    [SerializeField]
    private float m_speed = 0.1f;

#if UNITY_EDITOR
    private Vector3 m_clickPosition, m_delta;
    private const float k_mouseCameraSpeed = 10f;
#endif
}
