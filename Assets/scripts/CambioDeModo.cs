using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeModo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NivelDificilTrigger"))
        {
            //SceneManager.LoadScene("nivelDificil");
            GameManager.Instance.CambiarEscena("nivelDificil");
        }
    }
}
