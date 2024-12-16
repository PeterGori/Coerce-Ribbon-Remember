using UnityEngine;

public class Door : MonoBehaviour
{
    public BoxCollider2D DoorCollider;
    public Animator DoorAnim;
    public GameObject Button;
    public bool IsOpen = false;
    private float StartY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DoorCollider = GetComponent<BoxCollider2D>();
        DoorAnim = GetComponent<Animator>();
        Button = GameObject.Find("Button");
        StartY = DoorCollider.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOpen)
        {
            DoorAnim.SetBool("Open", true);
            DoorCollider.enabled = false;
            // DoorCollider.size = new Vector2(1f,0f);
            // DoorCollider.transform.position = new Vector2(DoorCollider.transform.position.x, StartY + 2f);
        }
        else
        {
            DoorAnim.SetBool("Open", false);
            DoorCollider.enabled = true;
            // DoorCollider.size = new Vector2(1f,1f);
            // DoorCollider.transform.position = new Vector2(DoorCollider.transform.position.x, StartY);
        }
        CheckButton();
    }
    
    private void CheckButton()
    {
        IsOpen = Button.GetComponent<Button>().Active;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, DoorCollider.size);
    }
}
