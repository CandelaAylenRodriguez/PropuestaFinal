using UnityEngine;
using System.Collections.Generic;

public class GeneradorFondoParallaxInfinito : MonoBehaviour
{
    //[System.Serializable]
    //public class CapaParallax
    //{
    //    [Header("Configuración de la Capa")]
    //    public GameObject prefabCapa;           // Prefab de la capa de fondo
    //    public Transform contenedorCapa;        // Transform padre para organizar
    //    [Range(0f, 1f)]
    //    public float factorParallax = 0.5f;     // Velocidad relativa al jugador
    //    public float anchoSegmento = 25.6f;     // Ancho de cada segmento (calculado automáticamente)
    //    public int segmentosIniciales = 3;      // Segmentos iniciales por capa
    //    public float posicionY = 0f;            // Altura específica de esta capa
    //    public float posicionZ = 10f;           // Profundidad (Z) de esta capa

    //    [Header("Estado Interno")]
    //    [HideInInspector] public float siguientePosX = 0f;
    //    [HideInInspector] public Queue<GameObject> segmentosActivos = new Queue<GameObject>();
    //    [HideInInspector] public float ultimaPosicionJugador = 0f;
    //}

    //[Header("Referencias")]
    //public Transform jugador;
    //public Transform camaraTransform;

    //[Header("Capas de Parallax")]
    //public CapaParallax[] capasParallax;

    //[Header("Configuración General")]
    //public float distanciaGeneracion = 30f;    // Distancia adelante del jugador para generar
    //public float distanciaEliminacion = 30f;   // Distancia atrás del jugador para eliminar

    //void Start()
    //{
    //    // Buscar referencias automáticamente si no están asignadas
    //    if (jugador == null)
    //    {
    //        GameObject playerObj = GameObject.FindWithTag("Player");
    //        if (playerObj != null) jugador = playerObj.transform;
    //    }

    //    if (camaraTransform == null)
    //    {
    //        camaraTransform = Camera.main.transform;
    //    }

    //    // Inicializar cada capa
    //    foreach (CapaParallax capa in capasParallax)
    //    {
    //        InicializarCapa(capa);
    //    }
    //}

    //void InicializarCapa(CapaParallax capa)
    //{
    //    if (capa.prefabCapa == null) return;

    //    // Crear contenedor para organizar la jerarquía
    //    if (capa.contenedorCapa == null)
    //    {
    //        GameObject contenedor = new GameObject($"Capa_Parallax_{capa.factorParallax}");
    //        contenedor.transform.SetParent(transform);
    //        capa.contenedorCapa = contenedor.transform;
    //    }

    //    // Calcular ancho automáticamente si no está definido
    //    if (capa.anchoSegmento <= 0)
    //    {
    //        SpriteRenderer spriteRenderer = capa.prefabCapa.GetComponent<SpriteRenderer>();
    //        if (spriteRenderer != null && spriteRenderer.sprite != null)
    //        {
    //            capa.anchoSegmento = spriteRenderer.bounds.size.x;
    //        }
    //        else
    //        {
    //            capa.anchoSegmento = 25.6f; // Valor por defecto
    //        }
    //    }

    //    // Generar segmentos iniciales
    //    capa.siguientePosX = 0f;
    //    for (int i = 0; i < capa.segmentosIniciales; i++)
    //    {
    //        GenerarSegmentoCapa(capa);
    //    }

    //    // Inicializar posición del jugador para esta capa
    //    if (jugador != null)
    //    {
    //        capa.ultimaPosicionJugador = jugador.position.x;
    //    }
    //}

    //void Update()
    //{
    //    if (jugador == null) return;

    //    foreach (CapaParallax capa in capasParallax)
    //    {
    //        ActualizarCapa(capa);
    //    }
    //}

    //void ActualizarCapa(CapaParallax capa)
    //{
    //    if (capa.prefabCapa == null || capa.contenedorCapa == null) return;

    //    // Calcular movimiento basado en el factor parallax
    //    float movimientoJugador = jugador.position.x - capa.ultimaPosicionJugador;
    //    float movimientoParallax = movimientoJugador * capa.factorParallax;

