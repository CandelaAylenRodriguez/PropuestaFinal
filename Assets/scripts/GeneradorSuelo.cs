using UnityEngine;
using System.Collections.Generic;

public class GeneradorPisoInfinito : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject prefabPiso;
    public Transform jugador;

    [Header("Configuración")]
    public int segmentosIniciales = 3;
    public float anchoSegmento = 10f;
    public bool calcularAnchoAutomatico = true;

    [Header("Configuración Avanzada")]
    public float distanciaGeneracion = 30f;
    public float distanciaEliminacion = 40f;
    public int maxSegmentos = 8;

    private float siguientePosX = 0f;
    private Queue<GameObject> segmentosActivos = new Queue<GameObject>();

    void Start()
    {
        if (calcularAnchoAutomatico && prefabPiso != null)
        {
            CalcularAnchoSegmento();
        }

        for (int i = 0; i < segmentosIniciales; i++)
        {
            GenerarSegmento();
        }
    }

    void CalcularAnchoSegmento()
    {
        SpriteRenderer spriteRenderer = prefabPiso.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && spriteRenderer.sprite != null)
        {
            float anchoSprite = spriteRenderer.sprite.bounds.size.x;
            Vector3 escala = prefabPiso.transform.localScale;
            anchoSegmento = anchoSprite * escala.x;
        }
    }

    void Update()
    {
        if (jugador == null) return;

        // Generar nuevos segmentos
        while (jugador.position.x + distanciaGeneracion > siguientePosX)
        {
            GenerarSegmento();
        }

        // Eliminar segmentos lejanos (pero no eliminar si hay una puerta)
        while (segmentosActivos.Count > 0)
        {
            GameObject primerSegmento = segmentosActivos.Peek();
            if (primerSegmento != null)
            {
                // Verificar si hay una puerta cerca antes de eliminar
                if (!HayPuertaCerca(primerSegmento.transform.position) &&
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
            else
            {
                segmentosActivos.Dequeue();
            }
        }

        while (segmentosActivos.Count > maxSegmentos)
        {
            GameObject primerSegmento = segmentosActivos.Peek();
            if (!HayPuertaCerca(primerSegmento.transform.position))
            {
                GameObject segmentoViejo = segmentosActivos.Dequeue();
                Destroy(segmentoViejo);
            }
            else
            {
                break;
            }
        }
    }

    private bool HayPuertaCerca(Vector3 posicion)
    {
        // Buscar puertas cerca para no eliminar el piso debajo de ellas
        PuertaNivel[] puertas = FindObjectsOfType<PuertaNivel>();
        foreach (PuertaNivel puerta in puertas)
        {
            if (Vector3.Distance(posicion, puerta.transform.position) < anchoSegmento * 2f)
            {
                return true;
            }
        }
        return false;
    }

    void GenerarSegmento()
    {
        Vector3 posicion = new Vector3(siguientePosX, 0.15f, 2f);
        GameObject nuevoSegmento = Instantiate(prefabPiso, posicion, Quaternion.identity);

        if (nuevoSegmento.GetComponent<SpriteRenderer>() != null)
        {
            SpriteRenderer sr = nuevoSegmento.GetComponent<SpriteRenderer>();
            sr.sortingLayerName = "Ground";
            sr.sortingOrder = 0;
        }

        segmentosActivos.Enqueue(nuevoSegmento);
        siguientePosX += anchoSegmento;
    }
}
