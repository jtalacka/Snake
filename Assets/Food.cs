using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject head;
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        // 4 -4
        //-7 7
        Vector2 position = new Vector2(Random.Range(-6.5f, 6.5f), Random.Range(-4, 4));
        transform.position = position;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.name);

        if (collision.name == "Player")
        {
            GameObject gm;

            gm = Instantiate(body);

            gm.GetComponent<test>().parent = GameObject.Find((head.GetComponent<mouse>().numberOfBodies-1).ToString());

            gm.transform.position = new Vector3(gm.GetComponent<test>().parent.transform.position.x, gm.GetComponent<test>().parent.transform.position.y, 10);

            head.GetComponent<mouse>().numberOfBodies++;
            gm.name = (head.GetComponent<mouse>().numberOfBodies-1).ToString();
            Instantiate(this);
            Destroy(this.gameObject);


        }
    }
}
