using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int Life;
    public int Power;
    public SeekPlayer agent;

    public void Set(int _life, int _power, GameObject target)
    {
        Life = _life;
        Power = _power;
        agent.target = target.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            puntaje.Instance.AddScore(10);
            Destroy(collision.gameObject);
            Destroy(gameObject);          
        }
    }
}
