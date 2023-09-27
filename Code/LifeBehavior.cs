using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class LifeBehavior : MonoBehaviour
{
    GameLogic lg;
    // Start is called before the first frame update
    void Start()
    {
        lg = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lg.errores == 1 && this.gameObject.transform.position.x == -6.3f)
            Destroy(this.gameObject);
        if (lg.errores == 2 && this.gameObject.transform.position.x == -7.3f)
            Destroy(this.gameObject);
        if (lg.errores == 3 && this.gameObject.transform.position.x == -8.3f)
            Destroy(this.gameObject);
    }
}
