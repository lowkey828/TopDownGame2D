using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] diemDiChuyen;
    public float tocDoDiChuyen = 3f;

    private int chiSoDiem;
    private Vector2 huongDiChuyen;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        XuLyDiChuyen();
    }

    void XuLyDiChuyen()
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
        
        if (huongDiChuyen != Vector2.zero)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }



        transform.position = Vector2.MoveTowards(transform.position, diemDiChuyen[chiSoDiem].position, tocDoDiChuyen * Time.deltaTime);
    }
}
