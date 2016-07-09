using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;


public partial class _WerdDefault : System.Web.UI.Page
{
    /*
     * License Info: Must remain in tact.
     * Plugin URI: http://247Coding.com
    * Description: Werd Validation Redirector
    * Author URI: http://247Coding.com
    * Version: 1.0
    * Copyright: (c) 2016 247Coding.com/WebMeToo.com
    * License: GNU General Public License v3.0
    * License URI: http://www.gnu.org/licenses/gpl-3.0.html
     */
    public static string DocDir = ConfigurationManager.AppSettings["DocDir"].ToString();
    public static string WerdCookie = ConfigurationManager.AppSettings["WerdCookie"].ToString();
    private bool UsingDropdown = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MobileCheck();
        }
    }
    protected void MobileCheck()
    {
        try
        {
            if (Request.QueryString.Count > 0)
            {
                try
                {
                    UsingDropdown = Convert.ToBoolean(Request.QueryString["m"].ToString());
                }
                catch { }
            }
        }
        catch { }
        if (Request.Browser.IsMobileDevice || UsingDropdown)
        {
            try
            {
                UsingDropdown = true;
                LoadDropdown(Server.MapPath(DocDir));

            }
            catch { }
        }
        else
        {
            try
            {
                LoadWords(Server.MapPath(DocDir));
                UsingDropdown = false;
            }
            catch { }

        }
        ddlWords.Visible = UsingDropdown;
        rblWords.Visible = !UsingDropdown;

    }
    protected void LoadWords(string mPath)
    {
        //loads the radio button list.
        //if you use a listbox, should work as well...
        // sets a session variable (you must have use System.Web.SessionState
        rblWords.Items.Clear();
        int maxWords = Convert.ToInt32(ConfigurationManager.AppSettings["maxWords"].ToString());
        int maxItems = Convert.ToInt32(ConfigurationManager.AppSettings["maxItems"].ToString());
        List<string> webWords = WerdGen.Word.GetWordList(mPath, 6, 10);
        for (int i = 0; i < webWords.Count; i++)
        {
            if (i == 0)
            {

                Session["GoodWordIndex"] = webWords[i];
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = webWords[i];
                rblWords.Items.Add(li);
            }
        }
         
    }
    protected void LoadDropdown(string mPath)
    {
        //loads the radio button list.
        //if you use a listbox, should work as well...
        // sets a session variable (you must have use System.Web.SessionState
        ddlWords.Items.Clear();
        int maxWords = Convert.ToInt32(ConfigurationManager.AppSettings["maxWords"].ToString());
        int maxItems = Convert.ToInt32(ConfigurationManager.AppSettings["maxItems"].ToString());
        List<string> webWords = WerdGen.Word.GetWordList(mPath, 6, 10);
        for (int i = 0; i < webWords.Count; i++)
        {
            if (i == 0)
            {

                Session["GoodWordIndex"] = webWords[i];
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = webWords[i];
                ddlWords.Items.Add(li);
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (rblWords.Visible)
        {
            LoadWords(Server.MapPath(DocDir));
        }
        else
        {
            LoadDropdown(Server.MapPath(DocDir));
        }
    }
    protected void InitUserModule(string modulePath)
    {
        if (File.Exists(modulePath))
        {
            TextReader tr = new StreamReader(modulePath);
            string tg = tr.ReadToEnd();
            tr.Dispose();
            Literal1.Text = tg;
        }
        else
        {
            lblWarn.Text = "Sorry, user processes are currently disabled.";

        }

    }
    protected void rblWords_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblWords.SelectedIndex == Convert.ToInt32(Session["GoodWordIndex"].ToString()))
        {
            lblWerd.Text = "";
            lblMsg.Text = "";
            pnlWerd.Visible = false;
            pnlLogin.Visible = true;
          //  Literal1.Text = "<iframe style=\"width:98%;height:98%;min-height:600px\" class=\"_PanelRounded\" src=\"/drupal/?user\"></iframe>";
            try
            {
                string xdays = ConfigurationManager.AppSettings["WerdExpirationDays"].ToString();
                if (xdays != "")
                {
                    try
                    {
                        int xset = Convert.ToInt32(xdays);
                        Response.Cookies[WerdCookie].Expires = DateTime.Now.AddDays(xset);
                    }
                    catch { }
                }
            }
            catch { }
            Response.Cookies[WerdCookie].Value = Request.ServerVariables["SERVER_NAME"].ToString();
            Response.Redirect(ConfigurationManager.AppSettings["WerdRedirectUrl"].ToString());
        }
        else
        {
            lblWerd.Text = "";
            LoadWords(Server.MapPath(DocDir));
            lblMsg.Text = "Sorry.. try again..";
        }
    }
    protected void ddlWords_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlWords.SelectedIndex == Convert.ToInt32(Session["GoodWordIndex"].ToString()))
        {
            lblWerd.Text = "";
            lblMsg.Text = "";
            pnlWerd.Visible = false;
            pnlLogin.Visible = true;
            Response.Cookies[WerdCookie].Value = Request.ServerVariables["SERVER_NAME"].ToString();// DateTime.Now.ToShortDateString();
            Response.Redirect(ConfigurationManager.AppSettings["WerdRedirectUrl"].ToString());
        }
        else
        {
            lblWerd.Text = "";
            LoadDropdown(Server.MapPath(DocDir));
            lblMsg.Text = "Sorry.. try again..";
        }
    }
}

