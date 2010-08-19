using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Schedule_Viewer
{
    public partial class Lookup_Form : Form
    {
        public bool initialized;
        public bool editingForm;
        public int selected_Label_Num;
        List<DropOption> SemesterList;
        List<DropOption> SessionList;
        List<DropOption> CampusList;
        List<DropOption> DistanceList;
        List<DropOption> CollegeList;
        List<DropOption> DepartmentList;
        List<DropOption> StatusList;
        List<DropOption> Status2List;
        List<DropOption> LevelList;
        List<DropOption> TimeList;
        List<DropOption> UGRList;
        List<String> SchedulePages = null;
        public List<Schedule_Record> Schedule;
        DropOption blankOption;
        WebClient webClient;
        int termIndex;

        public void InitializeToolTips()
        {
            System.Windows.Forms.ToolTip DistanceTip = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip DistanceComboTip = new System.Windows.Forms.ToolTip();
            DistanceTip.SetToolTip(this.labelDistanceLearning, "Courses offered via alternate teaching methods");
            DistanceComboTip.SetToolTip(this.comboDistanceLearning, "Courses offered via alternate teaching methods");
        }

        /* Load the schedule search website, pull in the options from the website for the various dropdown menus,
         * then fill in the combo boxes for these menus as well as the lists of value pairs (DropOptions)
         */

        public void InitializeLists()
        {
            UTF8Encoding objUTF8;
            String htmlText ="";
            
            // Try to load the staff schedule search website
            try
            {
                webClient = new WebClient();
                const string strUrl = "http://www.registrar.usf.edu/ssearch/staff/staff.php";
                byte[] reqHTML;
                reqHTML = webClient.DownloadData(strUrl);
                objUTF8 = new UTF8Encoding();
                htmlText = objUTF8.GetString(reqHTML);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }


            // Various Regex's to get the various options and value pairs from the website
            // Would love to have direct database access instead of having to use these
            // Tried to use a HTML Parser, but it was abysmally slow compared to loading the page
            // and using regex
            Regex Semester = new Regex("(?s)<SELECT NAME=\"P_SEMESTER\">(.+?)</SELECT>");
            Regex SemesterOption = new Regex("(?m)(?i)<OPTION VALUE=\"(\\d+)\"[^>]*>(.+?)(<.+)?\n|\r$");
            Regex Session = new Regex("(?s)<SELECT NAME=\"P_SESSION\">(.+?)</SELECT>");
            Regex SessionOption = new Regex("(?m)<OPTION VALUE=\"([A-z])\">(.+)\n|\r$");
            Regex Campus = new Regex("(?s)<SELECT NAME=\"P_CAMPUS\">(.+?)</SELECT>");
            Regex CampusOption = new Regex("(?m)<OPTION VALUE=\"([0-9A-z])\">(.+)\n|\r$");
            Regex Dist = new Regex("(?s)<SELECT NAME=\"P_DIST\">(.+?)</SELECT>");
            Regex DistOption = new Regex("(?m)<OPTION VALUE=\"(\\d)\">(.+)\n|\r$");
            Regex Col = new Regex("(?s)<SELECT NAME=\"P_COL\">(.+?)</SELECT>");
            Regex ColOption = new Regex("(?m)<OPTION VALUE=\"([A-Z][A-Z])\">(.+)\n|\r$");
            Regex Dept = new Regex("(?s)<SELECT NAME=\"P_DEPT\">(.+?)</SELECT>");
            Regex DeptOption = new Regex("(?m)<OPTION VALUE=\"([A-Z]{3})\">(.+)\n|\r$");
            Regex Status = new Regex("(?s)<SELECT NAME=\"p_status\">(.+?)</SELECT>");
            Regex StatusOption = new Regex("(?m)<OPTION VALUE=\"([A-Z])\">(.+)\n|\r$");
            Regex Ssts_code = new Regex("(?s)<SELECT NAME=\"p_ssts_code\">(.+?)</SELECT>");
            Regex Ssts_codeOption = new Regex("(?m)<OPTION VALUE=\"([A-Z])\">(.+)\n|\r$");
            Regex Crse_levl = new Regex("(?s)<SELECT NAME=\"P_CRSE_LEVL\">(.+?)</SELECT>");
            Regex Crse_levlOption = new Regex("(?m)<OPTION VALUE=\"([A-Z]{2})\">(.+)\n|\r$");
            Regex Time1 = new Regex("(?s)<SELECT NAME=\"P_TIME1\">(.+?)</SELECT>");
            Regex Time1Option = new Regex("(?m)(?i)<OPTION VALUE=(\'[0-9]{4}\')>(.+)</option>$");
            Regex Ugr = new Regex("(?s)<SELECT NAME=\"P_UGR\">(.+?)</SELECT>");
            Regex UgrOption = new Regex("(?m)<OPTION VALUE=\"([0-9A-z]{4})\">(.+)\n|\r$");

            blankOption = new DropOption();
            blankOption.description = "";
            blankOption.value = "";

            /* The following loops use the Regex's defined above to first search for each option name, 
             * then to pull in the various values for that option. For each option it creates a list
             * and creates a Dropoption value pair, for later submitting to the website.
             * I probably should have used dictionaries, but didn't think to do so at the time.
             */

            // Pull in the list of semesters
            SemesterList = new List<DropOption>();
            foreach (Match m in Semester.Matches(htmlText))
            {
                foreach (Match n in SemesterOption.Matches(m.Groups[1].Value.ToString()))
                {
                    DropOption option = new DropOption();
                    option.value = n.Groups[1].Value.ToString();
                    option.description = n.Groups[2].Value.ToString();
                    comboTerm.Items.Add(option);
                    SemesterList.Add(option);
                }
            }

            // Pull in the summer sessions
            SessionList = new List<DropOption>();
            foreach (Match m in Session.Matches(htmlText))
            {
                foreach (Match n in SessionOption.Matches(m.Groups[1].Value.ToString()))
                {
                    DropOption option = new DropOption();
                    option.value = n.Groups[1].Value.ToString();
                    option.description = n.Groups[2].Value.ToString();
                    comboSession.Items.Add(option);
                    SessionList.Add(option);
                }
            }

            // Pull in the list of campuses
            CampusList = new List<DropOption>();
            foreach (Match m in Campus.Matches(htmlText))
            {
                foreach (Match n in CampusOption.Matches(m.Groups[1].Value.ToString()))
                {
                    DropOption option = new DropOption();
                    option.value = n.Groups[1].Value.ToString();
                    option.description = n.Groups[2].Value.ToString();
                    comboCampus.Items.Add(option);
                    SessionList.Add(option);
                }
            }

            // Pull in the distance learning options
            DistanceList = new List<DropOption>();
            foreach (Match m in Dist.Matches(htmlText))
            {
                foreach (Match n in DistOption.Matches(m.Groups[1].Value.ToString()))
                {
                    DropOption option = new DropOption();
                    option.value = n.Groups[1].Value.ToString();
                    option.description = n.Groups[2].Value.ToString();
                    comboDistanceLearning.Items.Add(option);
                    DistanceList.Add(option);
                }
            }

            // Pull in list of colleges
            CollegeList = new List<DropOption>();
            foreach (Match m in Col.Matches(htmlText))
            {
                foreach (Match n in ColOption.Matches(m.Groups[1].Value.ToString()))
                {
                    DropOption option = new DropOption();
                    option.value = n.Groups[1].Value.ToString();
                    option.description = n.Groups[2].Value.ToString();
                    comboCollege.Items.Add(option);
                    CollegeList.Add(option);
                }
            }

            // List of departments
            DepartmentList = new List<DropOption>();
            foreach (Match m in Dept.Matches(htmlText))
            {
                foreach (Match n in DeptOption.Matches(m.Groups[1].Value.ToString()))
                {
                    DropOption option = new DropOption();
                    option.value = n.Groups[1].Value.ToString();
                    option.description = n.Groups[2].Value.ToString();
                    comboDepartment.Items.Add(option);
                    DepartmentList.Add(option);
                }
            }

            // List of course statuses (usually Open or Closed)
            StatusList = new List<DropOption>();
            foreach (Match m in Status.Matches(htmlText))
            {
                foreach (Match n in StatusOption.Matches(m.Groups[1].Value.ToString()))
                {
                    DropOption option = new DropOption();
                    option.value = n.Groups[1].Value.ToString();
                    option.description = n.Groups[2].Value.ToString();
                    comboStatus.Items.Add(option);
                    StatusList.Add(option);
                }
            }

            // List of secondary course statuses
            Status2List = new List<DropOption>();
            foreach (Match m in Ssts_code.Matches(htmlText))
            {
                foreach (Match n in Ssts_codeOption.Matches(m.Groups[1].Value.ToString()))
                {
                    DropOption option = new DropOption();
                    option.value = n.Groups[1].Value.ToString();
                    option.description = n.Groups[2].Value.ToString();
                    comboStatus2.Items.Add(option);
                    Status2List.Add(option);
                }
            }

            // list of course level (usually Undergraduate, Graduate)
            LevelList = new List<DropOption>();
            foreach (Match m in Crse_levl.Matches(htmlText))
            {
                foreach (Match n in Crse_levlOption.Matches(m.Groups[1].Value.ToString()))
                {
                    DropOption option = new DropOption();
                    option.value = n.Groups[1].Value.ToString();
                    option.description = n.Groups[2].Value.ToString();
                    comboLevel.Items.Add(option);
                    LevelList.Add(option);
                }
            }

            // List of available begin times
            TimeList = new List<DropOption>();
            foreach (Match m in Time1.Matches(htmlText))
            {
                foreach (Match n in Time1Option.Matches(m.Groups[1].Value.ToString()))
                {
                    DropOption option = new DropOption();
                    option.value = n.Groups[1].Value.ToString();
                    option.description = n.Groups[2].Value.ToString();
                    comboTime.Items.Add(option);
                    TimeList.Add(option);
                }
            }

            // List of undergraduate requirements
            UGRList = new List<DropOption>();
            foreach (Match m in Ugr.Matches(htmlText))
            {
                foreach (Match n in UgrOption.Matches(m.Groups[1].Value.ToString()))
                {
                    DropOption option = new DropOption();
                    option.value = n.Groups[1].Value.ToString();
                    option.description = n.Groups[2].Value.ToString();
                    comboUGR.Items.Add(option);
                    UGRList.Add(option);
                }
            }

            // Remove the default option at top of certain combo boxes(causes a weird problem)
            comboCampus.Items.RemoveAt(0);
            comboCollege.Items.RemoveAt(0);
            comboDepartment.Items.RemoveAt(0);
            comboDistanceLearning.Items.RemoveAt(0);
            comboLevel.Items.RemoveAt(0);
            comboSession.Items.RemoveAt(0);
            comboStatus.Items.RemoveAt(0);
            comboStatus2.Items.RemoveAt(0);
            comboTerm.Items.RemoveAt(0);
            comboTime.Items.RemoveAt(0);
            comboUGR.Items.RemoveAt(0);

            // Create a "blank" option at the top of each combo box, default option
            comboCampus.Items.Insert(0, blankOption);
            comboCollege.Items.Insert(0, blankOption);
            comboDepartment.Items.Insert(0, blankOption);
            comboDistanceLearning.Items.Insert(0, blankOption);
            comboLevel.Items.Insert(0, blankOption);
            comboSession.Items.Insert(0, blankOption);
            comboStatus.Items.Insert(0, blankOption);
            comboStatus2.Items.Insert(0, blankOption);
            comboTerm.Items.Insert(0, blankOption);
            comboTime.Items.Insert(0, blankOption);
            comboUGR.Items.Insert(0, blankOption);

         

            comboCampus.SelectedIndex = 0;
            comboCollege.SelectedIndex = 0;
            comboDepartment.SelectedIndex = 0;
            comboDistanceLearning.SelectedIndex = 0;
            comboLevel.SelectedIndex = 0;
            comboSession.SelectedIndex = 0;
            comboStatus.SelectedIndex = 1; // Default to selected Open
            comboStatus2.SelectedIndex = 1; // Default to selected Active
            comboTerm.SelectedIndex = 0;

            // Retrieve current date, and use to pick the term, as the website is often 
            // several terms behind
            String timeString;
            int timeYear = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            // If between January and May, choose summer
            if (month <= 5)
            {
                timeString = timeYear.ToString() + "05";
            }
            // If between June and August, inclusive, choose Fall
            else if (month <= 08)
            {
                timeString = timeYear.ToString() + "08";
            }
            // Otherwise, choose Spring of the next year
            else
            {
                timeYear++;
                timeString = timeYear.ToString() + "01";
            }
            // find the term option that matches the chosen term
            foreach(DropOption checkTime in comboTerm.Items){
                if (checkTime.value == timeString)
                    comboTerm.SelectedItem = checkTime;
            }
            termIndex = comboTerm.SelectedIndex; // save the chosen term for later clearing

            comboTime.SelectedIndex = 0;
            comboUGR.SelectedIndex = 0;


            // Create a new list of schedules, as the program is done initializing
            Schedule = new List<Schedule_Record>();
            initialized = true;
        }

        public Lookup_Form()
        {
            InitializeComponent();
            InitializeToolTips();
            if (!initialized)
                InitializeLists();

            // These should be disabled by default, but if they aren't do it anyways
            buttonEdit.Enabled = false;
            btnRemove.Enabled = false;
            buttonClearList.Enabled = false;
            saveToolStripMenuItem.Enabled = false;


            //SemesterValues.Add();
        }

        // Clear the form
        public void clearItems()
        {
            textCRN.Text = String.Empty;
            textHours.Text = String.Empty;
            textInstructor.Text = String.Empty;
            textLabel.Text = String.Empty;
            textNumber.Text = String.Empty;
            textSubject.Text = String.Empty;
            textTitle.Text = String.Empty;

            checkFri1.Checked = false;
            checkFri2.Checked = false;
            checkMon1.Checked = false;
            checkMon2.Checked = false;
            checkSat1.Checked = false;
            checkSat2.Checked = false;
            checkSun1.Checked = false;
            checkSun2.Checked = false;
            checkThurs1.Checked = false;
            checkThurs2.Checked = false;
            checkTues1.Checked = false;
            checkTues2.Checked = false;
            checkWed1.Checked = false;
            checkWed2.Checked = false;

            comboCampus.SelectedIndex = 0;
            comboCollege.SelectedIndex = 0;
            comboDepartment.SelectedIndex = 0;
            comboDistanceLearning.SelectedIndex = 0;
            comboLevel.SelectedIndex = 0;
            comboSession.SelectedIndex = 0;
            comboStatus.SelectedIndex = 1;
            comboStatus2.SelectedIndex = 1;
            comboTerm.SelectedIndex = termIndex;
            comboTime.SelectedIndex = 0;
            comboUGR.SelectedIndex = 0;
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            clearItems();
        }

        // Clear out the list of searches
        private void buttonClearList_Click(object sender, EventArgs e)
        {
            if (listLabels.Items.Count != 0)
            {
                listLabels.Items.Clear();
            }
            editingForm = false;
            buttonEdit.Enabled = false;
            btnRemove.Enabled = false;
            buttonClearList.Enabled = false;
            btnSearch.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            MessageBox.Show("List cleared");
            btnAddList.Text = "Add To List";
        }

        /* Function to Search based on the list */
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (SchedulePages == null)
                SchedulePages = new List<string>();
            else
            {
                SchedulePages.Clear();
            }

            // Ask if user wants to save the list of searches, if so call function to save to file
            DialogResult result = MessageBox.Show("Do you want to save this search list?", "Save search?", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                saveFunction();
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }

            WebSearch();

            foreach (String page in SchedulePages)
            {
                FactorPage(page);
            }

            // Sort the schedule by courses that are at the same time
            Schedule.Sort(new ScheduleDayComparer());
            Schedule.Sort();

            // Display the list of courses, then clear the list of searches
            Schedule_Viewer.ScheduleView scheduleForm = new Schedule_Viewer.ScheduleView(Schedule);
            scheduleForm.Show(this);
            scheduleForm.BringToFront();
            listLabels.Items.Clear();
            Schedule.Clear();
            btnSearch.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
        }

        // Function to edit an item in the list
        private void buttonEdit_Click(object sender, EventArgs e)
        {

            if (listLabels.SelectedItem == null)
            {
                return;
            }

            // Load the selected search from the list of searches
            Schedule_Search selected_Label = (Schedule_Search)listLabels.SelectedItem;
            if (selected_Label == null)
                return;

            selected_Label_Num = listLabels.SelectedIndex;
            editingForm = true;
            btnAddList.Text = "Save edited item";
            textLabel.Enabled = false;

            // Fill in every item on the form from the selected search
            textCRN.Text = selected_Label.CRN;
            textHours.Text = selected_Label.Hours;
            textInstructor.Text = selected_Label.Instructor;
            textLabel.Text = selected_Label.Label;
            textNumber.Text = selected_Label.Number;
            textSubject.Text = selected_Label.Subject;
            textTitle.Text = selected_Label.Title;

            checkFri1.Checked = selected_Label.CheckFri1;
            checkFri2.Checked = selected_Label.CheckFri2;
            checkMon1.Checked = selected_Label.CheckMon1;
            checkMon2.Checked = selected_Label.CheckMon2;
            checkSat1.Checked = selected_Label.CheckSat1;
            checkSat2.Checked = selected_Label.CheckSat2;
            checkSun1.Checked = selected_Label.CheckSun1;
            checkSun2.Checked = selected_Label.CheckSun2;
            checkThurs1.Checked = selected_Label.CheckThurs1;
            checkThurs2.Checked = selected_Label.CheckThurs2;
            checkTues1.Checked = selected_Label.CheckTues1;
            checkTues2.Checked = selected_Label.CheckTues2;
            checkWed1.Checked = selected_Label.CheckWed1;
            checkWed2.Checked = selected_Label.CheckWed2;

            comboCampus.SelectedItem = selected_Label.Campus;
            comboCollege.SelectedItem = selected_Label.Col;
            comboDepartment.SelectedItem = selected_Label.Dept;
            comboDistanceLearning.SelectedItem = selected_Label.Dist;
            comboLevel.SelectedItem = selected_Label.Crse_levl;
            comboSession.SelectedItem = selected_Label.Session;
            comboStatus.SelectedItem = selected_Label.Status;
            comboStatus2.SelectedItem = selected_Label.Ssts_code;
            comboTerm.SelectedItem = selected_Label.Semester;
            comboTime.SelectedItem = selected_Label.Time1;
            comboUGR.SelectedItem = selected_Label.Ugr;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult areYouSure = MessageBox.Show("Are you sure you want to remove that item?", "Warning", MessageBoxButtons.YesNo);
            if (areYouSure == DialogResult.Yes)
            {
                if(listLabels.SelectedItem != null)
                    listLabels.Items.Remove(listLabels.SelectedItem);
            }
            if (listLabels.Items.Count == 0)
            {
                btnSearch.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                buttonEdit.Enabled = false;
            }
        }

        /* Function that takes the list of searches, and posts each search to the website.
         * Once the results load, the function pulls in the results and saves the resulting HTML as a String
         * in the SchedulePages list.
         ****** IMPORTANT NOTE: EVERY value on the page MUST be in the post, otherwise the results page will 404
         */
        public void WebSearch()
        {
            NameValueCollection collection = new NameValueCollection();
            bool no_check = true; // for no items checked, as page must post a "no_val" value
                                  // for p_day_x and p_day_y (meets only on and at least on, respectively)
            foreach (Schedule_Search search in listLabels.Items)
            {
                collection.Add("P_SEMESTER", search.Semester.value);
                collection.Add("P_SESSION", search.Session.value);
                collection.Add("P_CAMPUS", search.Campus.value);
                collection.Add("P_DIST", search.Dist.value);
                collection.Add("P_COL", search.Col.value);
                collection.Add("P_DEPT", search.Dept.value);
                collection.Add("p_status", search.Status.value);
                collection.Add("p_ssts_code", search.Ssts_code.value);
                collection.Add("P_CRSE_LEVL", search.Crse_levl.value);
                collection.Add("P_REF", search.CRN);
                collection.Add("P_SUBJ", search.Subject);
                collection.Add("P_NUM", search.Number);
                collection.Add("P_TITLE", search.Title);
                collection.Add("P_CR", search.Hours);
                
                // Check the only on list for any checks
                // if none set p_day_x to no_val
                if (search.CheckMon1)
                {
                    collection.Add("p_day_x", "M");
                    no_check = false;
                }
                if (search.CheckTues1)
                {
                    no_check = false;
                    collection.Add("p_day_x", "T");
                }
                if (search.CheckWed1)
                {
                    no_check = false;
                    collection.Add("p_day_x", "W");
                }
                if (search.CheckThurs1)
                {
                    no_check = false;
                    collection.Add("p_day_x", "R");
                }
                if (search.CheckFri1)
                {
                    no_check = false;
                    collection.Add("p_day_x", "F");
                }
                if (search.CheckSat1)
                {
                    no_check = false;
                    collection.Add("p_day_x", "S");
                }
                if (search.CheckSun1)
                {
                    no_check = false;
                    collection.Add("p_day_x", "U");
                }
                if (no_check)
                    collection.Add("p_day_x", "no_val");

                no_check = true;
                // Check the at least on list for any checks
                // if none set p_day_y to no_val
                if (search.CheckMon2)
                {
                    collection.Add("p_day", "M");
                    no_check = false;
                }
                if (search.CheckTues2)
                {
                    no_check = false;
                    collection.Add("p_day", "T");
                }
                if (search.CheckWed2)
                {
                    no_check = false;
                    collection.Add("p_day", "W");
                }
                if (search.CheckThurs2)
                {
                    no_check = false;
                    collection.Add("p_day", "R");
                }
                if (search.CheckFri2)
                {
                    no_check = false;
                    collection.Add("p_day", "F");
                }
                if (search.CheckSat2)
                {
                    no_check = false;
                    collection.Add("p_day", "S");
                }
                if (search.CheckSun2)
                {
                    no_check = false;
                    collection.Add("p_day", "U");
                }
                if (no_check)
                    collection.Add("p_day", "no_val");
                no_check = true; // make sure no_check is true for the next search
                collection.Add("P_TIME1", search.Time1.value);
                collection.Add("P_INSTRUCTOR", search.Instructor);
                collection.Add("P_UGR", search.Ugr.value);

                // Add the referer and upload EVERY value on the page to the post, get response and convert to a string
                webClient.Headers.Add("Referer", "http://www.registrar.usf.edu/ssearch/staff/staff.php");
                byte[] responseArray;
                //****** IMPORTANT NOTE: EVERY value on the page MUST be in the post, otherwise the results page will 404
                try {
                    responseArray = webClient.UploadValues("http://usfonline.admin.usf.edu/pls/prod/wp_staff_search_db", "post", collection);
                    SchedulePages.Add(Encoding.ASCII.GetString(responseArray));
                }
                catch {
                    MessageBox.Show("Could not post values, check your internet connection");
                    Application.Exit();
                }
                // take response page and convert to string. add string the list of schedule pages

                collection.Clear();
            }
        }

        /* Function to take the HTML of a resulting schdule page, and parse 
         * using regexs for the resulting courses
         */
        public void FactorPage(String page){
            // Regexs to get the 
            Regex Table = new Regex("(?s)<TABLE CELLSPACING=\"0\" CELLSPADDING=\"0\" BORDER=\"1\" WIDTH=\"100%\">(.+?)</TABLE>");
            Regex Rows = new Regex("(?s)<(TR|TR BORDERCOLOR=\"#C0C0C0\" BGCOLOR=\"#C0C0C0\")>(.+?)</TR>");
            //Regex Item = new Regex("(?m)(?i)<(?:TD)[^>]+>([^>]+)?(?:<A[^>]+>)*([^>]+|)(?:<\\/A>)*([^>]+|)?<\\/(?:TD)>"); // Thanks to Aaron Kalin
            Regex Item = new Regex("(?s)(?i)<TD[^>]+>(.*?)</TD>");  // Thanks to Aaron Kalin
            Regex Subj = new Regex("(?s)(?i)<A[^>]+>(.*?)</A>");

            // Replace breaks with newlines and non-breaking space tags with actual spaces
            page = page.Replace("<BR>", "\n");
            page = page.Replace("&nbsp;", " ");

            List<String> Items = new List<string>();

            foreach(Match m in Table.Matches(page)){
                foreach(Match n in Rows.Matches(m.Groups[1].Value.ToString())){
                    foreach(Match o in Item.Matches(n.Groups[2].Value.ToString())){
                        Items.Add(o.Groups[1].Value.ToString());
                    }

                    Match subjChange = Subj.Match(Items[4]);
                    Items[4] = subjChange.Groups[1].Value.ToString();
                    if(Items[7].Contains("<A")){
                        Regex removeLink = new Regex("(?s)([^<]+(<A[^>]+>).*?(</A>))"); // regex to remove a hyperlink
                                                                                        // but keep the text
                        MatchCollection linkMatch = removeLink.Matches(Items[7]);
                        foreach(Match i in linkMatch){
                            String sMatch = i.Groups[2].Value.ToString();
                            Items[7] = Items[7].Replace(sMatch, "");
                        }
                        Items[7] = Items[7].Replace("</A>","");
                    }
                    if (Items[7].Contains("<a"))
                    {
                        Regex removeLink = new Regex("(?s)([^<]+(<a[^>]+>).*?(</a>))"); // regex to remove a hyperlink
                                                                                        // but keep the text
                        MatchCollection linkMatch = removeLink.Matches(Items[7]);
                        foreach (Match i in linkMatch)
                        {
                            String sMatch = i.Groups[2].Value.ToString();
                            Items[7] = Items[7].Replace(sMatch, "");
                        }
                        Items[7] = Items[7].Replace("</a>", "");
                    }

                    Schedule_Record newRecord = new Schedule_Record(Items);
                    Items.Clear();
                    if(!newRecord.Error_Detected())
                        Schedule.Add(newRecord);
                }
            }

        }

        private void listLabels_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEdit.Enabled = true;
            btnRemove.Enabled = true;
            buttonClearList.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult areYouSure = MessageBox.Show("Are you sure you want to quit?", "Warning", MessageBoxButtons.YesNo);
            if (areYouSure == DialogResult.Yes)
                Application.Exit();
        }

        // Function to save the list of searches as an XML file with extension .usf
        private void saveFunction()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "USF ScheduleSearch File|*.usf";
            saveFileDialog1.Title = "Save Search List";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                List<Schedule_Search> schedule_list = new List<Schedule_Search>();
                foreach (Schedule_Search item in listLabels.Items)
                {
                    schedule_list.Add(item);
                }

                XmlSerializer s = new XmlSerializer(typeof(List<Schedule_Search>));
                TextWriter w = new StreamWriter(saveFileDialog1.FileName);
                s.Serialize(w, schedule_list);
                w.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFunction();
        }

        // Function to load a list from a .usf xml file
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "USF ScheduleSearch File|*.usf";
            openFileDialog1.Title = "Open Search List";
            openFileDialog1.ShowDialog();

            if(openFileDialog1.FileName != ""){
                if (listLabels.Items.Count != 0)
                {
                    LoadMessageBox mb = new LoadMessageBox();
                    DialogResult dr = mb.ShowDialog(this);
                    if (mb.return_val == 2 || mb.return_val == 1)
                    {
                        XmlSerializer deserializer = new XmlSerializer(typeof(List<Schedule_Search>));
                        TextReader textReader = new StreamReader(openFileDialog1.FileName);
                        List<Schedule_Search> new_list;
                        new_list = (List<Schedule_Search>)deserializer.Deserialize(textReader);
                        if (dr.Equals(2))
                        {
                            listLabels.Items.Clear();
                        }

                        foreach (Schedule_Search record in new_list)
                        {
                            bool exists = false;
                            foreach (Schedule_Search item in listLabels.Items)
                            {
                                String label = item.Label;
                                if (label.Equals(record.Label))
                                {
                                    MessageBox.Show("Label " + record.Label + " already exists in the list, not re-adding.");
                                    exists = true;
                                }
                            }
                            if(!exists)
                                listLabels.Items.Add(record);
                        }
                        textReader.Close();
                    }
                }
                else
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Schedule_Search>));
                    TextReader textReader = new StreamReader(openFileDialog1.FileName);
                    List<Schedule_Search> new_list;
                    new_list = (List<Schedule_Search>)deserializer.Deserialize(textReader);
                    foreach (Schedule_Search record in new_list)
                    {
                        listLabels.Items.Add(record);
                    }
                }
                //verify that after loading that the count is not 0
                if (listLabels.Items.Count != 0)
                {
                    btnSearch.Enabled = true;
                    btnRemove.Enabled = true;
                    buttonClearList.Enabled = true;
                    buttonEdit.Enabled = true;
                }
            }


        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            if (textLabel.TextLength == 0)
            {
                MessageBox.Show("A label for this class search is required.");
                return;
            }
            if (comboTerm.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a term for this class search.");
                return;
            }
            if (!editingForm)
            {
                foreach (Schedule_Search item in listLabels.Items)
                {
                    String label = item.Label;
                    if (label.Equals(textLabel.Text))
                    {
                        MessageBox.Show("Label " + textLabel.Text + " already exists in the list, please choose another label.");
                        return;
                    }
                }
                Schedule_Search newSchedule = new Schedule_Search(textLabel.Text, textCRN.Text, textSubject.Text,
                    textNumber.Text, textHours.Text, textTitle.Text, textInstructor.Text, (DropOption)comboTerm.SelectedItem,
                    (DropOption)comboSession.SelectedItem, (DropOption)comboCampus.SelectedItem,
                    (DropOption)comboDistanceLearning.SelectedItem, (DropOption)comboCollege.SelectedItem,
                    (DropOption)comboDepartment.SelectedItem, (DropOption)comboStatus.SelectedItem,
                    (DropOption)comboStatus2.SelectedItem, (DropOption)comboLevel.SelectedItem,
                    (DropOption)comboTime.SelectedItem, (DropOption)comboUGR.SelectedItem, checkFri1.Checked,
                    checkFri2.Checked, checkMon1.Checked, checkMon2.Checked, checkSat1.Checked, checkSat2.Checked,
                    checkSun1.Checked, checkSun2.Checked, checkThurs1.Checked, checkThurs2.Checked, checkTues1.Checked,
                    checkTues2.Checked, checkWed1.Checked, checkWed2.Checked);
                listLabels.Items.Add(newSchedule);
            }
            else
            {
                Schedule_Search editSearch = (Schedule_Search)listLabels.Items[selected_Label_Num];
                editSearch.EditSearch(textLabel.Text, textCRN.Text, textSubject.Text,
                textNumber.Text, textHours.Text, textTitle.Text, textInstructor.Text, (DropOption)comboTerm.SelectedItem,
                (DropOption)comboSession.SelectedItem, (DropOption)comboCampus.SelectedItem,
                (DropOption)comboDistanceLearning.SelectedItem, (DropOption)comboCollege.SelectedItem,
                (DropOption)comboDepartment.SelectedItem, (DropOption)comboStatus.SelectedItem,
                (DropOption)comboStatus2.SelectedItem, (DropOption)comboLevel.SelectedItem,
                (DropOption)comboTime.SelectedItem, (DropOption)comboUGR.SelectedItem, checkFri1.Checked,
                checkFri2.Checked, checkMon1.Checked, checkMon2.Checked, checkSat1.Checked, checkSat2.Checked,
                checkSun1.Checked, checkSun2.Checked, checkThurs1.Checked, checkThurs2.Checked, checkTues1.Checked,
                checkTues2.Checked, checkWed1.Checked, checkWed2.Checked);
                editingForm = false;
                btnAddList.Text = "Add to List";
                textLabel.Enabled = true;
            }
            btnSearch.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            int selectedTerm = comboTerm.SelectedIndex; // hold the selected term, in case user is wanting to use a different term
            clearItems();
            comboTerm.SelectedIndex = selectedTerm; // set back to user-selected term after clear
            textLabel.Text = String.Empty;
        }

    }
}
