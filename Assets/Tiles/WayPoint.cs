using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    [SerializeField] bool isPlaceable;
    [SerializeField] Tower _towerPrefab;
    public bool IsPlaceable { get { return isPlaceable; } }
    
    private void OnMouseDown() 
    {
        if(isPlaceable)
        {
            bool isPlaced = _towerPrefab.CreateTower(_towerPrefab, transform.position);
            //Instantiate(_towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = !isPlaced;
        }
    }

}

