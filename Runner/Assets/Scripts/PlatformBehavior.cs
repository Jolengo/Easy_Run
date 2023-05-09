using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPosition;

    public float fallSpeed = 2f;
    public float maxFallDistance = 2f;
    public float restoreSpeed = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // If player is on the platform, disable gravity and start falling
            rb.useGravity = false;
            rb.velocity = Vector3.down * fallSpeed;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // If player is on the platform, check if it has fallen too far
            if (transform.position.y <= startPosition.y - maxFallDistance)
            {
                rb.velocity = Vector3.zero;
                transform.position = startPosition;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // If player leaves the platform, enable gravity and start restoring position
            rb.useGravity = true;
            rb.velocity = Vector3.zero;
            StartCoroutine(RestorePosition());
        }
    }

    private System.Collections.IEnumerator RestorePosition()
    {
        while (transform.position.y < startPosition.y)
        {
            transform.position += Vector3.up * restoreSpeed * Time.deltaTime;
            yield return null;
        }
        transform.position = startPosition;
    }
}

