/* Hide All some columns

VERSION: 0.1.0
AUTHOR: SDUFFY
------------------------

DESCRIPTION: Loop through all tables in the model and hide the column that end with...
 'DimKey'
 'Batch ID'
 'Last Modified'

INSTRUCTION: C# Script to be executed in Tabular Editor > Adavanced Scripting window
--------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------*/
foreach(var column in Model.Tables.SelectMany(t => t.Columns)) {
    if(column.Name.EndsWith("DimKey")) {
    column.IsHidden = true;
    }
     else if (column.Name.EndsWith("Batch ID")){
     column.IsHidden = true;
 }
      else if (column.Name.EndsWith("Last Modified")){
      column.IsHidden = true;
 }
}
