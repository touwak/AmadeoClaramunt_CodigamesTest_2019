using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class HUDController : MonoBehaviour
{
  #region VARIABLES
  [SerializeField]
  private TextMeshProUGUI gemsCounterText;
  [SerializeField]
  private Transform swordsContainer;
  #endregion

  /// <summary>
  /// Set the number of gems in the HUD
  /// </summary>
  /// <param name="_amount"> Amount of current gems in the game </param>
  public void SetNumGems(int _amount)
  {
    gemsCounterText.text = _amount.ToString();
    gemsCounterText.transform.DOScale(1.2f, 0.15f).From();
    
  }

  /// <summary>
  /// Remove a life of the HUD
  /// </summary>
  /// <returns> The number of players alive </returns>
  public int RemoveLife()
  {
    Image[] swords = swordsContainer.GetComponentsInChildren<Image>();

    Sequence anim = DOTween.Sequence();
    anim.Append(swords[swords.Length - 1].transform.DOScale(1.2f, 0.15f));
    anim.OnComplete(() =>
    {
      swords[swords.Length - 1].gameObject.SetActive(false);
    });
    
    return swords.Length -2;
  }
}
