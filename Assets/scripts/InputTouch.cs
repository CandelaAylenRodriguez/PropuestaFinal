using UnityEngine;

public class InputTouch : MonoBehaviour
{
    private Vector2 inicioToque;
    private Vector2 finToque;

    public float distanciaMinSwipe = 50f;

    private Jugador jugador;

    void Start()
    {
        jugador = GetComponent<Jugador>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            switch (toque.phase)
            {
                case TouchPhase.Began:
                    inicioToque = toque.position;
                    break;

                case TouchPhase.Ended:
                    finToque = toque.position;
                    DetectarEntrada();
                    break;
            }
        }

#if UNITY_EDITOR
        // Simulación con mouse
        if (Input.GetMouseButtonDown(0))
        {
            inicioToque = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            finToque = Input.mousePosition;
            DetectarEntrada();
        }
#endif
    }

    void DetectarEntrada()
    {
        float distancia = (finToque - inicioToque).magnitude;
        Vector2 direccion = finToque - inicioToque;

        if (distancia < distanciaMinSwipe)
        {
            // Toque corto o click → salto
            jugador.Saltar();
        }
        else
        {
            // Swipe
            if (Mathf.Abs(direccion.x) > Mathf.Abs(direccion.y) && direccion.x > 0)
            {
                jugador.Deslizarse();
            }
        }
    }
}