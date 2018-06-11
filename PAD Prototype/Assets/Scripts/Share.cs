using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Share : MonoBehaviour
{
    string score = "1234";

    #region Twitter variables
    //Twitter Share link
    string twitterAddress = "http://twitter.com/intent/tweet";
    //Language
    string tweetLanguage = "en";

    string textToDisplay = "Check out my score on FoodSmash!: ";
    #endregion

    #region Facebook variables
    //App ID
    string appID = "931129810293995";

    //This link is attached to this post
    string link = "https://google.com";

    //The URL of a picture attached to this post. The Size must be atleat 200px by 200px.
    string picture = "http://i-cdn.phonearena.com/images/article/85835-thumb/Google-Pixel-3-codenamed-Bison-to-be-powered-by-Andromeda-OS.jpg";

    //The Caption of the link appears beneath the link name
    string caption = "Check out my score on FoodSmash!: ";

    //The Description of the link
    string description = "test";
    #endregion

    //Twitter Share Button
    public void shareScoreOnTwitter()
    {
        Application.OpenURL(twitterAddress + "?text=" + WWW.EscapeURL(textToDisplay) 
            + score + "&amp;lang=" + WWW.EscapeURL(tweetLanguage));
    }

    //Facebook Share Button
    public void shareScoreOnFacebook()
    {
        Application.OpenURL("https://www.facebook.com/dialog/feed?" + 
            "app_id=" + appID + 
            "&link=" + link + 
            "&picture=" + picture +
            "&caption=" + caption +
            score + 
            "&description=" + description);
    }
}
