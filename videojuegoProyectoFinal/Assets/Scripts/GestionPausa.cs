using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionPausa : MonoBehaviour
{
    public GameObject objetoMenuPausa;
    private bool juegoPausado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
        objetoMenuPausa.SetActive(false);
        Time.timeScale = 1f; // El tiempo vuelve a la normalidad
        juegoPausado = false;
    }

    void Pausar()
    {
        objetoMenuPausa.SetActive(true);
        Time.timeScale = 0f; // Congela el movimiento del juego
        juegoPausado = true;
    }

    public void IrAlMenuPrincipal()
    {
        Time.timeScale = 1f; // ¡Importante! Si no, el menú principal estará congelado
        SceneManager.LoadScene("ScenaMenu"); // Cambia esto por el nombre real
    }
}