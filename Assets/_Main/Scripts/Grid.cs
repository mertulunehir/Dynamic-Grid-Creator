using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
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
        GetComponent<GridClickController>().ResetGrid();
    }
    public void SetGridPosition(int x, int y)
    {
        GetComponent<GridClickController>().SetGridPlace(x, y);
    }

    public void OnGridSelect()
    {
        if (clickController.CanClickGrid)
            clickController.OnGridSelect();
    }

    public bool IsSelected()
    {
        return clickController.IsSelected;
    }

    public void SetScale(float scaleMultiplier)
    {
        transform.localScale = Vector3.one * scaleMultiplier;
    }
}
