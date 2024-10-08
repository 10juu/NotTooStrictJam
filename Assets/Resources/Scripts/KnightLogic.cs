using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightLogic : MonoBehaviour
{
    [SerializeField]MoveToPlayer moveToPlayer;
    [SerializeField]float range;
    float theta = 0;

    // Start is called before the first frame update
    void Start()
    {
        moveToPlayer = GetComponent<MoveToPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
         Vector2 direction = new Vector2(Mathf.Cos((theta)), Mathf.Sin(theta));//once found player lock
        theta += Time.deltaTime*10;

         RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, (Vector2)direction, range,LayerMask.GetMask("Tower"));

        if (hit.collider != null && moveToPlayer.target == null){
            Debug.Log("Come here!");
            moveToPlayer.target = hit.collider.gameObject;
        }


        Ray ray = Camera.main.ViewportPointToRay(new Vector3(1f,1f, 0f)*.5f);
        if (Physics.Raycast(ray, out RaycastHit hits, 2))
        {
            
            if(hits.collider.gameObject.TryGetComponent(out IDamage damaged)){
                Debug.Log("Authentic Battle!");
            }
        }

    }
}
