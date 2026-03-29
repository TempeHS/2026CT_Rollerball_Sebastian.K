using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
public class playercontroller : MonoBehaviour
{
    public float speed = 0; 
    public TextMeshProUGUI countText;
    public GameObject winTextObject;    
    //public playerposition;
    public GameObject Enemy;
    public int count;
    private Rigidbody rb; 
    private float movementX;
    private float movementY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Resetbutton();
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    void SetCountText()
    {
        countText.text =  "Count: " + count.ToString();

        if(count >= 30)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    void FixedUpdate() 
   {
    Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
    rb.AddForce(movement * speed);
   }

   private void OnCollisionEnter(Collision collision)
{
   if (collision.gameObject.CompareTag("Enemy"))
   {
       Destroy(gameObject);
       winTextObject.gameObject.SetActive(true);
       winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
    StartCoroutine(DelayedAction());
       Resetbutton();
   }
}

   public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
       
    }
    public void Resetbutton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

       IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(3f);
    }
}