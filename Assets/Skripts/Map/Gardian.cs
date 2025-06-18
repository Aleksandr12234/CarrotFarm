using UnityEngine;

public class Gardian : MonoBehaviour
{
    [SerializeField] private float ripeningTime = 5;
    private string stage = "empty";
    private float time;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= ripeningTime && stage == "planted")
        {
            Swap(3);
            stage = "grown";
        }
        else if (stage == "planted")
        {
            if (time < ripeningTime / 2) Swap(1);
            else Swap(2);
        }
    }

    public string GetOccupied() { return stage; }
    public void SetOccupied()
    {
        switch (stage)
        {
            case "empty":
                stage = "planted";
                time = 0;
                break;

            case "grown":
                Swap(0);
                stage = "empty";
                break;
        }
    }
    
    private void Swap(int num)
    { 
        foreach (Transform i in transform)
        {
            ModelSwitcher switcher = i.gameObject.GetComponent<ModelSwitcher>();
            if (switcher != null) switcher.Switch(num);
        }
    }
}
