using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private BoardCreateController createController;

    public void CreateBoard()
    {
        createController.CreateBoardButton();
    }

    private void Awake()
    {
        createController = GetComponent<BoardCreateController>();
    }

    
}
