using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public void CalculateFPS()
    {
        m_deltaTime += (Time.unscaledDeltaTime - m_deltaTime) * 0.1f;
        float fps = 1.0f / m_deltaTime;

        m_fpsText.text = fps.ToString("F0");
    }

    [SerializeField]
    private TextMeshProUGUI m_fpsText;
    private float m_deltaTime = 0.0f;
}
