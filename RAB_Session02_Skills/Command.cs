#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace RAB_Session02_Skills
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;


            // read text file data
            var filepath = @"C:\Users\Valued Customer\Desktop\Revit Add-in Academy\Session02_Room List.csv";
            var fileText = System.IO.File.ReadAllText(filepath);

            TaskDialog.Show("Text", fileText);
            var fileArray = System.IO.File.ReadAllLines(filepath);

            foreach (var rowString in fileArray)
            {
                var cellString = rowString.Split(',');
                var roomNumber = cellString[0];
                var roomName = cellString[1];
                var roomArea = cellString[2];
            }
            return Result.Succeeded;
        }
    }
}
