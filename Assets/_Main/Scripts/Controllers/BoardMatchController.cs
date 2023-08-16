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

    [Inject] private BoardCreateController createController;

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
        visitedCells.Clear();
        currentConnectedCount = 1;
        visitedCells.Add(Grids[x, y]);
        CheckConnectedGrids(x, y);

    }

    private void CheckConnectedGrids(int x, int y)
    {
        if (x - 1 >= 0)
            if (Grids[x - 1, y] != null)
            {
                if (Grids[x - 1, y].IsSelected() && !visitedCells.Contains(Grids[x - 1, y]))
                {

                    visitedCells.Add(Grids[x - 1, y]);
                    currentConnectedCount++;
                    CheckConnectedGrids(x - 1, y);
                }
            }

        if (x + 1 < input)
            if (Grids[x + 1, y] != null)
            {
                if (Grids[x + 1, y].IsSelected() && !visitedCells.Contains(Grids[x + 1, y]))
                {

                    visitedCells.Add(Grids[x + 1, y]);
                    currentConnectedCount++;
                    CheckConnectedGrids(x + 1, y);
                }

            }

        if (y - 1 >= 0)
            if (Grids[x, y - 1] != null)
            {
                if (Grids[x, y - 1].IsSelected() && !visitedCells.Contains(Grids[x, y - 1]))
                {

                    visitedCells.Add(Grids[x, y - 1]);
                    currentConnectedCount++;
                    CheckConnectedGrids(x, y - 1);
                }
            }

        if (y + 1 < input)
            if (Grids[x, y + 1] != null)
            {
                if (Grids[x, y + 1].IsSelected() && !visitedCells.Contains(Grids[x, y + 1]))
                {

                    visitedCells.Add(Grids[x, y + 1]);
                    currentConnectedCount++;
                    CheckConnectedGrids(x, y + 1);
                }
            }

        if (currentConnectedCount >= 3)
        {
            createController.ResetGrids();
        }
    }

}
