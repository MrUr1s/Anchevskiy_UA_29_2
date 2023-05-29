using System.Collections.Generic;
using UnityEngine;

public abstract class APool<T> where T: MonoBehaviour
{
    [SerializeField]
    protected T _prefab;
    [SerializeField]
    protected Transform _parent;
    [SerializeField]
    protected List<T> _pool;

    public List<T> Pool => _pool;

    public APool(T prefab, Transform parent)
    {
        _prefab = prefab;
        _parent = parent;
        _pool = new();
    }
    protected void Init(int count)
    {
        for (int i = 0; i < count; i++)
            PoolUp(false);
    }
    public T Spawn(Vector3 position)
    {
        T temp = IsAvailable(out T element) ? element : PoolUp(true);
        temp.transform.position = position;
        return temp;
    }
    public T Spawn(Vector3 position, Vector3 rotation)
    {
        T element = Spawn(position);
        element.transform.eulerAngles = rotation;
        return element;
    }
    bool IsAvailable(out T element)
    {
        element = _pool.Find(t => t.gameObject.activeSelf == false);
        element?.gameObject.SetActive(true);
        return element != default;
    }
    protected abstract T GetCreated();
    private T PoolUp(bool isActive)
    {
        T element = GetCreated();
        element.transform.SetParent(_parent);
        element.gameObject.SetActive(isActive);
        _pool.Add(element);
        return element;
    }
}