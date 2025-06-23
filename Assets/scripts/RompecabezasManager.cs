using UnityEngine;
using UnityEngine.UI;

public class RompecabezasManager : MonoBehaviour
{
    [Header("Configuración del Rompecabezas")]
    public Sprite[] piezasRompecabezas;
    public Image imagenRompecabezas;

    [Header("Configuración de Seguimiento")]
    private Transform jugadorTransform;
    public Vector3 offset = new Vector3(-8f, 4f, 0f);

    [Header("Sistema de Puerta")]
    public GameObject prefabPuerta; // Prefab de la puerta
    public float distanciaAparicionPuerta = 15f; // Distancia adelante del jugador donde aparece
    public float tiempoVisibleRompecabezas = 2f; // Tiempo que el rompecabezas permanece visible

    private bool rompecabezasCompletado = false;
    private bool puertaGenerada = false;
    private GameObject puertaInstanciada;
    public SpawnerObstaculos spawnerObstaculos;

    void Start()
    {
        jugadorTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (imagenRompecabezas != null)
        {
            RectTransform rectTransform = imagenRompecabezas.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(150f, 200f);
            }

            Canvas canvas = imagenRompecabezas.GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                canvas.sortingOrder = 1;
            }
        }

        ActualizarRompecabezas();
    }

    void Update()
    {
        if (jugadorTransform != null)
        {
            transform.position = new Vector3(jugadorTransform.position.x, 0f, 0f) + offset;
        }
    }

    public void ActualizarRompecabezas()
    {
        if (imagenRompecabezas == null || piezasRompecabezas == null) return;

        RectTransform rectTransform = imagenRompecabezas.GetComponent<RectTransform>();

        if (GameProgress.piezasDesbloqueadas > 0 && GameProgress.piezasDesbloqueadas <= piezasRompecabezas.Length)
        {
            int indicePieza = GameProgress.piezasDesbloqueadas - 1;
            imagenRompecabezas.sprite = piezasRompecabezas[indicePieza];
            imagenRompecabezas.enabled = true;

            imagenRompecabezas.rectTransform.sizeDelta = new Vector2(150f, 200f);

            if (rectTransform != null)
            {
                Vector3 posicion = rectTransform.localPosition;
                posicion.z = -1f;
                rectTransform.localPosition = posicion;
            }

            if (RompecabezasCompleto() && !rompecabezasCompletado)
            {
                rompecabezasCompletado = true;
                StartCoroutine(ProcesarRompecabezasCompleto());
            }
            else if (!RompecabezasCompleto())
            {
                StartCoroutine(EfectoNuevaPieza());
            }
        }
    }

    private System.Collections.IEnumerator ProcesarRompecabezasCompleto()
    {
        // Efecto de rompecabezas completado
        yield return StartCoroutine(EfectoRompecabezasCompleto());

        // Mantener visible por el tiempo especificado
        yield return new WaitForSeconds(tiempoVisibleRompecabezas);

        // Hacer desaparecer el rompecabezas
        yield return StartCoroutine(DesaparecerRompecabezas());

        // Generar la puerta
        GenerarPuerta();
    }

    private System.Collections.IEnumerator EfectoRompecabezasCompleto()
    {
        // Efecto especial cuando se completa
        Vector3 escalaOriginal = imagenRompecabezas.transform.localScale;

        // Crecer y brillar
        float tiempo = 0f;
        while (tiempo < 0.5f)
        {
            tiempo += Time.deltaTime;
            float factor = Mathf.Lerp(1f, 1.3f, tiempo / 0.5f);
            imagenRompecabezas.transform.localScale = escalaOriginal * factor;

            // Efecto de parpadeo
            Color color = imagenRompecabezas.color;
            color.a = Mathf.Lerp(1f, 0.7f, Mathf.PingPong(tiempo * 4f, 1f));
            imagenRompecabezas.color = color;

            yield return null;
        }

        // Restaurar escala y color
        imagenRompecabezas.transform.localScale = escalaOriginal;
        Color colorFinal = imagenRompecabezas.color;
        colorFinal.a = 1f;
        imagenRompecabezas.color = colorFinal;
    }

    private System.Collections.IEnumerator DesaparecerRompecabezas()
    {
        float tiempo = 0f;
        Vector3 escalaOriginal = imagenRompecabezas.transform.localScale;
        Color colorOriginal = imagenRompecabezas.color;

        while (tiempo < 0.5f)
        {
            tiempo += Time.deltaTime;
            float factor = Mathf.Lerp(1f, 0f, tiempo / 0.5f);

            imagenRompecabezas.transform.localScale = escalaOriginal * factor;

            Color color = colorOriginal;
            color.a = factor;
            imagenRompecabezas.color = color;

            yield return null;
        }

        imagenRompecabezas.enabled = false;
    }

    //private void GenerarPuerta()
    //{
    //    if (prefabPuerta == null || puertaGenerada || jugadorTransform == null) return;

    //    // Posición de la puerta: adelante del jugador
    //    Vector3 posicionPuerta = new Vector3(
    //        jugadorTransform.position.x + distanciaAparicionPuerta,
    //        3f, // Ajusta según tu juego
    //        0f  // En el mismo plano que el jugador
    //    );

    //    puertaInstanciada = Instantiate(prefabPuerta, posicionPuerta, Quaternion.identity);
    //    puertaGenerada = true;

    //    Debug.Log("¡Puerta generada! El rompecabezas ha sido completado.");
    //}
    private void GenerarPuerta()
    {
        if (prefabPuerta == null || puertaGenerada || jugadorTransform == null) return;

        float posicionBaseJugador = jugadorTransform.position.x;
        float distanciaMinima = posicionBaseJugador + distanciaAparicionPuerta;
        float posXPuerta = distanciaMinima;

        // Intentar colocar entre obstáculos
        if (spawnerObstaculos != null && spawnerObstaculos.posicionesObstaculosX.Count >= 2)
        {
            // Filtrar solo los obstáculos que estén adelante del jugador
            var obstaculosAdelante = new System.Collections.Generic.List<float>();
            foreach (float x in spawnerObstaculos.posicionesObstaculosX)
            {
                if (x > distanciaMinima)
                    obstaculosAdelante.Add(x);
            }

            if (obstaculosAdelante.Count >= 2)
            {
                float x1 = obstaculosAdelante[0];
                float x2 = obstaculosAdelante[1];

                // Solo si hay suficiente espacio (por ejemplo, más de 4 unidades)
                if (Mathf.Abs(x2 - x1) >= 4f)
                {
                    posXPuerta = (x1 + x2) / 2f;
                }
                else
                {
                    Debug.Log("No hay suficiente espacio entre obstáculos, usando posición por defecto.");
                }
            }
        }

        // Altura de la puerta (ajustada cerca del piso)
        float alturaPuerta = 3f;

        Vector3 posicionPuerta = new Vector3(posXPuerta, alturaPuerta, 0f);

        puertaInstanciada = Instantiate(prefabPuerta, posicionPuerta, Quaternion.identity);
        puertaGenerada = true;
    }

    private System.Collections.IEnumerator EfectoNuevaPieza()
    {
        Vector3 escalaOriginal = imagenRompecabezas.transform.localScale;
        imagenRompecabezas.transform.localScale = escalaOriginal * 1.2f;

        float tiempo = 0f;
        while (tiempo < 0.3f)
        {
            tiempo += Time.deltaTime;
            float factor = Mathf.Lerp(1.2f, 1f, tiempo / 0.3f);
            imagenRompecabezas.transform.localScale = escalaOriginal * factor;
            yield return null;
        }

        imagenRompecabezas.transform.localScale = escalaOriginal;
    }

    public bool RompecabezasCompleto()
    {
        return GameProgress.piezasDesbloqueadas >= piezasRompecabezas.Length;
    }

    public float ObtenerProgreso()
    {
        if (piezasRompecabezas == null || piezasRompecabezas.Length == 0) return 0f;
        return (float)GameProgress.piezasDesbloqueadas / piezasRompecabezas.Length;
    }
}
