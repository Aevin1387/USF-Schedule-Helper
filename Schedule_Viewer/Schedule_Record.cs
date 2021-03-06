﻿using System;
using System.Collections.Generic;

namespace Schedule_Viewer
{

    /* This class is used to compare two different courses, and find which is before the other */
    public class ScheduleDayComparer : IComparer<Schedule_Record>
    {
        

        public int Compare(Schedule_Record a, Schedule_Record b)
        {
            int aDayType = 0;
            int bDayType = 0;

            if (a.days.Length == 0 && b.days.Length == 0)
                return 0;
            else if (a.days.Length == 0)
                return -1;
            else if (b.days.Length == 0)
                return 1;

            if ((a.days.ToUpper().Contains("M")) || (a.days.ToUpper().Contains("W")) || (a.days.ToUpper().Contains("F")))
                aDayType += 1;
            if ((a.days.ToUpper().Contains("T") && !(a.days.ToUpper()).Contains("TBA")) || (a.days.ToUpper().Contains("R")))
                aDayType += 2;
            if ((a.days.ToUpper().Contains("S")) || (a.days.ToUpper().Contains("U")))
                aDayType += 4;
            if(a.days.ToUpper().Contains("TBA"))
                aDayType = 9;

            if ((b.days.ToUpper().Contains("M")) || (b.days.ToUpper().Contains("W")) || (b.days.ToUpper().Contains("F")))
                bDayType += 1;
            if ((b.days.ToUpper().Contains("T") && !(b.days.ToUpper()).Contains("TBA")) || (b.days.ToUpper().Contains("R")))
                bDayType += 2;
            if ((b.days.ToUpper().Contains("S")) || (b.days.ToUpper().Contains("U")))
                bDayType += 4;
            if (b.days.ToUpper().Contains("TBA"))
                bDayType = 9;

            if (aDayType > bDayType)
                return 1;
            else if (aDayType < bDayType)
                return -1;
            else
                return 0;
            

        }
    }

    // The actual record for each course, as well as functions for comparing course times
    public class Schedule_Record : IComparable
    {
        public String session { get; set; }
        private String college { get; set; }
        private String department { get; set; }
        public String reference { get; set; }
        public String course_number { get; set; }
        public String section { get; set; }
        private String course_type { get; set; }
        public String course_title { get; set; }
        public String credit_hours { get; set; }
        public String permit { get; set; }
        public String status { get; set; }
        public String status2 { get; set; }
        public String seats_open { get; set; }
        public String seats_cap { get; set; }
        private String seats_used { get; set; }
        public String days { get; set; }
        public String time { get; set; }
        public String building { get; set; }
        public String room { get; set; }
        public String instructor { get; set; }
        public String campus { get; set; }
        private String delivery_method { get; set; }
        public String fees { get; set; }
        private bool error_detected { get; set; }

        public bool Error_Detected()
        {
            return error_detected;
        }

