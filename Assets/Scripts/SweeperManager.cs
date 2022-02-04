using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweeperManager
{
    private Vector2Int size;
    private int nbMines;
    private List<Vector2Int> emplacementsMines;
    SweeperGenerator sweeperGenerator=null;
    public GameObject[,] squareObjectCollection {get; set;}

    public SweeperManager(Vector2Int size, int nbMines)
    {
        this.size = size;
        this.nbMines = nbMines;
    }
    public void Activate(Vector2Int coords)
    {
        if (sweeperGenerator==null)
        {
            sweeperGenerator=new SweeperGenerator(size,nbMines);
            emplacementsMines=sweeperGenerator.Generate(coords);
            Debug.Log("Generation de ce genre de grid mon gars");
        }
        if (emplacementsMines.Contains(coords))
        {
            Debug.Log("! Mine trouvée !");
        }
        Material reaveled = squareObjectCollection[coords.x,coords.y].GetComponentInChildren<RayRecever>().reaveled;
        squareObjectCollection[coords.x,coords.y].GetComponentInChildren<Renderer>().material = reaveled;
    }
}
