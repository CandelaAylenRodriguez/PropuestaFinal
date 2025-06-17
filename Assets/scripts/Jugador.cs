using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    //    public float fuerzaSalto = 10f;
    //    public Animator animator;
    //    public AnimationClip idleClip;
    //    public AnimationClip saltarClip;
    //    public AnimationClip correrClip;
    //    public AnimationClip caerClip;
    //    public AnimationClip deslizarClip;

    //    // Valores para modo normal
    //    public float velocidadConstanteNormal = 5f;
    //    public float duracionDeslizamientoNormal = 0.5f;

    //    // Valores para modo difícil
    //    public float velocidadConstanteDificil = 10f;
    //    public float duracionDeslizamientoDificil = 0.3f;

    //    public float velocidadConstante;
    //    private float duracionDeslizamiento;

    //    [Header("Detección de Suelo")]
    //    public Transform checkSuelo;            // Punto para verificar si está en el suelo
    //    public float radioCheckSuelo = 0.2f;    // Radio del círculo de detección
    //    public LayerMask sueloLayerMask = 1;    // Layer del suelo

    //    private Rigidbody2D rb;
    //    private CapsuleCollider2D capsuleCollider;

    //    private bool estaEnSuelo = true;
    //    private bool estaDeslizando = false;

    //    private Vector2 colliderOriginalSize;
    //    private Vector2 colliderDeslizadoSize = new Vector2(1f, 0.5f);

    //    private float tiempoJugado = 0f;
    //    private bool modoDificil = false;
    //    private float tiempoModoDificil = 0f;
    //    private bool colisionandoConObstaculo = false;

    //    void Start()
    //    {
    //        Time.timeScale = 1f;
    //        rb = GetComponent<Rigidbody2D>();
    //        capsuleCollider = GetComponent<CapsuleCollider2D>();
    //        colliderOriginalSize = capsuleCollider.size;

    //        if (checkSuelo == null)
    //        {
    //            GameObject checkPoint = new GameObject("CheckSuelo");
    //            checkPoint.transform.SetParent(transform);
    //            checkPoint.transform.localPosition = new Vector3(0, -0.5f, 0);
    //            checkSuelo = checkPoint.transform;
    //        }

    //        // Detectar modo difícil por nombre de escena
    //        if (SceneManager.GetActiveScene().name == "nivelDificil")
    //        {
    //            modoDificil = true;
    //            velocidadConstante = velocidadConstanteDificil;
    //            duracionDeslizamiento = duracionDeslizamientoDificil;
    //        }
    //        else
    //        {
    //            modoDificil = false;
    //            velocidadConstante = velocidadConstanteNormal;
    //            duracionDeslizamiento = duracionDeslizamientoNormal;
    //        }
    //    }

    //    void Update()
    //    {
    //        tiempoJugado += Time.deltaTime;

    //        VerificarSuelo();

    //        if (modoDificil)
    //        {
    //            tiempoModoDificil += Time.deltaTime;

    //            // Después de 15 segundos en modo difícil, volver a modo normal
    //            if (tiempoModoDificil >= 15f)
    //            {
    //                modoDificil = false;
    //                velocidadConstante = velocidadConstanteNormal;
    //                duracionDeslizamiento = duracionDeslizamientoNormal;
    //            }
    //        }
    //        else
    //        {
    //            // Actualiza la velocidad progresiva en modo normal
    //            ActualizarVelocidad();
    //        }

    //        if (!colisionandoConObstaculo || rb.linearVelocityY != 0)
    //        {
    //            // Si no estoy colisionando, o si estoy en el aire, avanzo normal
    //            rb.linearVelocity = new Vector2(velocidadConstante, rb.linearVelocityY);
    //        }
    //        else
    //        {
    //            // Si estoy en el suelo y colisionando, me freno
    //            rb.linearVelocity = new Vector2(0f, rb.linearVelocityY);
    //        }

    //        Animantions();
    //    }

    //    void Animantions()
    //    {
    //        if (rb.linearVelocityY == 0)
    //        {
    //            if (estaDeslizando)
    //            {
    //                animator.Play(deslizarClip.name);
    //            }
    //            else
    //            {
    //                if (colisionandoConObstaculo)
    //                {
    //                    animator.Play(idleClip.name);
    //                }
    //                else
    //                {
    //                    animator.Play(correrClip.name);
    //                }
    //            }
    //        }
    //        else if (rb.linearVelocityY != 0)
    //        {
    //            if (rb.linearVelocityY > 0)
    //            {
    //                animator.Play(saltarClip.name);
    //            }
    //            else if (rb.linearVelocityY < 0)
    //            {
    //                animator.Play(caerClip.name);
    //            }
    //        }
    //    }

    //    void ActualizarVelocidad()
    //    {
    //        if (tiempoJugado < 30f)
    //            velocidadConstante = velocidadConstanteNormal;
    //        else if (tiempoJugado < 60f)
    //            velocidadConstante = 6f;
    //        else if (tiempoJugado < 90f)
    //            velocidadConstante = 7f;
    //        else if (tiempoJugado < 120f)
    //            velocidadConstante = 8f;
    //        else if (tiempoJugado < 180f)
    //            velocidadConstante = 9f;
    //        else
    //            velocidadConstante = 10f + Mathf.PingPong(Time.time * 0.5f, 2f);
    //    }

    //   public void Saltar()
    //{
    //    if (estaEnSuelo && !estaDeslizando)
    //    {
    //        // Mantiene la velocidad horizontal fija, solo da impulso en Y
    //        rb.linearVelocity= new Vector2(velocidadConstante, 0f); // Reinicia Y
    //        rb.linearVelocity = new Vector2(velocidadConstante, fuerzaSalto);
    //        estaEnSuelo = false;
    //    }
    //}

    //    public void Deslizarse()
    //    {
    //        if (!estaDeslizando && estaEnSuelo)
    //        {
    //            StartCoroutine(DeslizarCoroutine());
    //        }
    //    }

    //    private IEnumerator DeslizarCoroutine()
    //    {
    //        estaDeslizando = true;
    //        capsuleCollider.size = colliderDeslizadoSize;
    //        capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, capsuleCollider.offset.y - 0.25f);

    //        yield return new WaitForSeconds(duracionDeslizamiento);

    //        capsuleCollider.size = colliderOriginalSize;
    //        capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, capsuleCollider.offset.y + 0.25f);
    //        estaDeslizando = false;
    //    }

    //    void VerificarSuelo()
    //    {
    //        // Usar OverlapCircle para detectar el suelo
    //        estaEnSuelo = Physics2D.OverlapCircle(checkSuelo.position, radioCheckSuelo, sueloLayerMask);
    //    }

    //    private void OnCollisionEnter2D(Collision2D collision)
    //    {
    //        if (collision.gameObject.CompareTag("Suelo"))
    //        {
    //            estaEnSuelo = true;

    //            // Reset colision con obstaculo al tocar suelo
    //            colisionandoConObstaculo = false;
    //        }

    //        if (collision.gameObject.CompareTag("Obstaculo"))
    //        {
    //            colisionandoConObstaculo = true;
    //        }
    //    }

    //    void OnDrawGizmos()
    //    {
    //        // Círculo de detección de suelo
    //        if (checkSuelo != null)
    //        {
    //            Gizmos.color = estaEnSuelo ? Color.green : Color.red;
    //            Gizmos.DrawWireSphere(checkSuelo.position, radioCheckSuelo);
    //        }

    //        // Visualizar collider del jugador
    //        if (capsuleCollider != null)
    //        {
    //            Gizmos.color = colisionandoConObstaculo ? Color.yellow : Color.cyan;

    //            Vector3 centro = transform.position + (Vector3)capsuleCollider.offset;
    //            Vector3 tamaño = new Vector3(
    //                capsuleCollider.size.x * transform.localScale.x,
    //                capsuleCollider.size.y * transform.localScale.y,
    //                0.1f
    //            );

    //            // Dibujar wireframe del collider del jugador
    //            Gizmos.DrawWireCube(centro, tamaño);

    //            // Dibujar transparente si está colisionando
    //            if (colisionandoConObstaculo)
    //            {
    //                Color amarilloTransparente = Color.yellow;
    //                amarilloTransparente.a = 0.3f;
    //                Gizmos.color = amarilloTransparente;
    //                Gizmos.DrawCube(centro, tamaño);
    //            }
    //        }
    //    }

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
    public float radioCheckSuelo = 0.2f;
    public LayerMask sueloLayerMask = 1;

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
            spriteRenderer.sortingLayerName = "Player"; // Crear esta layer si no existe
            spriteRenderer.sortingOrder = 10;
        }

        if (checkSuelo == null)
        {
            GameObject checkPoint = new GameObject("CheckSuelo");
            checkPoint.transform.SetParent(transform);
            checkPoint.transform.localPosition = new Vector3(0, -0.5f, 0);
            checkSuelo = checkPoint.transform;
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
        VerificarSuelo();

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
        }
    }

    public void Deslizarse()
    {
        if (!estaDeslizando && estaEnSuelo)
        {
            StartCoroutine(DeslizarCoroutine());
        }
    }

    private IEnumerator DeslizarCoroutine()
    {
        estaDeslizando = true;
        capsuleCollider.size = colliderDeslizadoSize;
        capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, capsuleCollider.offset.y - 0.25f);

        yield return new WaitForSeconds(duracionDeslizamiento);

        capsuleCollider.size = colliderOriginalSize;
        capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, capsuleCollider.offset.y + 0.25f);
        estaDeslizando = false;
    }

    void VerificarSuelo()
    {
        estaEnSuelo = Physics2D.OverlapCircle(checkSuelo.position, radioCheckSuelo, sueloLayerMask);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnSuelo = true;
            colisionandoConObstaculo = false;
        }

        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            colisionandoConObstaculo = true;
        }
    }

    void OnDrawGizmos()
    {
        if (checkSuelo != null)
        {
            Gizmos.color = estaEnSuelo ? Color.green : Color.red;
            Gizmos.DrawWireSphere(checkSuelo.position, radioCheckSuelo);
        }

        if (capsuleCollider != null)
        {
            Gizmos.color = colisionandoConObstaculo ? Color.yellow : Color.cyan;

            Vector3 centro = transform.position + (Vector3)capsuleCollider.offset;
            Vector3 tamaño = new Vector3(
                capsuleCollider.size.x * transform.localScale.x,
                capsuleCollider.size.y * transform.localScale.y,
                0.1f
            );

            Gizmos.DrawWireCube(centro, tamaño);

            if (colisionandoConObstaculo)
            {
                Color amarilloTransparente = Color.yellow;
                amarilloTransparente.a = 0.3f;
                Gizmos.color = amarilloTransparente;
                Gizmos.DrawCube(centro, tamaño);
            }
        }
    }
}