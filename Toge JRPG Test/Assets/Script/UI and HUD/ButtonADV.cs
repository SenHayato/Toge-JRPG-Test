using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonADV : Button
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Vector2 normalSize;
    [SerializeField] float multipleSize;
    [SerializeField] float animDuration;
    [SerializeField] Ease animEase;


    protected override void Awake()
    {
        base.Awake();
        DOTween.Kill(this);
        rectTransform = GetComponent<RectTransform>();
        normalSize = rectTransform.sizeDelta;
    }

    protected override void Start()
    {
        base.Start();
        DOTween.Kill(this);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        DOTween.Kill(this);
        rectTransform.sizeDelta = normalSize;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        rectTransform.DOSizeDelta(normalSize * multipleSize, animDuration).SetEase(animEase).SetUpdate(true);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        rectTransform.DOSizeDelta(normalSize, animDuration).SetEase(animEase).SetUpdate(true);
    }
}
