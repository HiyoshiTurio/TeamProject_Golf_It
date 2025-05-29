using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 現在の打数表示
/// </summary>
public class StrokeView : MonoBehaviour
{
    [SerializeField] private Text _strokeText;

    private void OnEnable()
    {
        //登録
        GameSystem.Instance.OnDasuuChanged += UpdateStrokeText;
    }

    private void OnDisable()
    {
        //解除
        GameSystem.Instance.OnDasuuChanged -= UpdateStrokeText;
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