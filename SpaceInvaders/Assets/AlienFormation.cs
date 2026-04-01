using UnityEngine;

public class AlienFormation : MonoBehaviour
{
    [SerializeField] private GameObject alienType1Prefab;
    [SerializeField] private GameObject alienType2Prefab;

    [SerializeField] private int rows = 4;
    [SerializeField] private int cols = 8;
    [SerializeField] private float spacingX = 1.2f;
    [SerializeField] private float spacingY = 1.0f;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float leftLimit = -8f;
    [SerializeField] private float rightLimit = 8f;
    [SerializeField] private float stepDownAmount = 0.5f;

    private int direction = 1;

    private void Start()
    {
        SpawnFormation();
    }

    private void Update()
    {
        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        float leftEdge = GetLeftEdge();
        float rightEdge = GetRightEdge();

        if (rightEdge >= rightLimit && direction == 1)
        {
            direction = -1;
            transform.position += Vector3.down * stepDownAmount;
        }
        else if (leftEdge <= leftLimit && direction == -1)
        {
            direction = 1;
            transform.position += Vector3.down * stepDownAmount;
        }
    }

    private void SpawnFormation()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                GameObject prefab = (r % 2 == 0) ? alienType1Prefab : alienType2Prefab;

                Vector3 localPos = new Vector3(c * spacingX, -r * spacingY, 0f);
                Instantiate(prefab, transform.position + localPos, Quaternion.identity, transform);
            }
        }
    }

    private float GetLeftEdge()
    {
        float min = float.MaxValue;

        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf && child.position.x < min)
            {
                min = child.position.x;
            }
        }

        return min;
    }

    private float GetRightEdge()
    {
        float max = float.MinValue;

        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf && child.position.x > max)
            {
                max = child.position.x;
            }
        }

        return max;
    }

    public bool AllAliensDead()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                return false;
            }
        }

        return true;
    }
}