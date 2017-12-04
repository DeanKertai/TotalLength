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
                // Get the active document and editor
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;

                // Sum of lengths
                double total = 0;

                //Start a transaction for the active document
                using (Transaction tr = doc.TransactionManager.StartTransaction())
                {

                    // Get array of ObjectIds and iterate
                    ObjectId[] oidArr = result.Value.GetObjectIds();
                    foreach (ObjectId oid in oidArr)
                    {

                        //Check the class name of the object for pertinent types
                        switch (oid.ObjectClass.Name)
                        {
                            // Lines
                            case "AcDbLine":
                                Line line = tr.GetObject(oid, OpenMode.ForRead, false) as Line;
                                if (line != null)
                                {
                                    total += line.Length;
                                }
                                break;

                            // Arcs
                            case "AcDbArc":
                                Arc arc = tr.GetObject(oid, OpenMode.ForRead, false) as Arc;
                                if (arc != null)
                                {
                                    total += arc.Length;
                                }
                                break;

                            // Polylines
                            case "AcDbPolyline":
                                Polyline pline = tr.GetObject(oid, OpenMode.ForRead, false) as Polyline;
                                if (pline != null)
                                {
                                    total += pline.Length;
                                }
                                break;

                            // 2D Polylines
                            case "AcDb2dPolyline":
                                Polyline2d pline2d = tr.GetObject(oid, OpenMode.ForRead, false) as Polyline2d;
                                if (pline2d != null)
                                {
                                    total += pline2d.Length;
                                }
                                break;

                            // 3D Polylines
                            case "AcDb3dPolyline":
                                Polyline3d pline3d = tr.GetObject(oid, OpenMode.ForRead, false) as Polyline3d;
                                if (pline3d != null)
                                {
                                    total += pline3d.Length;
                                }
                                break;

                        }
                    } // End for-loop
                } // End transaction

                //Display message box with total length result 
                System.Windows.MessageBox.Show(string.Format("Total Length = {0:#,##0.000}", total));
            } // End if (PromptStatus == OK)
            
        } // End command method

    } // End class

}
