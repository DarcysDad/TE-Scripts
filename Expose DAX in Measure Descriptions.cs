/* Expose the DAX in the Measure Description

VERSION: 0.1.0
AUTHOR: SDUFFY
------------------------

DESCRIPTION: Attach the DAX expression of each measure in the description.
This will allow Citizen Devs to see the DAX when they hover over measures.
Also option to append the actual Description.

INSTRUCTION: C# Script to be executed in Tabular Editor > Adavanced Scripting window
--------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------*/
foreach( var m in Model.AllMeasures) {
    "Description:" + m.Description = m.Expression;
}
