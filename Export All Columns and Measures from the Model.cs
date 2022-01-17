/* Export Columns and Measures

VERSION: 0.1.0
AUTHOR: SDUFFY
------------------------

DESCRIPTION: Exports a list of Columns and Measures and their details form selected tables to 2 .tsv files
The tsv file can be edited to update exported details in Excel.

INSTRUCTION: 1. C# Script to be executed in Tabular Editor > Adavanced Scripting window
--------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------*/
// EXPORT the names and Detail Rows Expressions for all MEASURES in the Model
var tsv = ExportProperties(Model.AllColumns, "Name,DetailRowsExpression,Description");
SaveFile("C:\\ModelRelationships\\Exported Properties_Columns.tsv", tsv);

// EXPORT the names and Detail Rows Expressions for all COLUMNS in the Model
var tsv2 = ExportProperties(Model.AllMeasures, "Name,DetailRowsExpression,Description");
SaveFile("C:\\ModelRelationships\\Exported Properties_Measures.tsv", tsv2);
