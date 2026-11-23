using System.Net.Sockets;
using System.Text;

public static class TcpZplPrinter
{
    public static async Task SendAsync(
        string printerIp,
        int port,
        string zpl)
    {
	if (string.IsNullOrWhiteSpace(printerIp)) throw new ArgumentException("printer ip can't be empty");

	if (string.IsNullOrWhiteSpace(zpl)) throw new ArgumentException("zpl string can't be empty");
        
	using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        
        using var client =new TcpClient();
        
        //establishing the connection
        await client.ConnectAsync(
            printerIp,
            port,
            timeout.Token);
        
        //converting zpl text into bytes
        byte[] bytes=Encoding.ASCII.GetBytes(zpl);
        //sending the bytes to the printer
        using NetworkStream stream=client.GetStream();
        
        await stream.WriteAsync(bytes, timeout.Token);
        await stream.FlushAsync(timeout.Token);
    }
}