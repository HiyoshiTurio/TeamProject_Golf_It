using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class StageSelecter : MonoBehaviour 
{
    [SerializeField,Header("�X�e�[�W��Data")]
    private List<StageData> _stageData = new();

    [SerializeField, Header("���[�h���郉�x��")]
    private string _loadLabel;

    private void Start()
    {
        LoadStages(_loadLabel);
    }

    /// <summary>
    /// ���x���ŕR�Â����Ă���X�e�[�W���ꊇ�œǂݍ���
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
