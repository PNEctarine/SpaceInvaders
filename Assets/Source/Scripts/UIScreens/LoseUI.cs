using Kuhpik;
using UnityEngine;
using UnityEngine.UI;

public class LoseUI : UIScreen
{
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(() => Bootstrap.Instance.GameRestart(0));
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveAllListeners();
    }
}
