using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 3f;
    [SerializeField] private bool moveUp = true;
    [SerializeField] private bool spin = false;
    [SerializeField] private float spinSpeed = 360f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        Vector3 direction = moveUp ? Vector3.up : Vector3.down;
        transform.position += direction * speed * Time.deltaTime;

        if (spin)
        {
            transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (moveUp && other.CompareTag("Alien"))
        {
            other.GetComponent<Alien>()?.Die();
            Destroy(gameObject);
        }

        if (!moveUp && other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>()?.Die();
            Destroy(gameObject);
        }

        if (other.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }
}