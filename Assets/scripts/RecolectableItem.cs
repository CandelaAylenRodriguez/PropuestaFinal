using UnityEngine;

public class Recolectable : MonoBehaviour
{
    private Transform jugadorTransform;

    void Start()
    {
        jugadorTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (jugadorTransform != null)
        {
            // Si el recolectable quedó 5 unidades atrás del jugador, lo destruimos
            if (transform.position.x < jugadorTransform.position.x - 5f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Incrementamos las piezas desbloqueadas
            GameProgress.piezasDesbloqueadas++;

            // Notificamos al sistema de rompecabezas
            RompecabezasManager rompecabezasManager = FindObjectOfType<RompecabezasManager>();
            if (rompecabezasManager != null)
            {
                rompecabezasManager.ActualizarRompecabezas();
            }

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.ReproducirSonidoRecolectable();
            }

            // Llamamos a GameManager si existe
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.RecolectableRecogido();
            }

            GameProgress.SumarPuntaje(500);

            // Destruimos este recolectable
            Destroy(gameObject);
        }
    }
}