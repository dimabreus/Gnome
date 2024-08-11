using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider _sliderFPS;
    [SerializeField] private TMPro.TextMeshProUGUI _fpsText;

	private void Start()
	{
		SetFPS();
	}

	private void Update()
	{
		_fpsText.text = "FPS: " + ((int)(1 / Time.unscaledDeltaTime)).ToString();
	}

	public void SetFPS()
    {
		if (_sliderFPS.value < 0) return;

		Application.targetFrameRate = (int)((_sliderFPS.value + 1) * 30);
		QualitySettings.vSyncCount = 0;
	}

	public void CloseGame()
	{
		Application.Quit();
	}
}
