using UnityEngine;

public class ObstaculosTrigger : MonoBehaviour
{
    //public enum TipoObstaculo { Saltar, Deslizar }
    //public TipoObstaculo tipo;

    //private bool yaActivado = false;

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (yaActivado) return;

    //    if (other.CompareTag("Player"))
    //    {
    //        Jugador jugador = other.GetComponent<Jugador>();
    //        if (jugador == null) return;

    //        if (tipo == TipoObstaculo.Saltar && jugador.EstaSaltando())
    //        {
    //            GameProgress.SumarPuntaje(100);
    //            yaActivado = true;
    //            Destroy(transform.parent.gameObject); // Destruye el obstáculo completo
    //        }
    //        else if (tipo == TipoObstaculo.Deslizar && jugador.EstaDeslizando())
    //        {
    //            GameProgress.SumarPuntaje(150);
    //            yaActivado = true;
    //            Destroy(transform.parent.gameObject); // Destruye el obstáculo completo
    //        }
    //    }
    //}
}
