using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaNivel : MonoBehaviour
{
    [Header("Configuración de Nivel")]
    public string nombreSiguienteNivel = "nivel2";
    public bool cargarPorIndice = false;

    [Header("Configuración de Tamaño - NUEVO")]
    [Range(0.1f, 2f)]
    public float escalaPuerta = 0.5f; // Escala de la puerta (0.5 = mitad del tamaño)
    public bool aplicarEscalaAlIniciar = true;

    [Header("Efectos Visuales")]
    public bool efectoEntrada = true;
    public float tiempoEfectoEntrada = 1f;

    [Header("Audio (Opcional)")]
    public AudioClip sonidoPuerta;
    private AudioSource audioSource;

    private Vector3 escalaOriginalPrefab;

    void Start()
    {
        // Guardar escala original del prefab
        escalaOriginalPrefab = transform.localScale;

        // Aplicar nueva escala si está habilitado
        if (aplicarEscalaAlIniciar)
        {
            AplicarEscalaPuerta();
        }

        // Configurar audio si hay clip
        if (sonidoPuerta != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = sonidoPuerta;
            audioSource.playOnAwake = false;
        }

        // Efecto de aparición
        if (efectoEntrada)
        {
            StartCoroutine(EfectoAparicion());
        }
    }

    // NUEVO: Método para aplicar escala personalizada
    void AplicarEscalaPuerta()
    {
        Vector3 nuevaEscala = escalaOriginalPrefab * escalaPuerta;
        transform.localScale = nuevaEscala;

        Debug.Log($"Escala de puerta aplicada: {nuevaEscala} (factor: {escalaPuerta})");
    }

    // NUEVO: Método público para cambiar escala en runtime
    public void CambiarEscalaPuerta(float nuevaEscala)
    {
        escalaPuerta = Mathf.Clamp(nuevaEscala, 0.1f, 2f);
        AplicarEscalaPuerta();
    }

    private System.Collections.IEnumerator EfectoAparicion()
    {
        // Usar la escala configurada como "original" para el efecto
        Vector3 escalaParaEfecto = transform.localScale;
        transform.localScale = Vector3.zero;

        // Obtener componentes para efecto de transparencia
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        Color[] coloresOriginales = new Color[spriteRenderers.Length];

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            coloresOriginales[i] = spriteRenderers[i].color;
            Color colorTemp = coloresOriginales[i];
            colorTemp.a = 0f;
            spriteRenderers[i].color = colorTemp;
        }

        // Animar aparición
        float tiempo = 0f;
        while (tiempo < tiempoEfectoEntrada)
        {
            tiempo += Time.deltaTime;
            float factor = Mathf.Lerp(0f, 1f, tiempo / tiempoEfectoEntrada);

            // Escala - usar la escala configurada
            transform.localScale = Vector3.Lerp(Vector3.zero, escalaParaEfecto, factor);

            // Transparencia
            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                Color color = coloresOriginales[i];
                color.a = coloresOriginales[i].a * factor;
                spriteRenderers[i].color = color;
            }

            yield return null;
        }

        // Asegurar valores finales con la escala configurada
        transform.localScale = escalaParaEfecto;
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = coloresOriginales[i];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(CambiarNivel());
        }
    }

    private System.Collections.IEnumerator CambiarNivel()
    {
        // Reproducir sonido si existe
        if (audioSource != null && sonidoPuerta != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(sonidoPuerta.length * 0.5f);
        }
        string escenaActual = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        
        if (escenaActual == "nivelNormal")
        {
            // Cargar siguiente nivel
            SceneManager.LoadScene("nivel2");
            GameProgress.ReiniciarRompecabezasNivel2(); // Reiniciar rompecabezas del nivel 2
        } else if (escenaActual == "nivel2")
        {
            SceneManager.LoadScene("nivel3");
            GameProgress.ReiniciarRompecabezasNivel3(); // Reiniciar rompecabezas del nivel 3
        }
        else if (escenaActual == "nivel3")
        {
            GameProgress.puntajeFinal = GameProgress.ObtenerPuntaje();
            SceneManager.LoadScene("Winner");
            GameProgress.ReiniciarProgreso();
        }
    }

    // Método público para cambiar nivel manualmente
    public void IrAlSiguienteNivel()
    {
        StartCoroutine(CambiarNivel());
    }

    // NUEVO: Métodos para testing rápido
    [ContextMenu("Escala 25%")]
    public void Escala25() { CambiarEscalaPuerta(0.25f); }

    [ContextMenu("Escala 50%")]
    public void Escala50() { CambiarEscalaPuerta(0.5f); }

    [ContextMenu("Escala 75%")]
    public void Escala75() { CambiarEscalaPuerta(0.75f); }

    [ContextMenu("Escala Original")]
    public void EscalaOriginal() { CambiarEscalaPuerta(1f); }
}
