using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class OutGameUIManager : MonoBehaviour 
{
    [SerializeField,Header("�X�e�[�W��Data")]
    private List<StageData> _stageData = new();

    [SerializeField, Header("���[�h���郉�x��")]
    private string _loadLabel;

    

    private void Start()
    {
        
    }

    
 }
