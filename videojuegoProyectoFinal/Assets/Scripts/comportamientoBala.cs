using UnityEngine;

public class comportamientoBala : MonoBehaviour
{
    public float velocidad = 20f;

    public float dano = 10f;
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * velocidad;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        VidaEnemigo enemigo = collision.GetComponent<VidaEnemigo>();

        if (enemigo != null)
        {
            enemigo.TomarDano(dano);
            Destroy(gameObject);
        }


        if (collision.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
        }
    }
}
