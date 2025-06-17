using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //private Transform jugadorTransform;
    //public GameObject[] piezasRompecabezas; 
    //public GameObject recolectablePrefab;   
    //public Vector2 areaMin;                
    //public Vector2 areaMax;                 

    //private int piezasDesbloqueadas = 0;
    //private GameObject recolectableActual;
    //public SpawnerObstaculos spawnerObstaculos;

    //private void Start()
    //{
    //    piezasDesbloqueadas = GameProgress.piezasDesbloqueadas;

    //    // Desactivar/activar piezas seg�n progreso guardado
    //    for (int i = 0; i < piezasRompecabezas.Length; i++)
    //    {
    //        piezasRompecabezas[i].SetActive(i < piezasDesbloqueadas);
    //    }

    //    GameObject jugador = GameObject.FindGameObjectWithTag("Player");
    //    if (jugador != null)
    //    {
    //        jugadorTransform = jugador.transform;
    //    }
    //    else
    //    {
    //        Debug.LogError("No se encontr� el objeto con tag 'Player'!");
    //    }

    //    // Iniciamos la rutina para generar recolectables
    //    StartCoroutine(GenerarRecolectableCada10Segundos());
    //}

    //private IEnumerator GenerarRecolectableCada10Segundos()
    //{
    //    while (true)
    //    {
    //        // Esperamos 10 segundos
    //        yield return new WaitForSeconds(10f);

    //        // Si ya hay un recolectable en la escena, no generamos otro
    //        if (recolectableActual == null)
    //        {
    //            GenerarRecolectable();
    //        }
    //    }
    //}

    //private void GenerarRecolectable()
    //{
    //    if (jugadorTransform == null) return;

    //    float posXRecolectable;

    //    // Asegurarse que haya al menos 2 obst�culos spawneados
    //    if (spawnerObstaculos == null || spawnerObstaculos.posicionesObstaculosX.Count >= 2)
    //    {
    //        float x1 = spawnerObstaculos.posicionesObstaculosX[spawnerObstaculos.posicionesObstaculosX.Count - 2];
    //        float x2 = spawnerObstaculos.posicionesObstaculosX[spawnerObstaculos.posicionesObstaculosX.Count - 1];

    //        posXRecolectable = (x1 + x2) / 2f;
    //    }
    //    else
    //    {
    //        // Si no hay 2 obst�culos, lo ponemos un poco delante del jugador
    //        posXRecolectable = jugadorTransform.position.x + 10f;
    //    }

    //    // Y aleatorio como siempre
    //    float posYRecolectable = Random.Range(3.0f, 5.5f);

    //    Vector2 posicionRecolectable = new Vector2(posXRecolectable, posYRecolectable);

    //    recolectableActual = Instantiate(recolectablePrefab, posicionRecolectable, Quaternion.identity);
    //}

    //public void RecolectableRecogido()
    //{
    //    // Destruimos el recolectable actual
    //    if (recolectableActual != null)
    //    {
    //        Destroy(recolectableActual);
    //        recolectableActual = null;
    //    }

    //    // Activamos la siguiente pieza del rompecabezas si quedan piezas por activar
    //    if (piezasDesbloqueadas < piezasRompecabezas.Length)
    //    {
    //        piezasRompecabezas[piezasDesbloqueadas].SetActive(true);
    //        piezasDesbloqueadas++;

    //        // Guardamos progreso global
    //        GameProgress.piezasDesbloqueadas = piezasDesbloqueadas;
    //    }
    //}

    private Transform jugadorTransform;
    public GameObject[] piezasRompecabezas;
    public GameObject recolectablePrefab;
    public Vector2 areaMin;
    public Vector2 areaMax;
    private int piezasDesbloqueadas = 0;
    private GameObject recolectableActual;
    public SpawnerObstaculos spawnerObstaculos;

    [Header("Configuraci�n de Recolectables")]
    public float distanciaAdelanteJugador = 20f; // Distancia m�nima adelante del jugador
    public float rangoDistanciaExtra = 10f;      // Rango adicional aleatorio

    private void Start()
    {
        piezasDesbloqueadas = GameProgress.piezasDesbloqueadas;
        // Desactivar/activar piezas seg�n progreso guardado
        for (int i = 0; i < piezasRompecabezas.Length; i++)
        {
            piezasRompecabezas[i].SetActive(i < piezasDesbloqueadas);
        }

        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            jugadorTransform = jugador.transform;
        }
        else
        {
            Debug.LogError("No se encontr� el objeto con tag 'Player'!");
        }

        // Iniciamos la rutina para generar recolectables
        StartCoroutine(GenerarRecolectableCada10Segundos());
    }

    private IEnumerator GenerarRecolectableCada10Segundos()
    {
        while (true)
        {
            // Esperamos 10 segundos
            yield return new WaitForSeconds(10f);
            // Si ya hay un recolectable en la escena, no generamos otro
            if (recolectableActual == null)
            {
                GenerarRecolectable();
            }
        }
    }

    private void GenerarRecolectable()
    {
        if (jugadorTransform == null) return;

        float posXRecolectable;

        // CORREGIDO: Calcular posici�n siempre adelante del jugador
        float posicionBaseJugador = jugadorTransform.position.x;
        float distanciaMinima = posicionBaseJugador + distanciaAdelanteJugador;

        // Buscar obst�culos que est�n adelante del jugador
        if (spawnerObstaculos != null && spawnerObstaculos.posicionesObstaculosX.Count >= 2)
        {
            // Filtrar obst�culos que est�n adelante del punto m�nimo
            System.Collections.Generic.List<float> obstaculosAdelante = new System.Collections.Generic.List<float>();

            foreach (float posObstaculo in spawnerObstaculos.posicionesObstaculosX)
            {
                if (posObstaculo > distanciaMinima)
                {
                    obstaculosAdelante.Add(posObstaculo);
                }
            }

            // Si tenemos al menos 2 obst�culos adelante, colocar entre ellos
            if (obstaculosAdelante.Count >= 2)
            {
                // Tomar los dos primeros obst�culos adelante del jugador
                float x1 = obstaculosAdelante[0];
                float x2 = obstaculosAdelante[1];
                posXRecolectable = (x1 + x2) / 2f;
            }
            else
            {
                // Si no hay suficientes obst�culos adelante, usar distancia fija + aleatoria
                posXRecolectable = distanciaMinima + Random.Range(0f, rangoDistanciaExtra);
            }
        }
        else
        {
            // Si no hay obst�culos o spawner, usar distancia fija + aleatoria
            posXRecolectable = distanciaMinima + Random.Range(0f, rangoDistanciaExtra);
        }

        // Y aleatoria como siempre
        float posYRecolectable = Random.Range(3.0f, 5.5f);
        Vector2 posicionRecolectable = new Vector2(posXRecolectable, posYRecolectable);

        recolectableActual = Instantiate(recolectablePrefab, posicionRecolectable, Quaternion.identity);

        // DEBUG: Mostrar info en consola
        Debug.Log($"Recolectable generado en X: {posXRecolectable:F1} (Jugador en X: {posicionBaseJugador:F1})");
    }

    public void RecolectableRecogido()
    {
        // Destruimos el recolectable actual
        if (recolectableActual != null)
        {
            Destroy(recolectableActual);
            recolectableActual = null;
        }

        // Activamos la siguiente pieza del rompecabezas si quedan piezas por activar
        if (piezasDesbloqueadas < piezasRompecabezas.Length)
        {
            piezasRompecabezas[piezasDesbloqueadas].SetActive(true);
            piezasDesbloqueadas++;
            // Guardamos progreso global
            GameProgress.piezasDesbloqueadas = piezasDesbloqueadas;

            Debug.Log($"Pieza desbloqueada! Total: {piezasDesbloqueadas}/{piezasRompecabezas.Length}");
        }
    }
}
