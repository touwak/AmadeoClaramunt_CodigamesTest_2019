using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
  #region VARIABLES
  [SerializeField]
  private TextMeshProUGUI fpsText;
  private float deltaTime = 0.0f;
  #endregion


  private void Update()
  {
    CalculateFPS();
  }

  /// <summary>
  /// Calculate the FPS
  /// </summary>
  private void CalculateFPS()
  {
    deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    float fps = 1.0f / deltaTime;

    fpsText.text = fps.ToString("F0");
  }
}
