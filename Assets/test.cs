using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject parent;
    public Vector2 PreviousLocation;
    private float Count;

    // Start is called before the first frame update
    void Start()
    {
        PreviousLocation = new Vector2(transform.position.x, transform.position.y);
        Count = 0f;

      //  check = new Vector3(parent.transform.position.x,parent.transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Count += Time.deltaTime;
        {
            Count = 0;



            
            if (Vector2.Distance(parent.transform.position, transform.position) > 0.2f)
            {
                // print(Vector2.Distance(parent.transform.position, transform.position));
                PreviousLocation.x = transform.position.x;
                PreviousLocation.y = transform.position.y;

                if (this.gameObject.name == "body")
                {

               //     if ()
                    {
                        transform.position = (parent.GetComponent<mouse>().PreviousLocation);
                    }
                }
                else
                {
              //      if ()
                    {
                        transform.position = parent.GetComponent<test>().PreviousLocation;
                    }
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print(gameObject.name);
        int i;
        int.TryParse(gameObject.name,out i);
        if (collision.name == "Player" && i > 10)
        {
          //  print("End of Game");
        }
    }

}
