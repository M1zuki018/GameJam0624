using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private SceneType _nextScene = SceneType.Title;

    private readonly Dictionary<SceneType, string> _sceneNameDict = new()
    {
        { SceneType.Title, "TitleScene" },
        { SceneType.InGame, "GameScene" },
        { SceneType.Result, "ResultScene" }
    };

    public void SwitchScene(string sceneName = "TitleScene") => SceneManager.LoadScene(sceneName);

    public void SwitchScene() => SceneManager.LoadScene(_sceneNameDict[_nextScene]);
}
