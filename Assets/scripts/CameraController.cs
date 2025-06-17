using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    //public Jugador player;
    //public SpawnerObstaculos spawnerObstaculos;
    //public bool estaEnModoDificil = false;

    //private void Start()
    //{
    //    if (player == null)
    //    {
    //        GameObject obj = GameObject.FindWithTag("Player");
    //        if (obj != null)
    //        {
    //            player = obj.GetComponent<Jugador>();
    //        }
    //    }

    //    if (spawnerObstaculos == null)
    //    {
    //        GameObject spaw = GameObject.FindWithTag("SpawnerObstaculos");
    //        if (spaw != null)
    //        {
    //            spawnerObstaculos = spaw.GetComponent<SpawnerObstaculos>();
    //        }
    //    }

    //    // Detectar si estamos en nivel difícil
    //    estaEnModoDificil = (SceneManager.GetActiveScene().name == "nivelDificil");
    //}
    //void Update()
    //{
    //    if (player == null) return;

    //    if (spawnerObstaculos != null)
    //    {
    //        transform.position += Vector3.right * player.velocidadConstante * Time.deltaTime;
    //    }

    //    if (player.transform.position.x < transform.position.x - 8f)
    //    {
    //        if (!estaEnModoDificil)
    //        {
    //            // Cambiar a nivel difícil
    //            CambiarDeEscena("nivelDificil");
    //        }
    //        else
    //        {
    //            // Buscar el Canvas y luego el panel de GameOver dentro de ese Canvas
    //            Canvas canvas = GameObject.FindObjectOfType<Canvas>(); // Encuentra el Canvas en la escena

    //            if (canvas != null)
    //            {
    //                // Buscar el panel de GameOver dentro del Canvas
    //                GameObject gameOverPanel = canvas.transform.Find("GameOver")?.gameObject;

    //                if (gameOverPanel != null)
    //                {
    //                    // Activar el panel de GameOver
    //                    gameOverPanel.SetActive(true);
    //                    // Pausar el juego
    //                    Time.timeScale = 0f;
    //                }
    //                else
    //                {
    //                    Debug.LogWarning("No se encontró el panel GameOver dentro del Canvas");
    //                }
    //            }
    //            else
    //            {
    //                Debug.LogWarning("No se encontró el Canvas en la escena");
    //            }
    //        }
    //    }
    //}

    //// Método para cambiar de escena
    //void CambiarDeEscena(string nombreEscena)
    //{
    //    // Cargar la escena con el nombre que le pasamos
    //    SceneManager.LoadScene(nombreEscena);

    //    // Actualizar el estado de dificultad
    //    estaEnModoDificil = (nombreEscena == "nivelDificil");
    //}

    // public void ReanudarJuego()
    //{
    //    // Reanudar el tiempo
    //    Time.timeScale = 1f;

    //    // Ocultar el panel de GameOver
    //    Canvas canvas = GameObject.FindObjectOfType<Canvas>();
    //    if (canvas != null)
    //    {
    //        GameObject gameOverPanel = canvas.transform.Find("GameOver")?.gameObject;
    //        if (gameOverPanel != null)
    //        {
    //            gameOverPanel.SetActive(false);
    //        }
    //    }

    //    // Cambiar a la escena "nivelNormal"
    //    SceneManager.LoadScene("nivelNormal");
    //}

    public Jugador player;
    public SpawnerObstaculos spawnerObstaculos;
    public bool estaEnModoDificil = false;
    private void Start()
    {
        if (player == null)
        {
            GameObject obj = GameObject.FindWithTag("Player");
            if (obj != null)
            {
                player = obj.GetComponent<Jugador>();
            }
        }

        if (spawnerObstaculos == null)
        {
            GameObject spaw = GameObject.FindWithTag("SpawnerObstaculos");
            if (spaw != null)
            {
                spawnerObstaculos = spaw.GetComponent<SpawnerObstaculos>();
            }
        }

        // Detectar si estamos en nivel difícil
        estaEnModoDificil = (SceneManager.GetActiveScene().name == "nivelDificil");

        // NUEVO: Asegurar posición Z correcta de la cámara
        Vector3 pos = transform.position;
        pos.z = -10f;
        transform.position = pos;
    }

    // CAMBIADO: Usar LateUpdate en lugar de Update
    void LateUpdate()
    {
        if (player == null) return;

        // CORREGIDO: Cámara avanza a velocidad constante, no sigue al jugador
        if (spawnerObstaculos != null)
        {
            // Mover la cámara a velocidad constante hacia la derecha
            transform.position += Vector3.right * player.velocidadConstante * Time.deltaTime;
        }

        // Verificar game over
        if (player.transform.position.x < transform.position.x - 8f)
        {
            if (!estaEnModoDificil)
            {
                // Cambiar a nivel difícil
                CambiarDeEscena("nivelDificil");
            }
            else
            {
                // Buscar el Canvas y luego el panel de GameOver dentro de ese Canvas
                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                if (canvas != null)
                {
                    // Buscar el panel de GameOver dentro del Canvas
                    GameObject gameOverPanel = canvas.transform.Find("GameOver")?.gameObject;
                    if (gameOverPanel != null)
                    {
                        // Activar el panel de GameOver
                        gameOverPanel.SetActive(true);
                        // Pausar el juego
                        Time.timeScale = 0f;
                    }
                    else
                    {
                        Debug.LogWarning("No se encontró el panel GameOver dentro del Canvas");
                    }
                }
                else
                {
                    Debug.LogWarning("No se encontró el Canvas en la escena");
                }
            }
        }
    }

    // Método para cambiar de escena
    void CambiarDeEscena(string nombreEscena)
    {
        // Cargar la escena con el nombre que le pasamos
        SceneManager.LoadScene(nombreEscena);
        // Actualizar el estado de dificultad
        estaEnModoDificil = (nombreEscena == "nivelDificil");
    }

    public void ReanudarJuego()
    {
        // Reanudar el tiempo
        Time.timeScale = 1f;
        // Ocultar el panel de GameOver
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            GameObject gameOverPanel = canvas.transform.Find("GameOver")?.gameObject;
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(false);
            }
        }
        // Cambiar a la escena "nivelNormal"
        SceneManager.LoadScene("nivelNormal");
    }
}
