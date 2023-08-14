using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpriteController : MonoBehaviour
{
    public GameObject selectedParent;

    public void OpenSelectedImage()
    {
        selectedParent.SetActive(true);
    }

    public void CloseSelectedImage()
    {
        selectedParent.SetActive(false);
    }
}
