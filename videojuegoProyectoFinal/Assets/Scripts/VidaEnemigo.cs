using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public float salud = 50f;

    public void TomarDano(float cantidad)
    {
        salud -= cantidad;
        Debug.Log("Vida del NPC: " + salud);

        if (salud <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {

        Destroy(gameObject);
    }
}