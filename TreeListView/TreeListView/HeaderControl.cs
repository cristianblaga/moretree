using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.APIs;
using System.Security.Permissions;
using System.Windows.Forms;


namespace System.Windows.Forms
{
    public class HeaderControl : NativeWindow
    {
        TreeListView ListView;
        SizeF MaximumHeaderSize;
        Font HeaderFont = new Font("Arial", 18);
       
        public HeaderControl(TreeListView olv)
        {
            ListView = olv;
            AssignHandle(APIsUser32.GetHeaderControl(ListView));
            
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {

            const int HDM_FIRST = 0x1200;
            const int HDM_LAYOUT = (HDM_FIRST + 5);

            // System.Diagnostics.Debug.WriteLine(String.Format("WndProc: {0}", m.Msg));

            switch (m.Msg)
            {


                case HDM_LAYOUT:
                    if (!this.HandleLayout(ref m))
                        return;
                    break;

            }

            base.WndProc(ref m);
        }

        public override void DestroyHandle()
        {
            base.DestroyHandle();
            HeaderFont.Dispose();
        }

       

        private SizeF CalculateSpace(Graphics g)
        {

            TextFormatFlags flags = new TextFormatFlags();
            flags |= TextFormatFlags.VerticalCenter;
            flags |= TextFormatFlags.HorizontalCenter;



            MaximumHeaderSize = new SizeF();
            foreach (ColumnHeader col in ListView.Columns)
            {
                var asTreeListCol = col as TreeListColumnHeader;
                if (asTreeListCol != null && asTreeListCol.VerticalText)
                {
                    var size = g.MeasureString(col.Text, HeaderFont);
                    if (size.Width > MaximumHeaderSize.Height)
                        MaximumHeaderSize = new SizeF(MaximumHeaderSize.Width, size.Width);
                }
                else
                {
                    var size = g.MeasureString(col.Text, HeaderFont, new SizeF(col.Width, float.MaxValue));
                    if (size.Height > MaximumHeaderSize.Height)
                        MaximumHeaderSize = size;
                }
            }
        
            return MaximumHeaderSize;
        }

        protected bool HandleLayout(ref Message m)
        {
            var hdlayout = (APIsStructs.HDLAYOUT)m.GetLParam(typeof(APIsStructs.HDLAYOUT));
            APIsStructs.RECT rect = (APIsStructs.RECT)Marshal.PtrToStructure(hdlayout.prc, typeof(APIsStructs.RECT));
            APIsStructs.WINDOWPOS wpos = (APIsStructs.WINDOWPOS)Marshal.PtrToStructure(hdlayout.pwpos, typeof(APIsStructs.WINDOWPOS));

            using (Graphics g = this.ListView.CreateGraphics())
            {
                g.TextRenderingHint = TreeListView.TextRenderingHint;
                int height = (int)CalculateSpace(g).Height;
                wpos.hwnd = this.Handle;
                wpos.hwndInsertAfter = IntPtr.Zero;
                wpos.flags = APIsStructs.SWP_FRAMECHANGED;
                wpos.x = rect.left;
                wpos.y = rect.top;
                wpos.cx = rect.right - rect.left;
                wpos.cy = height;

                rect.top = height;
                System.Diagnostics.Debug.WriteLine($"Header height in layout {height}");
                Marshal.StructureToPtr(rect, hdlayout.prc, false);
                Marshal.StructureToPtr(wpos, hdlayout.pwpos, false);
            }

            this.ListView.BeginInvoke((MethodInvoker)delegate
            {
                this.Invalidate();
                this.ListView.Invalidate();
            });
            return false;
        }

        public void Invalidate()
        {
            APIsUser32.InvalidateRect(this.Handle, 0, true);
        }


        public Rectangle GetItemRect(int itemIndex)
        {
            const int HDM_FIRST = 0x1200;
            const int HDM_GETITEMRECT = HDM_FIRST + 7;
            APIsStructs.RECT r = new APIsStructs.RECT();
            var err = APIsUser32.SendMessageRECT(Handle, HDM_GETITEMRECT, itemIndex, ref r);
            return Rectangle.FromLTRB(r.left, r.top, r.right, r.bottom);
        }

        protected void DrawBackground(Graphics g, Rectangle r, int columnIndex, bool isPressed, bool isHot)
        {
            
            g.FillRectangle(SystemBrushes.Control, r);
            
            if (isPressed)
            {
                ControlPaint.DrawBorder3D(g, r, Border3DStyle.Sunken);
            }
            else
            {
                ControlPaint.DrawBorder3D(g, r, Border3DStyle.RaisedInner);
            }
        }

        public Rectangle GetHeaderDrawRect(int itemIndex)
        {
            Rectangle r = this.GetItemRect(itemIndex);
            r.Inflate(-3, 0);
            r.Y -= 2;

            return r;
        }

        protected void DrawHeaderImageAndText(Graphics g, Rectangle r, ColumnHeader column)
        {

            TextFormatFlags flags = new TextFormatFlags();
            flags |= TextFormatFlags.VerticalCenter;
            flags |= TextFormatFlags.HorizontalCenter;

            Font f = SystemFonts.DefaultFont;
            Color color = SystemColors.ControlText;

            var asTreeListColumnHeader = column as TreeListColumnHeader;
            if (asTreeListColumnHeader != null && asTreeListColumnHeader.VerticalText)
            {
                DrawVerticalText(g, r, column);
            }

            else
            {
                DrawText(g, r, column);
            }
        }

        private void DrawVerticalText(Graphics g, Rectangle r, ColumnHeader column)
        {
            try
            {
                Matrix m = new Matrix();
                m.RotateAt(-90, new Point(r.X, r.Bottom));
                m.Translate(0, r.Height);
                g.Transform = m;
                StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap);
                fmt.Alignment = StringAlignment.Center;
                fmt.LineAlignment = StringAlignment.Center;
                g.DrawString(column.Text, HeaderFont, SystemBrushes.ControlText, 3, 0);
            }

            finally
            {
                g.ResetTransform();
            }
        }
        private void DrawText(Graphics g, Rectangle r, ColumnHeader column)
        {
            TextFormatFlags flags = new TextFormatFlags();
            flags |= TextFormatFlags.VerticalCenter;
            
            g.DrawString(column.Text, HeaderFont, SystemBrushes.ControlText, r);
        }

