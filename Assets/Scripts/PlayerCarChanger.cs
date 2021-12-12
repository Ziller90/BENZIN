using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarChanger : MonoBehaviour
{
    public VehicleControlManager controlManager;
    public FractionMarker fractionMarker;
    public bool isEmptyVehicle;
    public GameManager gameManager;


    void Start()
    {
        if (isEmptyVehicle == true)
        {
            controlManager.controlMaster = VehicleControlManager.ControlMaster.None;
            fractionMarker.objectFraction = FractionMarker.Fraction.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.playersVehice)
    }
}
