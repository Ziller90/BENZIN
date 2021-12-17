using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanelShowView : MonoBehaviour // Make instance of panel, show it or not, giveLinkToButtonFunction
{
    GameObject panel;
    public Transform worldPosition;
    Camera mainCamera;
    public Vector3 offset;
    Transform listOfPanelOnCanvas;
    public GameObject panelToShowPrefab;
    public PanelShower panelShower;

    void Start()
    {
        listOfPanelOnCanvas = LinkContainer.instance.panelList;
        mainCamera = LinkContainer.instance.mainCamera;
        panel = Instantiate(panelToShowPrefab, listOfPanelOnCanvas);
    }
    void Update()
    {
        panel.GetComponent<PanelButtonOnClick>().buttonFunction = panelShower.ButtonFunction;
        if (panelShower.ShowPanel == true)
        {
            panel.transform.position = mainCamera.WorldToScreenPoint(worldPosition.position) + offset;
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        Destroy(panel);
    }
}
