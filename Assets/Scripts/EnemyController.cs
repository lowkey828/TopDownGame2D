using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] diemDiChuyen;
    public float tocDoDiChuyen = 3f;
    public float tocDoDiChuyenNhanh = 5f;
    public float khoangCachTanCong = 10f;
    public float khoangCachTieuDiet = 2f;
    public Transform player;
    public GameObject attackArea;

    private int chiSoDiem;
    private Vector2 huongDiChuyen;
    private Animator animator;
    private bool IsAttacking;

    private void Start()
    {
        attackArea.SetActive(false);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsAttacking == false)
        {
            XuLyDiChuyen();
        }
    }

    void XuLyDiChuyen()
    {
        float khoangCachDenPlayer = Vector2.Distance(transform.position, player.position);
        
        if (khoangCachDenPlayer < khoangCachTanCong)
        {
            huongDiChuyen = player.position - transform.position;
            huongDiChuyen.Normalize();

            if (huongDiChuyen.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (huongDiChuyen.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            animator.SetBool("IsRunning", true);

            transform.position = Vector2.MoveTowards(transform.position, player.position, tocDoDiChuyenNhanh * Time.deltaTime);

            if (khoangCachDenPlayer < khoangCachTieuDiet && IsAttacking == false)
            {
                animator.SetBool("IsRunning", false);
                animator.SetTrigger("IsAttacking");
                IsAttacking = true;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, diemDiChuyen[chiSoDiem].position) < 0.1f)
            {
                chiSoDiem++;

                if (chiSoDiem >= diemDiChuyen.Length)
                {
                    chiSoDiem = 0;
                }
            }

            huongDiChuyen = diemDiChuyen[chiSoDiem].position - transform.position;
            huongDiChuyen.Normalize();

            if (huongDiChuyen.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (huongDiChuyen.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            animator.SetBool("IsRunning", true);

            transform.position = Vector2.MoveTowards(transform.position, diemDiChuyen[chiSoDiem].position, tocDoDiChuyen * Time.deltaTime);
        }      
    }

    void StartAttack()
    {
        attackArea.SetActive(true);
    }

    void EndAttack()
    {
        IsAttacking = false;
        attackArea.SetActive(false);
    }
}
