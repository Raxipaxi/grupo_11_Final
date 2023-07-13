using System.Collections;
using System.Collections.Generic;
//using CustomUpdateManagerNSP;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public Button button;
    public TextMeshProUGUI txtButton;
    public GameObject selectedMarker;

    public void Initialize()
    {
        Deselect();
    }

    private void Select()
    {
        selectedMarker.SetActive(true);
        //AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.hoverButton);
    }

    public void Deselect()
    {
        selectedMarker.SetActive(false);
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
