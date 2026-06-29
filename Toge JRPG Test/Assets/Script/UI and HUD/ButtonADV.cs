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


    protected override void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        normalSize = rectTransform.sizeDelta;
        base.Start();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        rectTransform.sizeDelta = normalSize;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        rectTransform.DOSizeDelta(normalSize * multipleSize, animDuration).SetEase(animEase);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        rectTransform.DOSizeDelta(normalSize, animDuration).SetEase(animEase);
    }
}
