using UnityEngine;
using UnityEngine.UI;

public class ModalController : MonoBehaviour
{
    [Header("Referencias del Modal")]
    public GameObject modalPanel;
    public Button botonAbrir;
    public Button botonCerrar;

    [Header("Controles de Audio")]
    public Slider sliderMusica;
    public Slider sliderSFX;

    [Header("Configuración")]
    public bool cerrarConClickAfuera = true;
    public KeyCode teclaParaCerrar = KeyCode.Escape;

    void Start()
    {
        // Asegurar que el modal esté cerrado al inicio
        if (modalPanel != null)
        {
            modalPanel.SetActive(false);
        }

        // Configurar eventos de botones
        if (botonAbrir != null)
        {
            botonAbrir.onClick.AddListener(AbrirModal);
        }

        if (botonCerrar != null)
        {
            botonCerrar.onClick.AddListener(CerrarModal);
        }

        // Configurar sliders de audio
        ConfigurarSlidersAudio();
    }

    void ConfigurarSlidersAudio()
    {
        if (AudioManager.Instance != null)
        {
            // Configurar slider de música
            if (sliderMusica != null)
            {
                // Establecer valor inicial del slider según el volumen actual
                sliderMusica.value = AudioManager.Instance.volumenMusica;

                // Añadir listener para cambios en tiempo real
                sliderMusica.onValueChanged.AddListener(CambiarVolumenMusica);

                Debug.Log($"Slider música configurado. Valor inicial: {sliderMusica.value}");
            }

            // Configurar slider de SFX
            if (sliderSFX != null)
            {
                // Establecer valor inicial del slider según el volumen actual
                sliderSFX.value = AudioManager.Instance.volumenEfectos;

                // Añadir listener para cambios en tiempo real
                sliderSFX.onValueChanged.AddListener(CambiarVolumenSFX);

                Debug.Log($"Slider SFX configurado. Valor inicial: {sliderSFX.value}");
            }
        }
        else
        {
            Debug.LogWarning("AudioManager.Instance es null. Los sliders no se configurarán correctamente.");
        }
    }

    // Método llamado cuando cambia el slider de música
    public void CambiarVolumenMusica(float nuevoVolumen)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.AjustarVolumenMusica(nuevoVolumen);
            Debug.Log($"Volumen música cambiado a: {nuevoVolumen}");
        }
    }

    // Método llamado cuando cambia el slider de SFX
    public void CambiarVolumenSFX(float nuevoVolumen)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.AjustarVolumenEfectos(nuevoVolumen);
            Debug.Log($"Volumen SFX cambiado a: {nuevoVolumen}");

            // Reproducir sonido de prueba para que el usuario escuche el cambio
            AudioManager.Instance.ReproducirSonidoBtn();
        }
    }

    void Update()
    {
        // Cerrar con tecla Escape
        if (Input.GetKeyDown(teclaParaCerrar) && modalPanel.activeInHierarchy)
        {
            CerrarModal();
        }
    }

    public void AbrirModal()
    {
        if (modalPanel != null)
        {
            modalPanel.SetActive(true);

            // Actualizar valores de sliders al abrir el modal
            ActualizarValoresSliders();
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ReproducirSonidoBtn();
        }
    }

    public void CerrarModal()
    {
        if (modalPanel != null)
        {
            modalPanel.SetActive(false);
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ReproducirSonidoBtn();
        }
    }

    // Método para actualizar los valores de los sliders cuando se abre el modal
    void ActualizarValoresSliders()
    {
        if (AudioManager.Instance != null)
        {
            if (sliderMusica != null)
            {
                sliderMusica.value = AudioManager.Instance.volumenMusica;
            }

            if (sliderSFX != null)
            {
                sliderSFX.value = AudioManager.Instance.volumenEfectos;
            }
        }
    }

    // Método para cerrar con click fuera del modal
    public void OnClickFondo()
    {
        if (cerrarConClickAfuera)
        {
            CerrarModal();
        }
    }

    // Método para evitar que clicks dentro del modal lo cierren
    public void OnClickDentroModal()
    {
        // Este método no hace nada, solo evita que se propague el click al fondo
    }

    // MÉTODOS ADICIONALES ÚTILES

    // Restaurar valores por defecto
    public void RestaurarValoresPorDefecto()
    {
        if (sliderMusica != null)
        {
            sliderMusica.value = 0.7f; // Valor por defecto
            CambiarVolumenMusica(0.7f);
        }

        if (sliderSFX != null)
        {
            sliderSFX.value = 1f; // Valor por defecto
            CambiarVolumenSFX(1f);
        }

        Debug.Log("Valores de audio restaurados por defecto");
    }

    // Silenciar todo
    public void SilenciarTodo()
    {
        if (sliderMusica != null)
        {
            sliderMusica.value = 0f;
            CambiarVolumenMusica(0f);
        }

        if (sliderSFX != null)
        {
            sliderSFX.value = 0f;
            CambiarVolumenSFX(0f);
        }

        Debug.Log("Todo el audio silenciado");
    }

    // Método para debugging - mostrar valores actuales
    [ContextMenu("Mostrar Valores Audio")]
    public void MostrarValoresAudio()
    {
        if (AudioManager.Instance != null)
        {
            Debug.Log($"Volumen Música: {AudioManager.Instance.volumenMusica}");
            Debug.Log($"Volumen SFX: {AudioManager.Instance.volumenEfectos}");

            if (sliderMusica != null)
                Debug.Log($"Slider Música: {sliderMusica.value}");

            if (sliderSFX != null)
                Debug.Log($"Slider SFX: {sliderSFX.value}");
        }
    }
}
