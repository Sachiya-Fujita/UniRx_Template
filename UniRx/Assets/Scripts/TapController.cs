using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TapController : MonoBehaviour
{
    [SerializeField] private Button tapButton;
    [SerializeField] private Text counter;
    [SerializeField] private Button singleTapButton;
    [SerializeField] private Text singleCounter;
    [SerializeField] private Text judge;
    
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
