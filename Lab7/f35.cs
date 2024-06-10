using System;

class F35
{
    public void RunTR3()
    {
        Console.WriteLine("F-35 is running TR3 Tactical Reconnaissance program.");
        Console.WriteLine("Gathering reconnaissance data...");
        // Simulate reconnaissance operations
        Console.WriteLine("Reconnaissance data collected.");

        // Thêm chức năng xử lý dữ liệu và gửi dữ liệu đến trạm điều khiển
        ProcessData();
        SendDataToControlStation();
    }

    private void ProcessData()
    {
        Console.WriteLine("Processing reconnaissance data...");
        // Giả lập xử lý dữ liệu
        Console.WriteLine("Reconnaissance data processed.");
    }

    private void SendDataToControlStation()
    {
        Console.WriteLine("Sending reconnaissance data to control station...");
        // Giả lập gửi dữ liệu
        Console.WriteLine("Reconnaissance data sent to control station.");
    }

    public void TakeOff()
    {
        Console.WriteLine("F-35 is taking off...");
        // Giả lập quá trình cất cánh
        Console.WriteLine("F-35 is airborne.");
    }

    public void Land()
    {
        Console.WriteLine("F-35 is landing...");
        // Giả lập quá trình hạ cánh
        Console.WriteLine("F-35 has landed.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        F35 f35 = new F35();
        f35.TakeOff(); // Cất cánh
        f35.RunTR3(); // Chạy chương trình TR3
        f35.Land(); // Hạ cánh
    }
}
