using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensors : MonoBehaviour
{
    public bool SeeEnemy;
    public List<GameObject> EnemiesInFieldOfView;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CastViewRays(10, 80, 2);
    }
    private void OnTriggerEnter(Collider NewTrigger)
    {
        if (NewTrigger.gameObject.GetComponent<FractionMarker>() != null) 
        {
            if (NewTrigger.gameObject.GetComponent<FractionMarker>().ObjectFraction == FractionMarker.Fraction.Player)
            {
                EnemiesInFieldOfView.Add(NewTrigger.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider Trigger)
    {
        if (EnemiesInFieldOfView.Contains(Trigger.gameObject))
        {
            EnemiesInFieldOfView.Remove(Trigger.gameObject);
        }
    }
    public void CastViewRays(float MaxLength, float FieldOfViewAngle, int Period)
    {
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 100);
        for (int i = 0; i < FieldOfViewAngle / 2; i = i + Period)
        {
            Debug.DrawRay(gameObject.transform.position, Quaternion.Euler(0, i, 0) * gameObject.transform.forward * 100, Color.red);
            Debug.DrawRay(gameObject.transform.position, Quaternion.Euler(0, -i, 0) * gameObject.transform.forward * 100, Color.red);

            Physics.Raycast(gameObject.transform.position, Quaternion.Euler(0, i, 0) * gameObject.transform.forward * 100);
            Physics.Raycast(gameObject.transform.position, Quaternion.Euler(0, -i, 0) * gameObject.transform.forward * 100);


        }
    }
}
