using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    float lastFall = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       /* if (!IsValidPiecePosition())
        {
            Debug.Log("GAME OVER");
            Destroy(this.gameObject);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        lastFall += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.LeftArrow)) //Movimiento de la ficha a la izquierda
        {
            MovePieceHorizontally(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))   //Movimiento de la ficha a la derecha
        {
            MovePieceHorizontally(1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) // Rotar la ficha
        {
            this.transform.Rotate(0, 0, -90);
            if (IsValidPiecePosition())
            {
                UpdateGrid();
            }
            else
            {
                this.transform.Rotate(0, 0, 90);
            }
        }  //Mover la ficha hacia abajo || = o
        else if(Input.GetKeyDown(KeyCode.DownArrow)||(Time.time-lastFall)>1.0f)
        {
            this.transform.position += new Vector3(0, -1, 0);

            if (IsValidPiecePosition())
            {
                UpdateGrid();
            }
            else
            {
                this.transform.position += new Vector3(0, 1, 0);
                //Como la pieza no puede bajar m�s, a lo mejor ha llegado el momento de eliminar filas
                GridHelper.DeleteAllFullRows();
                //Hacemos que se spawnee una nueva ficha
                FindObjectOfType<PieceSpawner>().SpawnNextPiece();

                //Deshabilitamos el script para que esta pieza no vuelva a moverse
                this.enabled = false;
            }
            lastFall = Time.time;
       
        }


    }

    void MovePieceHorizontally(int direction)
    {
        //Muevo la pieza horizontalmente
        this.transform.position += new Vector3(direction, 0, 0);

        //Comprobamos si la nueva posici�n es v�lidad
        if (IsValidPiecePosition())
        {
            //Persisto la informaci�n del movimiento en la pantalla del helper
            UpdateGrid();
        }
        else
        {
            //Si la posici�n no es v�lida, revierto el movimiento
            this.transform.position += new Vector3(-direction, 0, 0);
        }
    }

    bool IsValidPiecePosition()
    {
        foreach(Transform block in this.transform)
        {
            //Posici�n de cada uno de los hijos de la pieza
            Vector2 pos = GridHelper.RoundVector(block.position);

            //Si la posici�n est� fuera de los l�mites, entonces no es una posici�n v�lida
            if (!GridHelper.IsInsideBorders(pos))
            {
                return false;
            }

            //Si ya hay otro bloque en esa misma posici�n, tampoco es v�lida
            Transform possibleObject = GridHelper.grid[(int)pos.x, (int)pos.y];
            if(possibleObject != null && possibleObject.parent !=this.transform )
            {
                return false;
            }

        }
        return true;
    }


    void UpdateGrid()
    {
        for (int y = 0; y<GridHelper.height; y++)
        {
            for(int x = 0; x <GridHelper.width; x++)
            {
                if (GridHelper.grid[x, y] != null)
                {
                    //El padre del bloque es la pieza del propio script
                    if(GridHelper.grid[x,y].parent == this.transform)
                    {
                        GridHelper.grid[x, y] = null;
                    }
                }
            }
        }
        foreach(Transform block in this.transform)
        {
            Vector2 pos = GridHelper.RoundVector(block.position);

            GridHelper.grid[(int)pos.x, (int)pos.y] = block;
        }
    }

}
