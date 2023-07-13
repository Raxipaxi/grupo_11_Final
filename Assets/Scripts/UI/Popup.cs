using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Popup : Panel
{
    public TMP_Text txtTitle;
    public TMP_Text txtDescription;
    public MenuButton btnConfirm;
    public MenuButton btnCancel;

    public override void Initialize()
    {
        base.Initialize();
        btnConfirm.Deselect();
        btnCancel.Deselect();

        btnCancel.button.onClick.AddListener(Close);
    }

    public void SetPopupInfo(GlobalConfig.PopupInfo popupInfo)
    {
        txtTitle.text = popupInfo.title;
        txtDescription.text = popupInfo.description;
    }

    public override void Open()
    {
        base.Open();
        AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.openPopup);
        btnConfirm.button.Select();
    }

    public override void Close()
    {
        base.Close();
        AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.closePopup);
        btnConfirm.button.onClick.RemoveAllListeners();
        btnCancel.Deselect();
    }
}
