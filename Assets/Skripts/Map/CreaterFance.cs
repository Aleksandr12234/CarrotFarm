using UnityEngine;

public class CreaterFance : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    [SerializeField] private float sizeX = 1;
    [SerializeField] private float rotationX, rotationY, rotationZ;

    void Start()
    {
        Vector3 startPosition = transform.position - new Vector3(sizeX * 3.5f / 2 - 1.75f, 0, 3.5f / 2 - 1.75f);
        for (int i = 0; i < sizeX; i++)
        {
            Vector3 vector3 = startPosition + new Vector3(i * 3.5f, 0, 1);
            Instantiate(tile, vector3, transform.rotation, transform).name = $"tile_{i}";
        }
        transform.Rotate(rotationX, rotationY, rotationZ);
    }
}