        protected void CustomDrawHeaderCell(Graphics g, int columnIndex, int itemState)
        {
            var column = this.ListView.Columns[columnIndex];
            const int CDIS_SELECTED = 1;
            bool isPressed = ((itemState & CDIS_SELECTED) == CDIS_SELECTED);


            // If there is an owner drawn delegate installed, give it a chance to draw the header
            Rectangle fullCellBounds = this.GetItemRect(columnIndex);
            System.Diagnostics.Debug.WriteLine($"Draw header height {fullCellBounds.Height}");

            DrawBackground(g, fullCellBounds, columnIndex, isPressed, false);

            Rectangle r = this.GetHeaderDrawRect(columnIndex);

            DrawHeaderImageAndText(g, r, column);
        }

        internal virtual bool HandleHeaderCustomDraw(ref Message m)
        {
            const int CDRF_NEWFONT = 2;
            const int CDRF_SKIPDEFAULT = 4;
            const int CDRF_NOTIFYPOSTPAINT = 0x10;
            const int CDRF_NOTIFYITEMDRAW = 0x20;

            const int CDDS_PREPAINT = 1;
            const int CDDS_POSTPAINT = 2;
            const int CDDS_ITEM = 0x00010000;
            const int CDDS_ITEMPREPAINT = (CDDS_ITEM | CDDS_PREPAINT);
            const int CDDS_ITEMPOSTPAINT = (CDDS_ITEM | CDDS_POSTPAINT);

            APIsStructs.NMCUSTOMDRAW_ nmcustomdraw = (APIsStructs.NMCUSTOMDRAW_)m.GetLParam(typeof(APIsStructs.NMCUSTOMDRAW_));
            //System.Diagnostics.Debug.WriteLine(String.Format("header cd: {0:x}, {1}, {2:x}", nmcustomdraw.dwDrawStage, nmcustomdraw.dwItemSpec, nmcustomdraw.uItemState));
            switch (nmcustomdraw.dwDrawStage)
            {
                case CDDS_PREPAINT:
                    m.Result = (IntPtr)CDRF_NOTIFYITEMDRAW;
                    return true;

                case CDDS_ITEMPREPAINT:
                    int columnIndex = nmcustomdraw.dwItemSpec.ToInt32();
                    if (columnIndex > ListView.Columns.Count - 1)
                        return true;



                    using (Graphics g = Graphics.FromHdc(nmcustomdraw.hdc))
                    {
                        g.TextRenderingHint = TreeListView.TextRenderingHint;
                        this.CustomDrawHeaderCell(g, columnIndex, nmcustomdraw.uItemState);
                    }
                    m.Result = (IntPtr)CDRF_SKIPDEFAULT;


                    return true;

                case CDDS_ITEMPOSTPAINT:

                    break;
            }

            return false;
        }
    }
}