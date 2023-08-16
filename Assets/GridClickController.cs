using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GridClickController : MonoBehaviour
{
    public int X,Y;

    public bool IsSelected { get; private set; }
    public bool CanClickGrid { get => canClickGrid; }

    private GridSpriteController spriteController;
    private bool canClickGrid;


    private void Awake()
    {
        canClickGrid = true;
        spriteController = GetComponent<GridSpriteController>();
    }
    public void ResetGrid()
    {
        canClickGrid = false;
        IsSelected = false;
        spriteController.CloseSelectedImage();

        Invoke("EnableClick", 0.5f);
    }

    private void EnableClick()
    {
        canClickGrid = true;
    }

    public void SetGridPlace(int x,int y)
    {
        X = x;
        Y = y;
    }

    public void OnGridSelect()
    {
        if(canClickGrid)
        {
            IsSelected = !IsSelected;
            if (IsSelected)
            {
                BoardMatchController.Instance.CheckForMatch(X, Y);
                spriteController.OpenSelectedImage();
            }
            else
            {
                spriteController.CloseSelectedImage();
            }
        }
        
    }
}
