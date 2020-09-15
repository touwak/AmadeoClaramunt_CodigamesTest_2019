using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Mummy"))
        {
            m_gameManager.RemovePlayer();
            gameObject.SetActive(false);
        }
    }

    [SerializeField]
    GameManager m_gameManager;
}
