using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensors : MonoBehaviour
{
    public bool SeeEnemy;
    public List<GameObject> EnemiesInDetectionZone;

    public GameObject NearestEnemy;
    public GameObject Vehicle;
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
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







    //public List<GameObject> VisualFinding(int MaxLength, int FieldOfViewAngle, int Period)
    //{
    //    List<GameObject> UnitsSee = new List<GameObject>();

    //    for (int i = -(FieldOfViewAngle / 2); i < FieldOfViewAngle / 2; i = i + Period)
    //    {
    //        Debug.DrawRay(gameObject.transform.position, Quaternion.Euler(0, i, 0) * gameObject.transform.forward * MaxLength, Color.red);
    //        if (Physics.Raycast(gameObject.transform.position, Quaternion.Euler(0, i, 0) * gameObject.transform.forward * MaxLength, out RaycastHit hit))
    //        {
    //            if (hit.collider.gameObject.layer == 6 && hit.collider.gameObject.GetComponent<FractionMarker>().ObjectFraction == FractionMarker.Fraction.Player)
    //            {
    //                UnitsSee.Add(hit.collider.gameObject);
    //            }
    //        }
    //    }
    //    return UnitsSee;
    //}
}
