using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Jugador player;
    public SpawnerObstaculos spawnerObstaculos;

    private void Start()
    {
        if (player == null)
        {
            GameObject obj = GameObject.FindWithTag("Player");
            if (obj != null)
            {
                player = obj.GetComponent<Jugador>();
            }
        }

        if (spawnerObstaculos == null)
        {
            GameObject spaw = GameObject.FindWithTag("SpawnerObstaculos");
            if (spaw != null)
            {
                spawnerObstaculos = spaw.GetComponent<SpawnerObstaculos>();
            }
        }

    }
    void Update()
    {
        if (player == null) return;

        if (spawnerObstaculos != null && spawnerObstaculos.esEscenaNormal)
        {
            transform.position += Vector3.right * player.velocidadConstanteNormal * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * player.velocidadConstanteDificil * Time.deltaTime;
        }

        if (player.transform.position.x < transform.position.x - 5f)
        {
            GameManager.Instance.GameOver();
        }
    }
}
