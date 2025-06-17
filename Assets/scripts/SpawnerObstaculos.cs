using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerObstaculos : MonoBehaviour
{
    //[Header("Referencias")]
    //public Transform jugador;
    //public GameObject obstaculoSaltar;      // Prefab base para saltar
    //public GameObject obstaculoDeslizar;    // Prefab base para deslizar

    //[Header("Sprites para Obstáculos de Saltar")]
    //public Sprite[] spritesSaltar = new Sprite[3];  // Array para 3 sprites de saltar

    //[Header("Sprites para Obstáculos de Deslizar")]
    //public Sprite[] spritesDeslizar = new Sprite[2]; // Array para 2 sprites de deslizar

    //[Header("Configuración")]
    //public float distanciaEntreObstaculos = 10f;
    //public bool modoDificil = false;
    //public bool esEscenaNormal = false;

    //private float tiempoJugado = 0f;
    //private float siguienteX = 15f;
    //private int ultimoSpriteSaltar = -1;    // Para evitar repetir sprites consecutivos
    //private int ultimoSpriteDeslizar = -1;  // Para evitar repetir sprites consecutivos
    //public List<float> posicionesObstaculosX = new List<float>();

    //void Start()
    //{
    //    string escena = SceneManager.GetActiveScene().name;
    //    modoDificil = (escena == "nivelDificil");
    //    esEscenaNormal = (escena == "nivelNormal");

    //    // Verificar que tenemos sprites asignados
    //    VerificarSprites();

    //    SpawnObstaculo(); // Spawn initial obstacle
    //}

    //void VerificarSprites()
    //{
    //    bool hayError = false;

    //    if (spritesSaltar.Length == 0 || SonTodosNull(spritesSaltar))
    //    {
    //        Debug.LogWarning("No hay sprites asignados para obstáculos de saltar!");
    //        hayError = true;
    //    }

    //    if (spritesDeslizar.Length == 0 || SonTodosNull(spritesDeslizar))
    //    {
    //        Debug.LogWarning("No hay sprites asignados para obstáculos de deslizar!");
    //        hayError = true;
    //    }

    //    if (hayError)
    //    {
    //        Debug.LogWarning("Asigna los sprites en el inspector para ver la variación visual.");
    //    }
    //}

    //bool SonTodosNull(Sprite[] sprites)
    //{
    //    foreach (Sprite sprite in sprites)
    //    {
    //        if (sprite != null) return false;
    //    }
    //    return true;
    //}

    //void Update()
    //{
    //    tiempoJugado += Time.deltaTime;
    //    ActualizarDificultad();

    //    if (jugador.position.x >= siguienteX)
    //    {
    //        SpawnObstaculo();
    //        siguienteX += distanciaEntreObstaculos;
    //    }
    //}

    //void ActualizarDificultad()
    //{
    //    if (modoDificil)
    //    {
    //        distanciaEntreObstaculos = Mathf.Lerp(8f, 5f, Mathf.Clamp01(tiempoJugado / 180f));
    //    }
    //    else
    //    {
    //        if (tiempoJugado < 30f)
    //            distanciaEntreObstaculos = 13f;
    //        else if (tiempoJugado < 60f)
    //            distanciaEntreObstaculos = 11f;
    //        else if (tiempoJugado < 90f)
    //            distanciaEntreObstaculos = 9f;
    //        else if (tiempoJugado < 120f)
    //            distanciaEntreObstaculos = 7f;
    //        else if (tiempoJugado < 180f)
    //            distanciaEntreObstaculos = 6f;
    //        else
    //            distanciaEntreObstaculos = Random.Range(3.5f, 5f);
    //    }
    //}

    //void SpawnObstaculo()
    //{
    //    GameObject prefabElegido;
    //    bool esSaltar;

    //    // Determinar tipo de obstáculo
    //    if (tiempoJugado < 15f)
    //    {
    //        prefabElegido = obstaculoSaltar;
    //        esSaltar = true;
    //    }
    //    else
    //    {
    //        esSaltar = Random.value > 0.5f;
    //        prefabElegido = esSaltar ? obstaculoSaltar : obstaculoDeslizar;
    //    }

    //    // Determinar posición
    //    Vector3 posicionSpawn = new Vector3(jugador.position.x + 15f, 0f, 0f);
    //    if (esSaltar)
    //        posicionSpawn.y = 2.8f;
    //    else
    //        posicionSpawn.y = 5.6f;

    //    // Instanciar el obstáculo
    //    GameObject obstaculo = Instantiate(prefabElegido, posicionSpawn, Quaternion.identity);

    //    // Aplicar sprite aleatorio
    //    AplicarSpriteAleatorio(obstaculo, esSaltar);

    //    // Guardar posición
    //    posicionesObstaculosX.Add(posicionSpawn.x);

    //    // Limitar la lista a máximo 3 elementos
    //    if (posicionesObstaculosX.Count > 3)
    //    {
    //        posicionesObstaculosX.RemoveAt(0);
    //    }
    //}

    //void AplicarSpriteAleatorio(GameObject obstaculo, bool esSaltar)
    //{
    //    SpriteRenderer spriteRenderer = obstaculo.GetComponent<SpriteRenderer>();
    //    if (spriteRenderer == null)
    //    {
    //        Debug.LogWarning($"El obstáculo {obstaculo.name} no tiene SpriteRenderer!");
    //        return;
    //    }

    //    if (esSaltar && spritesSaltar.Length > 0)
    //    {
    //        // Elegir sprite para saltar (evitando repetir el último)
    //        int indiceSprite = ElegirSpriteAleatorio(spritesSaltar.Length, ultimoSpriteSaltar);
    //        if (spritesSaltar[indiceSprite] != null)
    //        {
    //            spriteRenderer.sprite = spritesSaltar[indiceSprite];
    //            ultimoSpriteSaltar = indiceSprite;
    //        }
    //    }
    //    else if (!esSaltar && spritesDeslizar.Length > 0)
    //    {
    //        // Elegir sprite para deslizar (evitando repetir el último)
    //        int indiceSprite = ElegirSpriteAleatorio(spritesDeslizar.Length, ultimoSpriteDeslizar);
    //        if (spritesDeslizar[indiceSprite] != null)
    //        {
    //            spriteRenderer.sprite = spritesDeslizar[indiceSprite];
    //            ultimoSpriteDeslizar = indiceSprite;
    //        }
    //    }
    //}

    //int ElegirSpriteAleatorio(int totalSprites, int ultimoIndice)
    //{
    //    if (totalSprites <= 1) return 0;

    //    int nuevoIndice;
    //    do
    //    {
    //        nuevoIndice = Random.Range(0, totalSprites);
    //    }
    //    while (nuevoIndice == ultimoIndice && totalSprites > 1);

    //    return nuevoIndice;
    //}

    //// Método para testing - cambiar sprites en runtime
    //[ContextMenu("Test Spawn Saltar")]
    //public void TestSpawnSaltar()
    //{
    //    Vector3 pos = new Vector3(jugador.position.x + 5f, 2.8f, 0f);
    //    GameObject test = Instantiate(obstaculoSaltar, pos, Quaternion.identity);
    //    AplicarSpriteAleatorio(test, true);
    //}

    //[ContextMenu("Test Spawn Deslizar")]
    //public void TestSpawnDeslizar()
    //{
    //    Vector3 pos = new Vector3(jugador.position.x + 5f, 5.6f, 0f);
    //    GameObject test = Instantiate(obstaculoDeslizar, pos, Quaternion.identity);
    //    AplicarSpriteAleatorio(test, false);
    //}

    [Header("Referencias")]
    public Transform jugador;
    public GameObject obstaculoSaltar;      // Prefab base para saltar
    public GameObject obstaculoDeslizar;    // Prefab base para deslizar

    [Header("Sprites para Obstáculos de Saltar")]
    public Sprite[] spritesSaltar = new Sprite[3];  // Array para 3 sprites de saltar

    [Header("Sprites para Obstáculos de Deslizar")]
    public Sprite[] spritesDeslizar = new Sprite[2]; // Array para 2 sprites de deslizar

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

        // Verificar que tenemos sprites asignados
        VerificarSprites();

        SpawnObstaculo(); // Spawn initial obstacle
    }

    void VerificarSprites()
    {
        bool hayError = false;

        if (spritesSaltar.Length == 0 || SonTodosNull(spritesSaltar))
        {
            Debug.LogWarning("No hay sprites asignados para obstáculos de saltar!");
            hayError = true;
        }

        if (spritesDeslizar.Length == 0 || SonTodosNull(spritesDeslizar))
        {
            Debug.LogWarning("No hay sprites asignados para obstáculos de deslizar!");
            hayError = true;
        }

        if (hayError)
        {
            Debug.LogWarning("Asigna los sprites en el inspector para ver la variación visual.");
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

    void Update()
    {
        tiempoJugado += Time.deltaTime;
        ActualizarDificultad();

        if (jugador.position.x >= siguienteX)
        {
            SpawnObstaculo();
            siguienteX += distanciaEntreObstaculos;
        }
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
        ConfigurarObstaculo(obstaculo);

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
            Debug.LogWarning($"El obstáculo {obstaculo.name} no tiene SpriteRenderer!");
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
    void ConfigurarObstaculo(GameObject obstaculo)
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

        // Ajustar tamaño del collider según el tipo de obstáculo
        SpriteRenderer sr = obstaculo.GetComponent<SpriteRenderer>();
        if (sr != null && sr.sprite != null)
        {
            Bounds spriteBounds = sr.sprite.bounds;

            // Detectar si es obstáculo de deslizar (está más arriba en Y)
            if (obstaculo.transform.position.y > 3f) // Los de deslizar están en Y=4f
            {
                // OBSTÁCULO DE DESLIZAR - Rectángulo largo
                collider.size = new Vector2(1, spriteBounds.size.y); // 3 veces más ancho
                collider.offset = new Vector2(0f, 0f); // Centrado
            }
            else
            {
                // OBSTÁCULO DE SALTAR - Tamaño normal
                collider.size = new Vector2(1.2f, 1.2f);
                collider.offset = new Vector2(0f, 0f);
            }
        }

        // Añadir visualizador de collider
        VisualizadorCollider visualizador = obstaculo.GetComponent<VisualizadorCollider>();
        if (visualizador == null)
        {
            visualizador = obstaculo.AddComponent<VisualizadorCollider>();
            visualizador.colorCollider = Color.red;
            visualizador.mostrarCollider = true;
        }
    }

    // Método para testing - cambiar sprites en runtime
    [ContextMenu("Test Spawn Saltar")]
    public void TestSpawnSaltar()
    {
        Vector3 pos = new Vector3(jugador.position.x + 5f, 2.2f, 0f);  // Posición actualizada
        GameObject test = Instantiate(obstaculoSaltar, pos, Quaternion.identity);
        ConfigurarObstaculo(test);  // AÑADIR ESTA LÍNEA
        AplicarSpriteAleatorio(test, true);
    }

    [ContextMenu("Test Spawn Deslizar")]
    public void TestSpawnDeslizar()
    {
        Vector3 pos = new Vector3(jugador.position.x + 5f, 4.5f, 0f);  // Posición actualizada
        GameObject test = Instantiate(obstaculoDeslizar, pos, Quaternion.identity);
        ConfigurarObstaculo(test);  // AÑADIR ESTA LÍNEA
        AplicarSpriteAleatorio(test, false);
    }
}