using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject playersVehice;
    public Health playersVehicleHealth;
    public VehicleControlManager playerVehicleControl;
    public FractionMarker playerVehicleFractionMarker;
    public PlayerCarChanger playerCarChanger;
    public Transform cameraFollowingPoint;
    public CanvasGroup gameOverPanel;
    public float speed;
    public float timeToGameOverScreen;
    public bool HavePlayerCarOnScene;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HavePlayerCarOnScene)
            playerVehicleControl.controlMaster = VehicleControlManager.ControlMaster.Player;

        if (HavePlayerCarOnScene)
        {
            if (playersVehicleHealth.currentHealth <= 0)
            {
                StartCoroutine("ShowGameOverScreen");
            }
        }
    }
    public void ChangePlayerVehicle(VehicleControlManager newPlayerVehicleControl, Transform newCameraFollowingPoint, Health NewVehicleHealth)
    {
        playerVehicleControl.controlMaster = VehicleControlManager.ControlMaster.AI;
        playerVehicleControl = newPlayerVehicleControl;
        playerVehicleControl.controlMaster = VehicleControlManager.ControlMaster.Player;
        cameraFollowingPoint = newCameraFollowingPoint;
        playersVehicleHealth = NewVehicleHealth;
    }
    IEnumerator ShowGameOverScreen()
    {
        gameOverPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeToGameOverScreen);
        while (gameOverPanel.alpha < 1)
        {
            yield return new WaitForSeconds(100 / speed);
            gameOverPanel.alpha += 0.01f;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
