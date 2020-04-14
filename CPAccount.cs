using System;
using System.Collections.Generic;
using System.Text;

namespace ClubPenguinBot
{
    public class CPAccount
    {
        public enum Action
        {
            bootUp,
            moveLeft,
            moveRight,
            moveDown,
            startMining
        }
        public int tab { get; set; }
        public Action lastAction { get; set; }
        public Action nextAction { get; set; }
        public DateTime actionStartTime { get; set; }
        public Action lastMovement { get; set; }
        public CPAccount(int Tab)
        {
            tab = Tab;
            lastAction = Action.bootUp;
            nextAction = Action.moveLeft;
            lastMovement = Action.bootUp;
            actionStartTime = DateTime.Now;
        }

        public bool isReady()
        {
            DateTime currentTime = DateTime.Now;
            switch (lastAction)
            {
                case Action.bootUp:
                    {
                        return true;
                    }
                case Action.startMining:
                    {
                        TimeSpan t = currentTime - actionStartTime;
                        if (t.TotalMilliseconds >= 13000.0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        public void runNextAction()
        {
            if (isReady())
            {
                switch (nextAction)
                {
                    case Action.moveLeft:
                        {
                            WindowManip.openTab(tab);
                            System.Threading.Thread.Sleep(1000);
                            WindowManip.moveLeft();
                            System.Threading.Thread.Sleep(1000);
                            WindowManip.openActionMenu();
                            System.Threading.Thread.Sleep(500);
                            WindowManip.startMining();
                            System.Threading.Thread.Sleep(500);
                            actionStartTime = DateTime.Now;
                            lastAction = Action.startMining;
                            nextAction = Action.moveRight;
                            lastMovement = Action.moveLeft;
                            break;
                        }
                    case Action.moveRight:
                        {
                            WindowManip.openTab(tab);
                            System.Threading.Thread.Sleep(1000);
                            WindowManip.moveRight();
                            System.Threading.Thread.Sleep(1000);
                            WindowManip.openActionMenu();
                            System.Threading.Thread.Sleep(500);
                            WindowManip.startMining();
                            System.Threading.Thread.Sleep(500);
                            actionStartTime = DateTime.Now;
                            lastAction = Action.startMining;
                            nextAction = Action.moveDown;
                            lastMovement = Action.moveRight;
                            break;
                        }
                    case Action.moveDown:
                        {
                            WindowManip.openTab(tab);
                            System.Threading.Thread.Sleep(1000);
                            WindowManip.moveDown();
                            System.Threading.Thread.Sleep(1000);
                            WindowManip.openActionMenu();
                            System.Threading.Thread.Sleep(500);
                            WindowManip.startMining();
                            System.Threading.Thread.Sleep(500);
                            actionStartTime = DateTime.Now;
                            lastAction = Action.startMining;
                            nextAction = Action.moveLeft;
                            lastMovement = Action.moveDown;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
}
