using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnPrefabOnNavMesh : MonoBehaviour
{
    public GameObject prefabToSpawn; // El prefab que deseas generar
    public GameObject spawnArea; // El asset del entorno (plano) donde deben aparecer los prefabs
    public float spawnInterval = 40f; // Intervalo de tiempo entre spawns en segundos

    private void Start()
    {
        // Comienza el ciclo de spawn
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        // Ciclo infinito para spawnear prefabs cada cierto tiempo
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        // Genera una posición aleatoria dentro del plano especificado
        Vector3 randomPosition = GetRandomPointInSpawnArea();
        NavMeshHit hit;

        // Comprueba si la posición generada está sobre un NavMesh
        if (NavMesh.SamplePosition(randomPosition, out hit, 1.0f, NavMesh.AllAreas))
        {
            // Instancia el prefab en la posición encontrada sobre el NavMesh
            Instantiate(prefabToSpawn, hit.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("No se encontró una posición válida sobre el NavMesh.");
        }
    }

    private Vector3 GetRandomPointInSpawnArea()
    {
        // Obtiene los límites del collider del área de spawn
        Collider spawnCollider = spawnArea.GetComponent<Collider>();
        if (spawnCollider != null)
        {
            Vector3 boundsMin = spawnCollider.bounds.min;
            Vector3 boundsMax = spawnCollider.bounds.max;

            // Genera una posición aleatoria dentro de los límites del collider
            float randomX = Random.Range(boundsMin.x, boundsMax.x);
            float randomZ = Random.Range(boundsMin.z, boundsMax.z);
            float yPosition = spawnArea.transform.position.y;

            return new Vector3(randomX, yPosition, randomZ);
        }
        else
        {
           
            return Vector3.zero;
        }
    }
}

