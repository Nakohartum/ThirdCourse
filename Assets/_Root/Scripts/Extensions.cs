using UnityEngine;

namespace _Root.Scripts
{
    public static class Extensions
    {
        public static T GetOrAddComponent<T>(this GameObject self) where T : Component
        {
            var result = self.GetComponent<T>();
            if (result == null)
            {
                result = self.AddComponent<T>();
            }

            return result;
        }

        public static void ChangeName(this GameObject self, string name)
        {
            self.name = name;
        }
    }
}