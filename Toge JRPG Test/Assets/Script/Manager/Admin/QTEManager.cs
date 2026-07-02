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
    [SerializeField] int mashCount;
    [SerializeField] int targetMash;
    public bool IsRunning { get; private set; }
    public QTEResult Result { get; private set; }

    [SerializeField] Vector3 scaleSize = new(2.5f, 2.5f, 2.5f);
    [SerializeField] Vector3 normalScale = Vector3.one;

    private bool finished;

    private void OnEnable()
    {
        TimerHud.transform.localScale = scaleSize;
    }

    [SerializeField] QTEType currentQte;

    public void StartQTE(QTEType type)
    {
        timer = 0;
        currentQte = type;
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
            EvaluateResult();
        }
    }

    public void UiTimer()
    {
        TimerHud.transform.DOScale(normalScale, duration - 0.5f).SetEase(Ease.Linear);
    }

    public void OnConfirm()
    {
        if (!IsRunning)
            return;

        if (currentQte == QTEType.Mash)
        {
            mashCount++;
        }
        else if (currentQte == QTEType.Time)
        {
            EvaluateTimeBased();
        }
    }

    public void MashQte()
    {
        mashCount++;

        if (mashCount >= targetMash)
        {
            FinishQTE(QTEResult.Perfect);
        }
    }

    public void EvaluateTimeBased()
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

    private void EvaluateResult()
    {
        if (currentQte == QTEType.Mash)
        {
            if (mashCount >= targetMash)
            {
                FinishQTE(QTEResult.Perfect);
            }
            else if (mashCount >= targetMash * 0.6f)
            {
                FinishQTE(QTEResult.Good);
            }
            else
            {
                FinishQTE(QTEResult.Failed);
            }
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
