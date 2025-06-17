using UnityEngine;
using System.Collections.Generic;

public class GeneradorFondoParallaxInfinito : MonoBehaviour
{
    //[System.Serializable]
    //public class CapaParallax
    //{
    //    [Header("Configuraci�n de la Capa")]
    //    public GameObject prefabCapa;           // Prefab de la capa de fondo
    //    public Transform contenedorCapa;        // Transform padre para organizar
    //    [Range(0f, 1f)]
    //    public float factorParallax = 0.5f;     // Velocidad relativa al jugador
    //    public float anchoSegmento = 25.6f;     // Ancho de cada segmento (calculado autom�ticamente)
    //    public int segmentosIniciales = 3;      // Segmentos iniciales por capa
    //    public float posicionY = 0f;            // Altura espec�fica de esta capa
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

    //[Header("Configuraci�n General")]
    //public float distanciaGeneracion = 30f;    // Distancia adelante del jugador para generar
    //public float distanciaEliminacion = 30f;   // Distancia atr�s del jugador para eliminar

    //void Start()
    //{
    //    // Buscar referencias autom�ticamente si no est�n asignadas
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

    //    // Crear contenedor para organizar la jerarqu�a
    //    if (capa.contenedorCapa == null)
    //    {
    //        GameObject contenedor = new GameObject($"Capa_Parallax_{capa.factorParallax}");
    //        contenedor.transform.SetParent(transform);
    //        capa.contenedorCapa = contenedor.transform;
    //    }

    //    // Calcular ancho autom�ticamente si no est� definido
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

    //    // Inicializar posici�n del jugador para esta capa
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

    //    // Mover toda la capa seg�n el parallax
    //    Vector3 posicionActual = capa.contenedorCapa.position;
    //    capa.contenedorCapa.position = new Vector3(
    //        posicionActual.x + movimientoParallax,
    //        capa.posicionY,
    //        capa.posicionZ
    //    );

    //    // Actualizar �ltima posici�n del jugador para esta capa
    //    capa.ultimaPosicionJugador = jugador.position.x;

    //    // Generar nuevos segmentos si el jugador se acerca al final
    //    float posicionEfectivaJugador = jugador.position.x + (capa.contenedorCapa.position.x * (1f - capa.factorParallax));
    //    if (posicionEfectivaJugador + distanciaGeneracion > capa.siguientePosX + capa.contenedorCapa.position.x)
    //    {
    //        GenerarSegmentoCapa(capa);
    //    }

    //    // Eliminar segmentos que quedan muy atr�s
    //    EliminarSegmentosLejanos(capa);
    //}

    //void GenerarSegmentoCapa(CapaParallax capa)
    //{
    //    // Obtener la posici�n Y original del prefab
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

    //    // Revisar el segmento m�s antiguo
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

    //// M�todo para ajustar factores de parallax en runtime
    //public void AjustarFactorParallax(int indiceCapa, float nuevoFactor)
    //{
    //    if (indiceCapa >= 0 && indiceCapa < capasParallax.Length)
    //    {
    //        capasParallax[indiceCapa].factorParallax = Mathf.Clamp01(nuevoFactor);
    //    }
    //}

    //// M�todo para obtener informaci�n de debug
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
        [Header("Configuraci�n de la Capa")]
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

    [Header("Configuraci�n General")]
    public float distanciaGeneracion = 50f;    // AUMENTADO: m�s distancia para generar
    public float distanciaEliminacion = 60f;   // AUMENTADO: m�s conservador para eliminar
    public int segmentosMinimos = 5;            // NUEVO: m�nimo de segmentos activos

