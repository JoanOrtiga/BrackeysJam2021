using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public float speed;

    public Transform credits;
    public Transform target;
    public LoadScene loadScene;

    private float margin = 0.03f;

    void Update()
    {
        credits.position = Vector2.MoveTowards(credits.position, target.position, speed * Time.deltaTime);

        if ((credits.position - target.position).sqrMagnitude < margin * margin)
        {
            loadScene.SceneLoad(0);
        }
    }
}
