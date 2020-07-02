using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class doctor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortname { get; set; }
        public string pass { get; set; }
        public string sex { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public double MRI { get; set; }
        public double CT { get; set; }
        public int peemission { get; set; }
        public double DX { get; set; }
        public double US { get; set; }
        public double EO { get; set; }
        public double PET { get; set; }
        public double MAMO { get; set; }
    }

    public class createDoctor : doctor
    {
    }

    public class readDoctor : doctor
    {
        
        public readDoctor(DataRow row)
        {
            id = Convert.ToInt32(row["ID"]);
            name = row["Name"].ToString();
            shortname = row["ShortName"].ToString();
            pass = row["pass"].ToString();  
            sex = row["sex"].ToString();
            address = row["address"].ToString();
            email = row["email"].ToString();
            double mri = 0;
            double.TryParse(row["MRI"].ToString(), out mri);
            MRI = mri;
            double ct = 0;
            double.TryParse(row["MRI"].ToString(), out ct);
            CT = ct;
            peemission = Convert.ToInt32(row["permission"]);
            double dx = 0;
            double.TryParse(row["DX"].ToString(), out dx);
            DX = dx;
            double us = 0;
            double.TryParse(row["US"].ToString(), out us);
            US = us;
            double eo = 0;
            double.TryParse(row["EO"].ToString(), out eo);
            EO = eo;
            double pet = 0;
            double.TryParse(row["PET"].ToString(), out pet);
            PET = pet;
            double mamo = 0;
            double.TryParse(row["MAMO"].ToString(), out mamo);
            MAMO = mamo;
        }
    }
}