public class WerdGen
{
    //Licensed under GNU GENERAL PUBLIC LICENSE.. Free to use and copy as long as this
    //credit section and copyright stamps are left in tact within source or credit in any
    //source recode would be appreciated.
    //©CopyRight 2016 247Coding.com/WebMeToo.com - Author: ABitOWhit 03Mar2016
    public class Word
    {
        public Word()
        { }
        public Word(string filePath, int maxWords, int maxList)
        {
            WordList = GetWordList(filePath, maxWords, maxList);
        }
        public static bool validAssoc(string inAssoc)
        {
            string[] va = { "html", "aspx", "asp", "txt", "htm", "php","1","2" };
            bool fnd = false;
            for (int i = 0; i < va.Length && !fnd; i++)
            {
                if (inAssoc.ToLower() == va[i].ToLower())
                { fnd = true; }
            }
            return fnd;
        }

        public static string ToHexString(string str)
        {
            //use to determine hex value of special chars if you want to add time to the parsestring list...
            var builder = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                builder.Append(t.ToString("X2"));
            }

            return builder.ToString();
        }

        public static string ParseString(string inString)
        {
            string[] badchars = { "\n", "\t", "\r", "<", ">", "'", "\"", "/", ".", ",", ";", "@", "=", ")", "(", "%", "^", "*", "#", "&", "-", "[", "]", "{", "}", "mailto", "href", ":", "script" };
            for (int i = 0; i < badchars.Length; i++)
            {
                inString = inString.Replace(badchars[i], " ");
            }
            return inString;
        }
        public static List<string> GetWordList(string filePath, int maxWords, int maxList)
        {
            //this creates that list of words to return and most of the randomness..
            List<string> rValue = new List<string>();
            string myWord = "";
            if (Directory.Exists(filePath))
            {
                string[] fNames = Directory.GetFiles(filePath);
                List<string> validFiles = new List<string>();
                for (int i = 0; i < fNames.Length; i++)
                {
                    string[] fSplt = fNames[i].Split('.');
                    if (fSplt.Length > 1)
                    {
                        string fAssoc = fSplt[fSplt.Length - 1];
                        if (validAssoc(fAssoc))
                        {
                            validFiles.Add(fNames[i]);
                        }
                    }
                }
                Random rand = new Random();
                int fRand = rand.Next(0, validFiles.Count);
                string rFile = fNames[fRand].ToString();
                if (File.Exists(rFile))
                {
                    TextReader tR = new StreamReader(rFile);
                    string parseString = ParseString(tR.ReadToEnd());
                    string[] rSplit = parseString.Replace(" ", "|").Split('|');
                    tR.Dispose();//don't need this any more..
                    //now you are in the text body...
                    Random wordRnd = new Random();
                    //set a random sentence > 2 and less than the length
                    int wordCnt = wordRnd.Next(1, rSplit.Length);
                    //create a new sentence less than wordcount rand
                    Random rMxWrds = new Random();
                    int rmLngth = rMxWrds.Next(2, maxWords);
                    Random pickWord = new Random();
                    int pwrd = 0;
                    string word = "";
                    int spCnt = 0;
                    for (int i = 0; i < rmLngth; i++)
                    {
                        pwrd = pickWord.Next(0, rSplit.Length);
                        word = rSplit[pwrd].Trim();
                        if (word == "")
                        {
                            word = "word";

                        }
                        else
                        {
                            if (i == 0)
                            {
                                myWord = word;
                            }
                            else
                            {
                                spCnt++;
                                myWord += " " + word;
                            }
                        }
                    }
                    //ok, have my random sentence, lets create a list) 
                    Random randLL = new Random();
                    int randListLength = randLL.Next(4, maxList);
                    for (int i = 0; i < randListLength; i++)
                    {
                        string bogus = GenComplexString(6, 20);
                        if (!bogus.Contains(" "))
                        {
                            //no spaces so lets throw one in randomly for fun
                            Random bgRand = new Random();
                            for (int j = 0; j < spCnt; j++)
                            {
                                int iSpc = bgRand.Next(2, bogus.Length-1);
                                bogus = bogus.Insert(iSpc, " ");
                            }
                        }
                        rValue.Add(bogus);

                    }
                }

            }
            Random randSlot = new Random();
            int randIndex = randSlot.Next(0, rValue.Count);
            rValue.Insert(randIndex, myWord);
            rValue.Insert(0, randIndex.ToString());
            return rValue;
        }

