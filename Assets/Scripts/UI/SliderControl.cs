using UnityEngine;
using UnityEngine.EventSystems;

// Inheriting from these classes as these contain the functions required for performing drag/drop operations
public class SliderControl : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;    // transform of the slider, it is used to rotate the slider when it is being dragged
    [SerializeField] Transform ControlRingCenter;   // gives the location of the center of the control ring
    Vector2 DragBeginArm;   // stores the vector to mouse position when dragging begins

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
    }

    // called every frame when the slider is being dragged
    public void OnDrag(PointerEventData eventData)
    {
        // find vector from center of the control ring to the current mouse position
        Vector2 DragCurrentArm = eventData.position - new Vector2(ControlRingCenter.position.x, ControlRingCenter.position.y);
        // find angle by which the slider needs to be rotated
        float RotAngle = Vector2.SignedAngle(DragBeginArm, DragCurrentArm);
        rectTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, RotAngle));
    }

    // called once when dragging the slider stops
    public void OnEndDrag(PointerEventData eventData)
    {
        // reset the slider after dragging is complete
        rectTransform.localRotation = Quaternion.identity;
    }

    // called once when mouse button is pressed, needs to be present here for dragging to work
    public void OnPointerDown(PointerEventData eventData)
    {
    }

}
