using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource musicaFondo;      // Para música continua
    public AudioSource efectosSonido;   // Para efectos de sonido

    [Header("Clips de Música")]
    public AudioClip musicaNormal;
    public AudioClip musicaDificil;

    [Header("Clips de Efectos")]
    public AudioClip sonidoSalto;
    public AudioClip sonidoAterrizaje;
    public AudioClip sonidoDeslizar;
    public AudioClip sonidoRecolectable;
    public AudioClip sonidoBtn;

    [Header("Configuración")]
    [Range(0f, 1f)] public float volumenMusica = 0.7f;
    [Range(0f, 1f)] public float volumenEfectos = 1f;

    // Singleton para acceso fácil desde cualquier script
    public static AudioManager Instance;

    //void Awake()
    //{
    //    // Patrón Singleton
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    // Configurar AudioSources si no están asignados
    //    ConfigurarAudioSources();
    //}

    //void Start()
    //{
    //    //// Configurar volúmenes iniciales
    //    //AjustarVolumenMusica(volumenMusica);
    //    //AjustarVolumenEfectos(volumenEfectos);

    //    //// Reproducir música de fondo
    //    //ReproducirMusicaSegunEscena();

    //    // Configurar volúmenes iniciales
    //    AjustarVolumenMusica(volumenMusica);
    //    AjustarVolumenEfectos(volumenEfectos);

    //    // MODIFICADO: Solo reproducir música si NO estamos en el menú
    //    string escenaActual = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    //    if (escenaActual != "MenuPrincipal")
    //    {
    //        ReproducirMusicaSegunEscena();
    //    }
    //    else
    //    {
    //        //Debug.Log("Iniciando en menú - No hay música de fondo");
    //    }
    //}

    //void ConfigurarAudioSources()
    //{
    //    // Si no hay AudioSources asignados, crearlos
    //    if (musicaFondo == null)
    //    {
    //        GameObject musicaGO = new GameObject("MusicaFondo");
    //        musicaGO.transform.SetParent(transform);
    //        musicaFondo = musicaGO.AddComponent<AudioSource>();
    //        musicaFondo.loop = true;
    //        musicaFondo.playOnAwake = false;
    //    }

    //    if (efectosSonido == null)
    //    {
    //        GameObject efectosGO = new GameObject("EfectosSonido");
    //        efectosGO.transform.SetParent(transform);
    //        efectosSonido = efectosGO.AddComponent<AudioSource>();
    //        efectosSonido.loop = false;
    //        efectosSonido.playOnAwake = false;
    //    }
    //}

    //public void ReproducirMusicaSegunEscena()
    //{
    //    string escenaActual = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

    //    //Debug.Log($"Configurando música para escena: {escenaActual}");

    //    // NUEVO: No reproducir música en el menú principal
    //    if (escenaActual == "MenuPrincipal")
    //    {
    //        //Debug.Log("En menú principal - Deteniendo música");
    //        DetenerMusica();
    //        return; // Salir sin reproducir música
    //    }

    //    if (escenaActual == "nivelDificil" && musicaDificil != null)
    //    {
    //        //Debug.Log("Cambiando a música difícil");
    //        CambiarMusica(musicaDificil);
    //    }
    //    else if (escenaActual == "nivelNormal" || escenaActual == "nivel2" || escenaActual == "nivel3" && musicaNormal != null)
    //    {
    //        //Debug.Log("Cambiando a música normal");
    //        CambiarMusica(musicaNormal);
    //    }
    //    else
    //    {
    //        //Debug.LogWarning($"No hay música configurada para la escena: {escenaActual}");
    //    }
    //}

    //public void CambiarMusica(AudioClip nuevaMusica)
    //{
    //    if (nuevaMusica == null)
    //    {
    //        //Debug.LogWarning("Intentando cambiar a una música null");
    //        return;
    //    }

    //    if (musicaFondo.clip != nuevaMusica)
    //    {
    //        musicaFondo.Stop();
    //        musicaFondo.clip = nuevaMusica;
    //        musicaFondo.Play();
    //    }
    //    else
    //    {
    //        //Debug.Log("La música ya está reproduciéndose");
    //    }
    //}

    //// Métodos para efectos de sonido
    //public void ReproducirSonidoSalto()
    //{
    //    if (sonidoSalto != null)
    //    {
    //        efectosSonido.PlayOneShot(sonidoSalto);
    //    }
    //}

    //public void ReproducirSonidoDeslizar()
    //{
    //    if (sonidoDeslizar != null)
    //    {
    //        efectosSonido.PlayOneShot(sonidoDeslizar);
    //    }
    //}
    //public void ReproducirSonidoAterrizaje()
    //{
    //    if (sonidoAterrizaje != null)
    //    {
    //        efectosSonido.PlayOneShot(sonidoAterrizaje);
    //    }
    //}
    //public void ReproducirSonidoRecolectable()
    //{
    //    if (sonidoRecolectable != null)
    //    {
    //        efectosSonido.PlayOneShot(sonidoRecolectable);
    //    }
    //}

    //public void ReproducirSonidoBtn()
    //{
    //    if (sonidoBtn != null)
    //    {
    //        efectosSonido.PlayOneShot(sonidoBtn);
    //    }
    //}

    ////public void ReproducirSonidoGameOver()
    ////{
    ////    if (sonidoGameOver != null)
    ////    {
    ////        efectosSonido.PlayOneShot(sonidoGameOver);
    ////    }
    ////}

    //// Métodos para ajustar volúmenes
    //public void AjustarVolumenMusica(float volumen)
    //{
    //    volumenMusica = Mathf.Clamp01(volumen);
    //    if (musicaFondo != null)
    //    {
    //        musicaFondo.volume = volumenMusica;
    //    }
    //}

    //public void AjustarVolumenEfectos(float volumen)
    //{
    //    volumenEfectos = Mathf.Clamp01(volumen);
    //    if (efectosSonido != null)
    //    {
    //        efectosSonido.volume = volumenEfectos;
    //    }
    //}

    //// Métodos para pausar/reanudar
    //public void PausarMusica()
    //{
    //    if (musicaFondo != null && musicaFondo.isPlaying)
    //    {
    //        musicaFondo.Pause();
    //    }
    //}

    //public void ReanudarMusica()
    //{
    //    if (musicaFondo != null && !musicaFondo.isPlaying)
    //    {
    //        musicaFondo.UnPause();
    //    }
    //}

    //public void DetenerMusica()
    //{
    //    if (musicaFondo != null)
    //    {
    //        musicaFondo.Stop();
    //    }
    //}

    //void OnEnable()
    //{
    //    // Suscribirse al evento de cambio de escena
    //    UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    //}

    //void OnDisable()
    //{
    //    // Desuscribirse del evento
    //    UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    //}

    //// NUEVO: Método que se ejecuta cada vez que se carga una escena
    //private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    //{
    //    //Debug.Log($"Escena cargada: {scene.name}");

    //    // Esperar un frame para asegurar que todo esté inicializado
    //    StartCoroutine(CambiarMusicaConDelay());
    //}
    //private System.Collections.IEnumerator CambiarMusicaConDelay()
    //{
    //    yield return null; // Esperar un frame
    //    ReproducirMusicaSegunEscena();
    //}

    void Awake()
    {
        // Patrón Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Configurar AudioSources si no están asignados
        ConfigurarAudioSources();
    }

    void Start()
    {
        // Configurar volúmenes iniciales
        AjustarVolumenMusica(volumenMusica);
        AjustarVolumenEfectos(volumenEfectos);

        volumenMusica = PlayerPrefs.GetFloat("VolumenMusica", 0.7f);
        volumenEfectos = PlayerPrefs.GetFloat("VolumenSFX", 1f);

        // MODIFICADO: Solo reproducir música si NO estamos en el menú
        ReproducirMusicaSegunEscena();
    }

    void ConfigurarAudioSources()
    {
        // Si no hay AudioSources asignados, crearlos
        if (musicaFondo == null)
        {
            GameObject musicaGO = new GameObject("MusicaFondo");
            musicaGO.transform.SetParent(transform);
            musicaFondo = musicaGO.AddComponent<AudioSource>();
            musicaFondo.loop = true;
            musicaFondo.playOnAwake = false;
        }

        if (efectosSonido == null)
        {
            GameObject efectosGO = new GameObject("EfectosSonido");
            efectosGO.transform.SetParent(transform);
            efectosSonido = efectosGO.AddComponent<AudioSource>();
            efectosSonido.loop = false;
            efectosSonido.playOnAwake = false;
        }
    }

    public void ReproducirMusicaSegunEscena()
    {
        string escenaActual = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        Debug.Log($"[AudioManager] Configurando música para escena: {escenaActual}");

        // NUEVO: No reproducir música en el menú principal
        if (escenaActual == "MenuPrincipal")
        {
            Debug.Log("[AudioManager] En menú principal - Deteniendo música");
            DetenerMusica();
            return; // Salir sin reproducir música
        }

        // Seleccionar música según escena
        if (escenaActual == "nivelDificil" && musicaDificil != null)
        {
            Debug.Log("[AudioManager] Cambiando a música difícil");
            CambiarMusica(musicaDificil);
        }
        else if ((escenaActual == "nivelNormal" || escenaActual == "nivel2" || escenaActual == "nivel3") && musicaNormal != null)
        {
            Debug.Log($"[AudioManager] Cambiando a música normal para: {escenaActual}");
            CambiarMusica(musicaNormal);
        }
        else
        {
            Debug.LogWarning($"[AudioManager] No hay música configurada para la escena: {escenaActual}");
        }
    }

    public void CambiarMusica(AudioClip nuevaMusica)
    {
        if (nuevaMusica == null)
        {
            Debug.LogWarning("[AudioManager] Intentando cambiar a una música null");
            return;
        }

        // MEJORADO: Siempre cambiar la música, incluso si es la misma
        // Esto asegura que se reproduzca correctamente después de pausas o cambios de escena
        Debug.Log($"[AudioManager] Cambiando música a: {nuevaMusica.name}");

        musicaFondo.Stop();
        musicaFondo.clip = nuevaMusica;
        musicaFondo.Play();

        Debug.Log($"[AudioManager] Música cambiada y reproduciéndose: {musicaFondo.isPlaying}");
    }

    // NUEVO: Método específico para forzar música normal (útil para reiniciar)
    public void ForzarMusicaNormal()
    {
        if (musicaNormal != null)
        {
            Debug.Log("[AudioManager] Forzando música normal");
            CambiarMusica(musicaNormal);
        }
        else
        {
            Debug.LogWarning("[AudioManager] No hay clip de música normal asignado");
        }
    }

    // Métodos para efectos de sonido
    public void ReproducirSonidoSalto()
    {
        if (sonidoSalto != null)
        {
            efectosSonido.PlayOneShot(sonidoSalto);
        }
    }

    public void ReproducirSonidoDeslizar()
    {
        if (sonidoDeslizar != null)
        {
            efectosSonido.PlayOneShot(sonidoDeslizar);
        }
    }

    public void ReproducirSonidoAterrizaje()
    {
        if (sonidoAterrizaje != null)
        {
            efectosSonido.PlayOneShot(sonidoAterrizaje);
        }
    }

    public void ReproducirSonidoRecolectable()
    {
        if (sonidoRecolectable != null)
        {
            efectosSonido.PlayOneShot(sonidoRecolectable);
        }
    }

    public void ReproducirSonidoBtn()
    {
        if (sonidoBtn != null)
        {
            efectosSonido.PlayOneShot(sonidoBtn);
        }
    }

    // Métodos para ajustar volúmenes
    public void AjustarVolumenMusica(float volumen)
    {
        volumenMusica = Mathf.Clamp01(volumen);
        if (musicaFondo != null)
        {
            musicaFondo.volume = volumenMusica;
        }

        // Guardar valor
        PlayerPrefs.SetFloat("VolumenMusica", volumenMusica);
    }

    public void AjustarVolumenEfectos(float volumen)
    {
        volumenEfectos = Mathf.Clamp01(volumen);
        if (efectosSonido != null)
        {
            efectosSonido.volume = volumenEfectos;
        }

        // Guardar valor
        PlayerPrefs.SetFloat("VolumenSFX", volumenEfectos);
    }

    // Métodos para pausar/reanudar
    public void PausarMusica()
    {
        if (musicaFondo != null && musicaFondo.isPlaying)
        {
            Debug.Log("[AudioManager] Pausando música");
            musicaFondo.Pause();
        }
    }

    public void ReanudarMusica()
    {
        if (musicaFondo != null && !musicaFondo.isPlaying && musicaFondo.clip != null)
        {
            Debug.Log("[AudioManager] Reanudando música");
            musicaFondo.UnPause();
        }
    }

    public void DetenerMusica()
    {
        if (musicaFondo != null)
        {
            Debug.Log("[AudioManager] Deteniendo música");
            musicaFondo.Stop();
        }
    }

    void OnEnable()
    {
        // Suscribirse al evento de cambio de escena
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Desuscribirse del evento
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // MEJORADO: Método que se ejecuta cada vez que se carga una escena
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        Debug.Log($"[AudioManager] Escena cargada: {scene.name}");

        // Cambiar música inmediatamente
        StartCoroutine(CambiarMusicaConDelay());
    }

    private System.Collections.IEnumerator CambiarMusicaConDelay()
    {
        yield return null; // Esperar un frame para asegurar inicialización

        Debug.Log("[AudioManager] Ejecutando cambio de música con delay");
        ReproducirMusicaSegunEscena();
    }

    // NUEVO: Método para debugging
    public void MostrarEstadoAudio()
    {
        if (musicaFondo != null)
        {
            Debug.Log($"[AudioManager] Estado actual - Clip: {(musicaFondo.clip ? musicaFondo.clip.name : "ninguno")}, " +
                     $"Reproduciéndose: {musicaFondo.isPlaying}, Volumen: {musicaFondo.volume}");
        }
    }
}
