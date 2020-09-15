using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public void SetNumGems(int amount)
    {
        m_gemsCounterText.text = amount.ToString();
        m_gemsCounterText.transform.DOScale(1.2f, 0.15f).From();

    }

    public int RemoveLife()
    {
        Image sword = m_swords[m_swords.Count - 1];
        m_swords.RemoveAt(m_swords.Count - 1);

        Sequence anim = DOTween.Sequence();
        anim.Append(sword.transform.DOScale(1.2f, 0.15f));
        anim.OnComplete(() =>
        {
            sword.gameObject.SetActive(false);
        });

        return m_swords.Count;
    }

    [SerializeField]
    private TextMeshProUGUI m_gemsCounterText;
    [SerializeField]
    private Transform m_swordsContainer;
    [SerializeField]
    private List<Image> m_swords;
}
