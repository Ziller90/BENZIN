using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarChanger : PanelShower
{
    public VehicleControlManager controlManager;
    public GameObject vehicle;
    public Health vehicleHealth;
    public Transform cameraFollowingPoint;

    public FractionMarker fractionMarker;
    public bool isEmptyVehicle;
    public float DistanceToShowChangeVehicleButton;
    GameManager gameManager;
    void Start()
    {
        ButtonFunction = ChangeCar;
        gameManager = LinkContainer.instance.gameManager;
        if (isEmptyVehicle == true)
        {
            controlManager.controlMaster = VehicleControlManager.ControlMaster.None;
            fractionMarker.objectFraction = FractionMarker.Fraction.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.playersVehice != null)
        {
            if (Vector3.Distance(gameManager.playersVehice.transform.position, gameObject.transform.position) < DistanceToShowChangeVehicleButton && isEmptyVehicle)
            {
                ShowPanel = true;
            }
            else
            {
                ShowPanel = false;
            }
        }
    }
    public void ChangeCar()
    {
        fractionMarker.objectFraction = gameManager.playerVehicleFractionMarker.objectFraction;

        gameManager.playerVehicleFractionMarker.objectFraction = FractionMarker.Fraction.None;
        gameManager.playerVehicleControl.controlMaster = VehicleControlManager.ControlMaster.None;
        gameManager.playerVehicleFractionMarker = fractionMarker;

        gameManager.cameraFollowingPoint = cameraFollowingPoint;

        gameManager.playersVehice = vehicle;
        gameManager.playersVehicleHealth = vehicleHealth;
        gameManager.playerVehicleControl = controlManager;

        isEmptyVehicle = false;
        gameManager.playerCarChanger.isEmptyVehicle = true;
        gameManager.playerCarChanger = this;


        controlManager.controlMaster = VehicleControlManager.ControlMaster.Player;
    }
}
public abstract class PanelShower : MonoBehaviour
{
    public delegate void ButtonFunctioDelegate();

    public bool ShowPanel;
    public ButtonFunctioDelegate ButtonFunction;
}
