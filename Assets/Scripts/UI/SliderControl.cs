using UnityEngine;
using UnityEngine.EventSystems;

// Inheriting from these classes as these contain the functions required for performing drag/drop operations
public class SliderControl : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;    // transform of the slider, it is used to rotate the slider when it is being dragged
    [SerializeField] Transform ControlRingCenter;   // gives the location of the center of the control ring
    private Vector2 DragBeginArm;   // stores the vector to mouse position when dragging begins
    public float RotAngle = 0.0f;
    public bool isTurning = false;
    //private float prevRotAngle = 0.0f; // stores the rotation angle of the slider in the previous frame
    //public float RotDifference = 0.0f; // stores the difference in rotation angle of slider between current and previous frame
    // called at the beginning of the game
    private void Awake()
    {
        // get transform component of this (slider) object, to modify its rotation
        rectTransform = GetComponent<RectTransform>();
    }

    // called once when dragging the slider begins
    public void OnBeginDrag(PointerEventData eventData)
    {
        // find vector from center of the control ring to the mouse position at the beginning of the drag
        DragBeginArm = eventData.position - new Vector2(ControlRingCenter.position.x, ControlRingCenter.position.y);
        isTurning = true;
    }

    // called every frame when the slider is being dragged
    public void OnDrag(PointerEventData eventData)
    {
        // find vector from center of the control ring to the current mouse position
        Vector2 DragCurrentArm = eventData.position - new Vector2(ControlRingCenter.position.x, ControlRingCenter.position.y);
        // find angle by which the slider needs to be rotated
        RotAngle = Vector2.SignedAngle(DragBeginArm, DragCurrentArm);
        //RotDifference = RotAngle - prevRotAngle;
        rectTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, RotAngle));
        //prevRotAngle = RotAngle;
    }

    // called once when dragging the slider stops
    public void OnEndDrag(PointerEventData eventData)
    {
        // reset the slider after dragging is complete
        rectTransform.localRotation = Quaternion.identity;
        isTurning = false;
        RotAngle = 0.0f;
        //prevRotAngle = 0;   // reset the previous frame rotation on end of drag
        //RotDifference = 0;  // reset the rotation difference on end of drag
    }

    // called once when mouse button is pressed, needs to be present here for dragging to work
    public void OnPointerDown(PointerEventData eventData)
    {
    }

}
