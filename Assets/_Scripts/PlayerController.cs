using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; 

    void Start()
    {
        
    }

    
    void Update()
    {
        // Space = Velocitiy * Time (S = V * T)
        if(Input.GetAxisRaw("Horizontal") > 0.2f)
        {
            Vector3 translation = new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f);
        }
    }

}
