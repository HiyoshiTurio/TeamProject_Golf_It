using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 現在の打数表示
/// </summary>
public class StrokeView : MonoBehaviour
{
    [SerializeField] private GameSystem _gameSystem;
    [SerializeField] private Text _strokeText;

    private void OnEnable()
    {
        //登録
        // _gameSystem.OnDasuuChanged += UpdateStrokeText;
    }

    private void OnDisable()
    {
        //解除
        // _gameSystem.OnDasuuChanged -= UpdateStrokeText;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stroke">表示したい打数</param>
    private void UpdateStrokeText(int stroke)
    {
        _strokeText.text = $"{stroke}";
    }
}