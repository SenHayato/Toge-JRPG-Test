using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class QTEManager : Singleton<QTEManager>
{
    public GameObject ButtonHud;
    public GameObject TimerHud;
    public TextMeshProUGUI textPrompt;

    [SerializeField] float timer;
    [SerializeField] float duration;
    public bool IsRunning { get; private set; }
    public QTEResult Result { get; private set; }

    [SerializeField] Vector3 scaleSize = new(2.5f, 2.5f, 2.5f);
    [SerializeField] Vector3 normalScale = Vector3.one;

    private bool finished;

    private void OnEnable()
    {
        TimerHud.transform.localScale = scaleSize;
    }

    public void StartQTE()
    {
        timer = 0;

        Result = QTEResult.None;
        UiTimer();
        IsRunning = true;
        finished = false;
    }

    private void Update()
    {
        if (!IsRunning || finished)
            return;

        timer += Time.deltaTime;

        if (timer >= duration)
        {
            FinishQTE(QTEResult.Failed);
        }
    }

    public void UiTimer()
    {
        //StartCoroutine(TimerRoutine());
        TimerHud.transform.DOScale(normalScale, duration - 0.5f).SetEase(Ease.Linear);
    }

    //IEnumerator TimerRoutine()
    //{
    //    while (IsRunning)
    //    {
    //        float progress = timer / duration;
    //        TimerHud.transform.localScale = Vector3.Lerp(scaleSize, normalScale, progress);
    //        yield return null;
    //    }

    //    TimerHud.transform.localScale = Vector3.zero;
    //}

    public void OnConfirm()
    {
        if (!IsRunning || finished)
            return;

        if (timer > 0.8f)
        {
            FinishQTE(QTEResult.Perfect);
        }
        else if (timer > 0 && timer < 0.79f)
        {
            FinishQTE(QTEResult.Good);
        }
        else
        {
            FinishQTE(QTEResult.Failed);
        }
    }

    private void FinishQTE(QTEResult result)
    {
        if (finished) return;

        finished = true;
        Result = result;
        IsRunning = false;
    }

    public void SetQTEText(string textValue)
    {
        textPrompt.text = textValue;
    }

    private void OnDisable()
    {
        DOTween.Kill(TimerHud.transform);
    }
}
