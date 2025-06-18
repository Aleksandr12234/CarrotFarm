using UnityEngine;

public class Creater : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    [SerializeField] private float sizeX = 1;
    [SerializeField] private float sizeZ = 1;

    void Start()
    {
        Vector3 startPosition = transform.position-new Vector3(sizeX*2.5f/2-1.25f, 0, sizeZ*2.5f/2-1.25f);
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeZ; j++)
            {
                Vector3 vector3 = startPosition + new Vector3(i*2.5f, 0, j*2.5f);
                Instantiate(tile, vector3, transform.rotation, transform).name = $"tile_{i}:{j}";
            }
        }
    }
}
