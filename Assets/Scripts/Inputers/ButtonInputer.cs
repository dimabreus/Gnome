using Player;
using UnityEngine;
using UnityEngine.EventSystems;

class ButtonInputer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] private Vector2 _vectorMove;

	private bool _isPressed;

	public void OnPointerDown(PointerEventData e)
	{
		_isPressed = true;
		StartCoroutine(PerformActionWhileButtonPressed());
	}
	private System.Collections.IEnumerator PerformActionWhileButtonPressed()
	{
		while (_isPressed)
		{
			InputManager.Direction = _vectorMove;
			yield return null;
		}
	}

	public void OnPointerUp(PointerEventData e)
	{
		_isPressed = false;
		PerformActionOnButtonRelease();
	}
	private void PerformActionOnButtonRelease()
	{
		InputManager.Direction = Vector2.zero;
	}
}