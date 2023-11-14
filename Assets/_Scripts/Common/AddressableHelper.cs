using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableHelper : MonoBehaviour
{
    public static GameObject InstantiationGameObjectByAddressable(string address)
    {
        GameObject result = Instantiate(Addressables.LoadAssetAsync<GameObject>(address).WaitForCompletion());
        return result;
    }
}
