using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [ReadOnly] [SerializeField] private bool isOpen;
    public bool IsOpen => isOpen;

    private bool hasCanvas;

    public Action OnOpen;
    public Action OnClose;

    public virtual void Initialize()
    {
        hasCanvas = canvas != null;
    }

    public virtual void Dispose()
    {

    }

    public virtual void Open()
    {
        isOpen = true;

        if (hasCanvas)
            canvas.enabled = true;

        gameObject.SetActive(true);
        OnOpen?.Invoke();
    }

    public virtual void Close()
    {
        isOpen = false;

        if(hasCanvas)
            canvas.enabled = false;

        gameObject.SetActive(false);
        OnClose?.Invoke();
    }
}
