using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class TapController : MonoBehaviour
{
    [SerializeField] private Button tapButton;
    [SerializeField] private Text counter;
    [SerializeField] private Button singleTapButton;
    [SerializeField] private Text singleCounter;
    [SerializeField] private Text judge;
    [SerializeField] private Button longTapButton;
    [SerializeField] private GameObject Cube;

    private int _count = 0;
    private int _singleCount = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        singleTapButton.OnSafeClickAsObservable()
            .Subscribe(_ => CountSingle())
            .AddTo(this);

        tapButton.OnClickAsObservable()
            .Subscribe(_ => Count())
            .AddTo(this);
        
        longTapButton.OnLongClickAsObservable()
            .Subscribe(_ => Debug.Log("Long Tap"))
            .AddTo(this);
        
        Cube.OnDoubleClickAsObservable()
            .Subscribe(_ => Debug.Log("Double Click"))
            .AddTo(this);
         
        Cube.OnMultiTapAsObservable()
            .Subscribe(count => Debug.Log(count))
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Count()
    {
        _count++;
        counter.text = _count.ToString();
        judge.text = "tap";
    }
    
    private void CountSingle()
    {
        _singleCount++;
        singleCounter.text = _singleCount.ToString();
        judge.text = "single tap";
    }
}
