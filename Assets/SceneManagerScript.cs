using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Net.Http;
using System.IO;
using System.Net;
using TMPro;

public class SceneManagerScript : MonoBehaviour
{

    public GameObject VariablesPanel;
    public GameObject PhotoButton;
    public GameObject ControllerPanel;
    public GameObject slider;

    public GameObject AnglesText;
    public GameObject DistanceText;

    int[] anglesArray = { 15, 30, 45, 90 };
    double[] distanceArray = { 0.5, 1.0, 2.0, };

    int anglesArrayOffset = 0;
    int distanceArrayOffset = 0;

    public void incAng()
    {
        if (anglesArrayOffset == anglesArray.Length - 1) {
            anglesArrayOffset = 0;
        }
        else
        {
            anglesArrayOffset++;
        }
        AnglesText.GetComponent<TextMeshProUGUI>().text = anglesArray[anglesArrayOffset].ToString() + "°";

    }

    public void decAng()
    {
        if(anglesArrayOffset == 0)
        {
            anglesArrayOffset = anglesArray.Length - 1;
        }
        else
        {
            anglesArrayOffset--;
        }
        AnglesText.GetComponent<TextMeshProUGUI>().text = anglesArray[anglesArrayOffset].ToString() + "°";
    }

    public void incDis()
    {
        if (distanceArrayOffset == distanceArray.Length - 1)
        {
            distanceArrayOffset = 0;
        }
        else
        {
            distanceArrayOffset++;
        }
        DistanceText.GetComponent<TextMeshProUGUI>().text = distanceArray[distanceArrayOffset].ToString();
    }

    public void decDis()
    {
        if (distanceArrayOffset == 0)
        {
            distanceArrayOffset = distanceArray.Length - 1;
        }
        else
        {
            distanceArrayOffset--;
        }
        DistanceText.GetComponent<TextMeshProUGUI>().text = distanceArray[distanceArrayOffset].ToString();
    }

    public void ApplyVariables()
    {
        // sending distance
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://195.134.71.250:8082/topics/thesis_test");
        httpWebRequest.ContentType = "application/vnd.kafka.json.v2+json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "{\"records\":[{\"value\":{\"distance\":\"" + distanceArray[distanceArrayOffset].ToString() + "\"}}]}";

            streamWriter.Write(json);
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            Debug.Log(result);
        }
        // sending angles
        httpWebRequest = (HttpWebRequest)WebRequest.Create("http://195.134.71.250:8082/topics/thesis_test");
        httpWebRequest.ContentType = "application/vnd.kafka.json.v2+json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "{\"records\":[{\"value\":{\"angle\":\"" + anglesArray[anglesArrayOffset].ToString() + "\"}}]}";

            streamWriter.Write(json);
        }

        httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            Debug.Log(result);
        }


        VariablesPanel.SetActive(false);
        PhotoButton.SetActive(true);
        ControllerPanel.SetActive(true);
        slider.SetActive(true);

    }

    public void upClick()
    {
        Debug.Log("borot goiung up");

        var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://195.134.71.250:8082/topics/thesis_test");
        httpWebRequest.ContentType = "application/vnd.kafka.json.v2+json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "{\"records\":[{\"value\":{\"movement\":\"up\"}}]}";

            streamWriter.Write(json);
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            Debug.Log(result);
        }




    }

    public void downClick()
    {
        Debug.Log("borot going down");
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://195.134.71.250:8082/topics/thesis_test");
        httpWebRequest.ContentType = "application/vnd.kafka.json.v2+json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "{\"records\":[{\"value\":{\"movement\":\"down\"}}]}";

            streamWriter.Write(json);
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            Debug.Log(result);
        }



    }

    public void rightClick()
    {
        Debug.Log("borot going right");
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://195.134.71.250:8082/topics/thesis_test");
        httpWebRequest.ContentType = "application/vnd.kafka.json.v2+json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "{\"records\":[{\"value\":{\"movement\":\"right\"}}]}";

            streamWriter.Write(json);
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            Debug.Log(result);
        }


    }

    public void leftClick()
    {
        Debug.Log("borot going left");
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://195.134.71.250:8082/topics/thesis_test");
        httpWebRequest.ContentType = "application/vnd.kafka.json.v2+json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "{\"records\":[{\"value\":{\"movement\":\"left\"}}]}";

            streamWriter.Write(json);
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            Debug.Log(result);
        }


    }

    public void photoClick()
    {
        Debug.Log("borot took photo");
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://195.134.71.250:8082/topics/thesis_test");
        httpWebRequest.ContentType = "application/vnd.kafka.json.v2+json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "{\"records\":[{\"value\":{\"action\":\"photo\"}}]}";

            streamWriter.Write(json);
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            Debug.Log(result);
        }
    }
}
