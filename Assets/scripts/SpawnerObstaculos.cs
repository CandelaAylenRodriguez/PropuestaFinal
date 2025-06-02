using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerObstaculos : MonoBehaviour
{
    public Transform jugador;
    public GameObject obstaculoSaltar;
    public GameObject obstaculoDeslizar;
    public GameObject obstaculoModoDificil;

    private float tiempoJugado = 0f;
    public float distanciaEntreObstaculos = 10f;
    private float siguienteX = 15f;

    public bool modoDificil = false;
    public bool esEscenaNormal = false;
    public GameObject prefabMoneda;
    public static List<float> posicionesObstaculoX = new List<float>();

    void Start()
    {
        string escena = SceneManager.GetActiveScene().name;
        modoDificil = (escena == "nivelDificil");
        esEscenaNormal = (escena == "nivelNormal");

        SpawnObstaculo(); // Spawn initial obstacle
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
        // PROBABILIDAD DE OBSTÁCULO MODO DIFÍCIL SOLO EN ESCENA NORMAL
        if (esEscenaNormal && obstaculoModoDificil != null)
        {
            float probabilidad = Mathf.Clamp01(tiempoJugado / 60f); // 0 a 1 en 60 segundos
            if (Random.value < probabilidad)
            {
                Vector3 posicionEspecial = new Vector3(jugador.position.x + 15f, 4f, 0f);
                Instantiate(obstaculoModoDificil, posicionEspecial, Quaternion.identity);
                return; 
            }
        }

        GameObject prefabElegido;

        if (tiempoJugado < 15f)
        {
            prefabElegido = obstaculoSaltar;
        }
        else
        {
            prefabElegido = Random.value > 0.5f ? obstaculoSaltar : obstaculoDeslizar;
        }

        Vector3 posicionSpawn = new Vector3(jugador.position.x + 15f, 0f, 0f);

        if (prefabElegido == obstaculoSaltar)
            posicionSpawn.y = 2.8f;
        else
            posicionSpawn.y = 5.6f;

        Instantiate(prefabElegido, posicionSpawn, Quaternion.identity);

        posicionesObstaculoX.Add(posicionSpawn.x);

        // GENERAR MONEDAS ENTRE OBSTÁCULOS
        if (posicionesObstaculoX.Count >= 2)
        {
            float desdeX = posicionesObstaculoX[posicionesObstaculoX.Count - 2];
            float hastaX = posicionesObstaculoX[posicionesObstaculoX.Count - 1];

            if (hastaX - desdeX > 6f)
            {
                SpawnGrupoMonedas(desdeX, hastaX);
            }
        }
    }

    void SpawnGrupoMonedas(float desdeX, float hastaX)
    {
        int cantidad = Random.Range(3, 5); // 3 o 4 monedas
        float separacion = (hastaX - desdeX) / (cantidad + 1);
        float altura = Random.Range(2.5f, 4.5f);

        for (int i = 1; i <= cantidad; i++)
        {
            float x = desdeX + i * separacion;
            Vector3 posicion = new Vector3(x, altura, 0f);
            GameObject nuevaMoneda = Instantiate(prefabMoneda, posicion, Quaternion.identity);

            Moneda monedaScript = nuevaMoneda.GetComponent<Moneda>();
            if (monedaScript != null)
            {
                monedaScript.valor = modoDificil ? 300 : 100;
            }
        }
    }
}