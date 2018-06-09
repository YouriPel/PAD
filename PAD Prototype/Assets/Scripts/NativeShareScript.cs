using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class NativeShareScript : MonoBehaviour
{
    //Tutorial: www.youtube.com/watch?v=E4E4EfkGs0Y
    //print en spelerText.Text kan later weg

    public GameObject CanvasShareObj;//References share canvas
    private bool isProccesing = false;//Indicates if its currently proccesing and sharing the screenshot
    private bool isFocus = false;

    public Text spelerText;

    public void ShareButtonPress()
    {
        //If its not already proccesing a screenshot...
        if(!isProccesing)
        {
            CanvasShareObj.SetActive(true);

            //Shares the screenshot
            //It uses coroutine, because it takes some time to process the screenshot
            StartCoroutine(ShareScreenshot());
        }
    }

    //Shares the screenshot
    IEnumerator ShareScreenshot()
    {
        isProccesing = true;
        print("isProccesing " + isProccesing);

        yield return new WaitForEndOfFrame();
        //Captures screenshot, with filename and size
        ScreenCapture.CaptureScreenshot("screenshot.png", 1);
        //                                Unity persistentDataPath
        string destination = Path.Combine(Application.persistentDataPath, "screenshot.png");
        print(destination);

        //Waits till the screenshot is actually saved
        yield return new WaitForSecondsRealtime(0.3f);

        //Native Android Code

        //Checks if game is run in Unity Editor
        if(!Application.isEditor)
        {
            
            //Intent is a purpose or intention
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");

            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            spelerText.text = "ACTION_SEND";
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            spelerText.text = "parse destination";
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), 
                uriObject);
            spelerText.text = "EXTRA_STREAM";
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"),
                "Can you beat my score?");
            spelerText.text = "EXTRA_TEXT";
            //Intent to share an image
            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            spelerText.text = "setType image jpeg";
           


            //Get activity which is currently running
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.Unityplayer");//just the class
            //Get the current activity object
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            spelerText.text = "currentActivity";

            //Creates chooser where you can pick which app you want to share on
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser",
                intentObject, "Share your new score");
            currentActivity.Call("startActivity", chooser);
            spelerText.text = "chooser";

            yield return new WaitForSecondsRealtime(1);
        }

        yield return new WaitUntil(() => isFocus);
        //CanvasShareObj.SetActive(false);
        isProccesing = false;
        print("isProccesing " + isProccesing);
    }

    private void OnApplicationFocus(bool focus)
    {
        isFocus = focus;
        print("isFocus " + isFocus);
    }
}
