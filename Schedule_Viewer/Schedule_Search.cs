﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Schedule_Viewer
{
    public class Schedule_Search
    {
        public String Label { get; set; }
        public String CRN { get; set; }
        public String Subject { get; set; }
        public String Number { get; set; }
        public String Hours { get; set; }
        public String Title { get; set; }
        public String Instructor { get; set; }
        public DropOption Semester { get; set; }
        public DropOption Session { get; set; }
        public DropOption Campus { get; set; }
        public DropOption Dist { get; set; }
        public DropOption Col { get; set; }
        public DropOption Dept { get; set; }
        public DropOption Status { get; set; }
        public DropOption Ssts_code { get; set; }
        public DropOption Crse_levl { get; set; }
        public DropOption Time1 { get; set; }
        public DropOption Ugr { get; set; }
        public bool CheckMon1 { get; set; }
        public bool CheckMon2 { get; set; }
        public bool CheckTues1 { get; set; }
        public bool CheckTues2 { get; set; }
        public bool CheckWed1 { get; set; }
        public bool CheckWed2 { get; set; }
        public bool CheckThurs1 { get; set; }
        public bool CheckThurs2 { get; set; }
        public bool CheckFri1 { get; set; }
        public bool CheckFri2 { get; set; }
        public bool CheckSat1 { get; set; }
        public bool CheckSat2 { get; set; }
        public bool CheckSun1 { get; set; }
        public bool CheckSun2 { get; set; }

        public Schedule_Search(){}

        public Schedule_Search(String label, String crn, String subject, String number,
                String hours, String title, String instructor, DropOption semester,
                DropOption session, DropOption campus, DropOption dist, DropOption col,
                DropOption dept, DropOption status, DropOption ssts_code, DropOption crse_levl,
                DropOption time1, DropOption ugr, bool checkFri1, bool checkFri2, bool checkMon1,
                bool checkMon2, bool checkSat1, bool checkSat2, bool checkSun1, bool checkSun2,
                bool checkThurs1, bool checkThurs2, bool checkTues1, bool checkTues2,
                bool checkWed1, bool checkWed2)
        {
            Label = label;
            CRN = crn;
            Subject = subject;
            Number = number;
            Hours = hours;
            Title = title;
            Instructor = instructor;
            Semester = semester;
            Session = session;
            Campus = campus;
            Dist = dist;
            Col = col;
            Dept = dept;
            Status = status;
            Ssts_code = ssts_code;
            Crse_levl = crse_levl;
            Time1 = time1;
            Ugr = ugr;
            CheckFri1 = checkFri1;
            CheckFri2 = checkFri2;
            CheckMon1 = checkMon1;
            CheckMon2 = checkMon2;
            CheckSat1 = checkSat1;
            CheckSat2 = checkSat2;
            CheckSun1 = checkSun1;
            CheckSun2 = checkSun2;
            CheckThurs1 = checkThurs1;
            CheckThurs2 = checkThurs2;
            CheckTues1 = checkTues1;
            CheckTues2 = checkTues2;
            CheckWed1 = checkWed1;
            CheckWed2 = checkWed2;
        }

        public void EditSearch(String label, String crn, String subject, String number,
                String hours, String title, String instructor, DropOption semester,
                DropOption session, DropOption campus, DropOption dist, DropOption col,
                DropOption dept, DropOption status, DropOption ssts_code, DropOption crse_levl,
                DropOption time1, DropOption ugr, bool checkFri1, bool checkFri2, bool checkMon1,
                bool checkMon2, bool checkSat1, bool checkSat2, bool checkSun1, bool checkSun2,
                bool checkThurs1, bool checkThurs2, bool checkTues1, bool checkTues2,
                bool checkWed1, bool checkWed2)
        {
            Label = label;
            CRN = crn;
            Subject = subject;
            Number = number;
            Hours = hours;
            Title = title;
            Instructor = instructor;
            Semester = semester;
            Session = session;
            Campus = campus;
            Dist = dist;
            Col = col;
            Dept = dept;
            Status = status;
            Ssts_code = ssts_code;
            Crse_levl = crse_levl;
            Time1 = time1;
            Ugr = ugr;
            CheckFri1 = checkFri1;
            CheckFri2 = checkFri2;
            CheckMon1 = checkMon1;
            CheckMon2 = checkMon2;
            CheckSat1 = checkSat1;
            CheckSat2 = checkSat2;
            CheckSun1 = checkSun1;
            CheckSun2 = checkSun2;
            CheckThurs1 = checkThurs1;
            CheckThurs2 = checkThurs2;
            CheckTues1 = checkTues1;
            CheckTues2 = checkTues2;
            CheckWed1 = checkWed1;
            CheckWed2 = checkWed2;
        }

        public override String ToString()
        {
            return Label;
        }
    }
}
