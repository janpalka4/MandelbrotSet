using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OpenTK;

namespace MandelbrotovaMnozina
{
    public class ShaderContext : IDisposable
    {
        float[] screen = { -1, -1, 1, -1, 1, 1, -1, 1 };

        int vao;
        int vbo;

        int shader;
        int frag;
        int vert;

        int[] uniformy = new int[2];

        GLControl control;
        Pohled pohled = new Pohled(new PointF(-2,-2),new Point(2,2));

        public Bitmap bmp;
        public ShaderContext(GLControl control)
        {
            this.control = control;
            control.MakeCurrent();
            control.Paint += Draw;
            //form.Controls.Add(control)
            control.Width = 800;
            control.Height = 800;
            GL.Viewport(0, 0, 800, 800);
            bmp = new Bitmap(800, 800);
            vao = GL.GenVertexArray();
            vbo = GL.GenBuffer();

            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * screen.Length, screen, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);

            string vertex = ManazerZdroju.NacistZdroj("Shader.vert");
            string fragment = ManazerZdroju.NacistZdroj("Shader.frag");

            vert = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vert,vertex);
            GL.CompileShader(vert);
            string errors = GL.GetShaderInfoLog(vert);
            if (errors != "") ;
            frag = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(frag, fragment);
            GL.CompileShader(frag);
            errors = GL.GetShaderInfoLog(frag);
            if (errors != "") ;

            shader = GL.CreateProgram();
            GL.AttachShader(shader, vert);
            GL.AttachShader(shader, frag);
            GL.LinkProgram(shader);
            errors = GL.GetProgramInfoLog(shader);
            if (errors != "") ;

            uniformy[0] = GL.GetUniformLocation(shader, "region");

            // Draw();
            control.Refresh();

        }

        private void Draw(object sender = null, PaintEventArgs e = null)
        {          
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.UseProgram(shader);
            int reg = GL.GetUniformLocation(shader, "region");
            int res = GL.GetUniformLocation(shader, "resolution");
            GL.Uniform4(reg, pohled.p1.X, pohled.p1.Y, pohled.p2.X, pohled.p2.Y);
            GL.Uniform1(res, (float)bmp.Width);

            GL.BindVertexArray(vao);           
            
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, screen.Length/2);
            byte[] pixels = new byte[bmp.Width * bmp.Height * 4];
            GL.ReadPixels(0, 0, bmp.Width, bmp.Height, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, pixels);
            BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            Marshal.Copy(pixels, 0, bitmapData.Scan0, pixels.Length);
            bmp.UnlockBits(bitmapData);
            control.SwapBuffers();         
            GL.UseProgram(0);
        }
        public Bitmap Render(int width,int height,Pohled pohled) {
            this.pohled = pohled;
            control.Width = width;
            control.Height = height;
            bmp = new Bitmap(width, height);
            GL.Viewport(0, 0, width, height);
            control.Refresh();
            control.Width = 800;
            control.Height = 800;
            GL.Viewport(0, 0, 800, 800);
            return bmp;
        }
        public void Dispose()
        {
            GL.DeleteBuffer(vbo);
            GL.DeleteProgram(shader);
            GL.DeleteShader(frag);
            GL.DeleteShader(vert);
            GL.DeleteVertexArray(vao);
        }
    }
}
