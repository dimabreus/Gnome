using Player;
using UnityEngine;
using UnityEngine.EventSystems;

class ButtonMovementHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Vector2 _vectorMove;

    private bool _isPressed;

    private void Update()
    {
        if (_isPressed)
        {
            InputManager.Direction = _vectorMove;
        }
    }

    public void OnPointerDown(PointerEventData e)
    {
        _isPressed = true;
    }

    public void OnPointerUp(PointerEventData e)
    {
        _isPressed = false;
        InputManager.Direction = Vector2.zero;
    }
}
