using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;

    [SerializeField] private GameObject normalProjectilePrefab;
    [SerializeField] private GameObject spinningProjectilePrefab;
    [SerializeField] private Transform firePoint;

    private void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(normalProjectilePrefab, firePoint.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Instantiate(spinningProjectilePrefab, firePoint.position, Quaternion.identity);
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}