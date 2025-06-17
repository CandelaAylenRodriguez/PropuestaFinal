using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // M�todo para comenzar el juego (cargar la escena del juego)
    public void ComenzarJuego()
    {
        // Cargar la escena de nivel normal o como lo hayas llamado
        SceneManager.LoadScene("nivelNormal"); // Cambia "nivelNormal" por el nombre de tu escena de juego
    }

    // M�todo para salir del juego
    public void SalirJuego()
    {
        // Si estamos en el editor de Unity, se detendr� la ejecuci�n
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    // Si estamos en una compilaci�n, cerramos la aplicaci�n
                    Application.Quit();
        #endif
    }
}