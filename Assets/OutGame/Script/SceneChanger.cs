using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移用のクラス
/// </summary>
public static class SceneChanger
{
    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
