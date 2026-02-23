using UnityEngine;
using UnityEngine.SceneManagement;
public class menuPrincipal : MonoBehaviour
{
    void Update()
    {


    }


    public void botonInicio()
    {

        // Accedemos a la instancia y reseteamos la vida antes de cargar
        if (GameManager.instancia != null)
        {
            GameManager.instancia.vidas = 3;
        }

        SceneManager.LoadScene("Scena1");
    }
}
