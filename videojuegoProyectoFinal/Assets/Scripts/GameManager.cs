using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    [Header("Configuración de Vidas")]
    public int vidas = 3;
    public GameObject contenedorCorazones;
    private Image[] imagenesCorazones;

    [Header("Datos Persistentes del Jugador")]
    public bool tienePistola = false;
    public GameObject prefabPersonaje; // Arrastra tu Prefab de personaje aquí en el Inspector

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 1. Si no es el Menú, instanciamos al jugador
        // CAMBIA "MenuPrincipal" por el nombre exacto de tu escena de menú


        // 2. Buscamos y actualizamos la UI de corazones
        contenedorCorazones = GameObject.Find("ContenedorCorazones");
        if (contenedorCorazones != null)
        {
            imagenesCorazones = contenedorCorazones.GetComponentsInChildren<Image>();
            ActualizarUI();
        }
    }



    public void RestarVida()
    {
        if (vidas > 0)
        {
            vidas--;
            ActualizarUI();
        }

        if (vidas <= 0)
        {
            Debug.Log("Game Over");
            // Aquí podrías cargar una escena de Game Over o reiniciar
        }
    }

    public void ActualizarUI()
    {
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

    void ActualizarReferenciasManual()
    {
        contenedorCorazones = GameObject.Find("ContenedorCorazones");
        if (contenedorCorazones != null)
            imagenesCorazones = contenedorCorazones.GetComponentsInChildren<Image>();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}