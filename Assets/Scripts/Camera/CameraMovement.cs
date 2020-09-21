using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public void MoveCamera()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray screenRay = m_mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(screenRay, out hit))
            {
                transform.position = new Vector3( hit.point.x, transform.position.y, hit.point.z);
            }
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
    [SerializeField]
    private Camera m_mainCamera;
#endif
}
