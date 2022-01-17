/* Build a COUNTROWS Measure

VERSION: 0.1.0
AUTHOR: SDUFFY
------------------------

DESCRIPTION: Builds a COUNTROWS Measure for each of the selected tables.

INSTRUCTION: 1. C# Script to be executed in Tabular Editor > Adavanced Scripting window.
Select a bunch of measures and run the script
--------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------*/

// Creates a COUNTROWS Measure for each table selected
foreach(var m in Selected.Tables) {
    m.AddMeasure(
      m.Name + " Count",                                        // Name
      "CALCULATE( COUNTROWS( " + m.DaxObjectName + "))"      // DAX expression
     );

}
