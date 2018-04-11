using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panelmanager :MonoBehaviour {
    public GameObject panel1;
    public GameObject panel2;
    public GameObject aboutpanel;
    public GameObject help_panel;
    public GameObject about_us_panel;
    public GameObject LoginPanel;
    public GameObject StartPanel;
   

    public void buttonevent()
    {
        if(panel1.activeSelf)
        {
                panel1.SetActive(false);
                panel2.SetActive(true);
        }
        else if(panel2.activeSelf)
        {
            panel1.SetActive(true);
            panel2.SetActive(false);
        }
    }
    public void gotoabout()
    {
        aboutpanel.SetActive(true);
        panel2.SetActive(false);
    }
    public void goto_mainmenu()
    {
        aboutpanel.SetActive(false);
        panel1.SetActive(true);
    }
 
    public void help()
    {
        help_panel.SetActive(true);
        panel2.SetActive(false);
    }
    public void about_us()
    {
        about_us_panel.SetActive(true);
        panel2.SetActive(false);
    }
    public void gotosettingspanel()
    {
        if (help_panel.activeSelf)
        {
            help_panel.SetActive(false);
            panel2.SetActive(true);
        }
        else if (about_us_panel.activeSelf)
        {
            panel2.SetActive(true);
            about_us_panel.SetActive(false);
        }

    }

    public void gotologin ()
	{
		LoginPanel.SetActive(true);
		//StartPanel.SetActive(false);
	}

}
