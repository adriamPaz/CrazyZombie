using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    const int HITS_TO_DIE = 3;
    int hitCount = 0;

    EnemySelfSpawner spawner;

    void Start()
    {
        // Buscar o spawner na escena
        spawner = FindObjectOfType<EnemySelfSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            hitCount++;
            Destroy(other.transform.root.gameObject);

            if (hitCount >= HITS_TO_DIE)
            {
                // Avisar ao spawner antes de morrer
                
                Destroy(gameObject);
            }
        }
    }
}