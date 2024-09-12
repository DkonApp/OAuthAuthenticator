using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class OAuthAuthenticator : MonoBehaviour
{
    private const string LoginUrl = "https://api.dkon.app/api/v3/method/account.signIn";

    public void Login(string username, string password)
    {
        StartCoroutine(LoginCoroutine(username, password));
    }

    private IEnumerator LoginCoroutine(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("clientId", "1302");
        form.AddField("username", username);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(LoginUrl, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
                OnLoginFailed("An error occurred. Please try again later.");
            }
            else
            {
                // Handle the response
                var jsonResponse = www.downloadHandler.text;
                var responseData = JsonUtility.FromJson<LoginResponse>(jsonResponse);

                if (responseData.error_code == 0)
                {
                    // Save access token and account ID
                    PlayerPrefs.SetString("accessToken", responseData.accessToken);
                    PlayerPrefs.SetString("accountId", responseData.accountId);
                    PlayerPrefs.Save();

                    Debug.Log("Login successful!");
                    OnLoginSuccess();
                }
                else
                {
                    OnLoginFailed("Login failed. Please check your credentials.");
                }
            }
        }
    }

    private void OnLoginSuccess()
    {
        // Logic for successful login
        Debug.Log("User logged in successfully.");
    }

    private void OnLoginFailed(string message)
    {
        // Logic for handling login failure
        Debug.LogError(message);
    }

    [System.Serializable]
    public class LoginResponse
    {
        public int error_code;
        public string accessToken;
        public string accountId;
    }
}
