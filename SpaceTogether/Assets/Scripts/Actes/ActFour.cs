using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActFour : MonoBehaviour
{

    public void SittingDown()
    {
        gameObject.GetComponent<Animator>().SetBool("Seetting", true);
        this.transform.position = new Vector3(17.123f, 0.222f, - 18.287f);
    }
}
