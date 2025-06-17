using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TemporizadorModoDificil : MonoBehaviour
{
    public float duracionModoDificil = 25f;
    private float tiempoTranscurrido = 0f;

    public Slider barraTiempo;

    void Start()
    {
        if (barraTiempo != null)
        {
            barraTiempo.maxValue = duracionModoDificil;
            barraTiempo.value = duracionModoDificil;
        }
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        float tiempoRestante = Mathf.Max(0f, duracionModoDificil - tiempoTranscurrido);

        if (barraTiempo != null)
        {
            barraTiempo.value = tiempoRestante;
        }

        if (tiempoTranscurrido >= duracionModoDificil)
        {
            SceneManager.LoadScene("nivelNormal");
        }
    }
}
