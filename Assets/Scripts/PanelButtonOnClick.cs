using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButtonOnClick : MonoBehaviour
{
    public PanelShower.ButtonFunctioDelegate buttonFunction;
    public void OnClick()
    {
        buttonFunction();
    }
}
