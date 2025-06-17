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
        if (collision.CompareTag("Player")) // Asegúrate de que tu jugador tenga el tag "Player"
        {
            // Llamamos a GameManager
            FindObjectOfType<GameManager>().RecolectableRecogido();

            // Destruimos este recolectable
            Destroy(gameObject);
        }
    }
}