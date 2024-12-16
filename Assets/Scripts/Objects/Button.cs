using UnityEngine;

public class Button : MonoBehaviour
{
    public Rigidbody2D ButtonRb;
    public Animator ButtonAnim;
    public Transform PressCheck;
    public LayerMask PressLayers;
    public BoxCollider2D ButtonCollider;
    public Vector2 PressCheckRadius;

    public bool IsPressed = false;
    public bool Active = false;
    private float time = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ButtonRb = GetComponent<Rigidbody2D>();
        ButtonAnim = GetComponent<Animator>();
        ButtonCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPressed)
        {
            ButtonAnim.SetBool("Pressed", true);
            ButtonCollider.size = new Vector2(1f,0.25f);
            time = 0.25f;
            Active = true;
        }
        else
        {
            time -= Time.deltaTime;
            if (time < 0f)
            {
                ButtonAnim.SetBool("Pressed", false);
                ButtonCollider.size = new Vector2(1f,1f);
                Active = false;
            }
        }
        CheckSurroundings();
    }
    
    private void CheckSurroundings()
    {
        IsPressed = Physics2D.OverlapBox(PressCheck.position, PressCheckRadius, 0, PressLayers);
    }
    
}
