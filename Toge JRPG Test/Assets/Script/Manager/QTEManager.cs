using DG.Tweening;
using TMPro;
using UnityEngine;

public class QTEManager : Singleton<QTEManager>
{
    public GameObject ButtonHud;
    public GameObject TimerHud;
    public TextMeshProUGUI textPrompt;

    public bool IsRunning { get; private set; }
    public QTEResult Result { get; private set; }

    [SerializeField] float duration;
    private float timer;
    private Vector3 normalScale = Vector3.one;

    private void OnEnable()
    {
        TimerHud.transform.localScale = new(2.5f, 2.5f, 2.5f);
    }

    public void StartQTE()
    {
        timer = 0;
        UiTimer();
        Result = QTEResult.None;

        IsRunning = true;
    }

    private void Update()
    {
        if (!IsRunning)
            return;

        timer += Time.deltaTime;

        if (timer >= duration)
        {
            FinishQTE(QTEResult.Failed);
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

        FinishQTE(QTEResult.Perfect);
    }

    private void FinishQTE(QTEResult result)
    {
        Result = result;
        IsRunning = false;
    }

    private void OnDisable()
    {
        DOTween.Kill(TimerHud.transform);
    }
}
