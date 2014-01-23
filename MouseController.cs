using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LeapWrapper
{
    public static class MouseController
    {
        public static void MoveCurser(double x, double y)
        {
            try
            {
                System.Windows.Forms.Cursor.Position = new Point((int)x, (int)y);
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }

    }
}
