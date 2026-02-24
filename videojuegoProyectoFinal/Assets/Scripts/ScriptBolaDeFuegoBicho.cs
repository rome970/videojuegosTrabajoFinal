using UnityEngine;

public class BulletEnemigo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.instancia != null)
            {
                GameManager.instancia.RestarVida();
            }
            else
            {
                Debug.LogError("GameManager es NULL");
            }

            Destroy(gameObject);
        }
    }
}