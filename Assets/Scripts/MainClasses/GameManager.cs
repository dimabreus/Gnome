using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider _fpsSlider;
    [SerializeField] private TextMeshProUGUI _fpsText;
    [SerializeField] private int _fpsMultiplier = 30;

    private void Start()
    {
        SetFPS();
    }

    private void Update()
    {
        float fps = 1 / Time.unscaledDeltaTime;
        _fpsText.text = "FPS: " + Mathf.RoundToInt(fps).ToString();
    }

    public void SetFPS()
    {
        if (_fpsSlider.value < 0f)
        {
            Application.targetFrameRate = Mathf.RoundToInt(Mathf.Infinity);
            QualitySettings.vSyncCount = 1;
        };

        Application.targetFrameRate = Mathf.RoundToInt(_fpsSlider.value + 1) * _fpsMultiplier;
        QualitySettings.vSyncCount = 0;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
