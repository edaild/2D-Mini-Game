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
    public Transform player_point;


    private Collider2D player_collider;

    private bool isJump;

    private GameManager gameManager;


    private void Start()
    {
       gameManager = FindAnyObjectByType<GameManager>();
       player_Rigidbody = GetComponent<Rigidbody2D>();
       player_collider = GetComponent<Collider2D>();

        transform.position = player_point.position;
    }
    private void Update()
    {
        if (!gameManager.isUICanvers ||!gameManager.isFnishUICanvers)
            Jump();
    }

    private void FixedUpdate()
    {
        if (!gameManager.isUICanvers)
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
        // ���� ã�� ������
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
            Debug.Log("�÷��̾� ã��");
        }

        // ���� �浹������
        if (collision.gameObject.CompareTag("Castle"))
        {
            gameManager.CollisionCastle();
        }


        // �ʵ� ������ �߶� �� ó��
        if (collision.gameObject.CompareTag("ExitFildGround"))
            transform.position = player_point.position;
    }
}
