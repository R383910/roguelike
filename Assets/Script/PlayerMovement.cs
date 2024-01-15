using System;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float dashSpeed;
    public int reloadTimeDash;
    private bool isDashing = false;
    public int divDist = 1;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    public PlayerHealth pH;

    private void Awake()
    {
        if (divDist <= 0)
        {
            divDist = 1;
        }
    }

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;
        float horizontalDash = Input.GetAxis("Horizontal") * (dashSpeed / divDist);
        float verticalDash = Input.GetAxis("Vertical") * (dashSpeed / divDist);

        if (Input.GetKeyDown(KeyCode.E) && !isDashing)
        {
            StartCoroutine(Dash(horizontalDash, verticalDash, reloadTimeDash));
        }

        MovePlayer(horizontalMovement, verticalMovement);
    }

    public void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }

    IEnumerator Dash (float _horizontalDash, float _verticalDash, int _reloadTimeDash)
    {
        isDashing = true;
        pH.isInvisible = true;
        Vector3 targetVelocity = new Vector2(_horizontalDash, _verticalDash);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        pH.isInvisible = false;
        yield return new WaitForSeconds(_reloadTimeDash);
        rb.velocity = Vector3.zero;
        isDashing = false;
    }
}
