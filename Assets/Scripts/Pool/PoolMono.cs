using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace PhotonTestTask
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<T, PoolMono<T>>
        {
        }

        public T Prefab { get; }
        public bool AutoExpand { get; set; }

        public Transform Container { get; }

        private List<T> pool;

        public PoolMono(T prefab, int count, bool autoExpand, Transform container = null) 
        {
            Prefab = prefab;
            AutoExpand = autoExpand;
            Container = container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(Prefab, Container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            pool.Add(createdObject);
            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var item in pool)
            {
                if(!item.gameObject.activeSelf)
                {
                    element = item;
                    element.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if(HasFreeElement(out var element))
                return element;

            if(AutoExpand)
                return CreateObject(true);

            throw new Exception($"There is no free element in pool with type {typeof(T)}");
        }
    }
}
