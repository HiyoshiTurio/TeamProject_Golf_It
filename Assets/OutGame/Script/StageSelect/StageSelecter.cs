using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class StageSelecter : MonoBehaviour 
{
    [SerializeField,Header("ステージのData")]
    private List<StageData> _stageData = new();

    [SerializeField, Header("ロードするラベル")]
    private string _loadLabel;

    private void Start()
    {
        LoadStages(_loadLabel);
    }

    /// <summary>
    /// ラベルで紐づけしてあるステージを一括で読み込む
    /// </summary>
    public void LoadStages(string label)
    {
        Addressables.LoadAssetsAsync<StageData>(label, null).Completed += OnStagesLoaded;
    }

    public void OnStagesLoaded(AsyncOperationHandle<IList<StageData>> handle)
    {
        foreach (var stageData in handle.Result)
        {
            _stageData.Add(stageData);
        }
    }
 }
