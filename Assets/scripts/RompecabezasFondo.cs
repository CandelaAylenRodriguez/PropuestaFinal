using UnityEngine;

public class FondoRompecabezasFollowPlayer : MonoBehaviour
{
    private Transform jugadorTransform;

    // Offset para que las piezas queden siempre en la misma zona de la pantalla
    public Vector3 offset = new Vector3(-8f, 4f, 0f);

    void Start()
    {
        jugadorTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (jugadorTransform != null)
        {
            // Solo seguimos en X
            transform.position = new Vector3(jugadorTransform.position.x, 0f, 0f) + offset;
        }
    }
}