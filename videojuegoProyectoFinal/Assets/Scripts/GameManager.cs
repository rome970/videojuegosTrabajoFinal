using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Importante para detectar el cambio de escena

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public int vidas = 3;

    public GameObject contenedorCorazones;
    private Image[] imagenesCorazones;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);

            // Suscribirse al evento de cambio de escena
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Esta función se ejecuta SOLA cada vez que cambias de escena
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 1. Buscamos el contenedor en la nueva escena por su nombre
        contenedorCorazones = GameObject.Find("ContenedorCorazones");

        if (contenedorCorazones != null)
        {
            // 2. Obtenemos las imágenes de los corazones nuevos
            imagenesCorazones = contenedorCorazones.GetComponentsInChildren<Image>();
            // 3. Refrescamos la UI para que coincida con las vidas actuales
            ActualizarUI();
        }
    }

    public void RestarVida()
    {
        if (vidas > 0)
        {
            vidas--;
            Debug.Log("Vida restada. Quedan: " + vidas);
            ActualizarUI();
        }
    }

    public void ActualizarUI()
    {
        // Si por alguna razón no los tiene, intentamos buscarlos de nuevo
        if (imagenesCorazones == null || imagenesCorazones.Length == 0)
        {
            ActualizarReferenciasManual();
        }

        if (imagenesCorazones != null)
        {
            for (int i = 0; i < imagenesCorazones.Length; i++)
            {
                imagenesCorazones[i].enabled = (i < vidas);
            }
        }
    }

    // Método de apoyo
    void ActualizarReferenciasManual()
    {
        contenedorCorazones = GameObject.Find("ContenedorCorazones");
        if (contenedorCorazones != null)
            imagenesCorazones = contenedorCorazones.GetComponentsInChildren<Image>();
    }

    private void OnDestroy()
    {
        // Limpieza del evento al destruir el objeto
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}