    //    // Mover toda la capa según el parallax
    //    Vector3 posicionActual = capa.contenedorCapa.position;
    //    capa.contenedorCapa.position = new Vector3(
    //        posicionActual.x + movimientoParallax,
    //        capa.posicionY,
    //        capa.posicionZ
    //    );

    //    // Actualizar última posición del jugador para esta capa
    //    capa.ultimaPosicionJugador = jugador.position.x;

    //    // Generar nuevos segmentos si el jugador se acerca al final
    //    float posicionEfectivaJugador = jugador.position.x + (capa.contenedorCapa.position.x * (1f - capa.factorParallax));
    //    if (posicionEfectivaJugador + distanciaGeneracion > capa.siguientePosX + capa.contenedorCapa.position.x)
    //    {
    //        GenerarSegmentoCapa(capa);
    //    }

    //    // Eliminar segmentos que quedan muy atrás
    //    EliminarSegmentosLejanos(capa);
    //}

    //void GenerarSegmentoCapa(CapaParallax capa)
    //{
    //    // Obtener la posición Y original del prefab
    //    float posicionYOriginal = capa.prefabCapa.transform.position.y;

    //    Vector3 posicion = new Vector3(
    //        capa.siguientePosX,
    //        posicionYOriginal, // Usar la Y original del prefab
    //        capa.posicionZ     // Usar la Z configurada para esta capa
    //    );

    //    GameObject nuevoSegmento = Instantiate(capa.prefabCapa, posicion, Quaternion.identity);
    //    nuevoSegmento.transform.SetParent(capa.contenedorCapa);

    //    // Asegurar que el Z order se mantenga correcto
    //    nuevoSegmento.transform.localPosition = new Vector3(
    //        nuevoSegmento.transform.localPosition.x,
    //        nuevoSegmento.transform.localPosition.y,
    //        0f // Z local al contenedor
    //    );

    //    capa.segmentosActivos.Enqueue(nuevoSegmento);
    //    capa.siguientePosX += capa.anchoSegmento;
    //}

    //void EliminarSegmentosLejanos(CapaParallax capa)
    //{
    //    if (capa.segmentosActivos.Count <= capa.segmentosIniciales) return;

    //    // Revisar el segmento más antiguo
    //    if (capa.segmentosActivos.Count > 0)
    //    {
    //        GameObject segmentoMasAntiguo = capa.segmentosActivos.Peek();
    //        if (segmentoMasAntiguo != null)
    //        {
    //            float distanciaSegmento = jugador.position.x - (segmentoMasAntiguo.transform.position.x);

    //            if (distanciaSegmento > distanciaEliminacion)
    //            {
    //                GameObject segmentoViejo = capa.segmentosActivos.Dequeue();
    //                Destroy(segmentoViejo);
    //            }
    //        }
    //    }
    //}

    //// Método para ajustar factores de parallax en runtime
    //public void AjustarFactorParallax(int indiceCapa, float nuevoFactor)
    //{
    //    if (indiceCapa >= 0 && indiceCapa < capasParallax.Length)
    //    {
    //        capasParallax[indiceCapa].factorParallax = Mathf.Clamp01(nuevoFactor);
    //    }
    //}

    //// Método para obtener información de debug
    //public void MostrarInfoDebug()
    //{
    //    for (int i = 0; i < capasParallax.Length; i++)
    //    {
    //        CapaParallax capa = capasParallax[i];
    //        Debug.Log($"Capa {i}: Factor {capa.factorParallax}, Segmentos activos: {capa.segmentosActivos.Count}, Siguiente X: {capa.siguientePosX}");
    //    }
    //}

    [System.Serializable]
    public class CapaParallax
    {
        [Header("Configuración de la Capa")]
        public GameObject prefabCapa;
        public Transform contenedorCapa;
        [Range(0f, 1f)]
        public float factorParallax = 0.5f;
        public float anchoSegmento = 25.6f;
        public int segmentosIniciales = 3;
        public float posicionY = 0f;
        public float posicionZ = 10f;

