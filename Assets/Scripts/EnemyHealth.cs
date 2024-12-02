using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxMau = 10;
    public int mauHienTai = 10;
    public Slider thanhMau;

    public Camera cameraChinh;
    private UIManager uiManager;

    void Start()
    {
        mauHienTai = maxMau;
        thanhMau.value = mauHienTai;
        thanhMau.maxValue = maxMau;

        uiManager = Object.FindFirstObjectByType<UIManager>();
    }

    void Update()
    {
        thanhMau.value = mauHienTai;
        Vector3 viTriManHinh = cameraChinh.WorldToScreenPoint(transform.position + new Vector3(0, 1.5f, 0));
        thanhMau.transform.position = viTriManHinh;
    }

    public void NhapSatThuong(int satThuong)
    {
        mauHienTai -= satThuong;
        if (mauHienTai <= 0)
        {
            mauHienTai = 0;
            Die();
        }
        thanhMau.value = mauHienTai;
    }

    private void Die()
    {
        if (uiManager != null)
        {
            uiManager.UpdateEnemyKill();
        }
        Destroy(gameObject);
    }
}
