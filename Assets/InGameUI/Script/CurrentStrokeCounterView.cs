using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 現在の打数表示
/// </summary>
public class CurrentStrokeCounterView : MonoBehaviour
{
    [SerializeField] private Text _strokeText;

    private void OnEnable()
    {
        //todo: 登録
        //HogeClass.OnCurrentStroke += UpdateStrokeText;
    }

    private void OnDisable()
    {
        //todo: 解除
        //HogeClass.OnCurrentStroke -= UpdateStrokeText;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentStroke">現在のスコア</param>
    private void UpdateStrokeText(int currentStroke)
    {
        _strokeText.text = $"{currentStroke}";
    }
}