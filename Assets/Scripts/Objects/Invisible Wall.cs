using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    public bool IsThere;

    public BoxCollider2D WallCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WallCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
