using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;




public class FixedJoystick : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    public JoystickInputManager
        inputManager;
    public GameObject Handle;
    public float Horizontal;
    public float Vertical;
    public bool isDraged;
    public float JoystickMagnitude;
    public Vector3 Direction;
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
    }

    void FixedUpdate()
    {
        Vertical = Handle.transform.localPosition.y / 100;
        Horizontal = (Handle.transform.localPosition.x / 100);

        Direction = Utils.GetDirection(Horizontal, Vertical);
        Direction = FixAngle * Direction;

        inputManager.Direction = Direction;
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
