using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages accessing objects based on their types
/// </summary>
public class ObjectManager : Singleton<ObjectManager>
{
    private Dictionary<string, List<GridObject>> m_objectsDictionary;

    public List<GridObject> GetAllObjectsOfType(string objectType)
    {
        return m_objectsDictionary[objectType];
    }

    public void AddObject(GridObject gridObject)
    {
        if (!m_objectsDictionary.ContainsKey(gridObject.tag))
        {
            m_objectsDictionary.Add(gridObject.tag, new List<GridObject>());
        }

        m_objectsDictionary[gridObject.tag].Add(gridObject);
    }

    public void RemoveObject(GridObject gridObject)
    {
        if (!m_objectsDictionary.ContainsKey(gridObject.tag))
        {
            Debug.LogWarning("ObjectManager contains no objects of type " + gridObject.tag);
            return;
        }

        m_objectsDictionary[gridObject.tag].Remove(gridObject);
    }
}
