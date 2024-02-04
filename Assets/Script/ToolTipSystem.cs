using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipSystem : MonoBehaviour
{
    public static ToolTipSystem instance;

    [SerializeField]
    private ToolTip tooltip;


    private void Awake()
    {
        instance = this;
    }

    public void Show(string content, string header = "")
    {
        tooltip.SetText(content, header);
        tooltip.gameObject.SetActive(true);
    }


    public void Hide()
    {
        tooltip.gameObject.SetActive(false);
    }
}
