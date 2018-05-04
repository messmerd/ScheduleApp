using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Calendar
{
    public class NightRenderer : AbstractRenderer
    {
        Font baseFont;

        public NightRenderer(DayView parent)
        {
            this.parent = parent;
        }

        public NightRenderer()
        {
            this.parent = null;
        }

        public override Font BaseFont
        {
            get
            {
                if (baseFont == null)
                {
                    baseFont = new Font("Segoe UI", 8, FontStyle.Regular);
                }

                return baseFont;
            }
        }

        public override Color HourColor
        {
            get
            {
                return System.Drawing.Color.White; //System.Drawing.Color.FromArgb(230, 237, 247);
            }
        }

        public override Color HalfHourSeperatorColor
        {
            get
            {
                return System.Drawing.Color.FromArgb(165, 191, 225);
            }
        }

        public override Color HourSeperatorColor
        {
            get
            {
                return System.Drawing.Color.FromArgb(213, 215, 241);
            }
        }

        public override Color WorkingHourColor
        {
            get
            {
                return System.Drawing.Color.FromArgb(255, 255, 255);
            }
        }

        public override System.Drawing.Color BackColor  // Background of hours
        {
            get
            {
                //return Color.Gainsboro;  // Light grey 
                return Color.LightGray;
                //return Color.FromArgb(225,200,205);  // Light pink
            }
        }

        public override Color SelectionColor
        {
            get
            {
                return System.Drawing.Color.FromArgb(41, 76, 122);
            }
        }

        public override void DrawHourLabel(System.Drawing.Graphics g, System.Drawing.Rectangle rect, int hour)
        {
            Color color = Color.Black; // Hour text color

            using (Pen pen = new Pen(color))
                g.DrawLine(pen, rect.Left, rect.Y, rect.Width, rect.Y);

            using (SolidBrush brush = new SolidBrush(color))
            {
                if (hour < 21)  // Hours after 20 are not shown (makes it look better in our app)
                {
                    g.DrawString(hour.ToString("##00"), HourFont, brush, rect);

                    rect.X += 27;

                    g.DrawString("00", MinuteFont, brush, rect);
                }
            }
        }

        public override void DrawDayHeader(Graphics g, Rectangle rect, DateTime date)
        {
            StringFormat m_Format = new StringFormat();
            m_Format.Alignment = StringAlignment.Center;
            m_Format.FormatFlags = StringFormatFlags.NoWrap;
            m_Format.LineAlignment = StringAlignment.Center;

            ControlPaint.DrawButton(g, rect, ButtonState.Inactive);
            ControlPaint.DrawBorder3D(g, rect, Border3DStyle.Etched);

            g.DrawString(
                System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(date.DayOfWeek),
                BaseFont,
                SystemBrushes.WindowText,
                rect,
                m_Format
                );
        }

        public override void DrawDayBackground(System.Drawing.Graphics g, System.Drawing.Rectangle rect)
        {
            using (Pen aPen = new Pen(Color.FromArgb(242,228,228)))  // very light red 
                g.DrawRectangle(aPen, rect);
        }

        public override void DrawAppointment(System.Drawing.Graphics g, System.Drawing.Rectangle rect, Appointment appointment, bool isSelected, int gripWidth)
        {
            StringFormat m_Format = new StringFormat();
            m_Format.Alignment = StringAlignment.Near;
            m_Format.LineAlignment = StringAlignment.Near;

            Color start = InterpolateColors(appointment.Color, Color.White, 0.4f);
            Color end = InterpolateColors(appointment.Color, Color.FromArgb(235, 108, 163), 0.7f);  //

            if ((appointment.Locked))
            {
                // Draw back
                using (Brush m_Brush = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.LargeConfetti, Color.Blue, appointment.Color))
                    g.FillRectangle(m_Brush, rect);

                // little transparent
                start = Color.FromArgb(230, start);
                end = Color.FromArgb(180, end);

                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(rect);

                using (LinearGradientBrush aGB = new LinearGradientBrush(rect, start, end, LinearGradientMode.Vertical))
                    g.FillRectangle(aGB, rect);
            }
            else
            {
                // Draw back
                using (LinearGradientBrush aGB = new LinearGradientBrush(rect, start, end, LinearGradientMode.Vertical))
                    g.FillRectangle(aGB, rect);
            }

            if (isSelected)
            {
                Rectangle m_BorderRectangle = rect;

                using (Pen m_Pen = new Pen(appointment.BorderColor, 4))
                    g.DrawRectangle(m_Pen, rect);

                m_BorderRectangle.Inflate(2, 2);

                using (Pen m_Pen = new Pen(TrueCrimson, 1)) // using (Pen m_Pen = new Pen(SystemColors.WindowFrame, 1))
                    g.DrawRectangle(m_Pen, m_BorderRectangle);

                m_BorderRectangle.Inflate(-4, -4);

                using (Pen m_Pen = new Pen(TrueCrimson, 1)) // using (Pen m_Pen = new Pen(SystemColors.WindowFrame, 1))
                    g.DrawRectangle(m_Pen, m_BorderRectangle);
            }
            else
            {
                // Draw gripper
                Rectangle m_GripRectangle = rect;

                m_GripRectangle.Width = gripWidth + 1;

                start = InterpolateColors(appointment.BorderColor, appointment.Color, 0.2f);
                end = InterpolateColors(appointment.BorderColor, Color.White, 0.6f);

                using (LinearGradientBrush aGB = new LinearGradientBrush(rect, start, end, LinearGradientMode.Vertical))
                    g.FillRectangle(aGB, m_GripRectangle);

                using (Pen m_Pen = new Pen(SystemColors.WindowFrame, 1))
                    g.DrawRectangle(m_Pen, rect);

                // Draw shadow lines
                int xLeft = rect.X + 6;
                int xRight = rect.Right + 1;
                int yTop = rect.Y + 1;
                int yButton = rect.Bottom + 1;

                for (int i = 0; i < 5; i++)
                {
                    using (Pen shadow_Pen = new Pen(Color.FromArgb(70 - 12 * i, Color.Black)))
                    {
                        g.DrawLine(shadow_Pen, xLeft + i, yButton + i, xRight + i - 1, yButton + i); //horisontal lines
                        g.DrawLine(shadow_Pen, xRight + i, yTop + i, xRight + i, yButton + i); //vertical
                    }
                }

            }

            rect.X += gripWidth;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.DrawString(appointment.Title, this.BaseFont, SystemBrushes.WindowText, rect, m_Format);
            g.TextRenderingHint = TextRenderingHint.SystemDefault;

        }
    }
}
