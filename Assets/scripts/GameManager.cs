using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverPanel;
    public TextMeshProUGUI contadorMonedasText;
    public int contadorMonedas = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Espera un frame para que todos los objetos se carguen antes de buscar el panel
        StartCoroutine(AsignarGameOverPanel());

        if (contadorMonedasText == null)
        {
            GameObject obj = GameObject.FindWithTag("TextoPuntaje");
            if (obj != null)
            {
                contadorMonedasText = obj.GetComponent<TextMeshProUGUI>();
            }
        }

        ActualizarTexto();
    }
    public void SumarPuntaje(int cantidad)
    {
        contadorMonedas += cantidad;
        ActualizarTexto();
    }

    public void ActualizarTexto()
    {
        if (contadorMonedasText != null)
        {
            contadorMonedasText.text = "Puntaje: " + contadorMonedas.ToString();
        }
        else
        {
            Debug.LogWarning("No se encontró el texto de puntaje en esta escena.");
        }
    }

    public void ReiniciarPuntaje()
    {
        contadorMonedas = 0;
        ActualizarTexto();
    }

    private IEnumerator AsignarGameOverPanel()
    {
        yield return null; // espera 1 frame

        GameObject panel = GameObject.Find("GameOver");

        if (panel != null)
        {
            gameOverPanel = panel;
            gameOverPanel.SetActive(false);
            Debug.Log("gameOverPanel asignado correctamente.");
        }
        else
        {
            Debug.LogWarning("no se encontró GameOverPanel en la escena actual.");
        }
    }

    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogWarning("GameOverPanel no está asignado en GameManager.");
        }
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CambiarEscena(string nombreEscena)
    {
        Time.timeScale = 1f;
        StartCoroutine(CargarEscenaConPanel(nombreEscena));
    }

    private IEnumerator CargarEscenaConPanel(string nombreEscena)
    {
        yield return SceneManager.LoadSceneAsync(nombreEscena);
        yield return null; // espera a que todo en la nueva escena esté activo

        GameObject panel = GameObject.Find("GameOver");
        if (panel != null)
        {
            gameOverPanel = panel;
            gameOverPanel.SetActive(false);
            Debug.Log("panel asignado tras cambio de escena.");
        }
        else
        {
            Debug.LogWarning("gameOverPanel no encontrado tras cambio de escena.");
        }
    }

    public void SetGameOverPanel(GameObject panel)
    {
        gameOverPanel = panel;
        gameOverPanel.SetActive(false);
    }
}