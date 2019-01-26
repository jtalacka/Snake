using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public GameObject head;
    public GameObject body;
    private float IndividualSpeed;
    private static int count=0;
    private static float speed = 0.9f;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        speed += 0.1f;
        IndividualSpeed = speed;

        // 4 -4
        //-7 7
        Vector2 position = new Vector2(Random.Range(-5.5f, 5.5f), Random.Range(-3, 3));

        transform.position = position;
        GetComponent<Rigidbody2D>().velocity = new Vector3(1,1,0)*speed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Body")
        {

            print("triggered");
        }

        if (collision.transform.name=="Left"|| collision.transform.name == "Right")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);

        }
        else if(collision.transform.name == "Up" || collision.transform.name == "Down")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -GetComponent<Rigidbody2D>().velocity.y);
        }

        if (collision.transform.name == "Player")
        {
            GameObject gm;

            count++;
            score.text = count.ToString();

            gm = Instantiate(body);

            gm.GetComponent<test>().parent = GameObject.Find((head.GetComponent<mouse>().numberOfBodies - 1).ToString()).transform;

            gm.transform.position = new Vector3(gm.GetComponent<test>().parent.transform.position.x, gm.GetComponent<test>().parent.transform.position.y, head.GetComponent<mouse>().numberOfBodies + 5);

            head.GetComponent<mouse>().numberOfBodies++;
            gm.name = (head.GetComponent<mouse>().numberOfBodies - 1).ToString();
            Instantiate(this);
            Destroy(this.gameObject);


        }


    }
}

