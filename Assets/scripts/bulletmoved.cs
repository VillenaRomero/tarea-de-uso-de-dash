using UnityEngine;

public class bulletmoved : MonoBehaviour
{
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<playermoved>().TakeDamage();

            puntaje.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}