        [Header("Estado Interno")]
        [HideInInspector] public float siguientePosX = 0f;
        [HideInInspector] public Queue<GameObject> segmentosActivos = new Queue<GameObject>();
        [HideInInspector] public float ultimaPosicionJugador = 0f;
        [HideInInspector] public float offsetParallax = 0f;  // NUEVO: acumulador de offset
    }

    [Header("Referencias")]
    public Transform jugador;
    public Transform camaraTransform;

    [Header("Capas de Parallax")]
    public CapaParallax[] capasParallax;

    [Header("Configuración General")]
    public float distanciaGeneracion = 50f;    // AUMENTADO: más distancia para generar
    public float distanciaEliminacion = 60f;   // AUMENTADO: más conservador para eliminar
    public int segmentosMinimos = 5;            // NUEVO: mínimo de segmentos activos

    void Start()
    {
        // Buscar referencias automáticamente si no están asignadas
        if (jugador == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null) jugador = playerObj.transform;
        }

        if (camaraTransform == null)
        {
            camaraTransform = Camera.main.transform;
        }

        // Inicializar cada capa
        foreach (CapaParallax capa in capasParallax)
        {
            InicializarCapa(capa);
        }
    }

    void InicializarCapa(CapaParallax capa)
    {
        if (capa.prefabCapa == null) return;

        // Crear contenedor para organizar la jerarquía
        if (capa.contenedorCapa == null)
        {
            GameObject contenedor = new GameObject($"Capa_Parallax_{capa.factorParallax}");
            contenedor.transform.SetParent(transform);
            capa.contenedorCapa = contenedor.transform;
        }

        // Calcular ancho automáticamente si no está definido
        if (capa.anchoSegmento <= 0)
        {
            SpriteRenderer spriteRenderer = capa.prefabCapa.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && spriteRenderer.sprite != null)
            {
                capa.anchoSegmento = spriteRenderer.bounds.size.x;
            }
            else
            {
                capa.anchoSegmento = 25.6f;
            }
        }

        // MEJORADO: Generar más segmentos iniciales para mejor cobertura
        capa.siguientePosX = -capa.anchoSegmento; // Empezar un poco atrás
        for (int i = 0; i < capa.segmentosIniciales + 2; i++) // +2 segmentos extra
        {
            GenerarSegmentoCapa(capa);
        }

        // Inicializar posición del jugador para esta capa
        if (jugador != null)
        {
            capa.ultimaPosicionJugador = jugador.position.x;
        }

        capa.offsetParallax = 0f;
    }

    void Update()
    {
        if (jugador == null) return;

        foreach (CapaParallax capa in capasParallax)
        {
            ActualizarCapa(capa);
        }
    }

    void ActualizarCapa(CapaParallax capa)
    {
        if (capa.prefabCapa == null || capa.contenedorCapa == null) return;

        // CORREGIDO: Calcular movimiento parallax de forma más estable
        float movimientoJugador = jugador.position.x - capa.ultimaPosicionJugador;
        float movimientoParallax = movimientoJugador * (1f - capa.factorParallax);

        // Acumular el offset en lugar de recalcular cada vez
        capa.offsetParallax += movimientoParallax;

        // Aplicar posición del contenedor
        capa.contenedorCapa.position = new Vector3(
            -capa.offsetParallax,  // Offset acumulado negativo
            capa.posicionY,
            capa.posicionZ
        );

        // Actualizar última posición del jugador
        capa.ultimaPosicionJugador = jugador.position.x;

        // CORREGIDO: Lógica de generación más simple y confiable
        float limiteDerecho = ObtenerLimiteDerecho(capa);
        float posicionGeneracion = jugador.position.x + distanciaGeneracion;

        // Generar segmentos hasta cubrir la distancia necesaria
        while (limiteDerecho < posicionGeneracion)
        {
            GenerarSegmentoCapa(capa);
            limiteDerecho = ObtenerLimiteDerecho(capa);
        }

        // MEJORADO: Eliminación más conservadora
        EliminarSegmentosLejanos(capa);
    }

    // NUEVO: Método para obtener el límite derecho real de la capa
    float ObtenerLimiteDerecho(CapaParallax capa)
    {
        if (capa.segmentosActivos.Count == 0) return 0f;

        // El límite derecho es la posición del último segmento generado
        return capa.siguientePosX - capa.offsetParallax;
    }

    void GenerarSegmentoCapa(CapaParallax capa)
    {
        float posicionYOriginal = capa.prefabCapa.transform.position.y;

        Vector3 posicion = new Vector3(
            capa.siguientePosX,
            posicionYOriginal,
            capa.posicionZ
        );

        GameObject nuevoSegmento = Instantiate(capa.prefabCapa, posicion, Quaternion.identity);
        nuevoSegmento.transform.SetParent(capa.contenedorCapa);

        // Posición local relativa al contenedor
        nuevoSegmento.transform.localPosition = new Vector3(
            capa.siguientePosX,  // Mantener posición X absoluta como local
            nuevoSegmento.transform.localPosition.y,
            0f
        );

        capa.segmentosActivos.Enqueue(nuevoSegmento);
        capa.siguientePosX += capa.anchoSegmento;
    }

    void EliminarSegmentosLejanos(CapaParallax capa)
    {
        // CORREGIDO: No eliminar si tenemos pocos segmentos
        if (capa.segmentosActivos.Count <= segmentosMinimos) return;

        while (capa.segmentosActivos.Count > segmentosMinimos)
        {
            GameObject segmentoMasAntiguo = capa.segmentosActivos.Peek();
            if (segmentoMasAntiguo != null)
            {
                // Calcular posición real del segmento considerando el parallax
                float posicionRealSegmento = segmentoMasAntiguo.transform.position.x - capa.offsetParallax;
                float distanciaAlJugador = jugador.position.x - posicionRealSegmento;

                // Solo eliminar si está REALMENTE lejos
                if (distanciaAlJugador > distanciaEliminacion)
                {
                    GameObject segmentoViejo = capa.segmentosActivos.Dequeue();
                    Destroy(segmentoViejo);
                }
                else
                {
                    break; // No eliminar más si este no está lo suficientemente lejos
                }
            }
            else
            {
                // Si el objeto es null, eliminarlo de la cola
                capa.segmentosActivos.Dequeue();
            }
        }
    }

    // NUEVO: Método de debug visual
    void OnDrawGizmos()
    {
        if (jugador == null) return;

        // Línea azul: posición del jugador
        Gizmos.color = Color.blue;
        Vector3 posJugador = new Vector3(jugador.position.x, 0, 0);
        Gizmos.DrawLine(posJugador + Vector3.down * 5f, posJugador + Vector3.up * 5f);

        // Línea verde: zona de generación
        Gizmos.color = Color.green;
        Vector3 limiteGen = new Vector3(jugador.position.x + distanciaGeneracion, 0, 0);
        Gizmos.DrawLine(limiteGen + Vector3.down * 5f, limiteGen + Vector3.up * 5f);

        // Línea roja: zona de eliminación
        Gizmos.color = Color.red;
        Vector3 limiteElim = new Vector3(jugador.position.x - distanciaEliminacion, 0, 0);
        Gizmos.DrawLine(limiteElim + Vector3.down * 5f, limiteElim + Vector3.up * 5f);
    }

    // Métodos públicos para debugging
    public void AjustarFactorParallax(int indiceCapa, float nuevoFactor)
    {
        if (indiceCapa >= 0 && indiceCapa < capasParallax.Length)
        {
            capasParallax[indiceCapa].factorParallax = Mathf.Clamp01(nuevoFactor);
        }
    }

    public void MostrarInfoDebug()
    {
        for (int i = 0; i < capasParallax.Length; i++)
        {
            CapaParallax capa = capasParallax[i];
            float limiteDerecho = ObtenerLimiteDerecho(capa);
            Debug.Log($"Capa {i}: Factor {capa.factorParallax}, Segmentos: {capa.segmentosActivos.Count}, " +
                     $"Límite derecho: {limiteDerecho}, Offset: {capa.offsetParallax}");
        }
    }
}