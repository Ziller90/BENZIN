using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSmoke : MonoBehaviour
{
    public ParticleSystem Smoke1;
    public ParticleSystem Smoke2;
    public Vehicle vehicle;
    public float smokeAppearingSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vehicle.currentSpeed > smokeAppearingSpeed)
        {
            StartSmoke();
        }
        else 
        {
            EndSmoke();
        }
    }
    void StartSmoke()
    {
        if (Smoke1.isPlaying == false && Smoke2.isPlaying == false)
        {
            Smoke1.Play();
            Smoke2.Play();
        }
    }
    void EndSmoke()
    {
        if (Smoke1.isPlaying == true && Smoke2.isPlaying == true)
        {
            Smoke1.Stop();
            Smoke2.Stop();
        }
    }
}
