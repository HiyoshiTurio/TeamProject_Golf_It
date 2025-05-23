using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 残りの打数表示
/// </summary>
public class RemainingStrokesView : MonoBehaviour
{
    [SerializeField] private Text _strokeText;

    private void OnEnable()
    {
        //todo: 登録
        //HogeClass.OnRemainingStroke += UpdateRemainingStrokeText;
    }

    private void OnDisable()
    {
        //todo: 解除
        //HogeClass.OnRemainingStroke -= UpdateRemainingStrokeText;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="remainingStrokes">残りのスコア</param>
    private void UpdateRemainingStrokeText(int remainingStrokes)
    {
        _strokeText.text = $"{remainingStrokes}";
    }
}