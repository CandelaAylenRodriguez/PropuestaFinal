using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Transform jugadorTransform;
    public GameObject recolectablePrefab;
    public Vector2 areaMin;
    public Vector2 areaMax;
    private GameObject recolectableActual;
    public SpawnerObstaculos spawnerObstaculos;
    public TextMeshProUGUI txtNivel;
    public TextMeshProUGUI txtPuntaje;

    [Header("Configuración de Recolectables")]
    public float distanciaAdelanteJugador = 20f; 
    public float rangoDistanciaExtra = 10f;

    private void Start()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            jugadorTransform = jugador.transform;
        }
        else
        {
            //Debug.LogError("No se encontró el objeto con tag 'Player'!");
        }

        string nombreEscena = SceneManager.GetActiveScene().name;
        string nivel = ExtraerNumeroNivel(nombreEscena);
        txtNivel.text = "Nivel " + nivel;

        StartCoroutine(GenerarRecolectableCada10Segundos());
    }

    void Update()
    {
        txtPuntaje.text = "Puntaje: " + GameProgress.ObtenerPuntaje().ToString();
    }

    string ExtraerNumeroNivel(string escena)
    {
        if(escena == "nivelNormal")
        {
            return "1"; // Nivel normal
        } 
        else if (escena == "nivel2")
        {
            return "2"; // Nivel 2
        } 
        else if (escena == "nivel3")
        {
            return "3"; // Nivel 3
        } else
        {
          return "1"; // Para otros casos
        }
    }

    private IEnumerator GenerarRecolectableCada10Segundos()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            if (recolectableActual == null)
            {
                GenerarRecolectable();
            }
        }
    }
    private void GenerarRecolectable()
    {
        if (jugadorTransform == null || spawnerObstaculos == null)
        {
            //Debug.LogWarning("Faltan referencias para generar recolectable.");
            return;
        }

        float posicionJugador = jugadorTransform.position.x;
        float distanciaEntre = spawnerObstaculos.distanciaEntreObstaculos;

        // Buscar el primer obstáculo por delante del jugador
        float? obstaculoDelantero = null;
        foreach (float pos in spawnerObstaculos.posicionesObstaculosX)
        {
            if (pos > posicionJugador)
            {
                obstaculoDelantero = pos;
                break;
            }
        }

        // Si no se encuentra ningún obstáculo, abortamos
        if (obstaculoDelantero == null)
        {
            //Debug.LogWarning("No hay obstáculo por delante del jugador para colocar el recolectable.");
            return;
        }

        // Calcular posición intermedia
        float posXRecolectable = obstaculoDelantero.Value + (distanciaEntre / 2f);

        // Altura del piso (ajustable)
        float alturaDelPiso = 3.5f;

        Vector2 posicionRecolectable = new Vector2(posXRecolectable, alturaDelPiso);
        recolectableActual = Instantiate(recolectablePrefab, posicionRecolectable, Quaternion.identity);
    }

    public void RecolectableRecogido()
    {
        if (recolectableActual != null)
        {
            Destroy(recolectableActual);
            recolectableActual = null;
        }
    }

    public void VolverAlMenu()
    {
        // Detener la música
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.DetenerMusica(); // Asegúrate de tener este método
        }

        // Reiniciar progreso general
        GameProgress.ReiniciarProgreso();

        // Volver al menú
        SceneManager.LoadScene("MenuPrincipal");
    }
}
