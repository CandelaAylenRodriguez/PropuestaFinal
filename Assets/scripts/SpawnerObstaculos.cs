using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerObstaculos : MonoBehaviour
{
    //[Header("Referencias")]
    //public Transform jugador;
    //public GameObject obstaculoSaltar;      // Prefab base para saltar
    //public GameObject obstaculoDeslizar;    // Prefab base para deslizar

    //[Header("Sprites para Obst�culos de Saltar")]
    //public Sprite[] spritesSaltar = new Sprite[3];  // Array para 3 sprites de saltar

    //[Header("Sprites para Obst�culos de Deslizar")]
    //public Sprite[] spritesDeslizar = new Sprite[2]; // Array para 2 sprites de deslizar

    //[Header("Configuraci�n")]
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
    //        Debug.LogWarning("No hay sprites asignados para obst�culos de saltar!");
    //        hayError = true;
    //    }

    //    if (spritesDeslizar.Length == 0 || SonTodosNull(spritesDeslizar))
    //    {
    //        Debug.LogWarning("No hay sprites asignados para obst�culos de deslizar!");
    //        hayError = true;
    //    }

    //    if (hayError)
    //    {
    //        Debug.LogWarning("Asigna los sprites en el inspector para ver la variaci�n visual.");
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

    //    // Determinar tipo de obst�culo
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

    //    // Determinar posici�n
    //    Vector3 posicionSpawn = new Vector3(jugador.position.x + 15f, 0f, 0f);
    //    if (esSaltar)
    //        posicionSpawn.y = 2.8f;
    //    else
    //        posicionSpawn.y = 5.6f;

    //    // Instanciar el obst�culo
    //    GameObject obstaculo = Instantiate(prefabElegido, posicionSpawn, Quaternion.identity);

    //    // Aplicar sprite aleatorio
    //    AplicarSpriteAleatorio(obstaculo, esSaltar);

    //    // Guardar posici�n
    //    posicionesObstaculosX.Add(posicionSpawn.x);

    //    // Limitar la lista a m�ximo 3 elementos
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
    //        Debug.LogWarning($"El obst�culo {obstaculo.name} no tiene SpriteRenderer!");
    //        return;
    //    }

    //    if (esSaltar && spritesSaltar.Length > 0)
    //    {
    //        // Elegir sprite para saltar (evitando repetir el �ltimo)
    //        int indiceSprite = ElegirSpriteAleatorio(spritesSaltar.Length, ultimoSpriteSaltar);
    //        if (spritesSaltar[indiceSprite] != null)
    //        {
    //            spriteRenderer.sprite = spritesSaltar[indiceSprite];
    //            ultimoSpriteSaltar = indiceSprite;
    //        }
    //    }
    //    else if (!esSaltar && spritesDeslizar.Length > 0)
    //    {
    //        // Elegir sprite para deslizar (evitando repetir el �ltimo)
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

    //// M�todo para testing - cambiar sprites en runtime
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

    [Header("Sprites para Obst�culos de Saltar")]
    public Sprite[] spritesSaltar = new Sprite[3];  // Array para 3 sprites de saltar

    [Header("Sprites para Obst�culos de Deslizar")]
    public Sprite[] spritesDeslizar = new Sprite[2]; // Array para 2 sprites de deslizar

    [Header("Configuraci�n")]
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
            Debug.LogWarning("No hay sprites asignados para obst�culos de saltar!");
            hayError = true;
        }

        if (spritesDeslizar.Length == 0 || SonTodosNull(spritesDeslizar))
        {
            Debug.LogWarning("No hay sprites asignados para obst�culos de deslizar!");
            hayError = true;
        }

        if (hayError)
        {
            Debug.LogWarning("Asigna los sprites en el inspector para ver la variaci�n visual.");
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

        // Determinar tipo de obst�culo
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

        // Determinar posici�n (ajustada m�s abajo)
        Vector3 posicionSpawn = new Vector3(jugador.position.x + 15f, 0f, 0f);
        if (esSaltar)
            posicionSpawn.y = 1.5f;
        else
            posicionSpawn.y = 4.7f;

        // Instanciar el obst�culo
        GameObject obstaculo = Instantiate(prefabElegido, posicionSpawn, Quaternion.identity);

        // Ajustar tama�o autom�ticamente
        obstaculo.transform.localScale = new Vector3(0.6f, 0.6f, 1f);

        // A�ADIR ESTA L�NEA:
        ConfigurarObstaculo(obstaculo);

        // Aplicar sprite aleatorio
        AplicarSpriteAleatorio(obstaculo, esSaltar);

        // Guardar posici�n
        posicionesObstaculosX.Add(posicionSpawn.x);

        // Limitar la lista a m�ximo 3 elementos
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
            Debug.LogWarning($"El obst�culo {obstaculo.name} no tiene SpriteRenderer!");
            return;
        }

        if (esSaltar && spritesSaltar.Length > 0)
        {
            // Elegir sprite para saltar (evitando repetir el �ltimo)
            int indiceSprite = ElegirSpriteAleatorio(spritesSaltar.Length, ultimoSpriteSaltar);
            if (spritesSaltar[indiceSprite] != null)
            {
                spriteRenderer.sprite = spritesSaltar[indiceSprite];
                ultimoSpriteSaltar = indiceSprite;
            }
        }
        else if (!esSaltar && spritesDeslizar.Length > 0)
        {
            // Elegir sprite para deslizar (evitando repetir el �ltimo)
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

        // Verificar/a�adir Box Collider 2D
        BoxCollider2D collider = obstaculo.GetComponent<BoxCollider2D>();
        if (collider == null)
        {
            collider = obstaculo.AddComponent<BoxCollider2D>();
        }

        // Configurar el collider correctamente
        collider.isTrigger = false;
        collider.sharedMaterial = null;

        // Ajustar tama�o del collider seg�n el tipo de obst�culo
        SpriteRenderer sr = obstaculo.GetComponent<SpriteRenderer>();
        if (sr != null && sr.sprite != null)
        {
            Bounds spriteBounds = sr.sprite.bounds;

            // Detectar si es obst�culo de deslizar (est� m�s arriba en Y)
            if (obstaculo.transform.position.y > 3f) // Los de deslizar est�n en Y=4f
            {
                // OBST�CULO DE DESLIZAR - Rect�ngulo largo
                collider.size = new Vector2(1, spriteBounds.size.y); // 3 veces m�s ancho
                collider.offset = new Vector2(0f, 0f); // Centrado
            }
            else
            {
                // OBST�CULO DE SALTAR - Tama�o normal
                collider.size = new Vector2(1.2f, 1.2f);
                collider.offset = new Vector2(0f, 0f);
            }
        }

        // A�adir visualizador de collider
        VisualizadorCollider visualizador = obstaculo.GetComponent<VisualizadorCollider>();
        if (visualizador == null)
        {
            visualizador = obstaculo.AddComponent<VisualizadorCollider>();
            visualizador.colorCollider = Color.red;
            visualizador.mostrarCollider = true;
        }
    }

    // M�todo para testing - cambiar sprites en runtime
    [ContextMenu("Test Spawn Saltar")]
    public void TestSpawnSaltar()
    {
        Vector3 pos = new Vector3(jugador.position.x + 5f, 2.2f, 0f);  // Posici�n actualizada
        GameObject test = Instantiate(obstaculoSaltar, pos, Quaternion.identity);
        ConfigurarObstaculo(test);  // A�ADIR ESTA L�NEA
        AplicarSpriteAleatorio(test, true);
    }

    [ContextMenu("Test Spawn Deslizar")]
    public void TestSpawnDeslizar()
    {
        Vector3 pos = new Vector3(jugador.position.x + 5f, 4.5f, 0f);  // Posici�n actualizada
        GameObject test = Instantiate(obstaculoDeslizar, pos, Quaternion.identity);
        ConfigurarObstaculo(test);  // A�ADIR ESTA L�NEA
        AplicarSpriteAleatorio(test, false);
    }
}