        public bool Meets_on_Same_Day_As(Schedule_Record other)
        {
            foreach (Char c in days)
            {
                if (other.days.IndexOf(c) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Get the start time for a course. If a course has multiple times
        // This function (for now) returns the earliest start time
        public DateTime Start_Time()
        {
            DateTime start_time;
            if (time.Contains("TBA"))
                return DateTime.MaxValue;
            else if (!time.Contains("\n"))
            {
                String[] times = time.Split('-');
                start_time = DateTime.Parse(times[0]);
            }
            else
            {
                String[] timeSets = time.Split('\n');
                List<String> start_times = new List<String>();
                foreach (String timing in timeSets)
                {
                    String[] times = timing.Split('-');
                    start_times.Add(times[0]);
                }
                start_time = DateTime.Parse(start_times[0]);
                foreach (String timer in start_times)
                {
                    if (DateTime.Parse(timer) < start_time)
                        start_time = DateTime.Parse(timer);
                }
            }
            return start_time;
        }

        // Get the end time for a course. If a course has multiple times
        // This function (for now) returns the latest end time
        public DateTime End_Time()
        {
            DateTime end_time;
            if (time.Contains("TBA"))
                return DateTime.MaxValue;
            else if (!time.Contains("\n"))
            {
                String[] times = time.Split('-');
                end_time = DateTime.Parse(times[1]);
            }
            else
            {
                String[] timeSets = time.Split('\n');
                List<String> end_times = new List<String>();
                foreach (String timing in timeSets)
                {
                    String[] times = timing.Split('-');
                    end_times.Add(times[1]);
                }
                end_time = DateTime.Parse(end_times[0]);
                foreach (String timer in end_times)
                {
                    if (DateTime.Parse(timer) > end_time)
                        end_time = DateTime.Parse(timer);
                }
            }
            return end_time;
        }

        public bool Starts_Before_End_Of(Schedule_Record other)
        {
            return this.Start_Time() < other.End_Time();
        }

        public bool Class_Times_Overlap(Schedule_Record other)
        {
            return (this.Starts_Before_End_Of(other) &&
                    other.Starts_Before_End_Of(this));
        }

        public bool Conflicts_With(Schedule_Record other)
        {
            if (this.Meets_on_Same_Day_As(other))
            {
                if (this.Class_Times_Overlap(other))
                {
                    return true;
                }
            }
            return false;
        }
    
        private bool isDay(char day)
        {
            char upperDay = char.ToUpper(day);

            if(upperDay != 'M' && upperDay != 'T' && upperDay != 'W' 
               && upperDay != 'R' && upperDay != 'F' && upperDay != 'S'){
                    return false;
            }

            return true;
        }

        // Constructor
        public Schedule_Record()
        {
            session = "";
            college = "";
            department = "";
            reference = "";
            course_number = "";
            section = "";
            course_type = "";
            course_title = "";
            credit_hours = "";
            permit = "";
            status = "";
            status2 = "";
            seats_open = "";
            seats_cap = "";
            seats_used = "";
            days = "";
            time = "";
            building = "";
            room = "";
            instructor = "";
            campus = "";
            delivery_method = "";
            fees = "";
            error_detected = false;
        }


        // Constructor based on a list of strings
        public Schedule_Record(List<String> Schedule_Info)
        {
            if ((Schedule_Info.Count < 21) || 
                ((Schedule_Info[1] != "EN") && (Schedule_Info[1] != "AS")
                 && (Schedule_Info[1] != "BC") && (Schedule_Info[1] != "BA")
                 && (Schedule_Info[1] != "AM") && (Schedule_Info[1] != "FA")
                 && (Schedule_Info[1] != "ED") && (Schedule_Info[1] != "HC")
                 && (Schedule_Info[1] != "HM") && (Schedule_Info[1] != "MD")
                 && (Schedule_Info[1] != "NR") && (Schedule_Info[1] != "PH")
                 && (Schedule_Info[1] != "US")))
            {
                error_detected = true;
                return;
            }

            session = Schedule_Info[0];
            college = Schedule_Info[1];
            department = Schedule_Info[2];
            reference = Schedule_Info[3];
            course_number = Schedule_Info[4];
            section = Schedule_Info[5];
            course_type = Schedule_Info[6];
            course_title = Schedule_Info[7];
            credit_hours = Schedule_Info[8];
            permit = Schedule_Info[9];
            status = Schedule_Info[10];
            status2 = Schedule_Info[11];
            seats_open = Schedule_Info[12];
            seats_cap = Schedule_Info[13];
            seats_used = Schedule_Info[14];
            days = Schedule_Info[15];
            time = Schedule_Info[16];
            building = Schedule_Info[17];
            room = Schedule_Info[18];
            instructor = Schedule_Info[19];
            campus = Schedule_Info[20];
            delivery_method = Schedule_Info[21];
            fees = Schedule_Info[22];
            error_detected = false;
        }

        public int CompareTo(object o)
        {
            Schedule_Record other = (Schedule_Record) o;
            if (this.Start_Time() > other.Start_Time())
            {
                return 1;
            }
            else if (this.Start_Time() < other.Start_Time())
            {
                return -1;
            }
            else
                return 0;
        }

        public int getDayType()
        {
            int aDayType = 0;
            if ((days.ToUpper().Contains("M")) || (days.ToUpper().Contains("W")) || (days.ToUpper().Contains("F")))
                aDayType += 1;
            if ((days.ToUpper().Contains("T") && !(days.ToUpper()).Contains("TBA")) || (days.ToUpper().Contains("R")))
                aDayType += 2;
            if ((days.ToUpper().Contains("S")) || (days.ToUpper().Contains("U")))
                aDayType += 4;
            if (days.ToUpper().Contains("TBA"))
                aDayType = 9;

            return aDayType;
        }
    }
}
