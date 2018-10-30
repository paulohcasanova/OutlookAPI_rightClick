using Microsoft.Office.Interop.Outlook;
//using Microsoft.TeamFoundation.Client;
using rightClick.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new rclickXML();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace rightClick
{
    [ComVisible(true)]
    public class rclickXML : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        //private List<string> listOfFolders;
        private Dictionary<string, List<string>> folder_child;
        private static string userName = Environment.GetEnvironmentVariable("USERPROFILE");
        private static string folderLocation = userName + @"\Documents\folderStructure.txt";
        public rclickXML()
        {
            
        }
        public Image GetIcon(Office.IRibbonControl control)
        {
            return Resources.Capybara;
        }

        public string GetSynchronisationLabel(Office.IRibbonControl control)
        {
            return "Create Folder Structure";
        }
        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("rightClick.rclickXML.xml");
        }
        public int getMonth(string name)
        {
            switch (name)
            {
                case "January":
                    return 1;
                case "February":
                    return 2;
                case "March":
                    return 3;
                case "April":
                    return 4;
                case "May":
                    return 5;
                case "June":
                    return 6;
                case "July":
                    return 7;
                case "August":
                    return 8;
                case "September":
                    return 9;
                case "October":
                    return 10;
                case "November":
                    return 11;
                case "December":
                    return 12;
            }
            return 0;
        }
        //need to improve this method - too much reuse of auxlist
        public void defineFolerList()
        {
            folder_child = new Dictionary<string, List<string>>();
            //Main folder list
            folder_child.Add("A :: Automation", new List<string>());
            folder_child.Add("A :: Innovation", new List<string>());
            folder_child.Add("A :: Reports", new List<string>());
            folder_child.Add("A :: CoP", new List<string>());
            folder_child.Add("B :: Metrics", new List<string>());
            folder_child.Add("C :: Launch Related", new List<string>());

            // Is this worth it ?
            List<string> auxList = new List<string>();
            //auxList is child folders that will be added under folder_child which is the main folder
            auxList.Add("General Stuff");
            auxList.Add("INCIDENTS");
            folder_child.Add("D :: Projects Related :: ProjectName", auxList);
            auxList = null;

            auxList = new List<string>();
            //auxList is child folders that will be added under folder_child which is the main folder
            auxList.Add("General Stuff");
            auxList.Add("INCIDENTS");
            folder_child.Add("D :: Projects Related :: GCM Foundation", auxList);
            auxList = null;
            
            folder_child.Add("Y :: MIM Alert", new List<string>());
            folder_child.Add("Y :: Support", new List<string>());
            folder_child.Add("Z :: Articles", new List<string>());
            folder_child.Add("Z :: EMS", new List<string>());

            auxList = new List<string>();
            auxList.Add("Management");
            auxList.Add("Celebration");
            auxList.Add("Training");
            auxList.Add("Knowledge Base");
            folder_child.Add("Z :: Team", auxList);
            auxList = null;
        }
        public void OnMyButtonClick(Office.IRibbonControl control)
        {
            defineFolerList();
            string[] ret = new string[4];
            ret[0] = "0";
            ret[1] = "0";
            ret[2] = "0";
            ret[3] = "0";
            Option opt = new Option(ret);
            opt.ShowDialog();

            DateTime t = DateTime.Now;
            DateTime jan = new DateTime(t.Year, 12, 1);
            int year = (t.Year + 1) - 2000;
            int currentMonth = t.Month;
            int dayOfYear = 0;
            int currentSprint = 0;
            int aux = 0;
            int lastSprint = 0;
            string newFolder = string.Empty;

            if (t.Month != 1)
            {
                dayOfYear = t.DayOfYear - 30;
                currentSprint = (dayOfYear / 14);
            }
            else
            {
                dayOfYear = jan.DayOfYear + 30;
                currentSprint = (dayOfYear / 14);
            }       
            //
            
            //
            int m = 0;
            if (ret[0] == "0")
            {
                MessageBox.Show("Ops, you should have selected the next Release.");
            }
            else
            {
                DateTime n;
                m = getMonth(ret[0]);
                if (m == 1)
                {
                    //dayOfYear = t.DayOfYear;
                    lastSprint = 25;
                }
                else
                {
                    
                    for (int y = 1; y <= (m - currentMonth); y++)
                    {
                        aux += 31;
                    }
                    n = t.AddDays(aux);
                    lastSprint = currentSprint + (aux / 14);
                    //n = t.AddMonths(m - currentMonth);
                }
                
                //int dayOfYearInFuture = n.DayOfYear;
                //int lastSprint = currentSprint + (aux / 14);
                aux = currentSprint;
                try
                {
                    Outlook.MAPIFolder Folder = control.Context;

                    if (Folder != null && Folder.FolderPath != null)
                    {
                        string folderPath = Folder.FolderPath;

                        if (folderPath != null)
                        {
                            string newfolder = folderPath + "\\" + "FY" + year + " - " + getQuarter(ret[0]) + " - " + ret[0];// + " Releases"
                            newFolder = "FY" + year + " - " + getQuarter(ret[0]) + " - " + ret[0];// + " Releases"
                            Folder.Folders.Add("FY" + year + " - " + getQuarter(ret[0]) + " - " + ret[0]); // + " Releases"

                            Folder = GetFolder(newfolder);
                            
                            if (ret[2] == "1")
                            {
                                foreach (KeyValuePair<string, List<string>> dic in folder_child)
                                {
                                    Folder.Folders.Add(dic.Key);
                                    Folder = GetFolder(newfolder + "\\" + dic.Key);

                                    if (ret[1] == "1" && Folder.Name.Contains("Projects Related"))
                                    {
                                        while (currentSprint <= lastSprint)
                                        {
                                            currentSprint++;
                                            Folder.Folders.Add("SPRINT " + currentSprint);
                                        }
                                    }

                                    if (dic.Value.Count > 0)
                                    {
                                        foreach (string s in dic.Value)
                                        {
                                            Folder.Folders.Add(s);
                                        }
                                    }
                                    Folder = GetFolder(newfolder);
                                }
                                //foreach (string s in listOfFolders)
                                //{
                                //    Folder.Folders.Add(s);
                                //}
                            }
                        }
                    }

                }
                catch (System.Exception)
                {
                    MessageBox.Show("Ops, something went terribly wrong.");
                }
                if (ret[3] == "1")
                {
                    createDirectory(newFolder, aux, lastSprint);
                }
            }
        }
        public void createDirectory(string mainFolder, int currentSprint, int lastSprint)
        {
            string user = Environment.GetEnvironmentVariable("USERPROFILE");
            string mainDir = user + @"\Documents\My Documents";
            DirectoryInfo dir = new DirectoryInfo(mainDir);
            dir.Create();

            mainDir = mainDir + "\\" + mainFolder;
            dir = new DirectoryInfo(mainDir);
            dir.Create();

            while (currentSprint <= lastSprint)
            {
                currentSprint++;
                dir = new DirectoryInfo(mainDir + "\\SPRINT " + currentSprint);
                dir.Create();
            }
        }
        public string getQuarter(string month)
        {
            switch (month)
            {
                case "February":
                case "March":
                case "April":
                    return "Q1";
                case "May":
                case "June":
                case "July":
                    return "Q2";
                case "August":
                case "September":
                case "October":
                    return "Q3";
                case "January":
                case "November":
                case "December":
                    return "Q4";
            }
            return "Qx";
        }
        private Outlook.Folder GetFolder(string folderPath)
        {
            Outlook.Folder folder;
            string backslash = @"\";
            try
            {
                if (folderPath.StartsWith(@"\\"))
                {
                    folderPath = folderPath.Remove(0, 2);
                }
                String[] folders =
                    folderPath.Split(backslash.ToCharArray());
                folder =
                    Globals.ThisAddIn.Application.Session.Folders[folders[0]]
                    as Outlook.Folder;
                if (folder != null)
                {
                    for (int i = 1; i <= folders.GetUpperBound(0); i++)
                    {
                        Outlook.Folders subFolders = folder.Folders;
                        folder = subFolders[folders[i]]
                            as Outlook.Folder;
                        if (folder == null)
                        {
                            return null;
                        }
                    }
                }
                return folder;
            }
            catch { return null; }
        }
        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit http://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
