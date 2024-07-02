using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurserManager : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        Cursor.visible = false;
        if (Application.isPlaying)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void Update()
    {
        Vector2 cursorPosition = Input.mousePosition; 
        image.rectTransform.position = cursorPosition;

        if (Application.isPlaying) { return; }

        Cursor.visible = false;
    }
}
