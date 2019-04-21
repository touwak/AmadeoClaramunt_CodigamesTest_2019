using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  #region VARIABLES
  [SerializeField]
  private float speed = 0.1f;
  #endregion


  void Update()
  {
    MoveCamera();
  }

  /// <summary>
  /// Move the camera with two fingers
  /// </summary>
  void MoveCamera()
  {
    if(Input.touchCount == 2)
    {
      if(Input.GetTouch(0).phase == TouchPhase.Moved)
      {
        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        transform.Translate(-touchDeltaPosition.x * speed, 0, -touchDeltaPosition.y * speed, Space.Self);
      }
    }
  }

}
