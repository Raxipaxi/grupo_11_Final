using System.Collections;
using System.Collections.Generic;
//using CustomUpdateManagerNSP;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public string buttonSelectedMark = "-";
    public Button button;
    public TextMeshProUGUI txtButton;

    private string originalText;

    public void Awake()
    {
        originalText = txtButton.text;
    }

    private void Select()
    {
        //AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.hoverButton);
        txtButton.text = $"{buttonSelectedMark} {originalText} {buttonSelectedMark}";
    }

    public void Deselect()
    {
        txtButton.text = originalText;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Select();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Deselect();
    }

    public void OnSelect(BaseEventData eventData)
    {
        Select();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Deselect();
    }
}
