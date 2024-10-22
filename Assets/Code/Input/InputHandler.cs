using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private int tmpBrushSize;

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity);

            if (hit.collider != null)
            {
                DrawingBoard board = hit.collider.gameObject.GetComponent<DrawingBoard>();
                if (board != null)
                {
                    //board.SetPixel(10, 10);
                    Vector3 localPosition = transform.InverseTransformPoint(mousePosition);
                    //board.SetPixel(localPosition);
                    board.SetPixel(localPosition, tmpBrushSize);
                }
            }
        }
    }
}
