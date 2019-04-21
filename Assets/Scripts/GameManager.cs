using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  #region VARIABLES
  public static GameManager instance;
  [SerializeField] private HUDController HUD;
  [SerializeField] private Transform gemsParent;
  [SerializeField] private PopUp startPopUp;
  [SerializeField] private PopUp endPopUp;

  [HideInInspector]
  public Camera mainCamera;

  [HideInInspector]
  public bool gamePaused;

  private int totalPlayersAlife;

  // Gems
  int totalGems;
  public int TotalGems 
    {
    get 
      {
      return gemsParent.childCount;
    }
    set 
      {
      totalGems = value;
      HUD.SetNumGems(totalGems);

      // Check if the player has take all the gems and finish the game
      if(totalGems <= 0)
      {
        GameOver();
      }
    }
  }
  #endregion

  private void Awake()
  {
    DontDestroyOnLoad(gameObject);

    // Singleton
    if (instance == null)
    {
      instance = this;
    }
    else if (instance != this)
    {
      Destroy(gameObject);
    }

    // Set the camera
    mainCamera = Camera.main;

    gamePaused = true;
  }

  private void Start()
  {
    startPopUp.onClose.AddListener(StartGame);
    startPopUp.toggle();

    TotalGems = gemsParent.childCount;
  }

  /// <summary>
  /// Remove one player and check if is game over
  /// </summary>
  public void removePlayer()
  {
    totalPlayersAlife = HUD.RemoveLife();
    
    if(totalPlayersAlife <= 0)
    {
      GameOver();
    }
  }

  /// <summary>
  /// Start the game
  /// </summary>
  private void StartGame()
  {
    gamePaused = false;
  }

  /// <summary>
  /// Finish the game
  /// </summary>
  private void GameOver()
  {
    gamePaused = true;
    endPopUp.toggle();
  }
}
