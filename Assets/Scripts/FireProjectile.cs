using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    public int damage = 5;
    float timeToLive = 6f;

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (Time.frameCount % 6  == 0)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.7f);

            foreach (Collider2D c in hit)
            {
                IDamageable enemy = c.GetComponent<IDamageable>();
                Character character = c.GetComponent<Character>();
                if (enemy != null)
                {
                    PostDagmage(damage, transform.position);
                    enemy.TakeDamage(damage);
                    Destroy(gameObject);
                    break;
                } else if (character == null)
                {
                    Destroy(gameObject);
                    break;
                }

            }
        }

        timeToLive -= Time.deltaTime;
        if (timeToLive < 0f)
        {
            Destroy(gameObject);
        }


    }

    public void PostDagmage(int damage, Vector3 worldPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), worldPosition);
    }
}
