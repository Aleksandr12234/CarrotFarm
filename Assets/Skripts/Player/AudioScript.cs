using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    [SerializeField] private AudioResource[] steps;
    [SerializeField] private AudioResource[] plant;
    [SerializeField] private AudioSource audioSourceSteps;
    [SerializeField] private AudioSource audioSourcePlant;

    public void Step()
    {
        if (!audioSourceSteps.isPlaying)
        {
            int a = Random.Range(0, steps.Length);
            audioSourceSteps.resource = steps[a];
            audioSourceSteps.Play();
        }
    }

    public void Planting()
    {
        if (!audioSourcePlant.isPlaying)
        {
            int a = Random.Range(0, plant.Length);
            audioSourcePlant.resource = plant[a];
            audioSourcePlant.Play();
        }
    }
}
