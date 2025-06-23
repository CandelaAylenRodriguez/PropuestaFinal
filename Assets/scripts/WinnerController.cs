using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerController : MonoBehaviour
{
    public TextMeshProUGUI txtPuntajeWinner;
    void Start()
    {
        // Mostrar el puntaje final guardado antes de llegar a la escena
        if (txtPuntajeWinner != null)
        {
            txtPuntajeWinner.text = "Puntaje: " + GameProgress.puntajeFinal;
            Debug.Log("[Winner] Puntaje final mostrado: " + GameProgress.puntajeFinal);
        }
        else
        {
            Debug.LogWarning("No se asignó el TextMeshProUGUI txtPuntajeWinner en el inspector.");
        }

        // Pausar la música si el AudioManager está activo
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.DetenerMusica();
        }
    }

    public void ReiniciarJuego()
    {
        GameProgress.ReiniciarProgreso();
        SceneManager.LoadScene("nivelNormal");
    }
}
