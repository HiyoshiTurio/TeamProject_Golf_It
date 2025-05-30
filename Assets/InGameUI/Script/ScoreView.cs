using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private void OnEnable()
    {
        //登録
        GameSystem.Instance.OnScoreChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        // 解除
        GameSystem.Instance.OnScoreChanged -= UpdateScoreText;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentScore">表示したいスコア</param>
    private void UpdateScoreText(float currentScore)
    {
        _scoreText.text = $"{currentScore}";
    }
}