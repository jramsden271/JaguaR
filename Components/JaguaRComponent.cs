using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace JaguaR.Components
{
    public class JaguaRComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public JaguaRComponent()
            : base("Find slow components", "Speed",
                "Finds the slowest components in the canvas",
                "JaguaR", "Developer")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("threshold", "threshold", "threshold", GH_ParamAccess.item);
            pManager.AddBooleanParameter("refresh", "refresh", "refresh", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {


            


        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            int threshold = -1;
            bool refresh = false;

            DA.GetData(0, ref threshold);
            DA.GetData(1, ref refresh);

            int found = 0;
            Message = "None found";

            foreach (var obj in OnPingDocument().Objects)
            {
                var para = obj as Grasshopper.Kernel.GH_ActiveObject;
                if (para != null)
                {
                    if (para.ProcessorTime.Milliseconds > threshold)
                    {
                        para.Attributes.Selected = true;
                        found++;
                    }
                    else
                    {
                        para.Attributes.Selected = false;
                    }
                }
            }
            Message = found.ToString() + " found";

        }


        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{2e701d39-5e2d-4979-8b66-531d0fb7b30e}"); }
        }

        public override void CreateAttributes()
        {
            base.CreateAttributes();
            //m_attributes = new CustomAttributes2(this);
        }
    }
}
