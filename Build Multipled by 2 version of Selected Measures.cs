/* Builds a x2 Measure

VERSION: 0.1.0
AUTHOR: SDUFFY
------------------------

DESCRIPTION: Builds a (Multiplied by 2) version of selected measures. Especially useful
for the Max measure in 'Gauge visuals'

INSTRUCTION: 1. C# Script to be executed in Tabular Editor > Adavanced Scripting window.
Select a bunch of measures and run the script
--------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------*/

// Creates a (Multiplied by 2) measure for every selected measure.
foreach(var m in Selected.Measures) {
    m.Table.AddMeasure(
    m.Name + " x 2",                                        // Name
        m.DaxObjectName + " * 2",                           // DAX expression
        m.DisplayFolder                                     // Display Folder
    );
}
