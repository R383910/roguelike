using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    private float nextRandomMoveTime = 0f;
    private bool isMovingRandomly = false;

    void FixedUpdate()
    {
        if (!isMovingRandomly)
        {
            StartCoroutine(MoveRandomly());
        }
    }
    
    IEnumerator MoveRandomly()
    {
        isMovingRandomly = true;

        float randomHorizontal = Random.Range(-1f, 1f);
        float randomVertical = Random.Range(-1f, 1f);

        MovePlayer(randomHorizontal, randomVertical);

        yield return new WaitForSeconds(5f);

        nextRandomMoveTime = Time.time + 5f;
        isMovingRandomly = false;
    }
}