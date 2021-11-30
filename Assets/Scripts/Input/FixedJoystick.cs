using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;




public class FixedJoystick : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    public JoystickInputManager inputManager;
    public ButtonsInput buttonsInput;
    public GameObject Handle;
    public float Horizontal;
    public float Vertical;
    public bool isDraged;
    public float JoystickMagnitude;
    public Vector3 Direction;
    public float MaxMagnitude;
                         
    GameObject HandleBackGround;
    bool HandlerIsPressed;
    Vector2 TouchPosition;
    Vector2 LocalPoint;

    public bool RightJoystick;

    void Start()
    {
        Handle = gameObject;
        HandleBackGround = Handle.transform.parent.gameObject;
    }

    void Update()
    {
        Vertical = Handle.transform.localPosition.y / 100;
        Horizontal = (Handle.transform.localPosition.x / 100);

        Direction = Utils.GetDirection(Horizontal, Vertical, -30);
        inputManager.Direction = Direction;

        if (RightJoystick == true)
        {
            if (Vertical > 1 || Horizontal > 1 || Horizontal < -1 || Vertical < -1)
            {
                buttonsInput.isShooting = true;
            }
            else
            {
                buttonsInput.isShooting = false;
            }
        }
        else
        {
            if (Direction.magnitude == 0)
            {
                buttonsInput.isBraking = true;
            }
            else
            {
                buttonsInput.isBraking = false;
            }
        }
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
