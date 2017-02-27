using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ALS.Cls
{
[DataContract(Name="Model_PatientInfo")]
    class Model_PatientInfo
    {
        //START:{“alarmPerson”:”13073863816”,”description":"肝癌","doctor":"kk",“doctorId":"jj",
        //"endTime":0,"id":0,"lastAlarm":0,"patient":"zz","patientId":"mm",”startTime”:0,"
        //state":0,"surgeryNo":"19920327"}
        private string alarmPerson = "13963145201";
        [DataMember(Name="alarmPerson")]
        public string AlarmPerson
        {
            get { return alarmPerson; }
            set { alarmPerson = value; }
        }
        private string description = "肝炎";
        [DataMember(Name = "description")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string doctor = "章医生";
         [DataMember(Name = "doctor")]
        public string Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }
        private string doctorID = "0";
         [DataMember(Name = "doctorID")]
        public string DoctorID
        {
            get { return doctorID; }
            set { doctorID = value; }
        }
        private int endTime = 0;
         [DataMember(Name = "endTime")]
        public int EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private int id = 0;
         [DataMember(Name = "id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int lastAlarm = 0;
         [DataMember(Name = "lastAlarm")]
        public int LastAlarm
        {
            get { return lastAlarm; }
            set { lastAlarm = value; }
        }
        private string patient = "zz";
         [DataMember(Name = "patient")]
        public string Patient
        {
            get { return patient; }
            set { patient = value; }
        }
        private string patientID = "mm";
         [DataMember(Name = "patientID")]
        public string PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }
        private string startTime = "0";
         [DataMember(Name = "startTime")]
        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private int state = 0;
         [DataMember(Name = "state")]
        public int State
        {
            get { return state; }
            set { state = value; }
        }
        private string surgeryNo = DateTime.Now.ToString("yyMMddHHmmss");
         [DataMember(Name = "surgeryNo")]
        public string SurgeryNo
        {
            get { return surgeryNo; }
            set { surgeryNo = value; }
        }
        
        private string type = "PE";
        [DataMember(Name = "type")]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