        public static string GenComplexString(int minLength, int maxLength)
        {
            /*
            this part was taken from a random password generator which I found on google.. probably from MSoft.
            I did not create it, just changed parts to make it work here better.  
             Sorry, I could not find any credits for it, I will happily add in the credits if available.
             */
            int DefMinCharLength = minLength;
            int DefMaxCharLength = maxLength;
            string lCaseChars = "abcdefgijkmnopqrstwxyz";
            string uCaseChars = "ABCDEFGHJKLMNPQRSTWXYZ";
//you can add these back to the random gen'd words/sentences if you want them to have numerics or special chars
//but you must unrem the ones below as well..
            //  string numChars = "12345";
            //  string specChars = "&@!";
            if (minLength < 1)
            {
                minLength = 2;
            }
            if (maxLength < 5)
            {
                maxLength = 5;
            }
            if (minLength > maxLength)
            {
                minLength = 2;
                maxLength = 5;
            }
            //this is the list of character groups
            char[][] charGroups = new char[][] 
        {
            lCaseChars.ToCharArray(),
            uCaseChars.ToCharArray()
           // numChars.ToCharArray(),
          //  specChars.ToCharArray()
        };
            int[] charsLeftInGroup = new int[charGroups.Length];
            for (int i = 0; i < charsLeftInGroup.Length; i++)
                charsLeftInGroup[i] = charGroups[i].Length;
            int[] leftGroupsOrder = new int[charGroups.Length];
            for (int i = 0; i < leftGroupsOrder.Length; i++)
                leftGroupsOrder[i] = i;
            byte[] randomBytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            int seed = (randomBytes[0] & 0x7f) << 24 |
                        randomBytes[1] << 16 |
                        randomBytes[2] << 8 |
                        randomBytes[3];
            Random random = new Random(seed);
            char[] password = null;
            if (minLength < maxLength)
                password = new char[random.Next(minLength, maxLength + 1)];
            else
                password = new char[minLength];
            int nextCharIdx;
            int nextGroupIdx;
            int nextLeftGroupsOrderIdx;
            int lastCharIdx;
            int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
            for (int i = 0; i < password.Length; i++)
            {
                if (lastLeftGroupsOrderIdx == 0)
                    nextLeftGroupsOrderIdx = 0;
                else
                    nextLeftGroupsOrderIdx = random.Next(0,
                                                         lastLeftGroupsOrderIdx);

                nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];
                lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;

                if (lastCharIdx == 0)
                    nextCharIdx = 0;
                else
                    nextCharIdx = random.Next(0, lastCharIdx + 1);

                password[i] = charGroups[nextGroupIdx][nextCharIdx];
                if (lastCharIdx == 0)
                    charsLeftInGroup[nextGroupIdx] =
                                              charGroups[nextGroupIdx].Length;
                else
                {
                    if (lastCharIdx != nextCharIdx)
                    {
                        char temp = charGroups[nextGroupIdx][lastCharIdx];
                        charGroups[nextGroupIdx][lastCharIdx] =
                                    charGroups[nextGroupIdx][nextCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = temp;
                    }
                    charsLeftInGroup[nextGroupIdx]--;
                }

                if (lastLeftGroupsOrderIdx == 0)
                    lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                else
                {
                    if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                    {
                        int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                        leftGroupsOrder[lastLeftGroupsOrderIdx] =
                                    leftGroupsOrder[nextLeftGroupsOrderIdx];
                        leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                    }
                    lastLeftGroupsOrderIdx--;
                }
            }
            return new string(password);
        }
        private List<string> wordList;
        public List<string> WordList
        {
            get { return wordList; }
            set { wordList = value; }
        }
        private int goodIndex;
        public int GoodIndex
        {
            get { return goodIndex; }
            set { goodIndex = value; }
        }
    }
}