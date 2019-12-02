using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark3DObjectOnUI : MonoBehaviour
{
    /// <summary>
    /// this is your object that you want to have the UI element hovering over
    /// </summary>
    [SerializeField]
    private Transform targetTransform = null;
    /// <summary>
    /// this is the ui element
    /// </summary>
    [SerializeField]
    private RectTransform iconRect = null;

    [SerializeField]
    private RectTransform rootCanvasRect = null;
    [SerializeField]
    private Camera mainCamera = null;

    private Vector3 viewportPoint;
    private float ScreenWidth = 1920f, ScreenHeight = 1080f;

    private void Awake()
    {
        ScreenWidth = rootCanvasRect.rect.width;
        ScreenHeight = rootCanvasRect.rect.height;
    }

    void Update()
    {
        viewportPoint = mainCamera.WorldToViewportPoint(targetTransform.position);

        if (IsOnScreen(viewportPoint) && viewportPoint.z >= 0f)
        {
            iconRect.anchoredPosition = Vector2.up * viewportPoint.y * rootCanvasRect.rect.height + Vector2.right * viewportPoint.x * rootCanvasRect.rect.width;
        }
    }

    private bool IsOnScreen(Vector3 vp)
    {
        return vp.x >= 0f && vp.x <= 1f && vp.y >= 0f && vp.y <= 1f;
    }

}
