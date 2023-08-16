using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BoardMatchController : MonoBehaviour
{

    private Grid[,] Grids;

    private List<Grid> visitedCells = new List<Grid>();
    private int currentConnectedCount;
    private int input;

    [Inject]private BoardCreateController createController;

    public void SetInputValue(int input)
    {
        this.input = input;
        Grids = new Grid[input, input];
    }



    public void AddGrid(int x, int y, Grid grid)
    {
        Grids[x, y] = grid;
    }

    public void CheckForMatch(int x, int y)
    {
        //TODO : komşuları bul
        visitedCells.Clear();
        currentConnectedCount = 1;
        visitedCells.Add(Grids[x, y]);
        AddConnectedGrids(x, y);

    }

    private void AddConnectedGrids(int x, int y)
    {
        if (x - 1 >= 0)
            if (Grids[x - 1, y] != null)
            {
                Debug.Log("1");

                if (Grids[x - 1, y].IsSelected() && !visitedCells.Contains(Grids[x - 1, y]))
                {
                    Debug.Log("2");

                    visitedCells.Add(Grids[x - 1, y]);
                    currentConnectedCount++;
                    AddConnectedGrids(x - 1, y);
                }
            }

        if (x + 1 < input)
            if (Grids[x + 1, y] != null)
            {
                Debug.Log("3");

                if (Grids[x + 1, y].IsSelected() && !visitedCells.Contains(Grids[x + 1, y]))
                {
                    Debug.Log("4");

                    visitedCells.Add(Grids[x + 1, y]);
                    currentConnectedCount++;
                    AddConnectedGrids(x + 1, y);
                }

            }

        if (y - 1 >= 0)
            if (Grids[x, y - 1] != null)
            {
                Debug.Log("5");

                if (Grids[x, y - 1].IsSelected() && !visitedCells.Contains(Grids[x, y - 1]))
                {
                    Debug.Log("6");

                    visitedCells.Add(Grids[x, y - 1]);
                    currentConnectedCount++;
                    AddConnectedGrids(x, y - 1);
                }
            }

        if (y + 1 <input)
            if (Grids[x, y + 1] != null)
            {
                Debug.Log("7");

                if (Grids[x, y + 1].IsSelected() && !visitedCells.Contains(Grids[x, y + 1]))
                {
                    Debug.Log("8");

                    visitedCells.Add(Grids[x, y + 1]);
                    currentConnectedCount++;
                    AddConnectedGrids(x, y + 1);
                }
            }

        if (currentConnectedCount >= 3)
        {
            createController.ResetGrids();
        }
    }

}
