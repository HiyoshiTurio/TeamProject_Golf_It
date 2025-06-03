using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class OutGameUIManager : MonoBehaviour 
{
    [SerializeField,Header("ステージのData")]
    private List<StageData> _stageData = new();

    [SerializeField, Header("ロードするラベル")]
    private string _loadLabel;

    

    private void Start()
    {
        
    }

    
 }
