using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

class Program : GameWindow
{
    static void Main(string[] args)
    {
        using (Program program = new Program())
        {
            program.Run(30, 30);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadIdentity();

        GL.Rotate(45, 1.0, 0.0, 0.0);
        GL.Rotate(45, 0.0, 1.0, 0.0);

        // Vẽ mô hình chiến đấu cơ SU-57 ở đây
        DrawSu57Model();

        SwapBuffers();
    }

    private void DrawSu57Model()
    {
        // Sử dụng các hàm vẽ của OpenGL để tạo ra các hình 3D
        GL.Begin(PrimitiveType.Quads);
        // Vẽ thân máy bay
        GL.Color3(0.0f, 0.0f, 1.0f); // Màu xanh
        GL.Vertex3(-1.0f, -0.5f, -1.0f);
        GL.Vertex3(1.0f, -0.5f, -1.0f);
        GL.Vertex3(1.0f, -0.5f, 1.0f);
        GL.Vertex3(-1.0f, -0.5f, 1.0f);

        // Vẽ cánh máy bay
        GL.Color3(0.5f, 0.5f, 0.5f); // Màu xám
        GL.Vertex3(-2.0f, 0.0f, -0.5f);
        GL.Vertex3(2.0f, 0.0f, -0.5f);
        GL.Vertex3(2.0f, 0.0f, 0.5f);
        GL.Vertex3(-2.0f, 0.0f, 0.5f);

        // Vẽ đuôi máy bay
        GL.Color3(1.0f, 0.0f, 0.0f); // Màu đỏ
        GL.Vertex3(-0.5f, 0.0f, 0.5f);
        GL.Vertex3(0.5f, 0.0f, 0.5f);
        GL.Vertex3(0.5f, 1.0f, 0.5f);
        GL.Vertex3(-0.5f, 1.0f, 0.5f);

        GL.End();

        GL.PushMatrix(); // Lưu trạng thái hiện tại của ma trận modelview
        GL.Translate(0.0f, -0.4f, 0.8f); // Di chuyển tới vị trí của quả bom
        GL.Scale(0.2f, 0.2f, 0.2f); // Thay đổi kích thước của quả bom

        // Vẽ một hình lập phương đại diện cho quả bom
        GL.Begin(PrimitiveType.Quads);
        GL.Vertex3(-1.0f, -1.0f, -1.0f);
        GL.Vertex3(1.0f, -1.0f, -1.0f);
        GL.Vertex3(1.0f, -1.0f, 1.0f);
        GL.Vertex3(-1.0f, -1.0f, 1.0f);
        GL.End();

        GL.PopMatrix(); // Khôi phục trạng thái trước đó của ma trận modelview
    }
}
