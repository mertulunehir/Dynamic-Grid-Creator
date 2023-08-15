using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridClickController : MonoBehaviour
{


    public bool IsSelected { get; private set; }

    private GridSpriteController spriteController;

    private void Awake()
    {
        spriteController = GetComponent<GridSpriteController>();
    }
    public void ResetGrid()
    {
        IsSelected = false;
    }

    public void OnGridSelect()
    {
        IsSelected = !IsSelected;
        if(IsSelected)
        {
            spriteController.OpenSelectedImage();
        }
        else
        {
            spriteController.CloseSelectedImage();
        }
    }
}
