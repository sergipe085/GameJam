using UnityEngine;

public static class ObjectFinder {
    public static GameObject GetRootObject(GameObject obj) {
        if (obj.transform.parent != null) {
            return GetRootObject(obj.transform.parent.gameObject);
        }

        return obj;
    }
}