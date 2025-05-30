using UnityEngine;
using UnityEngine.SceneManagement;

public class TemporizadorModoDificil : MonoBehaviour
{
    public float duracionModoDificil = 25f;
    private float tiempoTranscurrido = 0f;

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= duracionModoDificil)
        {
            SceneManager.LoadScene("nivelNormal");
        }
    }
}
