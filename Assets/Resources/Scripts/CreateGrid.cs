using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : Singleton<CreateGrid>
{
    public GameObject topLeft, topRight, bottomLeft, bottomRight;//only needs three
    public int row, column;
    [SerializeField]   private float xDelta, yDelta, slope, b;
    public Vector2 cellSize;
    public Vector2 [,] gridArray;
    public GameObject temp;
    public Dictionary<Vector2,string> mapAsNodes;
    // Start is called before the first frame update
    void Start()
    {
        mapAsNodes = new Dictionary<Vector2, string>();
        gridArray = new Vector2[row,column];
        xDelta = ((bottomRight.transform.position.x-bottomLeft.transform.position.x));
        yDelta = ((bottomLeft.transform.position.y-topRight.transform.position.y));
        slope = (bottomRight.transform.position.y-bottomLeft.transform.position.y)/(bottomRight.transform.position.x-bottomLeft.transform.position.x);
       b = bottomLeft.transform.position.y -(slope*bottomLeft.transform.position.x);
        cellSize = column ==0 || row == 0? Vector2.zero:new Vector2(xDelta/row, yDelta/column); 

        float leftSlope = (topLeft.transform.position.y-bottomLeft.transform.position.y)/(topLeft.transform.position.x-bottomLeft.transform.position.x);
        float leftB = topLeft.transform.position.y -(leftSlope*topLeft.transform.position.x);
       /**/ for(int i =0; i< row; i++){
            for(int j=0; j<column; j++){
                Vector2 next = new Vector2(cellSize.x*(j),((cellSize.x*(j)*slope)+b) )+
                new Vector2(topLeft.transform.position.x-cellSize.x, -bottomLeft.transform.position.y+cellSize.y*i);
                Debug.Log(isLeft(topLeft.transform.position,bottomRight.transform.position, next )+$"{next}");
                if ( isLeft(topLeft.transform.position,bottomRight.transform.position, next ) || !isLeft(topLeft.transform.position,bottomRight.transform.position, next ) && next.y > next.x*leftSlope+leftB ){


                    gridArray[j,i]= next;//Used to get furtherest x starting point, lowest y starting point
                     Instantiate(temp, gridArray[j,i],Quaternion.identity);//may use to 'flash' map
                }
                        
    
                //SHOW GRID
               
                Debug.Log(gridArray[j,i]);
            }
            
        }

         for(int i =0; i< row; i++){
            for(int j=0; j<column; j++){
               Vector2 next =new Vector2(cellSize.x*(j),((cellSize.x*(j)*slope)-b) )+
                new Vector2(bottomLeft.transform.position.x-cellSize.x, topRight.transform.position.y+cellSize.y*i); //Used to get furtherest x starting point, lowest y starting point        

                if ( !isLeft(topRight.transform.position,bottomRight.transform.position, next ) ){


                    gridArray[j,i]= next;//Used to get furtherest x starting point, lowest y starting point
                     Instantiate(temp, gridArray[j,i],Quaternion.identity);//may use to 'flash' map
                }
                
                //SHOW GRID
                //Instantiate(temp, gridArray[j,i],Quaternion.identity);
                Debug.Log(gridArray[j,i]);
            }
            
        }
          leftSlope = (bottomRight.transform.position.y-bottomLeft.transform.position.y)/(bottomRight.transform.position.x-bottomLeft.transform.position.x);
         leftB = bottomLeft.transform.position.y -(leftSlope*bottomLeft.transform.position.x);
       for(int i =0; i< row; i++){
            for(int j=0; j<column; j++){
                Vector2 next =new Vector2(cellSize.x*(j),((cellSize.x*(j)*slope)+b) )+
                new Vector2(bottomLeft.transform.position.x-cellSize.x, topRight.transform.position.y+cellSize.y*i); //Used to get furtherest x starting point, lowest y starting point        
             if ( !isLeft(topRight.transform.position,bottomRight.transform.position, next ) &&   next.y > next.x*leftSlope+leftB ){


                    gridArray[j,i]= next;//Used to get furtherest x starting point, lowest y starting point
                     Instantiate(temp, gridArray[j,i],Quaternion.identity);//may use to 'flash' map
                }
                
                //SHOW GRID
                Instantiate(temp, gridArray[j,i],Quaternion.identity);
                Debug.Log(gridArray[j,i]);
            }
            
        } /* */
        
    }
public bool isLeft(Vector2 a, Vector2 b, Vector2 c) {
  return (b.x - a.x)*(c.y - a.y) - (b.y - a.y)*(c.x - a.x) >0;
}

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mapAsNodes.Count);
     cellSize = column ==0 || row == 0? Vector2.zero:new Vector2(xDelta/row, yDelta/column);   
    }
}
