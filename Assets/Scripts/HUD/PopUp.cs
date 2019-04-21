using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;


public class PopUp : MonoBehaviour {
  #region VARIABLES
  [SerializeField]
  public Image background;
  [SerializeField]
  public Transform content;
  [SerializeField]
  public Button startButton;

  public UnityEvent onClose;

  [HideInInspector]
  public bool opened = false;
  #endregion

  /// <summary>
  /// Switch between the open and closed animation
  /// </summary>
  public void toggle()
  {
    if (!opened)
    {
      Sequence popupAnimation;
      gameObject.SetActive(true);
      popupAnimation = DOTween.Sequence();
      popupAnimation.Append(background.DOFade(0, 0.5f).From().SetEase(Ease.Linear));
      popupAnimation.Join(content.DOScale(0, 0.5f).From().SetEase(Ease.OutBack));
      popupAnimation.OnComplete(() => startButton.interactable = true);
      opened = true;
    }
    else
    {
      Sequence popupAnimation;
      popupAnimation = DOTween.Sequence();
      popupAnimation.OnStart(() => startButton.interactable = false);
      popupAnimation.Append(background.DOFade(0, 0.5f).SetEase(Ease.Linear));
      popupAnimation.Join(content.DOScale(0, 0.5f).SetEase(Ease.InBack));
      popupAnimation.OnComplete(() => onClose.Invoke());
      opened = false;
    }
  }

}