    void Start()
    {
        // Buscar referencias autom�ticamente si no est�n asignadas
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

        // Crear contenedor para organizar la jerarqu�a
        if (capa.contenedorCapa == null)
        {
            GameObject contenedor = new GameObject($"Capa_Parallax_{capa.factorParallax}");
            contenedor.transform.SetParent(transform);
            capa.contenedorCapa = contenedor.transform;
        }

        // Calcular ancho autom�ticamente si no est� definido
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

        // MEJORADO: Generar m�s segmentos iniciales para mejor cobertura
        capa.siguientePosX = -capa.anchoSegmento; // Empezar un poco atr�s
        for (int i = 0; i < capa.segmentosIniciales + 2; i++) // +2 segmentos extra
        {
            GenerarSegmentoCapa(capa);
        }

        // Inicializar posici�n del jugador para esta capa
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

        // CORREGIDO: Calcular movimiento parallax de forma m�s estable
        float movimientoJugador = jugador.position.x - capa.ultimaPosicionJugador;
        float movimientoParallax = movimientoJugador * (1f - capa.factorParallax);

        // Acumular el offset en lugar de recalcular cada vez
        capa.offsetParallax += movimientoParallax;

        // Aplicar posici�n del contenedor
        capa.contenedorCapa.position = new Vector3(
            -capa.offsetParallax,  // Offset acumulado negativo
            capa.posicionY,
            capa.posicionZ
        );

        // Actualizar �ltima posici�n del jugador
        capa.ultimaPosicionJugador = jugador.position.x;

        // CORREGIDO: L�gica de generaci�n m�s simple y confiable
        float limiteDerecho = ObtenerLimiteDerecho(capa);
        float posicionGeneracion = jugador.position.x + distanciaGeneracion;

        // Generar segmentos hasta cubrir la distancia necesaria
        while (limiteDerecho < posicionGeneracion)
        {
            GenerarSegmentoCapa(capa);
            limiteDerecho = ObtenerLimiteDerecho(capa);
        }

        // MEJORADO: Eliminaci�n m�s conservadora
        EliminarSegmentosLejanos(capa);
    }

    // NUEVO: M�todo para obtener el l�mite derecho real de la capa
    float ObtenerLimiteDerecho(CapaParallax capa)
    {
        if (capa.segmentosActivos.Count == 0) return 0f;

        // El l�mite derecho es la posici�n del �ltimo segmento generado
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

        // Posici�n local relativa al contenedor
        nuevoSegmento.transform.localPosition = new Vector3(
            capa.siguientePosX,  // Mantener posici�n X absoluta como local
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
                // Calcular posici�n real del segmento considerando el parallax
                float posicionRealSegmento = segmentoMasAntiguo.transform.position.x - capa.offsetParallax;
                float distanciaAlJugador = jugador.position.x - posicionRealSegmento;

                // Solo eliminar si est� REALMENTE lejos
                if (distanciaAlJugador > distanciaEliminacion)
                {
                    GameObject segmentoViejo = capa.segmentosActivos.Dequeue();
                    Destroy(segmentoViejo);
                }
                else
                {
                    break; // No eliminar m�s si este no est� lo suficientemente lejos
                }
            }
            else
            {
                // Si el objeto es null, eliminarlo de la cola
                capa.segmentosActivos.Dequeue();
            }
        }
    }

    // NUEVO: M�todo de debug visual
    void OnDrawGizmos()
    {
        if (jugador == null) return;

        // L�nea azul: posici�n del jugador
        Gizmos.color = Color.blue;
        Vector3 posJugador = new Vector3(jugador.position.x, 0, 0);
        Gizmos.DrawLine(posJugador + Vector3.down * 5f, posJugador + Vector3.up * 5f);

        // L�nea verde: zona de generaci�n
        Gizmos.color = Color.green;
        Vector3 limiteGen = new Vector3(jugador.position.x + distanciaGeneracion, 0, 0);
        Gizmos.DrawLine(limiteGen + Vector3.down * 5f, limiteGen + Vector3.up * 5f);

        // L�nea roja: zona de eliminaci�n
        Gizmos.color = Color.red;
        Vector3 limiteElim = new Vector3(jugador.position.x - distanciaEliminacion, 0, 0);
        Gizmos.DrawLine(limiteElim + Vector3.down * 5f, limiteElim + Vector3.up * 5f);
    }

    // M�todos p�blicos para debugging
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
                     $"L�mite derecho: {limiteDerecho}, Offset: {capa.offsetParallax}");
        }
    }
}