using UnityEngine;
using UnityEngine.UI;

public class Planting : MonoBehaviour
{
    [SerializeField] private GameObject aktionInfo;
    [SerializeField] private GameObject scoreInfo;
    [SerializeField] private AudioScript audioScript;
    [SerializeField] private UserControl control;
    int score = 0;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit) && hit.distance < 4)
        {
            Gardian gardianScript = hit.collider.gameObject.GetComponent<Gardian>();
            aktionInfo.SetActive(true);

            if (gardianScript != null && gardianScript.GetOccupied() == "empty")
            {
                aktionInfo.GetComponent<Text>().text = "Посадить";
                if (control.GetAktionButton())
                {
                    gardianScript.SetOccupied();
                    audioScript.Planting();
                }
            }
                else if (gardianScript != null && gardianScript.GetOccupied() == "grown")
                {
                    aktionInfo.GetComponent<Text>().text = "Собрать";
                    if (control.GetAktionButton())
                    {
                        gardianScript.SetOccupied();
                        score++;
                        scoreInfo.GetComponent<Text>().text = "" + score;
                        audioScript.Planting();
                    }
                }
                else aktionInfo.SetActive(false);
        }
        else aktionInfo.SetActive(false);
    }
}
