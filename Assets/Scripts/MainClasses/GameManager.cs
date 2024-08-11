using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider _sliderFPS;
    [SerializeField] private TMPro.TextMeshProUGUI _fpsText;

	private void Update()
	{
		_fpsText.text = "FPS: " + ((int)(1 / Time.unscaledDeltaTime)).ToString();
	}

	public void SetFPS()
    {
        Application.targetFrameRate = (int)(_sliderFPS.value * 30) >= 3 ? 1000 : (int)(_sliderFPS.value * 30);
    }

	public void CloseGame()
	{
		Application.Quit();
	}
}
