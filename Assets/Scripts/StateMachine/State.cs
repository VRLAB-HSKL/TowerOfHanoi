using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public virtual IEnumerator Initial()
    {
        yield break;
    }

    public virtual IEnumerator Move()
    {
        yield break;
    }

    public virtual IEnumerator Rules()
    {
        yield break;
    }
}
