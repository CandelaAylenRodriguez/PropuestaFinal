using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Tutorial : MonoBehaviour
{
    [Header("Configuración")]
    public float delayBoton = 0.5f;

    void Start()
    {
        // Asegurar que no haya música en el menú
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.DetenerMusica();
            Debug.Log("Música detenida en el menú principal");
        }

        // DEBUG: Verificar AudioManager
        if (AudioManager.Instance != null)
        {
            Debug.Log("AudioManager encontrado en MenuPrincipal");

            if (AudioManager.Instance.sonidoBtn != null)
            {
                Debug.Log("Sonido de botón está asignado");
            }
            else
            {
                Debug.LogWarning("Sonido de botón NO está asignado!");
            }
        }
        else
        {
            Debug.LogError("AudioManager NO encontrado en MenuPrincipal!");
        }
    }
    public void ComenzarJuego()
    {
        // Iniciar corrutina para reproducir sonido y luego cambiar escena
        StartCoroutine(ComenzarJuegoConSonido());
    }

    private IEnumerator ComenzarJuegoConSonido()
    {
        // REPRODUCIR SONIDO DE BOTÓN
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ReproducirSonidoBtn();
            Debug.Log("Sonido de botón iniciado");
        }
        else
        {
            Debug.LogError("AudioManager.Instance es null!");
        }

        // Esperar que termine el sonido
        yield return new WaitForSeconds(delayBoton);

        // Cargar la escena
        SceneManager.LoadScene("nivelNormal");
    }
}
