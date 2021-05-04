using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeRandomPoint : MonoBehaviour
{
    private float aktzeit = 5.0f;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > aktzeit)
        {
            aktzeit = Time.time + 4.0f;
            if (PlayerController.level == 1)
            {
                transform.position = new Vector2(Random.Range(-12.00f, 12.00f), Random.Range(-12.00f, 12.00f));

            }
            else if (PlayerController.level == 2)
            {
                transform.position = new Vector2(Random.Range(-24.00f, 24.00f), Random.Range(-24.00f, 24.00f));

            }
            else if (PlayerController.level == 3)
            {
                transform.position = new Vector2(Random.Range(-36.00f, 36.00f), Random.Range(-36.00f, 36.00f));
            }
            else if (PlayerController.level == 4)
            {
                transform.position = new Vector2(Random.Range(-48.00f, 48.00f), Random.Range(-48.00f, 48.00f));
            }
            else if (PlayerController.level == 5)
            {
                transform.position = new Vector2(Random.Range(-60.00f, 60.00f), Random.Range(-60.00f, 60.00f));
            }
            else if (PlayerController.level == 6)
            {
                transform.position = new Vector2(Random.Range(-120.00f, 120.00f), Random.Range(-120.00f, 120.00f));
            }

        }

    }
}