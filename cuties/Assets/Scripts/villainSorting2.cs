using UnityEngine;

public class villainSorting : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform playerTransform;
    private Transform[] obstacleTransforms;

    private SpriteRenderer playerRenderer;

    private SpriteRenderer[] obstacleRenderers;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.Find("player").transform;
        // Find all obstacles in the scene
        GameObject[] obstacleObjects = GameObject.FindGameObjectsWithTag("obstacle");
        playerRenderer = GameObject.Find("player").GetComponent<SpriteRenderer>();
        obstacleTransforms = new Transform[obstacleObjects.Length];
        for (int i = 0; i < obstacleObjects.Length; i++)
        {
            obstacleTransforms[i] = obstacleObjects[i].transform;
        }

        obstacleRenderers = new SpriteRenderer[obstacleObjects.Length];

        for (int i = 0; i < obstacleObjects.Length; i++)
        {

            obstacleRenderers[i] = obstacleObjects[i].GetComponent<SpriteRenderer>();

        }
    }

    void Update()
    {
        float playerDistance = Vector2.Distance(transform.position, playerTransform.position);
        float closestObstacleDistance = float.MaxValue;

        // Find the closest obstacle
        foreach (Transform obstacleTransform in obstacleTransforms)
        {
            float obstacleDistance = Vector2.Distance(transform.position, obstacleTransform.position);
            if (obstacleDistance < closestObstacleDistance)
            {
                closestObstacleDistance = obstacleDistance;
            }
        }

        if (playerDistance < closestObstacleDistance)
        {
            // Player is closer
            if (transform.position.y < playerTransform.position.y)
            {
                // Set sorting layer to be behind the player
                spriteRenderer.sortingOrder = playerRenderer.sortingOrder + 1;
            }
            else
            {
                // Set sorting layer to be in front of the player
                spriteRenderer.sortingOrder = playerRenderer.sortingOrder - 1;
            }
        }
        else
        {
            // Closest obstacle is closer or at the same distance
            // Iterate through obstacles again to find the one closest in terms of Y position
            foreach (Transform obstacleTransform in obstacleTransforms)
            {
                if (Vector2.Distance(transform.position, obstacleTransform.position) == closestObstacleDistance)
                {
                    if (transform.position.y < obstacleTransform.position.y)
                    {
                        // Set sorting layer to be behind the obstacle
                        spriteRenderer.sortingOrder = 16;
                    }
                    else
                    {
                        // Set sorting layer to be in front of the obstacle
                        spriteRenderer.sortingOrder = 5;
                    }
                    break;
                }
            }
        }
    }
}