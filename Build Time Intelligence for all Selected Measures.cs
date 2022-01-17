/* Build time intelligence for all selected measures

VERSION: 0.1.0
SOURCE: https://docs.tabulareditor.com/te2/Useful-script-snippets.html
------------------------

DESCRIPTION: Create YTD, PY, YoY, YoY%, QTD, MTD time intelligence measures for all selected
measures.

INSTRUCTION: C# Script to be executed in Tabular Editor > Adavanced Scripting window
--------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------*/
var dateColumn = "'Date Dim'[Date]";

// Creates time intelligence measures for every selected measure:
foreach(var m in Selected.Measures) {
    // Year-to-date:
    m.Table.AddMeasure(
        m.Name + " YTD",                                       // Name
        "TOTALYTD(" + m.DaxObjectName + ", " + dateColumn + ")",     // DAX expression
        m.DisplayFolder                                        // Display Folder
    );

    // Previous year:
    m.Table.AddMeasure(
        m.Name + " PY",                                       // Name
        "CALCULATE(" + m.DaxObjectName + ", SAMEPERIODLASTYEAR(" + dateColumn + "))",     // DAX expression
        m.DisplayFolder                                        // Display Folder
    );

    // Year-over-year
    m.Table.AddMeasure(
        m.Name + " YoY",                                       // Name
        m.DaxObjectName + " - [" + m.Name + " PY]",            // DAX expression
        m.DisplayFolder                                        // Display Folder
    );

    // Year-over-year %:
    m.Table.AddMeasure(
        m.Name + " YoY%",                                           // Name
        "DIVIDE(" + m.DaxObjectName + ", [" + m.Name + " YoY])",    // DAX expression
        m.DisplayFolder                                             // Display Folder
    ).FormatString = "0.0 %";  // Set format string as percentage

    // Quarter-to-date:
    m.Table.AddMeasure(
        m.Name + " QTD",                                            // Name
        "TOTALQTD(" + m.DaxObjectName + ", " + dateColumn + ")",    // DAX expression
        m.DisplayFolder                                             // Display Folder
    );

    // Month-to-date:
    m.Table.AddMeasure(
        m.Name + " MTD",                                       // Name
        "TOTALMTD(" + m.DaxObjectName + ", " + dateColumn + ")",     // DAX expression
        m.DisplayFolder                                        // Display Folder
    );
}
