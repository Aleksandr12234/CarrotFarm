using UnityEngine;

public class ModelSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] models;
    [SerializeField] private GameObject currentModel;
    private int numberOfActiveModel=-1;

    private void Start()
    {
        Switch(0);
    }

    public void Switch(int modelIndex)
    {
        if (numberOfActiveModel == modelIndex) return;
        numberOfActiveModel = modelIndex;

        if (currentModel != null)
        {
            Destroy(currentModel);
        }

        currentModel = Instantiate(models[modelIndex], transform.position, transform.rotation, transform);
        currentModel.name = $"Model_{modelIndex}";
    }
}
