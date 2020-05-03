using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class UniRxUITest : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private InputField inputField;
    [SerializeField] private Text countText;
    [SerializeField] private Text greetText;

    private int count = 0;
    
    // ここが重要！！
    // SubjectはIObservableとIObserverの2つを実装しており，「値を発行する」「値を購読できる」という2つの機能を持ったクラスである
    private Subject<string> _onClickButton = new Subject<string>();
    // IObservableはイベントメッセージを購読できる」というふるまいを定義したインターフェース
    public IObservable<string> OnClickButton
    {
        get { return _onClickButton; }
    }

    // Start is called before the first frame update
    void Start()
    {
        countText.text = count.ToString();
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Setup()
    {
        button.OnClickAsObservable()
            .Subscribe(_ => CountUp())
            .AddTo(this);
        
        // インプットフィールドの入力が終わったらイベント発火
        inputField.OnEndEditAsObservable()
            .Subscribe(text => _onClickButton.OnNext(text))
            .AddTo(this);
        
        // 作成した_onClickButtonの値が変わったらイベント発火
        OnClickButton
            .Subscribe(text => Greet(text))
            .AddTo(this);
    }

    // カウントアップのメソッド
    private void CountUp()
    {
        count++;
        countText.text = count.ToString();
    }

    // 挨拶のメソッド
    private void Greet(string name)
    {
        greetText.text = "おはようございます" + name + "さん";
    }
}
