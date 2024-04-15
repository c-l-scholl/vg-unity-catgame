using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Marker : MonoBehaviour
{
    public Vector2 Position { get => gameObject.transform.position; }
    public List<Marker> adjacentMarkers;
    [SerializeField]
    private bool openForConnections;
    public bool OpenForConnections
    {
        get { return openForConnections; }
       
    }

    public List<Vector2> GetAdjacentPositions() {
        return new List<Vector2>(adjacentMarkers.Select(x => x.Position).ToList());
    }
    
}
