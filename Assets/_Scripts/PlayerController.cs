using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // MOVEMENT, INPUT
    [SerializeField] private float speed = 5.0f; 
    private const string Axis_H = "Horizontal", Axis_V = "Vertical";
    public Vector2 lastMovement = Vector2.zero;
    
    // ANIMATOR 
    private Animator _animator;
    private bool isWalking = false;
    private const string Walking = "Is Walking";
    private const string LastHorizontal = "Last Horizontal", LastVertical = "Last Vertical";


    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        isWalking = false; 

        // Space = Velocitiy * Time (S = V * T)
        if(Mathf.Abs(Input.GetAxisRaw(Axis_H)) > 0.2f)
        {
            Vector3 translation = new Vector3(Input.GetAxisRaw(Axis_H) * speed * Time.deltaTime, 0f, 0f);
            transform.Translate(translation);

            isWalking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(Axis_H), 0f);
        }

        if(Mathf.Abs(Input.GetAxisRaw(Axis_V)) > 0.2f)
        {
            Vector3 translation = new Vector3(0f, Input.GetAxisRaw(Axis_V) * speed * Time.deltaTime, 0f);
            transform.Translate(translation);

            isWalking = true;
            lastMovement = new Vector2(0f, Input.GetAxisRaw(Axis_V));
        }
    }

    void LateUpdate()
    {
        _animator.SetFloat(Axis_H, Input.GetAxisRaw(Axis_H));
        _animator.SetFloat(Axis_V, Input.GetAxisRaw(Axis_V));

        _animator.SetBool(Walking, isWalking);
        _animator.SetFloat(LastHorizontal, lastMovement.x);
        _animator.SetFloat(LastVertical, lastMovement.y);
    }

}
