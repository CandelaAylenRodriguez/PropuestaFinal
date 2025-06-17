using UnityEngine;

public class VisualizadorCollider : MonoBehaviour
{
    [Header("Configuración de Visualización")]
    public bool mostrarCollider = true;
    public Color colorCollider = Color.red;
    public bool mostrarSiempre = true;  // Si false, solo se muestra cuando está seleccionado

    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;
    private CapsuleCollider2D capsuleCollider;

    void Start()
    {
        // Buscar todos los tipos de colliders 2D
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void OnDrawGizmos()
    {
        if (!mostrarCollider || !mostrarSiempre) return;
        DibujarColliders();
    }

    void OnDrawGizmosSelected()
    {
        if (!mostrarCollider || mostrarSiempre) return;
        DibujarColliders();
    }

    void DibujarColliders()
    {
        Gizmos.color = colorCollider;

        // Dibujar BoxCollider2D
        if (boxCollider != null)
        {
            Vector3 centro = transform.position + (Vector3)boxCollider.offset;
            Vector3 tamaño = new Vector3(
                boxCollider.size.x * transform.localScale.x,
                boxCollider.size.y * transform.localScale.y,
                0.1f
            );

            // Dibujar el wireframe del collider
            Gizmos.DrawWireCube(centro, tamaño);

            // Opcional: dibujar con transparencia
            Color colorTransparente = colorCollider;
            colorTransparente.a = 0.2f;
            Gizmos.color = colorTransparente;
            Gizmos.DrawCube(centro, tamaño);
        }

        // Dibujar CircleCollider2D
        if (circleCollider != null)
        {
            Vector3 centro = transform.position + (Vector3)circleCollider.offset;
            float radio = circleCollider.radius * Mathf.Max(transform.localScale.x, transform.localScale.y);

            Gizmos.color = colorCollider;
            Gizmos.DrawWireSphere(centro, radio);
        }

        // Dibujar CapsuleCollider2D
        if (capsuleCollider != null)
        {
            Vector3 centro = transform.position + (Vector3)capsuleCollider.offset;
            Vector3 tamaño = new Vector3(
                capsuleCollider.size.x * transform.localScale.x,
                capsuleCollider.size.y * transform.localScale.y,
                0.1f
            );

            Gizmos.color = colorCollider;
            Gizmos.DrawWireCube(centro, tamaño);
        }
    }

    // Método para cambiar color desde código
    public void CambiarColor(Color nuevoColor)
    {
        colorCollider = nuevoColor;
    }

    // Método para alternar visualización
    public void AlternarVisualizacion()
    {
        mostrarCollider = !mostrarCollider;
    }
}
