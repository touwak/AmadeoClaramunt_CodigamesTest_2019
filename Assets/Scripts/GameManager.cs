﻿using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public void RemovePlayer()
    {
        m_camera.DOShakePosition(0.5f);
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
                character.Navigation(m_playerNavigator.GetTouchPosition());
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
    [SerializeField]
    private PlayerNavigator m_playerNavigator;

    [Space(10)]

    [SerializeField]
    private CameraMovement m_cameraMovement;
    [SerializeField]
    private Transform m_camera;

    [Space(10)]

    [SerializeField]
    private List<Character> m_characters;

    private bool m_gamePaused = true;
    private int m_totalGems = 10;
}
