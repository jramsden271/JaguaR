﻿using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace JaguaR
{
    public class JaguaRInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "JaguaR";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("1b958693-8bb0-4716-b872-b3a09f00c8be");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "Buro Happold";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
