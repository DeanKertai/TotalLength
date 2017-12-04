using System;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

[assembly: CommandClass(typeof(TotalLength.Main))]

namespace TotalLength
{

    public class Main
    {

        [CommandMethod("TotalLength", CommandFlags.Modal | CommandFlags.UsePickSet)]
        public void command()
        {
            // Get current selection set from the AutoCAD editor
            PromptSelectionResult result = Application.DocumentManager.MdiActiveDocument.Editor.GetSelection();
            if (result.Status == PromptStatus.OK)
            {
                
            }
            
        }

    }

}
