using UnityEngine;
using UnityEngine.SceneManagement;

public class ComportamientoPuerta : MonoBehaviour
{
    [Header("Configuración")]
    public string Scena2; // Escribe el nombre de tu siguiente nivel
    public KeyCode teclaParaEntrar = KeyCode.E; // Tecla para "tocar" o entrar

    private bool jugadorCerca = false;

    private void Update()
    {
        // Si el jugador está en el área y presiona la tecla
        if (jugadorCerca && Input.GetKeyDown(teclaParaEntrar))
        {
            EntrarEnPuerta();
        }
    }

    private void EntrarEnPuerta()
    {
        // Al cargar la escena, el GameManager ya tiene las vidas guardadas
        // porque es un Singleton con DontDestroyOnLoad.
        SceneManager.LoadScene(Scena2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = true;
            Debug.Log("Presiona " + teclaParaEntrar + " para entrar");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}