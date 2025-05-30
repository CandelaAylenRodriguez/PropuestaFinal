using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public float fuerzaSalto = 10f;

    // Valores para modo normal
    public float velocidadConstanteNormal = 5f;
    public float duracionDeslizamientoNormal = 0.5f;

    // Valores para modo difícil
    public float velocidadConstanteDificil = 10f;
    public float duracionDeslizamientoDificil = 0.3f;

    private float velocidadConstante;
    private float duracionDeslizamiento;

    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCollider;

    private bool estaEnSuelo = true;
    private bool estaDeslizando = false;

    private Vector2 colliderOriginalSize;
    private Vector2 colliderDeslizadoSize = new Vector2(1f, 0.5f);

    private float tiempoJugado = 0f;
    private bool modoDificil = false;
    private float tiempoModoDificil = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        colliderOriginalSize = capsuleCollider.size;

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
    }

    void Update()
    {
        tiempoJugado += Time.deltaTime;

        if (modoDificil)
        {
            tiempoModoDificil += Time.deltaTime;

            // Después de 15 segundos en modo difícil, volver a modo normal
            if (tiempoModoDificil >= 15f)
            {
                modoDificil = false;
                velocidadConstante = velocidadConstanteNormal;
                duracionDeslizamiento = duracionDeslizamientoNormal;
            }
        }
        else
        {
            // Actualiza la velocidad progresiva en modo normal
            ActualizarVelocidad();
        }

        rb.linearVelocity = new Vector2(velocidadConstante, rb.linearVelocityY);
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
        // Mantiene la velocidad horizontal fija, solo da impulso en Y
        rb.linearVelocity= new Vector2(velocidadConstante, 0f); // Reinicia Y
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnSuelo = true;
        }
    }
}