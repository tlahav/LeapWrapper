using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;

namespace LeapWrapper
{
    public class LeapListerner : Listener
    {
        public int sensetivity { get; set; }
        public Tool myTool { get; set; }
        public Finger myFinger { get; set; }
        public double zDistance { get; set; }

        public override void OnFrame(Controller controller)
        {
            try
            {
                // Get the most recent frame and report some basic information
                Frame frame = controller.Frame();
                
                if (frame.Tools.Count > 0)
                {
                    Tool tool = frame.Tools[0];
                    myTool = tool;

                    Screen screen = controller.CalibratedScreens[0];
                    Vector vic = screen.Intersect(tool, true);

                    int iScreenX = screen.WidthPixels;
                    int iScreenY = screen.HeightPixels;
                    zDistance = screen.DistanceToPoint(tool.TipPosition);
                    MouseController.MoveCurser(vic.x*iScreenX,(iScreenY- vic.y*iScreenY));
                }

                if (frame.Fingers.Count > 0)
                {
                    Finger finger = frame.Fingers[0];
                    myFinger = finger;

                    Screen screen = controller.CalibratedScreens[0];
                    Vector vic = screen.Intersect(finger, true);

                    int iScreenX = screen.WidthPixels;
                    int iScreenY = screen.HeightPixels;
                    zDistance = screen.DistanceToPoint(finger.TipPosition);
                    MouseController.MoveCurser(vic.x * iScreenX, (iScreenY - vic.y * iScreenY));
                }

            }
            catch (Exception ex)
            {
                
                throw;
            }

        }
    }
}
