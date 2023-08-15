using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private GridClickController clickController;

    private void Awake()
    {
        clickController = GetComponent<GridClickController>();
    }

    private void Start()
    {
        ResetGrid();
    }
    public void ResetGrid()
    {

    }


    public void OnGridSelect()
    {
        clickController.OnGridSelect();
    }

    public bool IsSelected()
    {
        return clickController.IsSelected;
    }

    public void SetScale(float scaleMultiplier)
    {
        transform.localScale = Vector3.one* scaleMultiplier;
    }
}
