using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;
    public GameObject[] pathPoints;
    public CastleController castleController;
    public int damageToCastle = 1;

    private int currentPathIndex;
    private const float ReachDistance = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (castleController == null)
        {
            castleController = FindObjectOfType<CastleController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pathPoints == null || pathPoints.Length == 0 || currentPathIndex >= pathPoints.Length)
        {
            return;
        }

        GameObject currentPoint = pathPoints[currentPathIndex];
        if (currentPoint == null)
        {
            currentPathIndex++;
            return;
        }

        Vector3 targetPosition = currentPoint.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) <= ReachDistance)
        {
            if (currentPathIndex == pathPoints.Length - 1)
            {
                if (castleController != null)
                {
                    castleController.DealDamage(damageToCastle);
                }

                Destroy(gameObject);
                return;
            }

            currentPathIndex++;
        }
    }
}
