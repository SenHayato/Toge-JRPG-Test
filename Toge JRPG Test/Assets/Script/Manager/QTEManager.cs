using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class QTEManager : Singleton<QTEManager>
{
    public GameObject ButtonHud;
    public GameObject TimerHud;
    public TextMeshProUGUI textPrompt;

    private float timer;
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
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (IsRunning)
        {
            float progress = timer / duration;
            TimerHud.transform.localScale = Vector3.Lerp(scaleSize, normalScale, progress);
            yield return null;
        }

        TimerHud.transform.localScale = Vector3.zero;
    }

    public void OnConfirm()
    {
        if (!IsRunning || finished)
            return;

        float progress = timer / duration;

        if (progress < 0.3f)
        {
            FinishQTE(QTEResult.Perfect);
        }
        else if (progress < 0.7f)
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

    private void OnDisable()
    {
        StopCoroutine(TimerRoutine());
    }
}
