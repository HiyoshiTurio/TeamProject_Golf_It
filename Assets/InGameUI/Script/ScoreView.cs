using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private void OnEnable()
    {
        //todo: 登録
        //HogeClass.OnScore += UpdateScoreText;
    }

    private void OnDisable()
    {
        //todo: 解除
        //HogeClass.OnScore -= UpdateScoreText;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentScore">現在のスコア</param>
    private void UpdateScoreText(int currentScore)
    {
        _scoreText.text = $"{currentScore}";
    }
}