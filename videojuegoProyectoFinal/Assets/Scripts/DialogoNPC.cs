using UnityEngine;
using TMPro;

public class DialogoNPC : MonoBehaviour
{
    public GameObject cuadroDialogo;
    public TextMeshProUGUI textoTMP;

    private bool playerEnRango = false;
    private bool historiaContada = false;

    void Start()
    {
        cuadroDialogo.SetActive(false);
    }

    void Update()
    {
        if (playerEnRango)
        {
            // Buscamos cuántos objetos con el tag "enemigo" quedan en la escena
            int enemigosRestantes = GameObject.FindGameObjectsWithTag("enemigo").Length;

            if (enemigosRestantes > 0)
            {
                // Si aún hay enemigos, sigue pidiendo socorro
                textoTMP.text = "¡¡SOCORRO!! ¡Mata a esos alienígenas!";
            }
            else if (!historiaContada)
            {
                // Si ya no hay enemigos (es 0) y no hemos contado la historia aún
                MostrarHistoria();
            }
        }
    }

    void MostrarHistoria()
    {
        textoTMP.text = "YellowMan eres tu!!, pensaba que habrías muerto, la nave ha sido tomada por unos alienígenas saqueadores, Foxy está retenido bajo el control de el comandante alien, vayamos a rescatarle!!";
        historiaContada = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerEnRango = true;
            cuadroDialogo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerEnRango = false;
            cuadroDialogo.SetActive(false);
        }
    }
}