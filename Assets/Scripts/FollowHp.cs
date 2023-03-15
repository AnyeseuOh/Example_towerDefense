using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowHp : MonoBehaviour
{
    public Transform target;
    public RectTransform canvas;
    public RectTransform hpBar;
    
    void Update()
    {
        Vector3 curPos = target.transform.position;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(curPos); //3D월드의 값을 2D 좌표로 변경
        Vector2 canvasPos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, screenPoint, Camera.main, out canvasPos);

        hpBar.localPosition = canvasPos;
    }
}
