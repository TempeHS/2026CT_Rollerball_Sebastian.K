using UnityEngine;
using UnityEngine.SceneManagement;
public class cameracontroller : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.R))
             {
                 Resetbutton();
             }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; 
    }

    public void Resetbutton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
