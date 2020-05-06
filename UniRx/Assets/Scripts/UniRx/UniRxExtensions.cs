using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public static class UniRxExtensions
{
    #region method

    /// <summary>
    /// 連打防止用クリック監視
    /// </summary>
    public static IObservable<Unit> OnSafeClickAsObservable(this Button button)
    {
        return button.onClick.AsObservable().ThrottleFirst(System.TimeSpan.FromMilliseconds(250));
    }
    
    #endregion
}