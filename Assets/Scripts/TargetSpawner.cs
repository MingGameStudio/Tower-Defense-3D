using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour
{
    [Header("Spawn Setup")]
    public GameObject targetPrefab;
    public Transform[] areaTargets = new Transform[3];
    public Vector3 spawnRotationEuler = new Vector3(0f, 90f, 0f);

    [Header("Spawn Timing")]
    public int spawnAmount = 5;
    public float spawnIntervalSeconds = 3f;

    void Start()
    {
        StartCoroutine(SpawnTargetsRoutine());
    }

    private IEnumerator SpawnTargetsRoutine()
    {
        if (targetPrefab == null || areaTargets == null || areaTargets.Length < 3 ||
            areaTargets[0] == null || areaTargets[1] == null || areaTargets[2] == null)
        {
            yield break;
        }

        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnPosition = GetRandomPointInTriangle(
                areaTargets[0].position,
                areaTargets[1].position,
                areaTargets[2].position);

            Instantiate(targetPrefab, spawnPosition, Quaternion.Euler(spawnRotationEuler));

            if (i < spawnAmount - 1)
            {
                yield return new WaitForSeconds(spawnIntervalSeconds);
            }
        }
    }

    private Vector3 GetRandomPointInTriangle(Vector3 a, Vector3 b, Vector3 c)
    {
        float r1 = Random.value;
        float r2 = Random.value;

        if (r1 + r2 > 1f)
        {
            r1 = 1f - r1;
            r2 = 1f - r2;
        }

        return a + r1 * (b - a) + r2 * (c - a);
    }
}
