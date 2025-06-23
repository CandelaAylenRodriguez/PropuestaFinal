
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Jugador player;
    public SpawnerObstaculos spawnerObstaculos;
    public TextMeshProUGUI textoPuntajeGameOver;

    private bool estaEnModoDificil = false;
    private float tiempoModoDificil = 0f;
    public float duracionModoDificil = 25f;

    private void Start()
    {
        if (player == null)
        {
            GameObject obj = GameObject.FindWithTag("Player");
            if (obj != null)
                player = obj.GetComponent<Jugador>();
        }

        if (spawnerObstaculos == null)
        {
            GameObject spaw = GameObject.FindWithTag("SpawnerObstaculos");
            if (spaw != null)
                spawnerObstaculos = spaw.GetComponent<SpawnerObstaculos>();
        }

        estaEnModoDificil = SceneManager.GetActiveScene().name == "nivelDificil";

        if (!estaEnModoDificil)
        {
            GameProgress.escenaAnterior = SceneManager.GetActiveScene().name;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ReproducirMusicaSegunEscena();
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        if (spawnerObstaculos != null)
        {
            transform.position += Vector3.right * player.velocidadConstante * Time.deltaTime;
        }

        float distanciaTolerancia = estaEnModoDificil ? 4f : 8f;

        if (player.transform.position.x < transform.position.x - distanciaTolerancia)
        {
            if (!estaEnModoDificil)
            {
                if (AudioManager.Instance != null && AudioManager.Instance.musicaDificil != null)
                {
                    AudioManager.Instance.CambiarMusica(AudioManager.Instance.musicaDificil);
                }

                GameProgress.escenaActual = SceneManager.GetActiveScene().name;
                GameProgress.tiempoJugadoNormal = spawnerObstaculos != null ? spawnerObstaculos.GetTiempoJugado() : 0f;
                SceneManager.LoadScene("nivelDificil");
            }
            else
            {
                MostrarGameOver();
            }
        }

        // Control de tiempo en modo difícil
        if (estaEnModoDificil)
        {
            tiempoModoDificil += Time.deltaTime;
            if (tiempoModoDificil >= duracionModoDificil)
            {
                SceneManager.LoadScene(GameProgress.escenaActual);
            }
        }
    }

    void MostrarGameOver()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PausarMusica();
        }

        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            Transform gameOverTransform = canvas.transform.Find("GameOver");
            if (gameOverTransform != null)
            {
                gameOverTransform.gameObject.SetActive(true);
                Time.timeScale = 0f;

                TextMeshProUGUI txtPuntaje = gameOverTransform.Find("txtGameOverPuntaje")?.GetComponent<TextMeshProUGUI>();
                if (txtPuntaje != null)
                {
                    txtPuntaje.text = "Puntuación: " + GameProgress.ObtenerPuntaje();
                }
            }
        }
    }

    public void ReiniciarDesdeGameOver()
    {
        Input.ResetInputAxes();
        Time.timeScale = 1f;

        GameProgress.ReiniciarProgreso();

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.CambiarMusica(AudioManager.Instance.musicaNormal);
        }

        SceneManager.LoadScene("nivelNormal");
    }
}