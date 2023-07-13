using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [ReadOnly] [SerializeField] private bool isOpen;
    public bool IsOpen => isOpen;

    public virtual void Initialize()
    {

    }

    public virtual void Dispose()
    {

    }

    public virtual void Open()
    {
        isOpen = true;
        gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        isOpen = false;
        gameObject.SetActive(false);
    }
}
