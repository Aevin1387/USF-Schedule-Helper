﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Drawing;

// Added:
using System.IO;

namespace Schedule_Viewer
{
    public partial class ScheduleView : Form
    {
        // define the widths for each colum
        public const int SESSION_W = 60;
        public const int COLLEGE_W = 50;
        public const int DEPARTMENT_W = 50;
        public const int REFERENCE_W = 40;
        public const int COURSE_NUM_W = 72;
        public const int SECTION_W = 40;
        public const int COURSE_TYPE_W = 40;
        public const int COURSE_TITLE_W = 200;
        public const int CREDIT_HRS_W = 38;
        public const int PERMIT_W = 35;
        public const int STATUS_W = 40;
        public const int STATUS2_W = 20;
        public const int SEATS_OPEN_W = 40;
        public const int SEATS_CAP_W = 40;
        public const int SEATS_USED_W = 40;
        public const int DAYS_W = 40;
        public const int TIME_W = 110;
        public const int BUILDING_W = 50;
        public const int ROOM_W = 55;
        public const int INSTRUCTOR_W = 100;
        public const int CAMPUS_W = 50;
        public const int DELIVERY_METHOD_W = 20;
        public const int FEES_W = 100;

        List<Schedule_Record> Schedule;
        List<Schedule_Record> conflictingSchedule;
        // The class that will do the printing process.
        DataGridViewPrinter MyDataGridViewPrinter;

        // set the column widths
        int[] widths = { SESSION_W, REFERENCE_W, COURSE_NUM_W, SECTION_W, COURSE_TITLE_W, 
                         CREDIT_HRS_W, PERMIT_W, STATUS_W, STATUS2_W, SEATS_OPEN_W, 
                         SEATS_CAP_W, DAYS_W, TIME_W, BUILDING_W, ROOM_W, INSTRUCTOR_W, 
                         CAMPUS_W, FEES_W};


