using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private GridClickController clickController;
    private GridSpriteController spriteController;


    public void OnGridSelect()
    {
        clickController.OnGridSelect();
    }

    public bool IsSelected()
    {
        return clickController.IsSelected;
    }
}
