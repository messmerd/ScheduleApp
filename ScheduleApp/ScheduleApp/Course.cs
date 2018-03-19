using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace comp350_semesterproj
{
    enum Build { BAO, HAL, HH, OFFCP, PFAC, PLC, RH, RO, STEM, TBD, NONE };

    public struct Course
    {
        public Build building;
        public int room;

        public string courseDept;
        public int courseNum;
        public char courseSect;
        public string courseCode;// = courseDept + courseNum.toString();

        public string shortName;
        public string longName;

        public int enrollment;
        public int capacity;

        public fixed Tuple<double, double> time[5];

        public Tuple<string, string> professor;
    
    }
}
