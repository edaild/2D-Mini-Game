using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float player_spped;
    [SerializeField] private float player_jumpForce;
    [SerializeField] private float player_jumpForce02;
    [SerializeField] private float delay;
    [SerializeField] private Rigidbody2D player_Rigidbody;
    [SerializeField] private Animator player_animator;

    private Collider2D player_collider;

    private bool isJump;


    private void Start()
    {
       player_Rigidbody = GetComponent<Rigidbody2D>();
       player_collider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

   void Move()
    {
        float hInput = Input.GetAxis("Horizontal");
        Vector3 Derection = new Vector3(hInput, 0, 0).normalized;
        Vector3 move = Derection * player_spped * Time.deltaTime;
        transform.position += move;

        bool isMove = Derection != Vector3.zero;
    }

    void Jump()
    {
        if (!isJump && (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftAlt))))
        {
            StartCoroutine(JumpStart());
        }
        if (!isJump &&(Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.LeftAlt))))
        {
            player_Rigidbody.AddForce(Vector2.up * player_jumpForce02, ForceMode2D.Impulse);
            StartCoroutine(JumpStart());
        }
        if (!isJump && Input.GetKey(KeyCode.LeftAlt))
        {
            player_Rigidbody.AddForce(Vector2.up * player_jumpForce, ForceMode2D.Impulse);
            StartCoroutine(JumpStart());
        }
     
    }

    IEnumerator JumpStart()
    {
        isJump = true;
        player_collider.enabled = false;
        yield return new WaitForSeconds(delay);
        player_collider.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
            Debug.Log("플레이어 찾지");
        }
    }
}
