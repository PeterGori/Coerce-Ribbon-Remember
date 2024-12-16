using System.Collections;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    public GameObject TalkWall;
    public GameObject Player;
    public Transform TalkWallCheck;
    public Vector2 TalkWallRadius;
    public LayerMask PlayerLayer;
    public GameObject TextBlock1;
    public GameObject TextBlock2;
    
    private bool ShouldTalk = false;
    private float time = 0;
    private bool Active = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TalkWall = GameObject.Find("NPC Talk Wall");
        Player = GameObject.Find("Player");
        TextBlock1 = GameObject.Find("Text Block 1");
        TextBlock2 = GameObject.Find("Text Block 2");
        TextBlock1.GetComponent<SpriteRenderer>().enabled = false;
        TextBlock2.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckSurroundings();

        if (ShouldTalk && !Active) StartCoroutine(Talk());
    }

    IEnumerator Talk()
    {
        // Sets Active
        Active = true;
        
        // Shows Text Block 1
        TextBlock1.GetComponent<SpriteRenderer>().enabled = true;
        
        // Waits for 5 Seconds
        yield return new WaitForSeconds(5);
        
        // Hides Text Block 1
        TextBlock1.GetComponent<SpriteRenderer>().enabled = false;
        
        // Shows Text Block 2
        TextBlock2.GetComponent<SpriteRenderer>().enabled = true;
        
        // Waits for 5 Seconds
        yield return new WaitForSeconds(5);
        
        // Hides Text Block 2
        TextBlock2.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void CheckSurroundings()
    {
        ShouldTalk = Physics2D.OverlapBox(TalkWallCheck.position, TalkWallRadius, 0, PlayerLayer);
    }


}
