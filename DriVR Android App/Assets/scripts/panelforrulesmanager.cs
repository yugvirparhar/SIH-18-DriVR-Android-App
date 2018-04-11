using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelforrulesmanager : MonoBehaviour {
    public GameObject rulespanel1;
    public GameObject rulespanel2;
    public GameObject rulespanel3;
    public GameObject nextroundpanel;
    public GameObject settingspanel;
    public GameObject about_us_panel;
    public GameObject help_panel;
    int count = 0;

    public void gotonextpanel()
    {
        if (rulespanel1.activeSelf)
        {
            rulespanel1.SetActive(false);
            rulespanel2.SetActive(true);
        }
        else if (rulespanel2.activeSelf)
        {
            rulespanel2.SetActive(false);
            rulespanel3.SetActive(true);
        }
        else if (rulespanel3.activeSelf)
        {
            rulespanel3.SetActive(false);
            nextroundpanel.SetActive(true);
        }
    }
    public void gotopreviouspanel()
    {
        if (rulespanel2.activeSelf)
        {
            rulespanel1.SetActive(true);
            rulespanel2.SetActive(false);
        }
        else if (rulespanel3.activeSelf)
        {
            rulespanel3.SetActive(false);
            rulespanel2.SetActive(true);
        }
        else if (nextroundpanel.activeSelf)
        {
            rulespanel3.SetActive(true);
            nextroundpanel.SetActive(false);
        }
    }
    public void gotosettinspanel()
    {
        if (count % 2 == 0)
        {

            if (rulespanel1.activeSelf)
            {
                //  rulespanel1.SetActive(false);
                settingspanel.SetActive(true);
            }
            else if (rulespanel2.activeSelf)
            {
                // rulespanel2.SetActive(false);
                settingspanel.SetActive(true);
            }
            else if (rulespanel3.activeSelf)
            {
                // rulespanel3.SetActive(false);
                settingspanel.SetActive(true);
            }
            else if (nextroundpanel.activeSelf)
            {
                settingspanel.SetActive(true);
                //  nextroundpanel.SetActive(false);
            }
            count++;
        }
        else
        {
            gobacktorules();
            count++;
        }
    }

    public void gobacktorules()
    {
        settingspanel.SetActive(false);
    }

    public void gobacktosettingspanel()
    {
        if (help_panel.activeSelf)
        {
            help_panel.SetActive(false);
            settingspanel.SetActive(true);
        }
        else if (about_us_panel.activeSelf)
        {
            settingspanel.SetActive(true);
            about_us_panel.SetActive(false);
        }

    }

    public void gotohelp ()
	{
		help_panel.SetActive(true);
        settingspanel.SetActive(false);
	}

	public void gottoabout()
	{
		settingspanel.SetActive(false);
        about_us_panel.SetActive(true);
	}
}
