using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 5f;
    public float planeWidth = 10f;
    public float planeLength = 10f;
        public float minDistanceToWall = 1f;

    void Start()
    {
        // Starte die Coroutine zum wiederholten Spawnen
        StartCoroutine(SpawnObjectsRoutine());
    }

    IEnumerator SpawnObjectsRoutine()
    {
        while (true)
        {
            // Warte für die angegebene Zeit
            yield return new WaitForSeconds(spawnInterval);

            // Spawne das Objekt an einer zufälligen Position im Plane
            SpawnObjectAtRandomPosition();
        }
    }

    void SpawnObjectAtRandomPosition()
    {
        // Versuche mehrmals, eine gültige Position zu finden
        int maxAttempts = 10;
        for (int i = 0; i < maxAttempts; i++)
        {
            // Berechne eine zufällige Position im Plane
            float randomX = Random.Range(-planeWidth / 2f, planeWidth / 2f);
            float randomZ = Random.Range(-planeLength / 2f, planeLength / 2f);

            // Überprüfe, ob die Position gültig ist
            if (IsValidSpawnPosition(randomX, randomZ))
            {
                // Erzeuge das Objekt an der zufälligen Position
                Instantiate(objectToSpawn, new Vector3(randomX, 0.35f, randomZ), Quaternion.identity);
                break; // Beende die Schleife, da eine gültige Position gefunden wurde
            }
        }
    }

    bool IsValidSpawnPosition(float x, float z)
    {
        // Erzeuge einen Ray von oben nach unten an der gewünschten Spawnposition
        Ray ray = new Ray(new Vector3(x, 10f, z), Vector3.down);
        RaycastHit hit;

        // Überprüfe, ob der Ray ein Objekt trifft
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Überprüfe, ob der Abstand zu anderen Objekten groß genug ist
            if (hit.distance > minDistanceToWall)
            {
                return true; // Die Position ist gültig
            }
        }

        return false; // Die Position ist ungültig
    }
}
