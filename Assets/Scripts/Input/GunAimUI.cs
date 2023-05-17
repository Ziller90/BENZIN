using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GunAimUI : MonoBehaviour
{
    public Transform AimUITransform;
    public GameObject AimUIObject;
    public Transform Gun;
    public float y;
    public VehicleControlManager VehicleControlManager;
    void Start()
    {
        VehicleControlManager = gameObject.transform.parent.GetComponent<VehicleControlManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (VehicleControlManager.controlMaster == VehicleControlManager.ControlMaster.Player)
        {
            AimUIObject.SetActive(true);
        }
        else
        {
            AimUIObject.SetActive(false);
        }

        AimUITransform.rotation = Quaternion.Euler(0, Gun.rotation.eulerAngles.y, 0);
    }
}
