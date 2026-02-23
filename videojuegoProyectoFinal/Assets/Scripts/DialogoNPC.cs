using UnityEngine;
using TMPro; // Necesario si usas TextMeshPro

public class DialogoNPC : MonoBehaviour
{
    public GameObject cuadroDialogo; // Arrastra aquí tu Canvas

    void Start()
    {
        cuadroDialogo.SetActive(false); // Aseguramos que empiece apagado
    }

    // Se activa al entrar en el área del NPC
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Algo ha entrado en el trigger: " + collision.name); // Esto imprimirá el nombre en la consola
        if (collision.CompareTag("Player"))
        {
            cuadroDialogo.SetActive(true);
        }
    }

    // Se desactiva al alejarse
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cuadroDialogo.SetActive(false);
        }
    }
}