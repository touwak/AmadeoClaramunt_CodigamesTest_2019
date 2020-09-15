using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PopUp : MonoBehaviour
{
    public void Toggle()
    {
        if (!m_opened)
        {
            Sequence popupAnimation;
            gameObject.SetActive(true);
            popupAnimation = DOTween.Sequence();
            popupAnimation.Append(m_background.DOFade(0, 0.5f).From().SetEase(Ease.Linear));
            popupAnimation.Join(m_content.DOScale(0, 0.5f).From().SetEase(Ease.OutBack));
            popupAnimation.OnComplete(() => m_startButton.interactable = true);
            m_opened = true;
        }
        else
        {
            Sequence popupAnimation;
            popupAnimation = DOTween.Sequence();
            popupAnimation.OnStart(() => m_startButton.interactable = false);
            popupAnimation.Append(m_background.DOFade(0, 0.5f).SetEase(Ease.Linear));
            popupAnimation.Join(m_content.DOScale(0, 0.5f).SetEase(Ease.InBack));
            m_opened = false;
        }
    }

    [SerializeField]
    private Image m_background;
    [SerializeField]
    private Transform m_content;
    [SerializeField]
    private Button m_startButton;
    [SerializeField]
    private bool m_opened = false;
}
