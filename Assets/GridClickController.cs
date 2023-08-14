using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridClickController : MonoBehaviour
{


    public bool IsSelected { get; private set; }

    public void ResetGrid()
    {
        IsSelected = false;
    }

    public void OnGridSelect()
    {
        IsSelected = !IsSelected;
        if(IsSelected)
        {
            GetComponent<GridSpriteController>().OpenSelectedImage();
        }
        else
        {
            GetComponent<GridSpriteController>().OpenSelectedImage();
        }
    }
}
