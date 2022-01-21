/* Create an explicit measure as a SUM of the Implicit Column
VERSION: 0.1.0
AUTHOR: SDUFFY
------------------------
DESCRIPTION: Creates a SUM measure for every currently selected column.  The name of the new AddMeasure
Will be the column name minus the first character (It is anticipated that the Column name Will
be prefixed with a single special character to differentiate it form the measure name)
INSTRUCTION: C# Script to be executed in Tabular Editor > Adavanced Scripting window
--------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------*/
// Creates a SUM measure for every currently selected column and hide the column.
foreach(var c in Selected.Columns)
{
    //Setup a string to be that of the Column name minus the first character
    string ImplicitName = c.Name;
    string ExplicitName = ImplicitName.Substring(1);
    string LeftChar = ".";
    string Compare = ImplicitName.Left(1);

    if (String.Equals(LeftChar,Compare))
{
    var newMeasure = c.Table.AddMeasure(
        ExplicitName,                          // Name
        "SUM(" + c.DaxObjectFullName + ")",    // DAX expression
        c.DisplayFolder                        // Display Folder
    );

    // Set the format string on the new measure:
    newMeasure.FormatString = "0.00";

    // Provide some documentation:
    newMeasure.Description = "This measure is the sum of column " + c.DaxObjectFullName;

    // Hide the base column:
    c.IsHidden = true;
}
}