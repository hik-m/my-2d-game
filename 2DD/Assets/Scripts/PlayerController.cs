using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    CharacterMove CharacterMove;
    PlayerAttack PlayerAttack;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAttack = GetComponent<PlayerAttack>();
        CharacterMove = GetComponent<CharacterMove>();
        CharacterMove.Fall();
    }

    // Update is called once per frame
    void Update()
    {
        if  (!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.S))
        {
            CharacterMove.IDLSet();
        }

        if (Input.GetKey(KeyCode.D))
        {
           
            CharacterMove.RightMove();
            
        }

        if (Input.GetKey(KeyCode.A))
        {
           
            CharacterMove.LeftMove();
           
        }

        CharacterMove.Fall();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAttack.Attack();
        }

        if ( Input.GetKeyDown(KeyCode.Space))
        {
            CharacterMove.Jump();
           
        }

        

       
    }
}
