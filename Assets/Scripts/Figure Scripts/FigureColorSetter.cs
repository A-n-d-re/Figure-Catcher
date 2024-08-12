using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FigureColorSetter : MonoBehaviour
{
    [SerializeField] private BasketColorChanger basketColorChanger;

    private Animator animator;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = basketColorChanger.GetRandomColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Basket"))
        {
            animator = GetComponent<Animator>();

            animator.SetTrigger("isCatched");
        }
    }

    private void DestroyFigure()
    {
        Destroy(gameObject);
    }
}
