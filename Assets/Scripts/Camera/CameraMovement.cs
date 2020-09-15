using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public void MoveCamera()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Translate(-touchDeltaPosition.x * m_speed, 0, -touchDeltaPosition.y * m_speed, Space.Self);
            }
        }
    }

    [SerializeField]
    private float m_speed = 0.1f;
}
