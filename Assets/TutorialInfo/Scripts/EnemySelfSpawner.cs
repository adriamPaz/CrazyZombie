using UnityEngine;
using UnityEngine.AI; // Para que sigan al jugador

public class EnemySelfSpawner : MonoBehaviour
{
    [Header("Configuración de Clonación")]
    public GameObject enemyPrefab;    // Arrastra aquí el PREFAB del zombie
    public static int currentZombies = 0; // Variable compartida por TODOS los zombies
    public float spawnInterval = 5f;  // Intentará crear un clon cada 5 segundos

    [Header("Configuración de Movimiento")]
    private Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        // 1. Aumentamos el contador global al nacer
        currentZombies++;
        
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // 2. Iniciamos el ciclo de clonación
        InvokeRepeating("TryToClone", spawnInterval, spawnInterval);
    }

    void Update()
    {
        // Persecución al jugador (para cumplir el requisito)
        if (agent != null && player != null && agent.isOnNavMesh)
        {
            agent.SetDestination(player.position);
        }
    }

    void TryToClone()
    {
        // 3. Solo si hay menos de 10 en total, este enemigo crea uno nuevo
        if (currentZombies < 10)
        {
            // Lo crea un poco a la derecha para que no se solapen
            Vector3 spawnPos = transform.position + transform.right * 2f; 
            Instantiate(enemyPrefab, spawnPos, transform.rotation);
            Debug.Log("Zombie clonado. Total: " + currentZombies);
        }
    }

    // 4. Muy importante: cuando el enemigo muere, restamos 1 al contador
    private void OnDestroy()
    {
        currentZombies--;
        Debug.Log("Zombie eliminado. Quedan: " + currentZombies);
    }
}