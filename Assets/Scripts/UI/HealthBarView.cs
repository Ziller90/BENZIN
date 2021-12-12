using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarView : MonoBehaviour
{
    public GameObject healthBarPrefab;
    public Camera camera;
    StandartHealthBar healthBar;
    Transform healthBarTransform;
    public Transform healthBarsListOnCanvas;
    public Transform objectWithHealthBar;
    public Vector3 offset;
    public Health health;
    void Start()
    {
        healthBarsListOnCanvas = LinkContainer.instance.healthBarList;
        camera = LinkContainer.instance.mainCamera;

        GameObject healthBarObject = Instantiate(healthBarPrefab, healthBarsListOnCanvas);
        healthBarTransform = healthBarObject.GetComponent<Transform>();
        healthBar = healthBarObject.GetComponent<StandartHealthBar>();
    }
    void Update()
    {
        healthBarTransform.position = camera.WorldToScreenPoint(objectWithHealthBar.position) + offset;
        healthBar.SetBarFillness(health.currentHealth / health.maxHealth);
    }
    private void OnDestroy()
    {
        if (healthBar != null )
            Destroy(healthBar.gameObject);
    }
}
