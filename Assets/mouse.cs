using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public float power;
    public float rotationSpeed;
    private float temp;
    public GameObject body;
    private bool GetClick;
    private Vector3 tempMouse;
    private static bool once = true;
    public int numberOfBodies;
    private Vector2 tempLocation;
    // Start is called before the first frame update
    void Start()
    {
        GetClick = false;
        temp = power;
        tempMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (once)
        {
            moreBodies();
            once = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
       // print(1 / Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            GetClick = true;
        }
        else { GetClick = false; }

    }
    void FixedUpdate()
    {


        mouseDirection();
        this.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, temp));
        if (GetClick)
        {
            temp = power * 3;

        }
        else
        {
            temp = power;
        }
    }
    void mouseDirection()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = new Vector3
(
    mouse.x - transform.position.x,
    mouse.y - transform.position.y,
    mouse.z = 0
);
        if (mouse != tempMouse)
        {
            tempMouse = mouse;
            direction.x = (mouse.x - transform.position.x);
            direction.y = (mouse.y - transform.position.y);


            //transform.up = direction;

        }

        if (direction != null)
        {
            rotation(direction);
        }
    }

    private void rotation(Vector3 direction)
    {

        // Vector3 newDir = Vector3.RotateTowards(transform.forward, direction, rotationSpeed * Time.deltaTime, 0.0f);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        float tempAngle;
        if (angle < 0) { tempAngle = 360 + angle; }
        else
        {
            tempAngle = angle;
        }
        if ((int)tempAngle != (int)transform.eulerAngles.z)
        {
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);

        }


    }
    void moreBodies()
    {
        GameObject[] bodies = new GameObject[numberOfBodies];
        bodies[0] = body;
        for (int i = 1; i < numberOfBodies; i++)
        {
            bodies[i] = Instantiate(body);
            bodies[i].GetComponent<test>().parent = bodies[i - 1].transform;
            bodies[i].transform.position = new Vector3(0, -10f, i + 5);
            bodies[i].name = i.ToString();


        }



    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
