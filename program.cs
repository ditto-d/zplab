string assetId= "AHU-1042";

string zpl=LabelBuilder.Build(assetId);

string outputDirectory= Path.Combine(Directory.GetCurrentDirectory(), "output");

Directory.CreateDirectory(outputDirectory);

string filePath= Path.Combine(outputDirectory, "sample-label.zpl");

await File.WriteAllTextAsync(filePath, zpl);

Console.WriteLine("Label created successfully");
Console.WriteLine($"Asset ID: {assetId}");
Console.WriteLine($"Saved to: {filePath}");

bool printEnabled=Environment.GetEnvironmentVariable("PRINT_ENABLED") == "true";

if (!printEnabled)
{
    Console.Write("Print mode disabled");
    return;
}

string? printerIp= Environment.GetEnvironmentVariable("PRINTER_IP");

if (string.IsNullOrEmpty(printerIp))
{
    Console.WriteLine("Printer mode enabled, but IP is missing");
    return;
}

try
{
    Console.WriteLine($"Connecting to printer at {printerIp}:9100...");
    await TcpZplPrinter.SendAsync(printerIp, 9100, zpl);
    
    Console.WriteLine("ZPL data sent to printer");
}
catch (Exception ex)
{
    Console.WriteLine($"Print failed: {ex.Message}");
}