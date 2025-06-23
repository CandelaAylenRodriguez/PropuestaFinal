using UnityEngine;
public static class GameProgress 
{
    public static int piezasDesbloqueadas = 0;
    public static float tiempoJugadoNormal = 0f;
    public static float tiempoNivel1 = 0f;
    public static float tiempoNivel2 = 60f;
    public static float tiempoNivel3 = 120f;
    public static int puntajeFinal = 0;
    public static string escenaAnterior = "nivelNormal";
    public static string escenaActual = "nivelNormal";

    // NUEVO: Puntaje total actual
    public static int puntajeTotal = 0;

    // --- MÉTODOS DE PROGRESO EXISTENTES ---

    public static void ReiniciarProgreso()
    {
        Debug.Log("[GameProgress] Reiniciando progreso completo");

        tiempoJugadoNormal = 0f;
        piezasDesbloqueadas = 0;
        tiempoNivel1 = 0f;
        tiempoNivel2 = 60f;    // Mantener valores base
        tiempoNivel3 = 120f;   // Mantener valores base
        escenaAnterior = "nivelNormal";  // Resetear a nivel normal
        puntajeTotal = 0; // Reiniciar puntaje también

        Debug.Log($"[GameProgress] Progreso reiniciado - Escena anterior: {escenaAnterior}");
    }

    public static void ReiniciarRompecabezasNivel2()
    {
        piezasDesbloqueadas = 0;
        tiempoNivel2 = 60f;
    }

    public static void ReiniciarRompecabezasNivel3()
    {
        piezasDesbloqueadas = 0;
        tiempoNivel3 = 120f;
    }

    public static float ObtenerTiempoInicialPorEscena(string nombreEscena)
    {
        switch (nombreEscena)
        {
            case "nivelNormal": return tiempoJugadoNormal;
            case "nivel1": return tiempoNivel1;
            case "nivel2": return tiempoNivel2;
            case "nivel3": return tiempoNivel3;
            default: return 0f;
        }
    }

    public static void MostrarEstado()
    {
        Debug.Log($"[GameProgress] Estado actual:");
        Debug.Log($"  - Escena anterior: {escenaAnterior}");
        Debug.Log($"  - Tiempo normal: {tiempoJugadoNormal}");
        Debug.Log($"  - Tiempo nivel1: {tiempoNivel1}");
        Debug.Log($"  - Tiempo nivel2: {tiempoNivel2}");
        Debug.Log($"  - Tiempo nivel3: {tiempoNivel3}");
        Debug.Log($"  - Piezas desbloqueadas: {piezasDesbloqueadas}");
        Debug.Log($"  - Puntaje total: {puntajeTotal}");
    }

    // --- MÉTODOS DE PUNTAJE NUEVOS ---

    public static void SumarPuntaje(int cantidad)
    {
        puntajeTotal += cantidad;
        Debug.Log($"[Puntaje] +{cantidad} => Total: {puntajeTotal}");
    }

    public static int ObtenerPuntaje()
    {
        return puntajeTotal;
    }

    public static void ReiniciarPuntaje()
    {
        puntajeTotal = 0;
        Debug.Log("[Puntaje] Puntaje reiniciado");
    }
}
