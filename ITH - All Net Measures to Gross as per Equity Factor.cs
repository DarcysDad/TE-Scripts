// Loop through all measures in the model
foreach (var measure in Model.AllMeasures)
{
    // Check if the measure name starts with "Sum of" and contains " Net "
    if (measure.Name.StartsWith("Sum of") && measure.Name.Contains(" Net "))
    {
        // Create the new measure name by replacing " Net " with " Gross "
        var newMeasureName = measure.Name.Replace(" Net ", " Gross ");

        // Create the new measure formula, using the DAX object name of the current measure
        var newMeasureFormula = measure.DaxObjectName + " /" + 
    @"
    CALCULATE(
        MAX('Dim Field'[Equity Factor]),
        FILTER(
            'Dim Field',
            'Dim Field'[FieldId] = MAX('Fact Export Production'[FieldId]) &&
            'Dim Field'[ValidFrom] <= MAX('Fact Export Production'[Production Date]) &&
            'Dim Field'[ValidTo] >= MAX('Fact Export Production'[Production Date])
        )
    )
    ";

        // Add the new measure to the model
        var newMeasure = measure.Table.AddMeasure(newMeasureName, newMeasureFormula);

        // Optional: Format the new measure (you can customize the format as needed)
        newMeasure.FormatString = measure.FormatString;
    }
}