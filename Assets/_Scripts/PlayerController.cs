using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // MOVEMENT, INPUT
    [SerializeField] private float speed = 5.0f; 
    private const string Axis_H = "Horizontal", Axis_V = "Vertical";
    
    // ANIMATOR 
    private Animator _animator;


    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        // Space = Velocitiy * Time (S = V * T)
        if(Mathf.Abs(Input.GetAxisRaw(Axis_H)) > 0.2f)
        {
            Vector3 translation = new Vector3(Input.GetAxisRaw(Axis_H) * speed * Time.deltaTime, 0f, 0f);
            transform.Translate(translation);
        }

        if(Mathf.Abs(Input.GetAxisRaw(Axis_V)) > 0.2f)
        {
            Vector3 translation = new Vector3(0f, Input.GetAxisRaw(Axis_V) * speed * Time.deltaTime, 0f);
            transform.Translate(translation);
        }
    }

    void LateUpdate()
    {
        _animator.SetFloat(Axis_H, Input.GetAxisRaw(Axis_H));
        _animator.SetFloat(Axis_V, Input.GetAxisRaw(Axis_V));
    }

}
