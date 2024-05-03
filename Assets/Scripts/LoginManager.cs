using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Models;
using Proyecto26;
using System.Collections.Generic;
using UnityEngine.Networking;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public string baseUrl = "https://appsoftspace.azurewebsites.net/Login/user";
    public TMP_InputField usernameInputField;
    public TMP_InputField passwordInputField;

  
    public void Login()
    {
        Debug.Log(usernameInputField.text);
        Debug.Log(passwordInputField.text);
        var jsonBody = new UserLogin
        {
            Username = usernameInputField.text,
            Password = passwordInputField.text
        };


        // Create request
        RestClient.Post("https://appsoftspace.azurewebsites.net/Login/user", jsonBody).Then(response =>
        {
            if (response.StatusCode == 200)
            {
                SceneManager.LoadScene("IdeaSceneVR", LoadSceneMode.Single);
            }
            else
            {
                Debug.LogError("Login failed. Status code: " + response.StatusCode);

            }
        }).Catch(error =>
        {
            Debug.LogError("Error: " + error.Message);

        });



    }
}