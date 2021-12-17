using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepareBox : MonoBehaviour
{
    GameManager gameManager;
    public GameObject playerVehicle;
    public float distanceToUse;
    public float appendHealth;
    bool isUsed = false;
    void Start()
    {
        gameManager = LinkContainer.instance.gameManager;
    }

    // Update is called once per frame
    void Update()
    {
        playerVehicle = gameManager.playersVehice;
        if (Vector3.Distance(playerVehicle.transform.position, gameObject.transform.position) < distanceToUse && isUsed == false && gameManager.playersVehicleHealth.currentHealth != gameManager.playersVehicleHealth.maxHealth)
        {
            gameManager.playersVehicleHealth.AddHealth(appendHealth);
            isUsed = true;
            Destroy(gameObject);
        }
    }
}
