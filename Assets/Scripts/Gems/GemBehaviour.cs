using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider))]
public class GemBehaviour : MonoBehaviour
{
  private void OnTriggerEnter(Collider _other)
  {
    if (_other.CompareTag("Player"))
    {
      GetComponent<Collider>().enabled = false;
      Sequence anim = DOTween.Sequence();
      anim.Append(transform.DOLocalMoveY(transform.localPosition.y + 0.5f, 0.5f).SetEase(Ease.OutBack));
      anim.Join(transform.DOLocalRotate(Vector3.up * 180, 0.5f).SetEase(Ease.Linear));
      anim.Append(transform.DOScale(Vector3.zero, 0.25f).SetEase(Ease.InBack));
      anim.OnComplete(() => {
        GameManager.instance.TotalGems--;
        gameObject.SetActive(false);
      });
      
    }
  }

}
