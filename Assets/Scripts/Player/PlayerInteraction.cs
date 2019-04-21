using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
  private void OnCollisionEnter(Collision _collision)
  {
    // Mummy
    if (_collision.collider.CompareTag("Mummy"))
    {
      // Disable the player and rest a life
      gameObject.SetActive(false);
      GameManager.instance.removePlayer();
    }
  }
}
