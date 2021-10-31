using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensors : MonoBehaviour
{
    public bool SeeEnemy;
    public List<GameObject> EnemiesInDetectionZone;

    public GameObject NearestEnemy;
    public GameObject Vehicle;

    private void FixedUpdate()
    {
        if (EnemiesInDetectionZone.Count > 0)
           NearestEnemy = Utils.GetNearestGameObject(Vehicle, EnemiesInDetectionZone);
    }

    private void OnTriggerEnter(Collider NewTrigger)
    {
        if (NewTrigger.gameObject.GetComponent<FractionMarker>() != null) 
        {
            if (NewTrigger.gameObject.GetComponent<FractionMarker>().ObjectFraction == FractionMarker.Fraction.Player)
            {
                EnemiesInDetectionZone.Add(NewTrigger.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider Trigger)
    {
        if (EnemiesInDetectionZone.Contains(Trigger.gameObject))
        {
            EnemiesInDetectionZone.Remove(Trigger.gameObject);
        }
    }
}
