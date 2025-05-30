using UnityEngine;
using System.Collections.Generic;

public class GeneradorPisoInfinito : MonoBehaviour
{
    public GameObject prefabPiso;      // Prefab del piso (con pivot abajo)
    public Transform jugador;           // Referencia al jugador
    public int segmentosIniciales = 3;  // Cantidad inicial de segmentos para empezar
    public float anchoSegmento = 10f;   // Ancho real de cada segmento de piso (unidades Unity)

    private float siguientePosX = 0f;   // Posición en X para el siguiente segmento
    private Queue<GameObject> segmentosActivos = new Queue<GameObject>();

    void Start()
    {
        // Generar segmentos iniciales
        for (int i = 0; i < segmentosIniciales; i++)
        {
            GenerarSegmento();
        }
    }

    void Update()
    {
        // Cuando el jugador se acerca al final del último segmento, generamos más
        if (jugador.position.x + (segmentosIniciales * anchoSegmento) > siguientePosX)
        {
            GenerarSegmento();

            // Para no saturar, eliminamos segmentos que quedan muy atrás
            if (segmentosActivos.Count > segmentosIniciales + 2)
            {
                GameObject segmentoViejo = segmentosActivos.Dequeue();
                Destroy(segmentoViejo);
            }
        }
    }

    void GenerarSegmento()
    {
        // Posición para el nuevo segmento: en X la siguientePosX, en Y 0 para que quede en la base
        Vector3 posicion = new Vector3(siguientePosX, 0f, 0f);

        GameObject nuevoSegmento = Instantiate(prefabPiso, posicion, Quaternion.identity);

        segmentosActivos.Enqueue(nuevoSegmento);

        siguientePosX += anchoSegmento; // Actualizamos la X para el próximo segmento
    }
}
