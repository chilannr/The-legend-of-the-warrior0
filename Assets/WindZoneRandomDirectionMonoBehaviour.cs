using UnityEngine;
using System.Collections;

public class WindZoneRandomDirectionMonoBehaviour : MonoBehaviour
{
    float timer = 0;
    float randomTime = 5.0f;
    WindZone windZone;

    void Start()
    {
        // Get the WindZone component attached to this gameObject
        windZone = GetComponent<WindZone>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > randomTime)
        {
            randomTime = Random.Range(2, 5);
            float newWindStrength = Random.Range(0.3f, 1.0f);
            windZone.windMain = newWindStrength;
            timer = 0;
        }
    }
}