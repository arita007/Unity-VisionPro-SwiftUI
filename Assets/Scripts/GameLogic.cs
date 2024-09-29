using System;
using Samples.PolySpatial.SwiftUI.Scripts;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private SwiftUIDriver _driver;
    private bool _showHelloView;
    private bool _showInjectView;

    private void Awake()
    {
        _driver = GetComponent<SwiftUIDriver>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void UpdateSwiftUI()
    {
        _showHelloView = !_showHelloView;
        _driver.UpdateSwiftUIWindow("HelloWorld", _showHelloView);
    }

    public void UpdateInjectedSwiftUI()
    {
        _showInjectView = !_showInjectView;
        _driver.UpdateInjectSwiftUIWindow(_showInjectView);
    }

    public void UpdateInjectedSwiftUIPos(Vector3 pos)
    {
        _driver.UpdateInjectSwiftUIWindowPos(pos);
    }
        
}
