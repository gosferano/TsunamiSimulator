using UnityEngine;

public class Singleton<Instance> : MonoBehaviour where Instance : Singleton<Instance>
{
    public static Instance instance;
    protected static bool onLevelLoadWasCalled = false;

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as Instance;
        }
        else
        {
            DestroyObject(gameObject);
        }
        onLevelLoadWasCalled = false;
    }

}