        public ScheduleView(List<Schedule_Record> passSchedule)
        {
            InitializeComponent();
            this.Schedule = passSchedule;
            if (this.Schedule.Count == 0)
            {
                MessageBox.Show("No classes matched your search criteria.");
                return;
            }

            find_conflicts();
            conflictingSchedule.RemoveAt(0); // remove first blank in schedule
            conflictingSchedule.RemoveAt(conflictingSchedule.Count - 1); // remove last blank in schedule
            foreach (Schedule_Record schedule in conflictingSchedule)
            {
                try
                {
                    schedule.course_title = schedule.course_title.Replace("\n", " | ");
                    schedule.days = schedule.days.Replace("\n", " | ");
                    schedule.time = schedule.time.Replace("\n", " | ");
                    schedule.building = schedule.building.Replace("\n", " | ");
                    schedule.room = schedule.room.Replace("\n", " | ");
                    schedule.instructor = schedule.instructor.Replace("\n", " | ");
                    //schedule.delivery_method = schedule.delivery_method.Replace("\n", " | ");
                    schedule.fees = schedule.fees.Replace("\n", " | ");
                    schedule.course_title = schedule.course_title.Replace(",", " ");
                    schedule.days = schedule.days.Replace(",", " ");
                    schedule.time = schedule.time.Replace(",", " ");
                    schedule.building = schedule.building.Replace(",", " ");
                    schedule.room = schedule.room.Replace(",", " ");
                    schedule.instructor = schedule.instructor.Replace(",", " ");
                    //schedule.delivery_method = schedule.delivery_method.Replace(",", " ");
                    schedule.fees = schedule.fees.Replace(",", " ");
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }
            dgvSchedule.DataSource = conflictingSchedule;


            DataGridViewColumnCollection cols = dgvSchedule.Columns;
            int col_count = cols.GetColumnCount(DataGridViewElementStates.Visible);
            for (int i = 0; i < col_count && i < widths.Length; i++)
            {
                cols[i].Width = widths[i];
                cols[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        /* Probably the most important function in the entire project
         * This function is used to find which classes conflict with each other
         * and sort the courses based on starting time
         * Its a bit buggy, especially in that it has to go through EACH course
         * and find other courses that conflict with it.
         */
        void find_conflicts()
        {
            Schedule_Record blankSchedule = new Schedule_Record();
            List<List<Schedule_Record>> ScheduleList = new List<List<Schedule_Record>>();
            List<Schedule_Record> mClassSchedule = new List<Schedule_Record>();
            List<Schedule_Record> tClassSchedule = new List<Schedule_Record>();
            List<Schedule_Record> sClassSchedule = new List<Schedule_Record>();
            List<Schedule_Record> multiClassSchedule = new List<Schedule_Record>();
            List<Schedule_Record> otherClassSchedule = new List<Schedule_Record>();

            conflictingSchedule = new List<Schedule_Record>();

            conflictingSchedule.Add(blankSchedule);
            int i, j;
            i = 0; j = 0;

            for (i = 0; i < Schedule.Count; i++)
            {
                if (Schedule[i].getDayType() == 1)
                {
                    mClassSchedule.Add(Schedule[i]);
                }
                else if (Schedule[i].getDayType() == 2)
                {
                    tClassSchedule.Add(Schedule[i]);
                }
                else if (Schedule[i].getDayType() == 4)
                {
                    sClassSchedule.Add(Schedule[i]);
                }
                else if (Schedule[i].getDayType() == 6 || Schedule[i].getDayType() == 3 || Schedule[i].getDayType() == 7)
                {
                    multiClassSchedule.Add(Schedule[i]);
                }
                else if(Schedule[i].getDayType() == 9)
                {
                    otherClassSchedule.Add(Schedule[i]);
                }
                else
                {
                    multiClassSchedule.Add(Schedule[i]);
                }

            }

            foreach (Schedule_Record record in multiClassSchedule)
            {
                List<Schedule_Record> holdMRecords = new List<Schedule_Record>();
                List<Schedule_Record> holdTRecords = new List<Schedule_Record>();
                holdMRecords.Add(record);
                foreach (Schedule_Record testRecord in mClassSchedule)
                {
                    if (record.Conflicts_With(testRecord))
                    {
                        holdMRecords.Add(testRecord);
                    }
                }
                
                holdTRecords.Add(record);
                foreach (Schedule_Record testRecord in tClassSchedule)
                {
                    if (record.Conflicts_With(testRecord))
                        holdTRecords.Add(testRecord);
                }
                //ScheduleList.Add(holdTRecords);

                if (holdMRecords.Count == 1 && holdTRecords.Count != 1)
                    ScheduleList.Add(holdTRecords);
                else if (holdTRecords.Count == 1 && holdMRecords.Count != 1)
                    ScheduleList.Add(holdMRecords);
                else if (holdMRecords.Count == 1 && holdTRecords.Count == 1)
                    ScheduleList.Add(holdMRecords);
                else
                {
                    ScheduleList.Add(holdMRecords);
                    ScheduleList.Add(holdTRecords);
                }

            }

            for (i = 0; i < mClassSchedule.Count; i++)
            {
                foreach (List<Schedule_Record> recordList in ScheduleList)
                {
                    if (i >= 0 && recordList.Contains(mClassSchedule[i]))
                    {
                        mClassSchedule.RemoveAt(i);
                        i--;
                    }
                }
            }
            for (i = 0; i < tClassSchedule.Count; i++)
            {
                foreach (List<Schedule_Record> recordList in ScheduleList)
                {
                    if (i >= 0 && recordList.Contains(tClassSchedule[i]))
                    {
                        tClassSchedule.RemoveAt(i);
                        i--;
                    }
                }
            }


            for (i = 0; i < mClassSchedule.Count; i++)
            {
                List<Schedule_Record> holdItems = new List<Schedule_Record>();
                holdItems.Add(mClassSchedule[i]);
                for (j = i + 1; j < mClassSchedule.Count; j++)
                {
                    if (!conflictingSchedule.Contains(mClassSchedule[j])
                       && mClassSchedule[i].Conflicts_With(mClassSchedule[j]))
                        holdItems.Add(mClassSchedule[j]);
                }
                if (holdItems.Count > 1)
                {
                    holdItems.Add(blankSchedule);
                    conflictingSchedule.AddRange(holdItems);
                }
                else if (holdItems.Count == 1 && !conflictingSchedule.Contains(holdItems[0]))
                {
                    holdItems.Add(blankSchedule);
                    conflictingSchedule.AddRange(holdItems);
                }
            }

            for (i = 0; i < tClassSchedule.Count; i++)
            {
                List<Schedule_Record> holdItems = new List<Schedule_Record>();
                holdItems.Add(tClassSchedule[i]);
                for (j = i + 1; j < tClassSchedule.Count; j++)
                {
                    if (!conflictingSchedule.Contains(tClassSchedule[j])
                       && tClassSchedule[i].Conflicts_With(tClassSchedule[j]))
                        holdItems.Add(tClassSchedule[j]);
                }
                if (holdItems.Count > 1)
                {
                    holdItems.Add(blankSchedule);
                    conflictingSchedule.AddRange(holdItems);
                }
                else if (holdItems.Count == 1 && !conflictingSchedule.Contains(holdItems[0]))
                {
                    holdItems.Add(blankSchedule);
                    conflictingSchedule.AddRange(holdItems);
                }
            }

            for (i = 0; i < sClassSchedule.Count; i++)
            {
                List<Schedule_Record> holdItems = new List<Schedule_Record>();
                holdItems.Add(sClassSchedule[i]);
                for (j = i + 1; j < sClassSchedule.Count; j++)
                {
                    if (!conflictingSchedule.Contains(sClassSchedule[j])
                       && sClassSchedule[i].Conflicts_With(sClassSchedule[j]))
                        holdItems.Add(sClassSchedule[j]);
                }
                if (holdItems.Count > 1)
                {
                    holdItems.Add(blankSchedule);
                    conflictingSchedule.AddRange(holdItems);
                }
                else if (holdItems.Count == 1 && !conflictingSchedule.Contains(holdItems[0]))
                {
                    holdItems.Add(blankSchedule);
                    conflictingSchedule.AddRange(holdItems);
                }
            }

            foreach (List<Schedule_Record> recordList in ScheduleList)
            {
                foreach (Schedule_Record record in recordList)
                {
                    conflictingSchedule.Add(record);
                }
                conflictingSchedule.Add(blankSchedule);
            }

            foreach (Schedule_Record record in otherClassSchedule)
            {
                conflictingSchedule.Add(record);
                conflictingSchedule.Add(blankSchedule);
            }
            //conflictingSchedule.RemoveAt(conflictingSchedule.Count - 1);

            /*for (i = 0; i < Schedule.Count; i++)
            {
                List<Schedule_Record> holdItems = new List<Schedule_Record>();
                holdItems.Add(Schedule[i]);
                for(j = i + 1; j < Schedule.Count; j++)
                {
                    if(!conflictingSchedule.Contains(Schedule[j])
                       && Schedule[i].Conflicts_With(Schedule[j]))
                          holdItems.Add(Schedule[j]);
                }
                if (holdItems.Count > 1)
                {
                    holdItems.Add(blankSchedule);
                    conflictingSchedule.AddRange(holdItems);
                }
                else if (holdItems.Count == 1 && !conflictingSchedule.Contains(holdItems[0]))
                {
                    holdItems.Add(blankSchedule);
                    conflictingSchedule.AddRange(holdItems);
                }
            }*/


        }

        private String createRecordString(Schedule_Record cRecord)
        {
            String returnString = "";
            returnString += cRecord.session;
            //returnString += "," + cRecord.college;
            //returnString += "," + cRecord.department;
            returnString = cRecord.reference;
            returnString += "," + cRecord.course_number;
            returnString += "," + cRecord.section;
            //returnString += "," + cRecord.course_type;
            returnString += "," + cRecord.course_title;
            returnString += "," + cRecord.credit_hours;
            returnString += "," + cRecord.permit;
            returnString += "," + cRecord.status;
            returnString += "," + cRecord.seats_open;
            //returnString += "," + cRecord.seats_cap;
            //returnString += "," + cRecord.seats_used;
            returnString += "," + cRecord.days;
            returnString += "," + cRecord.time;
            returnString += "," + cRecord.building;
            returnString += "," + cRecord.room;
            returnString += "," + cRecord.instructor;
            returnString += "," + cRecord.campus;
            //returnString += "," + cRecord.delivery_method;
            returnString += "," + cRecord.fees;


            return returnString;
        }

        // Function to save a list of courses as a csv file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.DefaultExt = ".csv";
            fileDialog.AddExtension = true;
            fileDialog.ShowDialog();
            Stream fileStream = null;
            StreamWriter writeStream = null;
            try
            {
                fileStream = fileDialog.OpenFile();
                writeStream = new StreamWriter(fileStream);
            }
            catch (FileNotFoundException Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }
            foreach (Schedule_Record record in conflictingSchedule)
            {
                //StreamWriter writeStream = new StreamWriter(fileStream);
                String recordString = createRecordString(record);
                writeStream.WriteLine(recordString);
            }
            writeStream.Close();
            //fileStream.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // The PrintPage action for the PrintDocument control
        private void MyPrintDocument_PrintPage(object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            MyPrintDocument.DocumentName = "Schedule Report";
            MyPrintDocument.PrinterSettings =
                                MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings =
            MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins =
                             new Margins(40, 40, 40, 40);

            MyPrintDocument.DefaultPageSettings.Landscape = true;

            MyDataGridViewPrinter = new DataGridViewPrinter(dgvSchedule,
                MyPrintDocument, false, true, "ScheduleViewer", new Font("Tahoma", 18,
                FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            foreach (int i in widths)
            {
                Font tmpFont = dgvSchedule.ColumnHeadersDefaultCellStyle.Font;
                //System.Drawing.SizeConverter
                MyDataGridViewPrinter.ColumnsWidth.Add(i * tmpFont.Size / (float)8.75);
            }

            return true;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MyPrintDocument = new PrintDocument();
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage);
            if (SetupThePrinting())
                MyPrintDocument.Print();

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 
            // MyPrintDocument
            //
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage);

            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }
    }
}