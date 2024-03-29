﻿using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public EnemyData enemyData;
    
    private bool isMovingRandomly = false;

    private void Start()
    {
        moveSpeed = enemyData.speed;
    }

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

        float randomHorizontal = Random.Range(-5f, 5f);
        float randomVertical = Random.Range(-5f, 5f);
        float RandomMoveTime = Random.Range(3f, 7f);

        MoveEnnemy(randomHorizontal, randomVertical);

        yield return new WaitForSeconds(RandomMoveTime);
        
        isMovingRandomly = false;
    }
    
    public void MoveEnnemy(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
}