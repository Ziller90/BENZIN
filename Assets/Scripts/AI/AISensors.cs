using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensors : MonoBehaviour
{
    public bool SeeEnemy;
    public List<GameObject> EnemiesInDetectionZone;

    GameObject NearestEnemy;
    public GameObject Vehicle;
    public FractionMarker VehicleFractionMarker;

    public GameObject GetEnemy()
    {
        return NearestEnemy;
    }
    private void FixedUpdate()
    {
        if (EnemiesInDetectionZone.Count > 0)
           NearestEnemy = GetNearestEnemy();
    }

    private void OnTriggerEnter(Collider NewTrigger)
    {
        if (NewTrigger.gameObject.GetComponent<FractionMarker>() != null) 
        {
            if (NewTrigger.gameObject.GetComponent<FractionMarker>().ObjectFraction != VehicleFractionMarker.ObjectFraction)
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
    public GameObject GetNearestEnemy()
    {
        float MinDistance = 1000000;
        foreach (GameObject point in EnemiesInDetectionZone)
        {
            if (Vector3.Distance(gameObject.transform.position, point.transform.position) < MinDistance)
            {
                NearestEnemy = point;
            }
        }
        return NearestEnemy;
    }
}
