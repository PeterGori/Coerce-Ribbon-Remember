using UnityEngine;

public class Button : MonoBehaviour
{
    public Rigidbody2D ButtonRb;
    public Animator ButtonAnim;
    public bool IsPressed = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ButtonRb = GetComponent<Rigidbody2D>();
        ButtonAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
