using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public GameObject[] _activeOnGameStartObjects;

    public void StartGame()
    {
        for (int i = 0; i < _activeOnGameStartObjects.Length; i++)
        {
            _activeOnGameStartObjects[i].SetActive(true);
        }
    }
}
