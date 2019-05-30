using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform parent;
    private Vector2 PreviousLocation;
    private Quaternion PreviousRotation;
    private Vector2 TempLocation;
    private Quaternion TempRotation;
    private float Count;

    // Start is called before the first frame update
    void Start()
    {
        PreviousLocation = transform.position;
        TempLocation = transform.position;
       // PreviousRotation = transform.rotation;
       // TempRotation = transform.rotation;

        Count = 0f;

      //  check = new Vector3(parent.transform.position.x,parent.transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(parent, Vector3.up);
        if (Vector2.Distance(parent.position, PreviousLocation) > 0.2f)
        {
            if (name == "5")
            {
                print(Vector2.Distance(parent.position, PreviousLocation));
            }
            TempLocation = PreviousLocation;
            TempRotation = PreviousRotation;
            transform.position = new Vector3(PreviousLocation.x, PreviousLocation.y, transform.position.z);
            PreviousLocation = parent.position;
            PreviousRotation = parent.rotation;

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
