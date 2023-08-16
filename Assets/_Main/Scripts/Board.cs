using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private BoardCreateController createController;



    private void Awake()
    {
        createController = GetComponent<BoardCreateController>();
    }

    //button event
    public void CreateBoard()
    {
        createController.CreateBoardButton();
    }
    
}
