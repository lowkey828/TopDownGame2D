using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public int maxMau = 10;
    public int mauHienTai = 10;
    public Slider thanhMau;

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

        if (mauHienTai == 0)
        {
            if (uiManager != null)
            {
                uiManager.ShowLoseScreen();
            }
        }
    }

    void NhanSatThuong(int satThuong)
    {
        mauHienTai -= satThuong;

        if (mauHienTai < 0)
        {
            mauHienTai = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            NhanSatThuong(1);
        }
    }
}
