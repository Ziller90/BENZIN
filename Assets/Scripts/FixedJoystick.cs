using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;




public class FixedJoystick : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    public GameObject Handle;
    public float Horizontal;
    public float Vectical;
    public bool isDraged;
    public float JoystickMagnitude;
    public Vector3 Dirrection;
    public float MaxMagnitude;

    Quaternion FixAngle;                            
    GameObject HandleBackGround;
    bool HandlerIsPressed;
    Vector2 TouchPosition;
    Vector2 LocalPoint;

    void Start()
    {
        Handle = gameObject;
        HandleBackGround = Handle.transform.parent.gameObject;
        FixAngle = Quaternion.Euler(0, -30, 0);
    }

    void FixedUpdate()
    {
        Vectical = Handle.transform.localPosition.y / 100;
        Horizontal = (Handle.transform.localPosition.x / 100);
        JoystickMagnitude = Handle.transform.localPosition.magnitude / 100;

        Dirrection = new Vector3(Horizontal, 0, Vectical); // Дорогой дневник, я умираю от кринжа...
        Dirrection = FixAngle * Dirrection;
        
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
        Handle.transform.localPosition = new Vector3(0, 0, 0);
        isDraged = false;
    }
    public void OnPointerDown(PointerEventData eventData) { }
    public void OnDrag(PointerEventData eventData)
    {
        isDraged = true;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(HandleBackGround.GetComponent<Image>().rectTransform,
            eventData.position, eventData.pressEventCamera, out LocalPoint);
        Handle.transform.localPosition = Vector2.ClampMagnitude(LocalPoint, MaxMagnitude);
    }

}
