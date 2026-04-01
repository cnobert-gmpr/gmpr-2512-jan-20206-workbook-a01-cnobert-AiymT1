using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireChance = 0.002f;

    private void Update()
    {
        if (Random.value < fireChance)
        {
            Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}