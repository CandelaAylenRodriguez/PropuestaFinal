using UnityEngine;

public class Moneda : MonoBehaviour
{
    public GameManager gameManager;
    public int valor = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SumarPuntaje(valor);
            Destroy(gameObject);
        }
    }
}
