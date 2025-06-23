using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerObstaculos : MonoBehaviour
{
    [Header("Referencias")]
    public Transform jugador;
    public GameObject obstaculoSaltar;      // Prefab base para saltar
    public GameObject obstaculoDeslizar;    // Prefab base para deslizar
    public GameObject obstaculoDeslizarDificil; // Prefab base para deslizar en modo difícil
    public GameObject obstaculoSaltarDificil; // Prefab base para saltar en modo difícil

    [Header("Sprites para Obstáculos de Saltar")]
    public Sprite[] spritesSaltar = new Sprite[3];  // Array para 3 sprites de saltar

    [Header("Sprites para Obstáculos de Deslizar")]
    public Sprite[] spritesDeslizar = new Sprite[2]; // Array para 2 sprites de deslizar

    public Vector2 tamañoColliderSaltar = new Vector2(1.2f, 1.2f);
    public Vector2 tamañoColliderDeslizar = new Vector2(1f, 7.86f);

    [Header("Configuración")]
    public float distanciaEntreObstaculos = 10f;
    public bool modoDificil = false;
    public bool esEscenaNormal = false;

    private float tiempoJugado = 0f;
    private float siguienteX = 15f;
    private int ultimoSpriteSaltar = -1;    // Para evitar repetir sprites consecutivos
    private int ultimoSpriteDeslizar = -1;  // Para evitar repetir sprites consecutivos
    public List<float> posicionesObstaculosX = new List<float>();

    void Start()
    {
        string escena = SceneManager.GetActiveScene().name;
        modoDificil = (escena == "nivelDificil");
        esEscenaNormal = (escena == "nivelNormal");

        // Si es modo normal, restauramos tiempo
        if (esEscenaNormal)
        {
            tiempoJugado = GameProgress.tiempoJugadoNormal;
        }

        ConfigurarTiempoInicialPorNivel(escena);

        if (modoDificil)
        {
            tiempoJugado = GameProgress.tiempoJugadoNormal;
            Debug.Log($"Nivel Difícil - Tiempo heredado del normal: {tiempoJugado} segundos");
        }

        // Verificar que tenemos sprites asignados
        VerificarSprites();

        SpawnObstaculo(); // Spawn initial obstacle
    }

    void VerificarSprites()
    {
        bool hayError = false;

        if (spritesSaltar.Length == 0 || SonTodosNull(spritesSaltar))
        {
            //Debug.LogWarning("No hay sprites asignados para obstáculos de saltar!");
            hayError = true;
        }

        if (spritesDeslizar.Length == 0 || SonTodosNull(spritesDeslizar))
        {
            //Debug.LogWarning("No hay sprites asignados para obstáculos de deslizar!");
            hayError = true;
        }

        if (hayError)
        {
            //Debug.LogWarning("Asigna los sprites en el inspector para ver la variación visual.");
        }
    }

    bool SonTodosNull(Sprite[] sprites)
    {
        foreach (Sprite sprite in sprites)
        {
            if (sprite != null) return false;
        }
        return true;
    }

    void ConfigurarTiempoInicialPorNivel(string escenaActual)
    {
        if (modoDificil) return;

        switch (escenaActual)
        {
            case "nivel1":
                tiempoJugado = GameProgress.tiempoNivel1;
                break;

            case "nivel2":
                tiempoJugado = GameProgress.tiempoNivel2;
                break;

            case "nivel3":
                tiempoJugado = GameProgress.tiempoNivel3;
                break;

            case "nivelDificil":
                // No hacer nada: se mantiene el tiempo actual
                break;

            default:
                tiempoJugado = 0f;
                break;
        }

        //Debug.Log($"[Inicio] Tiempo inicial para {escenaActual}: {tiempoJugado}");
    }

    void Update()
    {
        tiempoJugado += Time.deltaTime;
        ActualizarDificultad();

        if (jugador.position.x >= siguienteX)
        {
            SpawnObstaculo();
            siguienteX += distanciaEntreObstaculos;
        }

        if (esEscenaNormal)
        {
            GameProgress.tiempoJugadoNormal = tiempoJugado;
        }

        string escena = SceneManager.GetActiveScene().name;
        if (escena == "nivel1") GameProgress.tiempoNivel1 = tiempoJugado;
        if (escena == "nivel2") GameProgress.tiempoNivel2 = tiempoJugado;
        if (escena == "nivel3") GameProgress.tiempoNivel3 = tiempoJugado;
        if (escena == "nivelNormal") GameProgress.tiempoJugadoNormal = tiempoJugado;

        Debug.Log($"[Tiempo] Escena: {escena} | Tiempo Jugado: {tiempoJugado:F1}s");
    }

    void ActualizarDificultad()
    {
        if (modoDificil)
        {
            distanciaEntreObstaculos = Mathf.Lerp(8f, 5f, Mathf.Clamp01(tiempoJugado / 180f));
        }
        else
        {
            if (tiempoJugado < 30f)
                distanciaEntreObstaculos = 13f;
            else if (tiempoJugado < 60f)
                distanciaEntreObstaculos = 11f;
            else if (tiempoJugado < 90f)
                distanciaEntreObstaculos = 9f;
            else if (tiempoJugado < 120f)
                distanciaEntreObstaculos = 7f;
            else if (tiempoJugado < 180f)
                distanciaEntreObstaculos = 6f;
            else
                distanciaEntreObstaculos = Random.Range(3.5f, 5f);
        }
    }

    void SpawnObstaculo()
    {
        GameObject prefabElegido;
        bool esSaltar;

        // Determinar tipo de obstáculo
        if (modoDificil != true)
        {
            if (tiempoJugado < 15f)
            {
                prefabElegido = obstaculoSaltar;
                esSaltar = true;
            }
            else
            {
                esSaltar = Random.value > 0.5f;
                prefabElegido = esSaltar ? obstaculoSaltar : obstaculoDeslizar;
            }
        }
        else
        {
            esSaltar = Random.value > 0.5f;
            prefabElegido = esSaltar ? obstaculoSaltar : obstaculoDeslizar;
        }

        // Verificar que tenemos el prefab
        if (prefabElegido == null)
        {
            //Debug.LogError($"Prefab no asignado para obstáculo de {(esSaltar ? "saltar" : "deslizar")}");
            return;
        }

        // Determinar posición (ajustada más abajo)
        Vector3 posicionSpawn = new Vector3(jugador.position.x + 15f, 0f, 0f);
        if (esSaltar)
            posicionSpawn.y = 1.5f;
        else
            posicionSpawn.y = 4.7f;

        // Instanciar el obstáculo
        GameObject obstaculo = Instantiate(prefabElegido, posicionSpawn, Quaternion.identity);

        // Ajustar tamaño automáticamente
        obstaculo.transform.localScale = new Vector3(0.6f, 0.6f, 1f);

        // AÑADIR ESTA LÍNEA:
        ConfigurarObstaculo(obstaculo, esSaltar);

        // Aplicar sprite aleatorio
        AplicarSpriteAleatorio(obstaculo, esSaltar);

        // Guardar posición
        posicionesObstaculosX.Add(posicionSpawn.x);

        // Limitar la lista a máximo 3 elementos
        if (posicionesObstaculosX.Count > 3)
        {
            posicionesObstaculosX.RemoveAt(0);
        }
    }

    void AplicarSpriteAleatorio(GameObject obstaculo, bool esSaltar)
    {
        SpriteRenderer spriteRenderer = obstaculo.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            //Debug.LogWarning($"El obstáculo {obstaculo.name} no tiene SpriteRenderer!");
            return;
        }

        if (esSaltar && spritesSaltar.Length > 0)
        {
            // Elegir sprite para saltar (evitando repetir el último)
            int indiceSprite = ElegirSpriteAleatorio(spritesSaltar.Length, ultimoSpriteSaltar);
            if (spritesSaltar[indiceSprite] != null)
            {
                spriteRenderer.sprite = spritesSaltar[indiceSprite];
                ultimoSpriteSaltar = indiceSprite;
            }
        }
        else if (!esSaltar && spritesDeslizar.Length > 0)
        {
            // Elegir sprite para deslizar (evitando repetir el último)
            int indiceSprite = ElegirSpriteAleatorio(spritesDeslizar.Length, ultimoSpriteDeslizar);
            if (spritesDeslizar[indiceSprite] != null)
            {
                spriteRenderer.sprite = spritesDeslizar[indiceSprite];
                ultimoSpriteDeslizar = indiceSprite;
            }
        }
    }
    public float GetTiempoJugado()
    {
        return tiempoJugado;
    }

    int ElegirSpriteAleatorio(int totalSprites, int ultimoIndice)
    {
        if (totalSprites <= 1) return 0;

        int nuevoIndice;
        do
        {
            nuevoIndice = Random.Range(0, totalSprites);
        }
        while (nuevoIndice == ultimoIndice && totalSprites > 1);

        return nuevoIndice;
    }

    void ConfigurarObstaculo(GameObject obstaculo, bool esSaltar)
    {
        // Asegurar que tenga el tag correcto
        if (!obstaculo.CompareTag("Obstaculo"))
        {
            obstaculo.tag = "Obstaculo";
        }

        // Verificar/añadir Box Collider 2D
        BoxCollider2D collider = obstaculo.GetComponent<BoxCollider2D>();
        if (collider == null)
        {
            collider = obstaculo.AddComponent<BoxCollider2D>();
        }

        // Configurar el collider correctamente
        collider.isTrigger = false;
        collider.sharedMaterial = null;

        // USAR TAMAÑOS FIJOS PARA CONSISTENCIA
        if (esSaltar)
        {
            // OBSTÁCULO DE SALTAR
            collider.size = tamañoColliderSaltar;
            collider.offset = new Vector2(0f, 0f);
            //Debug.Log($"Configurando obstáculo SALTAR - Size: {collider.size}");
        }
        else
        {
            // OBSTÁCULO DE DESLIZAR - SIEMPRE el mismo tamaño
            collider.size = tamañoColliderDeslizar;
            collider.offset = new Vector2(0f, 0f);
            //Debug.Log($"Configurando obstáculo DESLIZAR - Size: {collider.size}");
        }

        // Añadir visualizador de collider
        VisualizadorCollider visualizador = obstaculo.GetComponent<VisualizadorCollider>();
        if (visualizador == null)
        {
            visualizador = obstaculo.AddComponent<VisualizadorCollider>();
        }

        // Colores diferentes para cada tipo
        if (esSaltar)
        {
            visualizador.colorCollider = Color.red; // Rojo para saltar
        }
        else
        {
            visualizador.colorCollider = Color.blue; // Azul para deslizar
        }

        visualizador.mostrarCollider = true;
    }
}