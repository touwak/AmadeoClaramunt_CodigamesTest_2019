using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GemBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
            Sequence anim = DOTween.Sequence();
            anim.Append(transform.DOLocalMoveY(transform.localPosition.y + 0.5f, 0.5f).SetEase(Ease.OutBack));
            anim.Join(transform.DOLocalRotate(Vector3.up * 180, 0.5f).SetEase(Ease.Linear));
            anim.Append(transform.DOScale(Vector3.zero, 0.25f).SetEase(Ease.InBack));
            anim.OnComplete(() =>
            {
                m_gameManager.RestAGem();
                gameObject.SetActive(false);
            });

        }
    }

    [SerializeField]
    GameManager m_gameManager;
}
