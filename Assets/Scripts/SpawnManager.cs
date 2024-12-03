using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject[] itemPrefab; // Prefabs de los objetos a instanciar
  public float minTime = 1f; // Tiempo mínimo entre spawns
  public float maxTime = 2f; // Tiempo máximo entre spawns
  public Vector3 spawnRangeMin = new Vector3(-250, 50, 5);
  public Vector3 spawnRangeMax = new Vector3(200, 50, 375);

  void Start()
  {
    StartCoroutine(SpawnCoroutine(Random.Range(minTime, maxTime))); // Iniciar la corrutina de spawn
    StartCoroutine(MoveRandomlyCoroutine()); // Iniciar la corrutina para moverse aleatoriamente
  }

  // Corrutina para mover el SpawnManager a una nueva posición aleatoria después de un tiempo aleatorio
  IEnumerator MoveRandomlyCoroutine()
  {
    while (true)
    {
      // Esperar un tiempo aleatorio antes de moverse
      float waitTime = Random.Range(minTime, maxTime);
      yield return new WaitForSeconds(waitTime);

      // Calcular una nueva posición aleatoria dentro del rango
      float x = Random.Range(spawnRangeMin.x, spawnRangeMax.x);
      float y = Random.Range(spawnRangeMin.y, spawnRangeMax.y);
      float z = Random.Range(spawnRangeMin.z, spawnRangeMax.z);

      // Actualizar la posición del SpawnManager
      transform.position = new Vector3(x, y, z);
    }
  }

  // Corrutina para generar objetos aleatorios
  IEnumerator SpawnCoroutine(float waitTime)
  {
    yield return new WaitForSeconds(waitTime);

    // Instanciar un prefab aleatorio en la posición actual del SpawnManager
    Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], transform.position, Quaternion.identity);

    // Repetir la corrutina con un nuevo tiempo aleatorio
    StartCoroutine(SpawnCoroutine(Random.Range(minTime, maxTime)));
  }
}
