using UnityEngine;
using UnityEngine.SceneManagement;

public class comportamientoPlayer : MonoBehaviour
{

    public Animator animator;
    public float velocidad = 8f;
    public float fuerzaSalto = 12f;
    public bool estaSuelo;
    public Transform puntoDisparo;
    public GameObject prefabBala;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Disparar();
        }

    }

    void FixedUpdate()
    {
        bool seMueve = false;

        if (Input.GetKey(KeyCode.A))
        {
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            transform.position -= new Vector3(5, 0, 0) * velocidad * Time.deltaTime;
            seMueve = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            transform.position += new Vector3(5, 0, 0) * velocidad * Time.deltaTime;
            seMueve = true;
        }

        animator.SetBool("seMueve", seMueve);

        if (Input.GetKey(KeyCode.W) && estaSuelo)
        {

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 175));

        }

    }

    void morir()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Suelo")
        {
            estaSuelo = true;
        }

        if (collision.collider.tag == "puertaAScena2")
        {
            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.CompareTag("enemigo"))
        {
            // El GameManager es quien lleva la cuenta real
            GameManager.instancia.RestarVida();

            // Si quieres comprobar si murió para destruir al jugador:
            if (GameManager.instancia.vidas <= 0)
            {
                morir();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Suelo")
        {

            estaSuelo = false;
        }
    }

    void Disparar()
    {

        animator.SetTrigger("disparar");
        Instantiate(prefabBala, puntoDisparo.position, puntoDisparo.rotation);
    }

}