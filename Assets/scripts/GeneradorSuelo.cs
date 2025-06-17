using UnityEngine;
using System.Collections.Generic;

public class GeneradorPisoInfinito : MonoBehaviour
{
    //public GameObject prefabPiso;      // Prefab del piso (con pivot abajo)
    //public Transform jugador;           // Referencia al jugador
    //public int segmentosIniciales = 3;  // Cantidad inicial de segmentos para empezar
    //public float anchoSegmento = 10f;   // Ancho real de cada segmento de piso (unidades Unity)

    //private float siguientePosX = 0f;   // Posición en X para el siguiente segmento
    //private Queue<GameObject> segmentosActivos = new Queue<GameObject>();

    //void Start()
    //{
    //    // Generar segmentos iniciales
    //    for (int i = 0; i < segmentosIniciales; i++)
    //    {
    //        GenerarSegmento();
    //    }
    //}

    //void Update()
    //{
    //    // Cuando el jugador se acerca al final del último segmento, generamos más
    //    if (jugador.position.x + (segmentosIniciales * anchoSegmento) > siguientePosX)
    //    {
    //        GenerarSegmento();

    //        // Para no saturar, eliminamos segmentos que quedan muy atrás
    //        if (segmentosActivos.Count > segmentosIniciales + 2)
    //        {
    //            GameObject segmentoViejo = segmentosActivos.Dequeue();
    //            Destroy(segmentoViejo);
    //        }
    //    }
    //}

    //void GenerarSegmento()
    //{
    //    // Posición para el nuevo segmento: en X la siguientePosX, en Y 0 para que quede en la base
    //    Vector3 posicion = new Vector3(siguientePosX, 0f, 0f);

    //    GameObject nuevoSegmento = Instantiate(prefabPiso, posicion, Quaternion.identity);

    //    segmentosActivos.Enqueue(nuevoSegmento);

    //    siguientePosX += anchoSegmento; // Actualizamos la X para el próximo segmento
    //}

    [Header("Referencias")]
    public GameObject prefabPiso;      // Prefab del piso con SpriteRenderer
    public Transform jugador;          // Referencia al jugador

    [Header("Configuración")]
    public int segmentosIniciales = 3;
    public float anchoSegmento = 10f;   // Se calculará automáticamente del sprite
    public bool calcularAnchoAutomatico = true; // Calcular ancho del sprite automáticamente

    [Header("Configuración Avanzada")]
    public float distanciaGeneracion = 30f;    // Distancia adelante para generar
    public float distanciaEliminacion = 40f;   // Distancia atrás para eliminar
    public int maxSegmentos = 8;               // Máximo de segmentos activos

    private float siguientePosX = 0f;
    private Queue<GameObject> segmentosActivos = new Queue<GameObject>();

    void Start()
    {
        // Calcular ancho automáticamente si está habilitado
        if (calcularAnchoAutomatico && prefabPiso != null)
        {
            CalcularAnchoSegmento();
        }

        // Generar segmentos iniciales
        for (int i = 0; i < segmentosIniciales; i++)
        {
            GenerarSegmento();
        }
    }

    void CalcularAnchoSegmento()
    {
        // Buscar SpriteRenderer en el prefab
        SpriteRenderer spriteRenderer = prefabPiso.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && spriteRenderer.sprite != null)
        {
            // Obtener el ancho real del sprite considerando la escala
            float anchoSprite = spriteRenderer.sprite.bounds.size.x;
            Vector3 escala = prefabPiso.transform.localScale;
            anchoSegmento = anchoSprite * escala.x;

            Debug.Log($"Ancho calculado automáticamente: {anchoSegmento} unidades");
        }
        else
        {
            Debug.LogWarning("No se encontró SpriteRenderer en el prefab. Usando ancho manual.");
        }
    }

    void Update()
    {
        if (jugador == null) return;

        // Generar nuevos segmentos cuando el jugador se acerca
        while (jugador.position.x + distanciaGeneracion > siguientePosX)
        {
            GenerarSegmento();
        }

        // Eliminar segmentos que están muy atrás
        while (segmentosActivos.Count > 0)
        {
            GameObject primerSegmento = segmentosActivos.Peek();
            if (primerSegmento != null &&
                primerSegmento.transform.position.x < jugador.position.x - distanciaEliminacion)
            {
                GameObject segmentoViejo = segmentosActivos.Dequeue();
                Destroy(segmentoViejo);
            }
            else
            {
                break;
            }
        }

        // Limitar el número máximo de segmentos
        while (segmentosActivos.Count > maxSegmentos)
        {
            GameObject segmentoViejo = segmentosActivos.Dequeue();
            Destroy(segmentoViejo);
        }
    }

    void GenerarSegmento()
    {
        // Posición para el nuevo segmento
        Vector3 posicion = new Vector3(siguientePosX, 0.15f, 2f);
        GameObject nuevoSegmento = Instantiate(prefabPiso, posicion, Quaternion.identity);

        // Asegurar que esté en la capa correcta (opcional)
        if (nuevoSegmento.GetComponent<SpriteRenderer>() != null)
        {
            SpriteRenderer sr = nuevoSegmento.GetComponent<SpriteRenderer>();
            sr.sortingLayerName = "Ground"; // Cambia por tu sorting layer
            sr.sortingOrder = 0;
        }

        segmentosActivos.Enqueue(nuevoSegmento);
        siguientePosX += anchoSegmento;
    }

    // Método para recalcular ancho si cambias el prefab en runtime
    [ContextMenu("Recalcular Ancho Segmento")]
    public void RecalcularAnchoSegmento()
    {
        CalcularAnchoSegmento();
    }

    // Debug visual
    void OnDrawGizmos()
    {
        if (jugador == null) return;

        // Línea roja: límite de eliminación
        Gizmos.color = Color.red;
        Vector3 limiteElim = new Vector3(jugador.position.x - distanciaEliminacion, -2f, 0f);
        Gizmos.DrawLine(limiteElim, limiteElim + Vector3.up * 4f);

        // Línea verde: límite de generación
        Gizmos.color = Color.green;
        Vector3 limiteGen = new Vector3(jugador.position.x + distanciaGeneracion, -2f, 0f);
        Gizmos.DrawLine(limiteGen, limiteGen + Vector3.up * 4f);

        // Línea azul: posición del jugador
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(jugador.position + Vector3.down * 2f, jugador.position + Vector3.up * 2f);

        // Información de debug
        if (Application.isPlaying)
        {
            Gizmos.color = Color.yellow;
            Vector3 proximoSegmento = new Vector3(siguientePosX, -1f, 0f);
            Gizmos.DrawWireCube(proximoSegmento, new Vector3(anchoSegmento, 0.2f, 0f));
        }
    }
}
