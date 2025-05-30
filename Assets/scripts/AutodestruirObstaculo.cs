using UnityEngine;

public class AutodestruirObstaculo : MonoBehaviour
{
    private Transform jugador;
    public float distanciaParaDestruir = 20f;

    void Start()
    {
        // Busca el jugador automáticamente por etiqueta
        GameObject jugadorGO = GameObject.FindGameObjectWithTag("Player");
        if (jugadorGO != null)
            jugador = jugadorGO.transform;
    }

    void Update()
    {
        if (jugador == null) return;

        // Si el obstáculo está detrás del jugador cierta distancia
        if (transform.position.x < jugador.position.x - distanciaParaDestruir)
        {
            Destroy(gameObject);
        }
    }
}
