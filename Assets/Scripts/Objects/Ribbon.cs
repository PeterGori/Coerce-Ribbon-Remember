using System;
using UnityEngine;

public class Ribbon : MonoBehaviour
{
    public BoxCollider2D RibbonCollider;
    public GameObject Player;
    public Transform PickupCheck;
    public LayerMask PlayerLayer;
    public float PickupCheckRadius;
    public bool Contact = false;
    private bool exists = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RibbonCollider = GetComponent<BoxCollider2D>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Contact)
        {
            Player.GetComponent<PlayerController>().HasRibbon = true;
            if (exists)
            { 
                Destroy(gameObject);
                exists = false;
            }
        }
        
        CheckSurroundings();
        
    }

    private void CheckSurroundings()
    {
        Contact = Physics2D.OverlapCircle(PickupCheck.position, PickupCheckRadius, PlayerLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PickupCheck.position,PickupCheckRadius);
    }
}
