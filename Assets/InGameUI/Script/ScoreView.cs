using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private GameSystem _gameSystem;
    [SerializeField] private Text _scoreText;

    private void OnEnable()
    {
        //登録
        // _gameSystem.OnScoreChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        // 解除
        // _gameSystem.OnScoreChanged -= UpdateScoreText;
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