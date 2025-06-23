using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public float fuerzaSalto = 10f;
    public Animator animator;
    public AnimationClip idleClip;
    public AnimationClip saltarClip;
    public AnimationClip correrClip;
    public AnimationClip caerClip;
    public AnimationClip deslizarClip;

    // Valores para modo normal
    public float velocidadConstanteNormal = 5f;
    public float duracionDeslizamientoNormal = 0.5f;

    // Valores para modo difícil
    public float velocidadConstanteDificil = 10f;
    public float duracionDeslizamientoDificil = 0.3f;

    public float velocidadConstante;
    private float duracionDeslizamiento;

    [Header("Detección de Suelo")]
    public Transform checkSuelo;
    public Vector2 size;
    public LayerMask sueloLayerMask;

    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCollider;
    private SpriteRenderer spriteRenderer; // NUEVO
    
    private bool estaEnSuelo = true;
    private bool estaDeslizando = false;

    private Vector2 colliderOriginalSize;
    private Vector2 colliderDeslizadoSize = new Vector2(1f, 0.5f);

    private float tiempoJugado = 0f;
    private bool modoDificil = false;
    private float tiempoModoDificil = 0f;
    private bool colisionandoConObstaculo = false;

    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // NUEVO
        colliderOriginalSize = capsuleCollider.size;

        // NUEVO: Configurar Z position y sorting para evitar parpadeo
        Vector3 pos = transform.position;
        pos.z = -1f; // Asegurar que esté por delante del fondo
        transform.position = pos;

        // NUEVO: Configurar sorting layer
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingLayerName = "Player";
            spriteRenderer.sortingOrder = 10;
        }

        // Detectar modo difícil por nombre de escena
        if (SceneManager.GetActiveScene().name == "nivelDificil")
        {
            modoDificil = true;
            velocidadConstante = velocidadConstanteDificil;
            duracionDeslizamiento = duracionDeslizamientoDificil;
        }
        else
        {
            modoDificil = false;
            velocidadConstante = velocidadConstanteNormal;
            duracionDeslizamiento = duracionDeslizamientoNormal;
        }

        // NUEVO: Configurar Rigidbody2D para mejor estabilidad
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void Update()
    {
        tiempoJugado += Time.deltaTime;

        estaEnSuelo = Physics2D.OverlapBox(checkSuelo.transform.position, size, 0, sueloLayerMask);

        if (modoDificil)
        {
            tiempoModoDificil += Time.deltaTime;

            if (tiempoModoDificil >= 15f)
            {
                modoDificil = false;
                velocidadConstante = velocidadConstanteNormal;
                duracionDeslizamiento = duracionDeslizamientoNormal;
            }
        }
        else
        {
            ActualizarVelocidad();
        }

        Animantions();
    }

    // NUEVO: Mover la lógica de física a FixedUpdate para mejor sincronización
    void FixedUpdate()
    {
        if (!colisionandoConObstaculo || rb.linearVelocityY != 0)
        {
            rb.linearVelocity = new Vector2(velocidadConstante, rb.linearVelocityY);
        }
        else
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocityY);
        }
    }
    void Animantions()
    {
        if (rb.linearVelocityY == 0)
        {
            if (estaDeslizando)
            {
                animator.Play(deslizarClip.name);
            }
            else
            {
                if (colisionandoConObstaculo)
                {
                    animator.Play(idleClip.name);
                }
                else
                {
                    animator.Play(correrClip.name);
                }
            }
        }
        else if (rb.linearVelocityY != 0)
        {
            if (rb.linearVelocityY > 0)
            {
                animator.Play(saltarClip.name);
            }
            else if (rb.linearVelocityY < 0)
            {
                animator.Play(caerClip.name);
            }
        }
    }
    void ActualizarVelocidad()
    {
        if (tiempoJugado < 30f)
            velocidadConstante = velocidadConstanteNormal;
        else if (tiempoJugado < 60f)
            velocidadConstante = 6f;
        else if (tiempoJugado < 90f)
            velocidadConstante = 7f;
        else if (tiempoJugado < 120f)
            velocidadConstante = 8f;
        else if (tiempoJugado < 180f)
            velocidadConstante = 9f;
        else
            velocidadConstante = 10f + Mathf.PingPong(Time.time * 0.5f, 2f);
    }

    public void Saltar()
    {
        if (estaEnSuelo && !estaDeslizando)
        {
            rb.linearVelocity = new Vector2(velocidadConstante, fuerzaSalto);
            estaEnSuelo = false;

            // AÑADIR SONIDO DE SALTAR
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.ReproducirSonidoSalto();
            }

            GameProgress.SumarPuntaje(100);
        }
    }

    public void Deslizarse()
    {
        if (!estaDeslizando && estaEnSuelo)
        {
            // AÑADIR SONIDO DE DESLIZAR
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.ReproducirSonidoDeslizar();
            }

            GameProgress.SumarPuntaje(150);

            StartCoroutine(DeslizarCoroutine());
        }
    }
    private IEnumerator DeslizarCoroutine()
    {
        //Debug.Log("=== INICIANDO DESLIZAMIENTO ===");
        estaDeslizando = true;

        // Cambiar collider
        Vector2 offsetOriginal = capsuleCollider.offset;
        capsuleCollider.size = colliderDeslizadoSize;
        capsuleCollider.offset = new Vector2(offsetOriginal.x, offsetOriginal.y - 0.25f);

        yield return new WaitForSeconds(duracionDeslizamiento);

        // Restaurar collider
        capsuleCollider.size = colliderOriginalSize;
        capsuleCollider.offset = offsetOriginal;
        estaDeslizando = false;

        //Debug.Log("=== FIN DESLIZAMIENTO ===");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnSuelo = true;
            Debug.Log("Tocando suelo");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Solo manejar suelo aquí
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnSuelo = false;
        }
    }
}