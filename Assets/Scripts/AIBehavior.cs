using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    public GameObject bombPrefab;       // Bomb prefab to throw
    public Transform player;           // Player's transform
    public float moveSpeed = 3.0f;     // Speed at which AI moves towards the player
    public float throwDistance = 5.0f; // Distance at which AI will throw the bomb
    public float bombThrowForce = 10f; // Force applied to the bomb
    public Transform bombSpawnPoint;   // Point from where the bomb will be thrown
    public Animator animator;          // Animator for AI's animations

    private bool hasThrownBomb = false;

    private void Start()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > throwDistance)
        {
            // Move towards the player
            MoveTowardsPlayer();
        }
        else
        {
            // Throw the bomb
            if (!hasThrownBomb)
            {
                ThrowBomb();
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        // Set the run animation
        animator.SetBool("isRunning", true);

        // Move towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Face the player
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }

    private void ThrowBomb()
    {
        hasThrownBomb = true;

        // Play the throw animation
        animator.SetTrigger("throw");

        // Wait for the animation to reach the throwing point
        Invoke(nameof(SpawnBomb), 0.5f); // Adjust the timing as needed to sync with animation
    }

    private void SpawnBomb()
    {
        if (bombPrefab && bombSpawnPoint)
        {
            GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, bombSpawnPoint.rotation);

            // Add force to the bomb to throw it towards the player
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            if (rb)
            {
                Vector3 throwDirection = (player.position - bombSpawnPoint.position).normalized;
                rb.AddForce(throwDirection * bombThrowForce, ForceMode.Impulse);
            }
        }
    }
}
