using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    private int count;
    private int leben;
    public Text countText;
    public Text winText;
    public Text lifeText;
    private Rigidbody2D rb2d;
    private GameObject[] enemies;
    private GameObject[] enemies2;
    private float aktzeit = 5.0f;
    private GameObject bg;
    public static int level;
    public Transform prefab;
    public Transform lifeee;
    private bool enemy1 = true;
    private bool enemy2 = true;
    private bool enemy3 = true;
    private bool enemy4 = true;
    private bool enemy5 = true;
    private bool ende = false;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        leben = 3;
        level = 1;
        SetLifeText();
        winText.text = "Level 1";
        SetCountText();
        enemies = GameObject.FindGameObjectsWithTag("Pickup");
        enemies2 = GameObject.FindGameObjectsWithTag("Square");
        bg = GameObject.FindGameObjectWithTag("Background");

    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name );
        }
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    count = 73;
        //}
        if (Time.time > aktzeit)
        {
            winText.text = "";
        }

        if (Time.time > aktzeit && ende)
        {
            SceneManager.LoadScene(0);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            if (level == 1)
            {
                other.gameObject.transform.position = new Vector2(Random.Range(-12.50f, 12.50f), Random.Range(-12.50f, 12.50f));
            }
            else if (level == 2)
            {
                other.gameObject.transform.position = new Vector2(Random.Range(-25.00f, 25.00f), Random.Range(-25.00f, 25.00f));
            }
            else if (level == 3)
            {
                other.gameObject.transform.position = new Vector2(Random.Range(-37.50f, 37.50f), Random.Range(-37.50f, 37.50f));
            }
            else if (level == 4)
            {
                other.gameObject.transform.position = new Vector2(Random.Range(-50.00f, 50.00f), Random.Range(-50.00f, 50.00f));
            }
            else if (level == 5)
            {
                other.gameObject.transform.position = new Vector2(Random.Range(-62.50f, 62.50f), Random.Range(-62.50f, 62.50f));
            }
            else if (level == 6)
            {
                other.gameObject.transform.position = new Vector2(Random.Range(-125.00f, 125.00f), Random.Range(-125.00f, 125.00f));
            }
            count++;
            SetCountText();


        }

        if (other.gameObject.CompareTag("Square"))
        {
            leben--;
            SetLifeText();
            other.gameObject.transform.position = new Vector2(Random.Range(-12.00f, -11.00f), Random.Range(-12.00f, -11.00f));

        }
        if (other.gameObject.CompareTag("Leben+"))
        {
            leben++;
            SetLifeText();
            other.gameObject.transform.position = new Vector2(Random.Range(-12.00f, -11.00f), Random.Range(-12.00f, -11.00f));

        }

    }

    void SetLifeText()
    {
        lifeText.text = "Verbleibende Leben: " + leben.ToString();

        if (leben == 0)
        {
            aktzeit = Time.time + 5.0f;
            winText.text = "You lose!";
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].SetActive(false);
            }
            enemies2 = GameObject.FindGameObjectsWithTag("Square");
            for (int i = 0; i < enemies2.Length; i++)
            {
                enemies2[i].SetActive(false);
            }
                ende = true;
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count == 10)
        {
            if (enemy1)
            {
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(lifeee, new Vector3(45, 0, 0), Quaternion.identity);
                enemy1 = false;
            }
            level = 2;
            aktzeit = Time.time + 4.0f;
            winText.text = "Level 2";
            speed = 20;
            bg.transform.localScale = new Vector2(2.0F, 2.0F);
            transform.localScale = new Vector2(0.75F, 0.75F);
        }

        if (count ==20)
        {
            if (enemy2)
            {
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                enemy2 = false;
            }
            level = 3;
            aktzeit = Time.time + 4.0f;
            winText.text = "Level 3";
            speed = 30;
            bg.transform.localScale = new Vector2(3.0F, 3.0F);
        }

        if (count == 30)
        {
            if (enemy3)
            {
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                enemy3 = false;
            }
            level = 4;
            aktzeit = Time.time + 4.0f;
            winText.text = "Level 4";
            speed = 50;
            bg.transform.localScale = new Vector2(4.0F, 4.0F);
        }

        if (count == 40)
        {
            if (enemy4)
            {
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                enemy4 = false;
            }
            level = 5;
            aktzeit = Time.time + 4.0f;
            winText.text = "Level 5";
            speed = 70;
            bg.transform.localScale = new Vector2(5.0F, 5.0F);
        }

        if (count == 50)
        {
            if (enemy5)
            {
                for (int i = 0; i<50;i++)
                {
                    Instantiate(prefab, new Vector3(45, 0, 0), Quaternion.identity);
                }
                enemy5 = false;
                Instantiate(lifeee, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(lifeee, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(lifeee, new Vector3(45, 0, 0), Quaternion.identity);
                Instantiate(lifeee, new Vector3(45, 0, 0), Quaternion.identity);
            }
            level = 6;
            aktzeit = Time.time + 7.0f;
            winText.text = "Level X";
            speed = 100;
            bg.transform.localScale = new Vector2(10.0F, 10.0F);
        }


        if (count >= 75)
        {
            aktzeit = Time.time + 5.0f;
            ende = true;
            winText.text = "You win!";
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].SetActive(false);
            }
            enemies2 = GameObject.FindGameObjectsWithTag("Square");
            for (int i = 0; i < enemies2.Length; i++)
            {
                enemies2[i].SetActive(false);
            }
        }
    }
}
