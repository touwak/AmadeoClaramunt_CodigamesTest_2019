using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void RemovePlayer()
    {
        if (m_Hud.RemoveLife() <= 0)
        {
            GameOver();
        }
    }

    public void RestAGem()
    {
        m_totalGems--;
        m_Hud.SetNumGems(m_totalGems);

        if (m_totalGems <= 0)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        m_gamePaused = false;
    }

    private void Update()
    {
        if (!m_gamePaused)
        {
            foreach (var character in m_characters)
            {
                character.Updater();
            }

            m_cameraMovement.MoveCamera();
        }

        m_fpsCounter.CalculateFPS();
    }

    private void GameOver()
    {
        m_gamePaused = true;
        m_endPopUp.Toggle();
    }

    
    [SerializeField]
    private HUDController m_Hud;
    [SerializeField]
    private PopUp m_endPopUp;
    [SerializeField]
    private FPSCounter m_fpsCounter;

    [Space(10)]

    [SerializeField]
    private CameraMovement m_cameraMovement;

    [Space(10)]

    [SerializeField]
    private List<Character> m_characters;

    private bool m_gamePaused = true;
    private int m_totalGems = 10;
}
