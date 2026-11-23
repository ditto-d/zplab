string assetId= "AHU-1042";

string zpl=LabelBuilder.Build(assetId);

string outputDirectory= Path.Combine(Directory.GetCurrentDirectory(), "output");

Directory.CreateDirectory(outputDirectory);

string filePath= Path.Combine(outputDirectory, "sample-label.zpl");

await File.WriteAllTextAsync(filePath, zpl);

Console.WriteLine("Label created successfully");
Console.WriteLine($"Asset ID: {assetId}");
Console.WriteLine($"Saved to: {filePath}");
Console.WriteLine();
Console.WriteLine(zpl);
Console.WriteLine("No print job sent");


