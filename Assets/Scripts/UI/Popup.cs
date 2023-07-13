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
    }

    public void SetPopupInfo(string title, string description)
    {
        txtTitle.text = title;
        txtDescription.text = description;
    }

    public override void Open()
    {
        base.Open();
        btnConfirm.button.Select();
    }

    public override void Close()
    {
        base.Close();
        btnConfirm.button.onClick.RemoveAllListeners();
        btnCancel.button.onClick.RemoveAllListeners();
    }
}
