using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField]
    private Text headerField;

    [SerializeField]
    private Text contentField;

    [SerializeField]
    private LayoutElement layoutElement;

    [SerializeField]
    private int maxChar;

    [SerializeField]
    private RectTransform RectTransform;


    public void SetText(string content, string header = "")
    {
        if (header == "")
        { 
            headerField.gameObject.SetActive(false);
        }
        else {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }

        contentField.text = content;



        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > maxChar || contentLength > maxChar) ? true : false;
    }

    private void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        float pivotX = mousePosition.x / Screen.width;
        float pivotY = mousePosition.y / Screen.height;

        RectTransform.pivot = new Vector2(pivotX, pivotY);

        transform.position = mousePosition;
    }
}