using System;
using OpenTK;
using System.IO;
using System.Collection.Generic;
using OpenTK.Graphics.OpenGL;

interface IDataDevice
{
    // Gửi dữ liệu
    void SendData(string data);
    // Nhận dữ liệu
    string ReceiveData();
}
class ControlStation : IDataDevice
{
    public void SendData(string data)
    {
        Console.WriteLine("Control station sends data: " + data);
        // Giả lập việc gửi dữ liệu đến trạm điều khiển
    }

    public string ReceiveData()
    {
        string data = "Reconnaissance data from F-35";
        Console.WriteLine("Control station receives data: " + data);
        // Giả lập việc nhận dữ liệu từ trạm điều khiển
        return data;
    }
}
public class Weapon
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int Priority { get; set; }
    public int Quantity { get; set; }  // Số lượng (lượng vũ)
    // public Weapon TargetWeapon { get; set; } // Vũ khí của mục tiêu

    // Constructor
    public Target(string name, string location, int priority, int quantity)
    {
        Name = name;
        Location = location;
        Priority = priority;
        Quantity = quantity;
    }
}
class Target
{
    public string Name {get; set;}
    public string Nation {get; set;}
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }

    public Target(string name, string quocgia, float x, float y, float z)
    {
        // Tọa độ x,y,z của chúng nó trên bản đồ để xác định, rồi ship vài cái tủ lạnh
        Name = name;
        Nation = quocgia;
        X = x;
        Y = y;
        Z = z;
    }
    public void Draw()
    {
        GL.Color3(1.0f, 0.0f, 0.0f); // Màu đỏ
        GL.Begin(PrimitiveType.Quads);
        GL.Vertex3(X - 0.1f, Y - 0.1f, Z);
        GL.Vertex3(X + 0.1f, Y - 0.1f, Z);
        GL.Vertex3(X + 0.1f, Y + 0.1f, Z);
        GL.Vertex3(X - 0.1f, Y + 0.1f, Z);
        GL.End();
    }
}

class F35: IDataDevice
{
    private Target target;
    private Weapon weapon;

    private bool evasiveManeuverEnabled;

    public F35(Target target)
    {
        this.target = target;
        evasiveManeuverEnabled =false;
    }
    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadIdentity();

        // Di chuyển camera đến vị trí của máy bay F-35
        GL.Translate(0.0f, 0.0f, -10.0f); // Di chuyển camera lùi ra phía sau để nhìn thấy mục tiêu

        // Vẽ mục tiêu
        f35.DrawTarget();

        SwapBuffers();
    }
    private void EnableEvasiveManeuver()
    {
        evasiveManeuverEnabled = true;
        Console.WriteLine("Evasive maneuver enabled. Performing evasive actions...");
        
        // Giả lập các hành động né tránh trong một khoảng thời gian ngắn
        Thread.Sleep(2000); // Dừng 2 giây để giả lập hành động né tránh
        
        // Về sau, nếu có thể, chúng ta cũng có thể vô hiệu hóa chế độ này
        DisableEvasiveManeuver();
    }

    private void DisableEvasiveManeuver()
    {
        evasiveManeuverEnabled = false;
        Console.WriteLine("Evasive maneuver disabled.");
    }
    private void ListWeapon(){
        List<Weapon> vukhi = new List<Weapon>{

            new Weapon("GAU-22A", "Left-hand-side", 3, 2),
            new Weapon("AIM-9X Block II", "Coordinate", 1, 4),
            new Weapon("AIM-120C ASSRAM", "Coordinate", 1, 6)
        }

    }
    private void DetermineTargetPosition()
    {
        muctieu_j20  = new Target("QBZ-191","Russia", 4.3f, 5.5f, -100.5f);
        muctieu_su27 = new Target("SU-27", "Russia", 10.0f, -20.4f, 7.0f);
        muctieu_su35 = new Target("su35", "Russia", 1.2f, -40.0f, 53.0f);
        muctieu_j16 = new Target("16g","China", 1.4f, 8.0f, 34.0f);
        louis = new Target("Louis Pham","Cali", 18.4f, 68.0f, 3.0f);
        haley_fr = new Target("Nguyen Minh Trang","Cali", 165.4f, 89.0f, 434.0f);

        List<Target> targets = new List<Target>
        {
            muctieu_j16,
            muctieu_j20,
            muctieu_su27,
            muctieu_su35,
            louis,
            haley_fr
        };
        
        // Có thể thêm hàng loạt mục tiêu ở đây
    }
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

public class Program
{
    public static void Main(string[] args)
    {
        F35 f35 = new F35();
        f35.TakeOff(); // Cất cánh

        f35.RunTR3(); // Chạy chương trình TR3
        string receivedData = f35.ReceiveData(); // Nhận dữ liệu từ trạm điều khiển
        Console.WriteLine("Received data from control station: " + receivedData);

        f35.Land(); // Hạ cánh
    }
}
