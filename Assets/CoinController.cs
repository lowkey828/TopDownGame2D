using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject coinPrefabs;

    private UIManager uiManager;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        uiManager = Object.FindFirstObjectByType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (uiManager != null)
            {
                uiManager.EatCoin();
            }
            anim.SetTrigger("IsCoin");
            Destroy(gameObject, 0.15f);
        }
    }
}
